namespace StockPortfolioTracker.Common;

public class InsiderHoldersDto : BaseApiResponseDto
{
	#region Properties
	public List<HoldersDto>? Holders { get; set; }
	#endregion
}

public class HoldersDto
{
	#region Properties
	public string? Name { get; set; }
	public string? Relation { get; set; }
	public string? Url { get; set; }
	public string? TransactionDescription { get; set; }
	public ResultFormatDto? LatestTransDate { get; set; }
	public ResultFormatDto? PositionDirect { get; set; }
	public ResultFormatDto? PositionDirectDate { get; set; }
	#endregion
}