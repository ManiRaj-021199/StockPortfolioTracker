using StockPortfolioTracker.Common;

namespace StockStatistics.Services;

public interface IEquityServices
{
	public AssetProfileDto GetAssetProfile(string strStockSympol);
	public CalendarEventsDto GetCalendarEvents(string strStockSympol);
	public EarningsDto GetEarnings(string strStockSympol);
	public EarningsTrendDto GetEarningsTrend(string strStockSympol);
	public EsgScoresDto GetEsgScores(string strStockSympol);
	public FinancialDataDto GetFinancialData(string strStockSympol);
	public IndexTrendDto GetIndexTrend(string strStockSympol);
	public IndustryTrendDto GetIndustryTrend(string strStockSympol);
	public PriceDto GetPrice(string strStockSympol);
	public QuoteTypeDto GetQuoteType(string strStockSympol);
	public SummaryDetailDto GetSummaryDetail(string strStockSympol);
	public FundOwnershipDto GetFundOwnership(string strStockSympol);
	public InsiderHoldersDto GetInsiderHolders(string strStockSympol);
	public InsiderTransactionsDto GetInsiderTransactions(string strStockSympol);
	public RecommendationTrendDto GetRecommendationTrend(string strStockSympol);
}