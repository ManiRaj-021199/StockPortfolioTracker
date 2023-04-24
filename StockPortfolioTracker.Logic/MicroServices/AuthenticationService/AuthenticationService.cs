using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public async Task<BaseApiResponseDto> RegisterUser(UserRegisterDto userRegisterDto)
    {
        BaseApiResponseDto response = new();

        try
        {
            // Check if the user already exist.
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByEmail, userRegisterDto.Email), HttpMethods.Get, null!);
            
            if(apiResponse.Result != null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = AuthenticationMessages.UserAlreadyRegistered;

                return response;
            }

            PasswordHasherDto hashedPassword = PasswordHashingHelper.EncryptPassword(userRegisterDto.Password!);

            User user = AutoMapperHelper.MapUserRegisterDtoToUser(userRegisterDto);
            user.UserRoleId = EntityUserRoles.USERID;
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

    public async Task<BaseApiResponseDto> LoginUser(UserLoginDto userLoginDto)
    {
        BaseApiResponseDto response = new();

        try
        {
            // Check if the user already exist.
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByEmail, userLoginDto.Email), HttpMethods.Get, null!);
            
            if(apiResponse.Result == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = AuthenticationMessages.UserNotRegistered;

                return response;
            }

            UserDto? user = JsonConvert.DeserializeObject<UserDto>(((JObject) apiResponse.Result).ToString(Formatting.None));

            bool bIsValidUser = PasswordHashingHelper.VerifyHashedPassword(userLoginDto.Password!, new PasswordHasherDto
                                                                                                   {
                                                                                                       PasswordHash = user!.PasswordHash,
                                                                                                       PasswordSalt = user.PasswordSalt
                                                                                                   });

            if(!bIsValidUser)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = AuthenticationMessages.IncorrectPassword;
                return response;
            }

            UserRole userRole = dbContext.UserRoles!.FirstOrDefault(x => x.RoleId == user.UserRoleId)!;

            user.UserRole = !string.IsNullOrEmpty(userRole.RoleName) ? userRole.RoleName : user.UserRole;

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = AuthenticationMessages.UserLoginSuccess;
            response.Result = JwtTokenHelper.GenerateJwtToken(user);
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