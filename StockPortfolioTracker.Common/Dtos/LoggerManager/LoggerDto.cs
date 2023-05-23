namespace StockPortfolioTracker.Common;

public class LoggerDto
{
    #region Properties
    public int PageId { get; set; }
    public string Severity { get; set; }
    public string Request { get; set; }
    public string Response { get; set; }
    #endregion
}