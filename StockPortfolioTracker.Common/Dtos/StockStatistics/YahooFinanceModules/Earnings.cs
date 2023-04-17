namespace StockPortfolioTracker.Common;

public class Earnings : BaseApiResponse
{
	#region Properties
	public string? FinancialCurrency { get; set; }
	public EarningsChart? EarningsChart { get; set; }
	public FinancialsChart? FinancialsChart { get; set; }
	#endregion
}

#region EarningsChart
public class EarningsChart
{
	#region Properties
	public string? CurrentQuarterEstimateDate { get; set; }
	public string? CurrentQuarterEstimateYear { get; set; }
	public ResultFormatDto? CurrentQuarterEstimate { get; set; }
	public List<ResultFormatDto>? EarningsDate { get; set; }
	public List<QuarterlyEarningsChart>? Quarterly { get; set; }
	#endregion
}

public class QuarterlyEarningsChart
{
	#region Properties
	public string? Date { get; set; }
	public ResultFormatDto? Actual { get; set; }
	public ResultFormatDto? Estimate { get; set; }
	#endregion
}
#endregion

#region FinancialChart
public class FinancialsChart
{
	#region Properties
	public List<FinancialsChartProperties>? Yearly { get; set; }
	public List<FinancialsChartProperties>? Quarterly { get; set; }
	#endregion
}

public class FinancialsChartProperties
{
	#region Properties
	public string? Date { get; set; }
	public ResultFormatDto? Revenue { get; set; }
	public ResultFormatDto? Earnings { get; set; }
	#endregion
}
#endregion