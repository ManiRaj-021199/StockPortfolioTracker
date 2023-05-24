using AutoMapper;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;

namespace StockPortfolioTracker.Logic;

public class AutoMapperInitializer
{
    #region Constants
    public static readonly Mapper Mapper = InitializeAutoMapper();
    #endregion

    #region Privates
    private static Mapper InitializeAutoMapper()
    {
        MapperConfiguration config = GetMapperConfiguration();
        Mapper mapper = new(config);

        return mapper;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        return new MapperConfiguration(cfg =>
                                       {
                                           // User Entity
                                           cfg.CreateMap<User, UserDto>();
                                           cfg.CreateMap<UserRegisterDto, User>();

                                           // PortfolioStock Entity
                                           cfg.CreateMap<PortfolioStockDto, Holding>();

                                           // PortfolioTransaction Entity
                                           cfg.CreateMap<PortfolioTransactionDto, Transaction>();

                                           // Logger Entity
                                           cfg.CreateMap<LogDto, Log>();
                                       });
    }
    #endregion
}