using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

public class ClientManagementFacade : IClientManagementFacade
{
    #region Fields
    private readonly ClientManagementBL blClientManagement;
    #endregion

    #region Constructors
    public ClientManagementFacade(PortfolioTrackerDbContext dbContext)
    {
        blClientManagement = new ClientManagementBL(dbContext);
    }
    #endregion

    #region Publics
    public async Task<BaseApiResponseDto> GetClientByEmail(string strEmail)
    {
        BaseApiResponseDto response = await blClientManagement.GetClientByEmail(strEmail);

        return response;
    }
    #endregion
}