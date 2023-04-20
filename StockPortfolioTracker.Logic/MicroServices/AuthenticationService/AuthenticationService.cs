using System.Net;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data;

namespace StockPortfolioTracker.Logic;

public class AuthenticationService : IAuthenticationService
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    #endregion

    #region Constructors
    public AuthenticationService(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Publics
    public async Task<BaseApiResponseDto> RegisterUser(UserDto userDto)
    {
        BaseApiResponseDto response = new();

        try
        {
            HttpResponseMessage resp = HttpClientHelper.GetApiResponse(ApiEndPoints.UserManagementApiUrl, $"/GetUserByEmail/{userDto.Email}");

            if(!resp.IsSuccessStatusCode)
            {
                response.ResponseCode = HttpStatusCode.ServiceUnavailable;
                response.ResponseMessage = CommonWebServiceMessages.SomethingWentWrong;
                
                return response;
            }

            string strApiResponse = await resp.Content.ReadAsStringAsync();
            BaseApiResponseDto apiResponse = JsonConvert.DeserializeObject<BaseApiResponseDto>(strApiResponse)!;

            if(apiResponse.Result != null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = AuthenticationMessages.UserAlreadyRegistered;

                return response;
            }

            PasswordHasherDto hashedPassword = PasswordHashingHelper.EncryptPassword(userDto.Password!);
            
            User user = AutoMapperHelper.MapUserDtoToUser(userDto);
            user.PasswordHash = hashedPassword.PasswordHash;
            user.PasswordSalt = hashedPassword.PasswordSalt;

            dbContext.Users!.Add(user);
            await dbContext.SaveChangesAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = AuthenticationMessages.UserRegisteredSuccess;
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
        }

        return response;
    }
    #endregion
}