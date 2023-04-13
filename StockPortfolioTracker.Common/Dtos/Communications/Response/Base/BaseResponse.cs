namespace StockPortfolioTracker.Common.Dtos
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
    }
}
