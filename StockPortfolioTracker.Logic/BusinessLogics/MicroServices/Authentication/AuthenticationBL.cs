using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

internal class AuthenticationBL
{
    #region Fields
    internal readonly PortfolioTrackerDbContext dbContext;
    private readonly LogManager logManager;
    #endregion

    #region Constructors
    internal AuthenticationBL(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
        logManager = new LogManager(dbContext);
    }
    #endregion

    #region Internals
    internal async Task<BaseApiResponseDto> GenerateAccessToken(UserLoginDto userLoginDto)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.UsersId, userLoginDto, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            // Check if the client already exist.
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetClientByEmail, $"{userLoginDto.Email}|{userLoginDto.SecretKey}"), HttpMethods.Get, string.Empty, null!);

            if(apiResponse.Result == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = AuthenticationMessages.UserNotRegistered;
                
                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            ClientProfile client = JsonConvert.DeserializeObject<ClientProfile>(apiResponse.Result.ToString()!)!;

            bool bIsValidUser = PasswordHashingHelper.VerifyHashedPassword(userLoginDto.Password!, new PasswordHasherDto
                                                                                                   {
                                                                                                       PasswordHash = client.PasswordHash,
                                                                                                       PasswordSalt = client.PasswordSalt
                                                                                                   });

            if(!bIsValidUser)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = AuthenticationMessages.IncorrectPassword;
                
                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            UserDto dtoUser = new()
                              {
                                  FirstName = client.ClientName,
                                  LastName = string.Empty,
                                  Email = client.ClientEmail,
                                  UserId = client.ClientProfileId
                              };

            UserRole? resUserRole = await dbContext.UserRoles.FirstOrDefaultAsync(x => x.UserRoleId == client.ClientProfileId);
            dtoUser.UserRole = resUserRole!.RoleName;

            string strAccessToken = JwtTokenHelper.GenerateJwtToken(dtoUser, DateTime.Now.AddDays(1));

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = AuthenticationMessages.TokenGeneratedSuccess;
            response.Result = strAccessToken;
            
            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;

            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }

    internal async Task<BaseApiResponseDto> RegisterUser(UserRegisterDto userRegisterDto)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.UsersId, userRegisterDto, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);
            // Check if the user already exist.
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByEmail, userRegisterDto.Email), HttpMethods.Get, string.Empty, null!);

            if(apiResponse.Result != null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = AuthenticationMessages.UserAlreadyRegistered;
                
                await logManager.AddWarningLog(dtoLog, response);

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
            
            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;

            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }

    internal async Task<BaseApiResponseDto> LoginUser(UserLoginDto userLoginDto)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.UsersId, userLoginDto, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            // Check if the user already exist.
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(UserManagementEndPoints.GetUserByEmail, userLoginDto.Email), HttpMethods.Get, string.Empty, null!);

            if(apiResponse.Result == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = AuthenticationMessages.UserNotRegistered;
                
                await logManager.AddWarningLog(dtoLog, response);

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
                
                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            UserRole userRole = dbContext.UserRoles.FirstOrDefault(x => x.UserRoleId == user.UserRoleId)!;
            user.UserRole = userRole.RoleName;

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = AuthenticationMessages.UserLoginSuccess;
            response.Result = JwtTokenHelper.GenerateJwtToken(user, DateTime.Now.AddDays(1));
            
            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;

            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }
    #endregion
}