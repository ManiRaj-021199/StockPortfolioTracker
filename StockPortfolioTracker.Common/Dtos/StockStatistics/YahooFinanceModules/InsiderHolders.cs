namespace StockPortfolioTracker.Common;

public class InsiderHolders : BaseApiResponse
{
	#region Properties
	public List<Holders>? Holders { get; set; }
	#endregion
}

public class Holders
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