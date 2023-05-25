namespace StockPortfolioTracker.Common;

public interface IUserManagementFacade
{
    public Task<BaseApiResponseDto> GetAllUsers();
    public Task<BaseApiResponseDto> GetUserByEmail(string strEmail);
    public Task<BaseApiResponseDto> GetUserByUserId(int nUserId);
    public Task<BaseApiResponseDto> UpdateUserDetails(UserUpdateDto dtoUserUpdate);
}