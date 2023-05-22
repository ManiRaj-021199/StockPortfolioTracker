using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

public class RecommendationFacade : IRecommendationFacade
{
    #region Fields
    private readonly RecommendationBL blRecommendation;
    #endregion

    #region Constructors
    public RecommendationFacade(PortfolioTrackerDbContext dbContext)
    {
        blRecommendation = new RecommendationBL(dbContext);
    }
    #endregion

    #region Publics
    public async Task<BaseApiResponseDto> TestDBCheckApi()
    {
        BaseApiResponseDto response = await blRecommendation.TestDBCheckApi();

        return response;
    }
    #endregion
}