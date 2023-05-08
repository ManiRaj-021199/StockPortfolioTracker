namespace StockPortfolioTracker.Common;

public class SmartSearchResponseDto
{
    #region Properties
    public int Count { get; set; }
    public List<SmartSearchQuotesDto>? Quotes { get; set; }
    #endregion
}