using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using StockPortfolioTracker.Logic;

namespace StockPortfolioTracker.Common;

public static class HttpClientHelper
{
    #region Publics
    public static async Task<BaseApiResponseDto> MakeApiRequest(string strUrl, string httpMethod, object objRequestBody)
    {
        BaseApiResponseDto response = new();

        try
        {
            string strAccessToken = GetApplicationAccessToken();

            HttpClient httpClient = new()
                                    {
                                        BaseAddress = new Uri(strUrl)
                                    };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strAccessToken);

            HttpResponseMessage responseMessage = new();

            switch(httpMethod)
            {
                case HttpMethods.Get:
                    responseMessage = await httpClient.GetAsync(string.Empty);
                    break;
                case HttpMethods.Post:
                    responseMessage = await httpClient.PostAsJsonAsync(string.Empty, objRequestBody);
                    break;
                case HttpMethods.Delete:
                    HttpRequestMessage request = new(HttpMethod.Delete, strUrl);
                    StringContent strContent = new(TypeCastingHelper.ConvertObjectToString(objRequestBody), Encoding.UTF8, "application/json");
                    request.Content = strContent;
                    responseMessage = await httpClient.SendAsync(request);
                    break;
            }

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

    #region Privates
    private static string GetApplicationAccessToken()
    {
        UserDto user = new()
                       {
                           UserId = 0,
                           FirstName = "SPT",
                           LastName = "Application",
                           Email = "spt@application.com",
                           UserRole = EntityUserRoles.APPLICATION
                       };

        return JwtTokenHelper.GenerateJwtToken(user, DateTime.Now.AddMinutes(30));
    }
    #endregion
}