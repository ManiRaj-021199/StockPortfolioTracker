using AutoMapper;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data;

namespace StockPortfolioTracker.Logic;

public class AutoMapperInitializer
{
    #region Publics
    public static Mapper InitializeAutoMapper()
    {
        MapperConfiguration config = new(cfg =>
                                         {
                                             cfg.CreateMap<User, UserDto>();
                                             cfg.CreateMap<UserRegisterDto, User>();
                                         });

        Mapper mapper = new(config);

        return mapper;
    }
    #endregion
}