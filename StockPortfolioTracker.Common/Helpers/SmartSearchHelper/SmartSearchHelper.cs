using System.Net;
using Newtonsoft.Json;

namespace StockPortfolioTracker.Common;

public class SmartSearchHelper
{
    #region Publics
    public static async Task<SmartSearchResponseDto> GetSmartSearchStocks(string strValue)
    {
        SmartSearchResponseDto response = new();
        SmartSearchRequestDto request = new()
                                        {
                                            StocksCount = 3,
                                            NewsCount = 0,
                                            SearchQuery = strValue
                                        };

        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(StockStatisticEndPoints.GetSmartSearchStocks, HttpMethods.Post, request);

        if(apiResponse.ResponseCode == HttpStatusCode.OK)
        {
            response = JsonConvert.DeserializeObject<SmartSearchResponseDto>(apiResponse.Result!.ToString()!)!;
        }

        return response;
    }
    #endregion
}