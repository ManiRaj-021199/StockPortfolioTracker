using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data;

namespace StockPortfolioTracker.Logic;

public class UserAutoMapperHelper
{
    #region Publics
    public static UserDto MapUserToUserDto(User user)
    {
        UserDto userDto = AutoMapperInitializer.Mapper.Map<UserDto>(user);

        return userDto;
    }

    public static User MapUserRegisterDtoToUser(UserRegisterDto userRegisterDto)
    {
        User user = AutoMapperInitializer.Mapper.Map<User>(userRegisterDto);

        return user;
    }
    #endregion
}