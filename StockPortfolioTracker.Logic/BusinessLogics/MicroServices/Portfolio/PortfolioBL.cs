using System.Net;
using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

internal class PortfolioBL
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    private readonly LogManager logManager;
    #endregion

    #region Constructors
    internal PortfolioBL(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
        logManager = new LogManager(dbContext);
    }
    #endregion

    #region Internals
    internal async Task<BaseApiResponseDto> GetHoldingStocks(int nUserId)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, nUserId, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            List<Holding> stocks = await dbContext.Holdings.Where(stock => stock.UserId == nUserId).ToListAsync();
            IEnumerable<string> stockUniqueNames = stocks.Select(stock => stock.Symbol).Distinct();

            List<PortfolioStockDto> portfolioStocks = (from unique in stockUniqueNames
                                                       let lstUniqueStocks = stocks.Where(stock => stock.Symbol == unique).ToList()
                                                       let nTotalStockQuantity = lstUniqueStocks.Sum(stock => stock.Quantity)
                                                       let dAveragePrice = lstUniqueStocks.Sum(stock => stock.BuyPrice * stock.Quantity) / nTotalStockQuantity
                                                       select new PortfolioStockDto
                                                              {
                                                                  UserId = nUserId,
                                                                  Symbol = unique,
                                                                  BuyPrice = dAveragePrice,
                                                                  Quantity = nTotalStockQuantity
                                                              }).ToList();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = PortfolioMessages.StockFetchSuccess;
            response.Result = portfolioStocks;
            
            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = CommonWebServiceMessages.SomethingWentWrong;
            
            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }

    internal async Task<BaseApiResponseDto> AddStockToPortfolio(PortfolioStockDto portfolioStockDto, string strUserToken)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, portfolioStockDto, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            Holding portfolioStock = PortfolioAutoMapperHelper.ToHolding(portfolioStockDto);
            portfolioStock.BuyDate = DateTimeHelper.GetCurrentDateTime();

            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByUserId, portfolioStockDto.UserId), HttpMethods.Get, string.Empty, null!);

            if(apiResponse.Result == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = UserManagementMessages.UserNotFound;

                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(StockStatisticEndPoints.GetPrice, portfolioStockDto.Symbol), HttpMethods.Get, strUserToken, null!);

            if(apiResponse.Result == null)
            {
                response.ResponseCode = HttpStatusCode.NotFound;
                response.ResponseMessage = PortfolioMessages.InvalidStock;

                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            dbContext.Holdings.Add(portfolioStock);
            await dbContext.SaveChangesAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = PortfolioMessages.StockBuySuccess;
            
            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
            
            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }

    internal async Task<BaseApiResponseDto> SellStockFromPortfolio(PortfolioTransactionDto transactionDto)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, transactionDto, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            Transaction transaction = PortfolioAutoMapperHelper.ToTransaction(transactionDto);

            response = await RemoveStockFromPortfolio(transaction);

            if(response.ResponseCode == HttpStatusCode.OK)
            {
                transaction.SellDate = DateTimeHelper.GetCurrentDateTime();

                dbContext.Transactions.Add(transaction);
                await dbContext.SaveChangesAsync();
            }
            
            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
            
            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }
    #endregion

    #region Privates
    private async Task<BaseApiResponseDto> RemoveStockFromPortfolio(Transaction transaction)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, transaction, LogManagerHelper.GetMethodStartedMessage());

        await logManager.AddInfoLog(dtoLog);
        List<Holding> lstStocksFromHolding = await dbContext.Holdings.Where(x => x.UserId == transaction.UserId && x.Symbol == transaction.Symbol).ToListAsync();

        if(lstStocksFromHolding.Count == 0)
        {
            response.ResponseCode = HttpStatusCode.Accepted;
            response.ResponseMessage = PortfolioMessages.StockNotAvailable;

            await logManager.AddWarningLog(dtoLog, response);

            return response;
        }

        int nQuantityNeedToRemove = transaction.Quantity;
        int nTotalHoldingStocks = lstStocksFromHolding.Sum(portfolioStock => portfolioStock.Quantity);

        if(nQuantityNeedToRemove > nTotalHoldingStocks)
        {
            response.ResponseCode = HttpStatusCode.Accepted;
            response.ResponseMessage = PortfolioMessages.StockQuantityMismatch;

            await logManager.AddWarningLog(dtoLog, response);

            return response;
        }

        foreach(Holding? stock in lstStocksFromHolding.ToList().TakeWhile(_ => nQuantityNeedToRemove > 0))
        {
            if(stock.Quantity <= nQuantityNeedToRemove)
            {
                nQuantityNeedToRemove -= stock.Quantity;

                lstStocksFromHolding.Remove(stock);
                dbContext.Holdings.Remove(stock);
                continue;
            }

            lstStocksFromHolding.First().Quantity -= nQuantityNeedToRemove;
            break;
        }

        await dbContext.SaveChangesAsync();
        response.ResponseCode = HttpStatusCode.OK;
        response.ResponseMessage = PortfolioMessages.StockSellSuccess;

        await logManager.AddInfoLog(dtoLog, response);

        return response;
    }
    #endregion
}