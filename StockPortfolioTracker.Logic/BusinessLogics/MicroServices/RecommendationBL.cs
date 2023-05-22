using System.Net;
using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

internal class RecommendationBL
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    #endregion

    #region Constructors
    internal RecommendationBL(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Internals
    internal async Task<BaseApiResponseDto> TestDBCheckApi()
    {
        BaseApiResponseDto response = new();

        try
        {
            List<Recommendation> recommendations = await dbContext.Recommendations.ToListAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
            response.Result = recommendations;
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = CommonWebServiceMessages.NotFound;
            response.Result = err.Message;
        }

        return response;
    }
    #endregion
}