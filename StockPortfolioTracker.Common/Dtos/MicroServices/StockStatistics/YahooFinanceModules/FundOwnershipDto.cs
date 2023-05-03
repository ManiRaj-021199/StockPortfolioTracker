namespace StockPortfolioTracker.Common;

public class FundOwnershipDto
{
    #region Properties
    public List<OwnershipListDto>? OwnershipList { get; set; }
    #endregion
}

public class OwnershipListDto
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