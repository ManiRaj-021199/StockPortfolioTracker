using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Logic;

public class EquityFacade : IEquityFacade
{
    #region Fields
    private readonly EquityBL blEquity;
    #endregion

    #region Constructors
    public EquityFacade()
    {
        blEquity = new EquityBL();
    }
    #endregion

    #region Publics
    public BaseApiResponseDto GetDataFromYahooFinance(string strStockSympol, string strModule)
    {
        BaseApiResponseDto response = blEquity.GetDataFromYahooFinance(strStockSympol, strModule);

        return response;
    }

    public BaseApiResponseDto GetSmartSearchStocks(SmartSearchRequestDto dtoSmartSearchRequest)
    {
        BaseApiResponseDto response = blEquity.GetSmartSearchStocks(dtoSmartSearchRequest);

        return response;
    }
    #endregion
}