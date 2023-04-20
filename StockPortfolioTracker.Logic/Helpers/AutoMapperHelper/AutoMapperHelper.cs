using AutoMapper;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data;

namespace StockPortfolioTracker.Logic;

public class AutoMapperHelper
{
    #region Constants
    private static readonly Mapper Mapper = AutoMapperInitializer.InitializeAutoMapper();
    #endregion

    #region Publics
    // User Entity
    public static UserDto MapUserToUserDto(User user)
    {
        UserDto userDto = Mapper.Map<UserDto>(user);

        return userDto;
    }

    public static User MapUserDtoToUser(UserDto userDto)
    {
        User user = Mapper.Map<User>(userDto);

        return user;
    }
    #endregion
}