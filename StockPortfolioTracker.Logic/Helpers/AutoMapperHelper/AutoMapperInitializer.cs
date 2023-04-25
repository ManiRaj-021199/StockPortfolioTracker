using AutoMapper;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data;

namespace StockPortfolioTracker.Logic;

public class AutoMapperInitializer
{
    public static readonly Mapper Mapper = InitializeAutoMapper();

    #region Publics
    private static Mapper InitializeAutoMapper()
    {
        MapperConfiguration config = new(cfg =>
                                         {
                                             // User Entity
                                             cfg.CreateMap<User, UserDto>();
                                             cfg.CreateMap<UserRegisterDto, User>();
                                         });

        Mapper mapper = new(config);

        return mapper;
    }
    #endregion
}