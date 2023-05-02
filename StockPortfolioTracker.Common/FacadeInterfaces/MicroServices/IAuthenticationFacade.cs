namespace StockPortfolioTracker.Common;

public interface IAuthenticationFacade
{
    public Task<BaseApiResponseDto> RegisterUser(UserRegisterDto userRegisterDto);
    public Task<BaseApiResponseDto> LoginUser(UserLoginDto userLoginDto);
}