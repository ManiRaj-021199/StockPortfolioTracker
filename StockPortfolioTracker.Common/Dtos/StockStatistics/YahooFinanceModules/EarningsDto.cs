namespace StockPortfolioTracker.Common;

public class EarningsDto : BaseApiResponseDto
{
	#region Properties
	public string? FinancialCurrency { get; set; }
	public EarningsChartDto? EarningsChart { get; set; }
	public FinancialsChartDto? FinancialsChart { get; set; }
	#endregion
}

#region EarningsChartDto
public class EarningsChartDto
{
	#region Properties
	public string? CurrentQuarterEstimateDate { get; set; }
	public string? CurrentQuarterEstimateYear { get; set; }
	public ResultFormatDto? CurrentQuarterEstimate { get; set; }
	public List<ResultFormatDto>? EarningsDate { get; set; }
	public List<QuarterlyEarningsChartDto>? Quarterly { get; set; }
	#endregion
}

public class QuarterlyEarningsChartDto
{
	#region Properties
	public string? Date { get; set; }
	public ResultFormatDto? Actual { get; set; }
	public ResultFormatDto? Estimate { get; set; }
	#endregion
}
#endregion

#region FinancialChart
public class FinancialsChartDto
{
	#region Properties
	public List<FinancialsChartPropertiesDto>? Yearly { get; set; }
	public List<FinancialsChartPropertiesDto>? Quarterly { get; set; }
	#endregion
}

public class FinancialsChartPropertiesDto
{
	#region Properties
	public string? Date { get; set; }
	public ResultFormatDto? Revenue { get; set; }
	public ResultFormatDto? Earnings { get; set; }
	#endregion
}
#endregion