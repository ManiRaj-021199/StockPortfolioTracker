using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using StockPortfolioTracker.Logic;

namespace StockPortfolioTracker.Common;

public static class HttpClientHelper
{
    #region Publics
    public static async Task<BaseApiResponseDto> MakeApiRequest(string strUrl, string httpMethod, string strAccessToken, object objRequestBody)
    {
        BaseApiResponseDto response = new();

        try
        {
            if(string.IsNullOrEmpty(strAccessToken))
            {
                UserDto user = new()
                               {
                                   UserId = 0,
                                   FirstName = "Application",
                                   LastName = "User",
                                   Email = "application@gmail.com",
                                   UserRole = EntityUserRoles.APPLICATION
                               };

                strAccessToken = JwtTokenHelper.GenerateJwtToken(user, DateTime.Now.AddMinutes(30));
            }

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