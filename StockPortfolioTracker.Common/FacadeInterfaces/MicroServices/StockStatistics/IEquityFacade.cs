namespace StockPortfolioTracker.Common;

public interface IEquityFacade
{
    public BaseApiResponseDto GetDataFromYahooFinance(string strStockSympol, string strModule);
    public BaseApiResponseDto GetSmartSearchStocks(SmartSearchRequestDto dtoSmartSearchRequest);
}