using System.Net;
using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data;

namespace StockPortfolioTracker.Logic;

public class UserManagementService : IUserManagementService
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    #endregion

    #region Constructors
    public UserManagementService(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Publics
    public Task<BaseApiResponseDto> GetAllUsers()
    {
        BaseApiResponseDto response = new();

        try
        {
            List<User> users = dbContext.Users!.ToListAsync().Result;
            List<UserDto> lstUserDtos = users.Select(AutoMapperHelper.MapUserToUserDto).ToList();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = $"{lstUserDtos.Count} Users Found.";
            response.Result = lstUserDtos;
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
        }

        return Task.FromResult(response);
    }

    public Task<BaseApiResponseDto> GetUserByEmail(string strEmail)
    {
        BaseApiResponseDto response = new();

        try
        {
            User? user = dbContext.Users!.FirstOrDefault(user => user.Email == strEmail);
            UserDto userDto = AutoMapperHelper.MapUserToUserDto(user!);

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = "User Found.";
            response.Result = userDto;
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
        }

        return Task.FromResult(response);
    }
    #endregion
}