using System.Net;
using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

internal class ClientManagementBL
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    private readonly LogManager logManager;
    #endregion

    #region Constructors
    internal ClientManagementBL(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
        logManager = new LogManager(dbContext);
    }
    #endregion

    #region Internals
    internal async Task<BaseApiResponseDto> GetClientByEmail(string strEmail)
    {
        BaseApiResponseDto response = new();
        LogDto dtoLog = LogManagerHelper.BuildLogDto(PagesListConstants.UsersId, strEmail, LogManagerHelper.GetMethodStartedMessage());

        try
        {
            await logManager.AddInfoLog(dtoLog);

            string[] splittedEmail = strEmail.Split("|");
            string strSecretKey = splittedEmail[1];
            strEmail = splittedEmail[0];

            if(strSecretKey != CredentialConstants.GenerateTokenSecretKey)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = UserManagementMessages.NotAuthorized;
                
                await logManager.AddInfoLog(dtoLog, response);

                return response;
            }

            ClientProfile clientProfile = (await dbContext.ClientProfiles.FirstOrDefaultAsync(x => x.ClientEmail == strEmail))!;

            if(clientProfile == null)
            {
                response.ResponseCode = HttpStatusCode.Accepted;
                response.ResponseMessage = UserManagementMessages.ClientNotFound;
                response.Result = clientProfile;
                
                await logManager.AddWarningLog(dtoLog, response);

                return response;
            }

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
            response.Result = clientProfile;
            
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