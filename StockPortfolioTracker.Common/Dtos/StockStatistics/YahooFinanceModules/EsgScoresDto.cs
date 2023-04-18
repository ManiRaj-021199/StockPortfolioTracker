namespace StockPortfolioTracker.Common;

public class EsgScoresDto : BaseApiResponseDto
{
	#region Properties
	public string? RatingYear { get; set; }
	public string? RatingMonth { get; set; }
	public string? HighestControversy { get; set; }
	public string? PeerCount { get; set; }
	public string? EsgPerformance { get; set; }
	public string? EnvironmentPercentile { get; set; }
	public string? SocialPercentile { get; set; }
	public string? GovernancePercentile { get; set; }
	public string? Adult { get; set; }
	public string? Alcoholic { get; set; }
	public string? AnimalTesting { get; set; }
	public string? Catholic { get; set; }
	public string? ControversialWeapons { get; set; }
	public string? SmallArms { get; set; }
	public string? FurLeather { get; set; }
	public string? Gambling { get; set; }
	public string? Gmo { get; set; }
	public string? MilitaryContract { get; set; }
	public string? Nuclear { get; set; }
	public string? Pesticides { get; set; }
	public string? PalmOil { get; set; }
	public string? Coal { get; set; }
	public string? Tobacco { get; set; }
	public ResultFormatDto? TotalEsg { get; set; }
	public ResultFormatDto? EnvironmentScore { get; set; }
	public ResultFormatDto? SocialScore { get; set; }
	public ResultFormatDto? GovernanceScore { get; set; }
	public ResultFormatDto? Percentile { get; set; }
	public List<string>? RelatedControversy { get; set; }
	public PerformanceScaleDto? PeerEsgScorePerformance { get; set; }
	public PerformanceScaleDto? PeerGovernancePerformance { get; set; }
	public PerformanceScaleDto? PeerSocialPerformance { get; set; }
	public PerformanceScaleDto? PeerEnvironmentPerformance { get; set; }
	public PerformanceScaleDto? PeerHighestControversyPerformance { get; set; }
	#endregion
}

public class PerformanceScaleDto
{
	#region Properties
	public string? Min { get; set; }
	public string? Avg { get; set; }
	public string? Max { get; set; }
	#endregion
}