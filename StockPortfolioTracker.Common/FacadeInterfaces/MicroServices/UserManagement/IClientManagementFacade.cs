namespace StockPortfolioTracker.Common;

public interface IClientManagementFacade
{
    public Task<BaseApiResponseDto> GetClientByEmail(string strEmail);
}