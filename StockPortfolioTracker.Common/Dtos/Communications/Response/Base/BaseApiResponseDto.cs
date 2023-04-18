using System.Net;

namespace StockPortfolioTracker.Common;

public class BaseApiResponseDto
{
	#region Properties
	public HttpStatusCode ResponseCode { get; set; }
	public string? ResponseMessage { get; set; }
	#endregion
}