using System.Net;
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
            PasswordHasherDto hashedPassword = PasswordHashingHelper.EncryptPassword(userDto.Password!);
            User user = new()
                        {
                            FirstName = userDto.FirstName,
                            LastName = userDto.LastName,
                            Email = userDto.Email,
                            PasswordHash = hashedPassword.PasswordHash,
                            PasswordSalt = hashedPassword.PasswordSalt
                        };

            dbContext.Users!.Add(user);
            await dbContext.SaveChangesAsync();

            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = "User Added Successfully.";
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