namespace StockPortfolioTracker.Common;

public class RecommendationTrendDto : BaseApiResponseDto
{
    #region Properties
    public List<TrendRecommendationDto>? Trend { get; set; }
    #endregion
}

public class TrendRecommendationDto
{
    #region Properties
    public string? Period { get; set; }
    public string? StrongBuy { get; set; }
    public string? Buy { get; set; }
    public string? Hold { get; set; }
    public string? Sell { get; set; }
    public string? StrongSell { get; set; }
    #endregion
}