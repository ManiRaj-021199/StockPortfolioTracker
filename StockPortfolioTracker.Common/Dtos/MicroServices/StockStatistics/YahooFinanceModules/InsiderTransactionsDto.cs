namespace StockPortfolioTracker.Common;

public class InsiderTransactionsDto : BaseApiResponseDto
{
    #region Properties
    public List<TransactionsDto>? Transactions { get; set; }
    #endregion
}

public class TransactionsDto
{
    #region Properties
    public string? FilerName { get; set; }
    public string? FilerRelation { get; set; }
    public string? FilerUrl { get; set; }
    public string? TransactionText { get; set; }
    public string? MoneyText { get; set; }
    public string? Ownership { get; set; }
    public ResultFormatDto? StartDate { get; set; }
    public ResultFormatDto? Value { get; set; }
    public ResultFormatDto? Shares { get; set; }
    #endregion
}