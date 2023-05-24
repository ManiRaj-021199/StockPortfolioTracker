namespace StockPortfolioTracker.Common;

public interface IRecommendationFacade
{
    public Task<BaseApiResponseDto> TestDBCheckApi();
}