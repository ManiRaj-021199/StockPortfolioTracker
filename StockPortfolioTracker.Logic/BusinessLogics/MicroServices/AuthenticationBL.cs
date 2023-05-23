using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

internal class AuthenticationBL
{
    #region Fields
    internal readonly PortfolioTrackerDbContext dbContext;
    #endregion

    #region Constructors
    internal AuthenticationBL(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Internals
    internal async Task<BaseApiResponseDto> GenerateAccessToken(string strSource)
    {
        BaseApiResponseDto response = new();

        try
        {
            UserDto dtoUser = new()
                              {
                                  FirstName = "Source",
                                  LastName = strSource,
                                  Email = "source@gmail.com",
                                  UserId = 1111,
                                  UserRole = EntityUserRoles.USER
                              };

            string strAccessToken = JwtTokenHelper.GenerateJwtToken(dtoUser, DateTime.Now.AddDays(1));

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = "";
            response.Result = strAccessToken;
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
        }

        return response;
    }

    internal async Task<BaseApiResponseDto> RegisterUser(UserRegisterDto userRegisterDto)
    {
        BaseApiResponseDto response = new();

        try
        {
            // Check if the user already exist.
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByEmail, userRegisterDto.Email), HttpMethods.Get, string.Empty, null!);

            if(apiResponse.Result != null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = AuthenticationMessages.UserAlreadyRegistered;

                return response;
            }

            PasswordHasherDto hashedPassword = PasswordHashingHelper.EncryptPassword(userRegisterDto.Password!);

            User user = UserAutoMapperHelper.ToUser(userRegisterDto);
            user.UserRoleId = EntityUserRoles.USERID;
            user.PasswordHash = hashedPassword.PasswordHash!;
            user.PasswordSalt = hashedPassword.PasswordSalt!;
            user.RegisterDate = DateTimeHelper.GetCurrentDateTime();

            dbContext.Users.Add(user);
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

    internal async Task<BaseApiResponseDto> LoginUser(UserLoginDto userLoginDto)
    {
        BaseApiResponseDto response = new();

        try
        {
            // Check if the user already exist.
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByEmail, userLoginDto.Email), HttpMethods.Get, string.Empty, null!);

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

            UserRole userRole = dbContext.UserRoles.FirstOrDefault(x => x.UserRoleId == user.UserRoleId)!;

            user.UserRole = !string.IsNullOrEmpty(userRole.RoleName) ? userRole.RoleName : user.UserRole;

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = AuthenticationMessages.UserLoginSuccess;
            response.Result = JwtTokenHelper.GenerateJwtToken(user, DateTime.Now.AddDays(1));
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