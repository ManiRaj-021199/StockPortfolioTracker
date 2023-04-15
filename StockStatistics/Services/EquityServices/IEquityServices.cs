using StockPortfolioTracker.Common;

namespace StockStatistics.Services;

public interface IEquityServices
{
    public FinancialData GetFinancialData(string strStockSympol);
}