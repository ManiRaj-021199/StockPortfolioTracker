namespace StockPortfolioTracker.Common;

public class SmartSearchQuotesDto
{
    #region Properties
    public string? Exchange { get; set; }
    public string? ShortName { get; set; }
    public string? LongName { get; set; }
    public string? TypeDisp { get; set; }
    public string? ExchDisp { get; set; }
    public string? Symbol { get; set; }
    public string? Sector { get; set; }
    public string? Industry { get; set; }
    #endregion
}