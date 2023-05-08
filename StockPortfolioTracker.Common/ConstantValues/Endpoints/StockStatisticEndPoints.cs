namespace StockPortfolioTracker.Common;

public class StockStatisticEndPoints
{
    #region Constants
    public static readonly string StockSmartSearch = "https://query1.finance.yahoo.com/v1/finance/search?q={0}&lang=en-US&region=US&quotesCount={1}&newsCount={2}&listsCount=0&enableFuzzyQuery=false&quotesQueryId=tss_match_phrase_query&multiQuoteQueryId=multi_quote_single_token_query&enableNavLinks=false";

    public static readonly string GetPrice = ApiEndPoints.StockStatisticsEquityBaseUrl + "/GetPrice/{0}";
    public static readonly string GetSmartSearchStocks = ApiEndPoints.StockStatisticsEquityBaseUrl + "/GetSmartSearchStocks";
    #endregion
}