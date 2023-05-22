using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

public class AuthenticationFacade : IAuthenticationFacade
{
    #region Fields
    private readonly AuthenticationBL blAuthentication;
    #endregion

    #region Constructors
    public AuthenticationFacade(PortfolioTrackerDbContext dbContext)
    {
        blAuthentication = new AuthenticationBL(dbContext);
    }
    #endregion

    #region Publics
    public Task<BaseApiResponseDto> GenerateAccessToken(string strSource)
    {
        BaseApiResponseDto response = blAuthentication.GenerateAccessToken(strSource).Result;

        return Task.FromResult(response);
    }

    public async Task<BaseApiResponseDto> RegisterUser(UserRegisterDto userRegisterDto)
    {
        BaseApiResponseDto response = await blAuthentication.RegisterUser(userRegisterDto);

        return response;
    }

    public async Task<BaseApiResponseDto> LoginUser(UserLoginDto userLoginDto)
    {
        BaseApiResponseDto response = await blAuthentication.LoginUser(userLoginDto);

        return response;
    }
    #endregion
}