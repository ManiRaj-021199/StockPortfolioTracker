using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;

namespace StockPortfolioTracker.Logic;

public class UserAutoMapperHelper
{
    #region Publics
    public static UserDto ToUserDto(User user)
    {
        UserDto dtoUser = AutoMapperInitializer.Mapper.Map<UserDto>(user);

        return dtoUser;
    }

    public static User ToUser(UserRegisterDto dtoUserRegister)
    {
        User user = AutoMapperInitializer.Mapper.Map<User>(dtoUserRegister);

        return user;
    }
    #endregion
}