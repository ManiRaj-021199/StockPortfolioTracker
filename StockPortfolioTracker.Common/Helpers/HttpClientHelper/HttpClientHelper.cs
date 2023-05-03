using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace StockPortfolioTracker.Common;

public static class HttpClientHelper
{
    #region Publics
    public static HttpResponseMessage GetYahooFinanceModuleResponse(string strStockSympol, string strModule)
    {
        HttpClient httpClient = new()
                                {
                                    BaseAddress = new Uri(string.Format(ApiEndPoints.YahooFinanceModulesApiUrl, strStockSympol, strModule))
                                };
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

        return response;
    }

    public static async Task<BaseApiResponseDto> MakeApiRequest(string strUrl, string httpMethod, string strAccessToken, object objRequestBody)
    {
        BaseApiResponseDto response = new();

        try
        {
            HttpClient httpClient = new()
                                    {
                                        BaseAddress = new Uri(strUrl)
                                    };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strAccessToken);

            HttpResponseMessage responseMessage = httpMethod switch
            {
                HttpMethods.Get => await httpClient.GetAsync(string.Empty),
                HttpMethods.Post => await httpClient.PostAsJsonAsync(string.Empty, objRequestBody),
                _ => new HttpResponseMessage()
            };

            string strResult = await responseMessage.Content.ReadAsStringAsync();

            response = JsonConvert.DeserializeObject<BaseApiResponseDto>(strResult)!;
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = CommonWebServiceMessages.SomethingWentWrong;
            response.Result = err.Message;
        }

        return response;
    }
    #endregion
}