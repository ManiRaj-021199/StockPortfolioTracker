using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

public class UserManagementFacade : IUserManagementFacade
{
    #region Fields
    private readonly UserManagementBL blUserManagement;
    #endregion

    #region Constructors
    public UserManagementFacade(PortfolioTrackerDbContext dbContext)
    {
        blUserManagement = new UserManagementBL(dbContext);
    }
    #endregion

    #region Publics
    public async Task<BaseApiResponseDto> GetAllUsers()
    {
        BaseApiResponseDto response = await blUserManagement.GetAllUsers();

        return response;
    }

    public async Task<BaseApiResponseDto> GetUserByEmail(string strEmail)
    {
        BaseApiResponseDto response = await blUserManagement.GetUserByEmail(strEmail);

        return response;
    }

    public async Task<BaseApiResponseDto> GetUserByUserId(int nUserId)
    {
        BaseApiResponseDto response = await blUserManagement.GetUserByUserId(nUserId);

        return response;
    }

    public async Task<BaseApiResponseDto> UpdateUserDetails(UserUpdateDto dtoUserUpdate)
    {
        BaseApiResponseDto response = await blUserManagement.UpdateUserDetails(dtoUserUpdate);

        return response;
    }
    #endregion
}