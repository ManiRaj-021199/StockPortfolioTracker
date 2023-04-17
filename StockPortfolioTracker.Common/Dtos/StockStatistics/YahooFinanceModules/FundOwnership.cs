namespace StockPortfolioTracker.Common;

public class FundOwnership : BaseApiResponse
{
	#region Properties
	public List<OwnershipList>? OwnershipList { get; set; }
	#endregion
}

public class OwnershipList
{
	#region Properties
	public string? Organization { get; set; }
	public ResultFormatDto? ReportDate { get; set; }
	public ResultFormatDto? PctHeld { get; set; }
	public ResultFormatDto? Position { get; set; }
	public ResultFormatDto? Value { get; set; }
	public ResultFormatDto? PctChange { get; set; }
	#endregion
}