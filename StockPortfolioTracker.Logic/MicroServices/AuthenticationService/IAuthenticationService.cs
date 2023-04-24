using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Logic;

public interface IAuthenticationService
{
    public Task<BaseApiResponseDto> RegisterUser(UserRegisterDto userRegisterDto);
    public Task<BaseApiResponseDto> LoginUser(UserLoginDto userLoginDto);
}