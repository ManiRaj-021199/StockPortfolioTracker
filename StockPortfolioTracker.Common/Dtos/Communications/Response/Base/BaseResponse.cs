using System.Net;

namespace StockPortfolioTracker.Common;

public class BaseApiResponse
{
    public HttpStatusCode ResponseCode { get; set; }
    public string? ResponseMessage { get; set; }
}
