using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data;

namespace StockPortfolioTracker.Logic;

public class PortfolioFacade : IPortfolioFacade
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    #endregion

    #region Constructors
    public PortfolioFacade(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Publics
    public async Task<BaseApiResponseDto> AddStockToPortfolio(PortfolioStockDto portfolioStockDto)
    {
        BaseApiResponseDto response = new();

        try
        {
            PortfolioStock portfolioStock = PortfolioAutoMapperHelper.ToPortfolioStock(portfolioStockDto);
            portfolioStock.BuyDate = DateTimeHelper.GetCurrentDateTime();

            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByUserId, portfolioStockDto.UserId), HttpMethods.Get, null!);

            if(apiResponse.Result == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = UserManagementMessages.UserNotFound;

                return response;
            }

            dbContext.PortfolioStocks?.Add(portfolioStock);
            await dbContext.SaveChangesAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = PortfolioMessages.StockBuySuccess;
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
        }

        return response;
    }

    public async Task<BaseApiResponseDto> SellStockFromPortfolio(PortfolioTransactionDto transactionDto)
    {
        BaseApiResponseDto response = new();

        try
        {
            PortfolioTransaction transaction = PortfolioAutoMapperHelper.ToPortfolioTransaction(transactionDto);

            response = await RemoveStockFromPortfolio(transaction);

            if(response.ResponseCode == HttpStatusCode.OK)
            {
                transaction.SellDate = DateTimeHelper.GetCurrentDateTime();

                dbContext.PortfolioTransactions?.Add(transaction);
                await dbContext.SaveChangesAsync();
            }
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
        }

        return response;
    }
    #endregion

    #region Privates
    private async Task<BaseApiResponseDto> RemoveStockFromPortfolio(PortfolioTransaction transaction)
    {
        BaseApiResponseDto response = new();

        List<PortfolioStock> lstStocksFromHolding = await dbContext.PortfolioStocks!.Where(x => x.UserId == transaction.UserId && x.Symbol == transaction.Symbol).ToListAsync();

        if(lstStocksFromHolding.Count == 0)
        {
            response.ResponseCode = HttpStatusCode.Accepted;
            response.ResponseMessage = PortfolioMessages.StockNotAvailable;
            return response;
        }

        int nQuantityNeedToRemove = transaction.Quantity;
        int nTotalHoldingStocks = lstStocksFromHolding.Sum(portfolioStock => portfolioStock.Quantity);

        if(nQuantityNeedToRemove > nTotalHoldingStocks)
        {
            response.ResponseCode = HttpStatusCode.Accepted;
            response.ResponseMessage = PortfolioMessages.StockQuantityMismatch;
            return response;
        }

        foreach(PortfolioStock? stock in lstStocksFromHolding.ToList().TakeWhile(_ => nQuantityNeedToRemove > 0))
        {
            if(stock.Quantity <= nQuantityNeedToRemove)
            {
                nQuantityNeedToRemove -= stock.Quantity;

                lstStocksFromHolding.Remove(stock);
                dbContext.PortfolioStocks!.Remove(stock);
                continue;
            }

            lstStocksFromHolding.First().Quantity -= nQuantityNeedToRemove;
            break;
        }

        await dbContext.SaveChangesAsync();
        response.ResponseCode = HttpStatusCode.OK;
        response.ResponseMessage = PortfolioMessages.StockSellSuccess;
        return response;
    }
    #endregion
}