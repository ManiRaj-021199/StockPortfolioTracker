using System.Net;

namespace StockPortfolioTracker.Common;

public class BaseApiResponse
{
	#region Properties
	public HttpStatusCode ResponseCode { get; set; }
	public string? ResponseMessage { get; set; }
	#endregion
}