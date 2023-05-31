using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
    internal async Task<BaseApiResponseDto> GetAllPortfolioCategories(int nUserId)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, nUserId, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            List<KeyValuePair<int, string>> lstPortfolioCategories = await (from pc in dbContext.PortfolioCategories
                                                                            where pc.UserId == nUserId
                                                                            select new KeyValuePair<int, string>(pc.CategoryId, pc.CategoryName)).ToListAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = PortfolioMessages.CategoriesFetchSuccess;
            response.Result = lstPortfolioCategories;

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

    internal async Task<BaseApiResponseDto> GetHoldingStocks(PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, dtoPortfolioCategory, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            List<Holding> lstHoldings = await (from holding in dbContext.Holdings
                                               where holding.UserId == dtoPortfolioCategory.UserId &&
                                                     holding.CategoryId == dtoPortfolioCategory.CategoryId
                                               select holding).ToListAsync();

            IEnumerable<string> stockUniqueNames = lstHoldings.Select(stock => stock.Symbol).Distinct();

            List<PortfolioStockDto> portfolioStocks = (from unique in stockUniqueNames
                                                       let lstUniqueStocks = lstHoldings.Where(stock => stock.Symbol == unique).ToList()
                                                       let nTotalStockQuantity = lstUniqueStocks.Sum(stock => stock.Quantity)
                                                       let dAveragePrice = lstUniqueStocks.Sum(stock => stock.BuyPrice * stock.Quantity) / nTotalStockQuantity
                                                       select new PortfolioStockDto
                                                              {
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

    internal async Task<BaseApiResponseDto> AddNewPortfolioCategory(PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, dtoPortfolioCategory, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByUserId, dtoPortfolioCategory.UserId), HttpMethods.Get, null!);

            if(apiResponse.Result == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = UserManagementMessages.UserNotFound;

                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            PortfolioCategory portfolioCategory = PortfolioAutoMapperHelper.ToPortfolioCategory(dtoPortfolioCategory);

            dbContext.PortfolioCategories.Add(portfolioCategory);
            await dbContext.SaveChangesAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = PortfolioMessages.AddCategorySuccess;

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

    internal async Task<BaseApiResponseDto> AddStockToPortfolio(PortfolioStockDto portfolioStockDto)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, portfolioStockDto, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            Holding portfolioStock = PortfolioAutoMapperHelper.ToHolding(portfolioStockDto);
            portfolioStock.BuyDate = DateTimeHelper.GetCurrentDateTime();

            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByUserId, portfolioStockDto.UserId), HttpMethods.Get, null!);

            if(apiResponse.Result == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = UserManagementMessages.UserNotFound;

                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            if(!dbContext.PortfolioCategories.Any(category => category.UserId == portfolioStockDto.UserId && category.CategoryId == portfolioStockDto.CategoryId))
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = PortfolioMessages.CategoryNotFound;

                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(StockStatisticEndPoints.GetPrice, portfolioStockDto.Symbol), HttpMethods.Get, null!);

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
            response.ResponseMessage = CommonWebServiceMessages.SomethingWentWrong;

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

            response = await RemoveStockFromPortfolio(transactionDto);

            if(response.Result == null) return response;

            Transaction transaction = JsonConvert.DeserializeObject<Transaction>(TypeCastingHelper.ConvertObjectToString(response.Result))!;

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

    internal async Task<BaseApiResponseDto> UpdatePortfolioCategoryName(PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, dtoPortfolioCategory, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            PortfolioCategory? portfolioCategory = await (from pc in dbContext.PortfolioCategories
                                                         where pc.UserId == dtoPortfolioCategory.UserId &&
                                                               pc.CategoryId == dtoPortfolioCategory.CategoryId
                                                         select pc).FirstOrDefaultAsync();

            if(portfolioCategory == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = PortfolioMessages.CategoryNotFound;

                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            portfolioCategory.CategoryName = dtoPortfolioCategory.CategoryName;

            dbContext.Update(portfolioCategory);
            await dbContext.SaveChangesAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = PortfolioMessages.CategoryNameUpdateSuccess;

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

    internal async Task<BaseApiResponseDto> DeletePortfolioCategory(PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, dtoPortfolioCategory, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            PortfolioCategory? portfolioCategory = await (from pc in dbContext.PortfolioCategories
                                                          where pc.UserId == dtoPortfolioCategory.UserId &&
                                                                pc.CategoryId == dtoPortfolioCategory.CategoryId
                                                          select pc).FirstOrDefaultAsync();

            if(portfolioCategory == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = PortfolioMessages.CategoryNotFound;

                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }
            
            dbContext.Remove(portfolioCategory);
            await dbContext.SaveChangesAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = PortfolioMessages.RemoveCategorySuccess;

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
    private async Task<BaseApiResponseDto> RemoveStockFromPortfolio(PortfolioTransactionDto transactionDto)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.PortfolioId, transactionDto, LogManagerHelper.GetMethodStartedMessage());

        await logManager.AddInfoLog(dtoLog);

        Transaction transaction = PortfolioAutoMapperHelper.ToTransaction(transactionDto);
        
        List<Holding> lstStocksFromHolding = await (from holding in dbContext.Holdings
                                                    where holding.UserId == transaction.UserId &&
                                                          holding.Symbol == transaction.Symbol &&
                                                          holding.CategoryId == transactionDto.CategoryId
                                                    select holding).ToListAsync();

        if(lstStocksFromHolding.Count == 0)
        {
            response.ResponseCode = HttpStatusCode.Accepted;
            response.ResponseMessage = PortfolioMessages.StockNotAvailableInCategory;

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
        response.Result = transaction;

        await logManager.AddInfoLog(dtoLog, response);

        return response;
    }
    #endregion
}