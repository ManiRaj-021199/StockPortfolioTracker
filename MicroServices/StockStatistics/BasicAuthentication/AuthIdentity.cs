using System.Net;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using HttpMethods = Microsoft.AspNetCore.Http.HttpMethods;

namespace StockStatistics.BasicAuthentication;

public class AuthIdentity
{
    #region Internals
    internal static async Task<bool> ValidateCredentials(string name, string password)
    {
        BaseApiResponseDto response = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetClientByEmail, $"{name}|{CredentialConstants.GenerateTokenSecretKey}"), HttpMethods.Get, null!);

        if(response.ResponseCode != HttpStatusCode.OK) return false;

        ClientDto? client = JsonConvert.DeserializeObject<ClientDto>(response.Result!.ToString()!);
        bool bIsValidUser = PasswordHashingHelper.VerifyHashedPassword(password, new PasswordHasherDto
                                                                                 {
                                                                                     PasswordHash = client!.PasswordHash,
                                                                                     PasswordSalt = client.PasswordSalt
                                                                                 });

        return bIsValidUser;
    }
    #endregion
}