namespace StockPortfolioTracker.Common;

public class IndexTrendDto
{
    #region Properties
    public string? Symbol { get; set; }
    public ResultFormatDto? PeRatio { get; set; }
    public ResultFormatDto? PegRatio { get; set; }
    public List<IndexTrendEstimatesDto>? Estimates { get; set; }
    #endregion
}

public class IndexTrendEstimatesDto
{
    #region Properties
    public string? Period { get; set; }
    public ResultFormatDto? Growth { get; set; }
    #endregion
}