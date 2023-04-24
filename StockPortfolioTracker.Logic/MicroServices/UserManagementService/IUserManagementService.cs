using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Logic;

public interface IUserManagementService
{
    public Task<BaseApiResponseDto> GetAllUsers();
    public Task<BaseApiResponseDto> GetUserByEmail(string strEmail);
}