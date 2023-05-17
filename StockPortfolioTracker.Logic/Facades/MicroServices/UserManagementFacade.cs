﻿using System.Net;
using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

public class UserManagementFacade : IUserManagementFacade
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    #endregion

    #region Constructors
    public UserManagementFacade(PortfolioTrackerDbContext dbContext)
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
            List<User> users = dbContext.Users.ToListAsync().Result;
            List<UserDto> lstUserDtos = users.Select(UserAutoMapperHelper.ToUserDto).ToList();

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
            User? user = dbContext.Users.FirstOrDefault(user => user.Email == strEmail);
            UserDto userDto = UserAutoMapperHelper.ToUserDto(user!);

            userDto.UserRole = dbContext.UserRoles.FirstOrDefault(role => role.UserRoleId == userDto.UserRoleId)!.RoleName;

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = $"User {(userDto != null ? userDto.FirstName + userDto.LastName : "Not")} Found.";
            response.Result = userDto;
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
        }

        return Task.FromResult(response);
    }

    public Task<BaseApiResponseDto> GetUserByUserId(int nUserId)
    {
        BaseApiResponseDto response = new();

        try
        {
            User? user = dbContext.Users.FirstOrDefault(user => user.UserId == nUserId);

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = $"User {(user != null ? user.FirstName + user.LastName : "Not")} Found.";
            response.Result = user;
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