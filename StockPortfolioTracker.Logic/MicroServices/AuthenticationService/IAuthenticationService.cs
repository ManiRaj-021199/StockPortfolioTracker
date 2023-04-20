using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Logic;

public interface IAuthenticationService
{
    public Task<BaseApiResponseDto> RegisterUser(UserDto userDto);
}