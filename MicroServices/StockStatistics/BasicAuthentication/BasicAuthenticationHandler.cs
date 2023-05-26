using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace StockStatistics.BasicAuthentication;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    #region Constructors
    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }
    #endregion

    #region Protecteds
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string? username;
        try
        {
            AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(this.Request.Headers["Authorization"]);
            string[] credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter!)).Split(':');
            username = credentials.FirstOrDefault();
            string? password = credentials.LastOrDefault();
            bool bIsValidUser = await AuthIdentity.ValidateCredentials(username!, password!);

            if(!bIsValidUser)
                throw new("Invalid credentials");
        }
        catch(Exception ex)
        {
            return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
        }

        Claim[] claims =
        {
            new(ClaimTypes.Name, username!)
        };
        ClaimsIdentity identity = new(claims, this.Scheme.Name);
        ClaimsPrincipal principal = new(identity);
        AuthenticationTicket ticket = new(principal, this.Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
    #endregion
}