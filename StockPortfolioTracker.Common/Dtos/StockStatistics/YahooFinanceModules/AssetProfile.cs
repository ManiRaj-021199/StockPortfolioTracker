namespace StockPortfolioTracker.Common;

public class AssetProfile : BaseApiResponse
{
	#region Properties
	public string? Address1 { get; set; }
	public string? Address2 { get; set; }
	public string? City { get; set; }
	public string? Zip { get; set; }
	public string? Country { get; set; }
	public string? Phone { get; set; }
	public string? Website { get; set; }
	public string? Industry { get; set; }
	public string? Sector { get; set; }
	public string? LongBusinessSummary { get; set; }
	public string? GovernanceEpochDate { get; set; }
	public string? CompensationAsOfEpochDate { get; set; }
	public int AuditRisk { get; set; }
	public int BoardRisk { get; set; }
	public int CompensationRisk { get; set; }
	public int ShareHolderRightsRisk { get; set; }
	public int OverallRisk { get; set; }
	public List<CompanyOfficer>? CompanyOfficers { get; set; }
	#endregion
}

public class CompanyOfficer
{
	#region Properties
	public string? Name { get; set; }
	public string? Title { get; set; }
	public int? Age { get; set; }
	public int? YearBorn { get; set; }
	public int? FiscalYear { get; set; }
	public ResultFormatDto? TotalPay { get; set; }
	public ResultFormatDto? ExercisedValue { get; set; }
	public ResultFormatDto? UnexercisedValue { get; set; }
	#endregion
}