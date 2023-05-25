using System.Net;
using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

internal class UserManagementBL
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    private readonly LogManager logManager;
    #endregion

    #region Constructors
    internal UserManagementBL(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
        logManager = new LogManager(dbContext);
    }
    #endregion

    #region Internals
    internal async Task<BaseApiResponseDto> GetAllUsers()
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.UsersId, string.Empty, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            List<User> users = await dbContext.Users.ToListAsync();
            List<UserDto> lstUserDtos = users.Select(UserAutoMapperHelper.ToUserDto).ToList();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = $"{lstUserDtos.Count} Users Found.";
            response.Result = lstUserDtos;

            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = CommonWebServiceMessages.SomethingWentWrong;

            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }

    internal async Task<BaseApiResponseDto> GetUserByEmail(string strEmail)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.UsersId, strEmail, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            User? user = await dbContext.Users.FirstOrDefaultAsync(user => user.Email == strEmail);
            UserDto userDto = UserAutoMapperHelper.ToUserDto(user!);

            UserRole? userRole = await dbContext.UserRoles.FirstOrDefaultAsync(role => role.UserRoleId == userDto.UserRoleId);
            userDto.UserRole = userRole!.RoleName;

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = $"User {(userDto != null ? userDto.FirstName + userDto.LastName : "Not")} Found.";
            response.Result = userDto;

            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = CommonWebServiceMessages.SomethingWentWrong;

            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }

    internal async Task<BaseApiResponseDto> GetUserByUserId(int nUserId)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.UsersId, nUserId, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);
            User? user = await dbContext.Users.FirstOrDefaultAsync(user => user.UserId == nUserId);

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = $"User {(user != null ? user.FirstName + user.LastName : "Not")} Found.";
            response.Result = user;

            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = CommonWebServiceMessages.SomethingWentWrong;

            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }

    internal async Task<BaseApiResponseDto> UpdateUserDetails(UserUpdateDto dtoUserUpdate)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.UsersId, dtoUserUpdate, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            User? user = await dbContext.Users.FirstOrDefaultAsync(user => user.UserId == dtoUserUpdate.UserId);

            if(user == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = UserManagementMessages.UserNotFound;

                await logManager.AddWarningLog(dtoLog, response);
            }

            if(dtoUserUpdate.BranchId > 0 && dbContext.Branches.Any(x => x.BranchId == dtoUserUpdate.BranchId)) user!.BranchId = dtoUserUpdate.BranchId;
            if(dtoUserUpdate.UserRoleId > 0 && dbContext.UserRoles.Any(x => x.UserRoleId == dtoUserUpdate.UserRoleId)) user!.UserRoleId = dtoUserUpdate.UserRoleId;

            if(!string.IsNullOrEmpty(dtoUserUpdate.FirstName)) user!.FirstName = dtoUserUpdate.FirstName;
            if(!string.IsNullOrEmpty(dtoUserUpdate.LastName)) user!.LastName = dtoUserUpdate.LastName;
            if(!string.IsNullOrEmpty(dtoUserUpdate.Email)) user!.Email = dtoUserUpdate.Email;

            dbContext.Users.Update(user!);
            await dbContext.SaveChangesAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = UserManagementMessages.UserUpdatedSuccess;

            await logManager.AddInfoLog(dtoLog, response);
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = CommonWebServiceMessages.SomethingWentWrong;

            await logManager.AddErrorLog(dtoLog, err);
        }

        return response;
    }
    #endregion
}