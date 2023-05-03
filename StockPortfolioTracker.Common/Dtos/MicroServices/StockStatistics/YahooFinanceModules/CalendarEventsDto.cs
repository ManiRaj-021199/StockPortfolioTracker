namespace StockPortfolioTracker.Common;

public class CalendarEventsDto
{
    #region Properties
    public CalenderEventEarningsDto? Earnings { get; set; }
    public ResultFormatDto? DividendDate { get; set; }
    public ResultFormatDto? ExDividendDate { get; set; }
    #endregion
}

public class CalenderEventEarningsDto
{
    #region Properties
    public List<ResultFormatDto>? EarningsDate { get; set; }
    public ResultFormatDto? EarningsAverage { get; set; }
    public ResultFormatDto? EarningsLow { get; set; }
    public ResultFormatDto? EarningsHigh { get; set; }
    public ResultFormatDto? RevenueAverage { get; set; }
    public ResultFormatDto? RevenueLow { get; set; }
    public ResultFormatDto? RevenueHigh { get; set; }
    #endregion
}