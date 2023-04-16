using StockPortfolioTracker.Common;

namespace StockStatistics.Services;

public interface IEquityServices
{
    public AssetProfile GetAssetProfile(string strStockSympol);
    public CalendarEvents GetCalendarEvents(string strStockSympol);
    public Earnings GetEarnings(string strStockSympol);
    public EarningsTrend GetEarningsTrend(string strStockSympol);
    public EsgScores GetEsgScores(string strStockSympol);
    public FinancialData GetFinancialData(string strStockSympol);
    public IndexTrend GetIndexTrend(string strStockSympol);
    public IndustryTrend GetIndustryTrend(string strStockSympol);
    public Price GetPrice(string strStockSympol);
    public QuoteType GetQuoteType(string strStockSympol);
    public SummaryDetail GetSummaryDetail(string strStockSympol);
    public SummaryProfile GetSummaryProfile(string strStockSympol);
    public FundOwnership GetFundOwnership(string strStockSympol);
    public InsiderHolders GetInsiderHolders(string strStockSympol);
    public InsiderTransactions GetInsiderTransactions(string strStockSympol);
    public RecommendationTrend GetRecommendationTrend(string strStockSympol);
}