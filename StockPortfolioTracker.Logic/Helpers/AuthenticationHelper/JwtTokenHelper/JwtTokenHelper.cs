using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Logic;

public class JwtTokenHelper
{
    #region Publics
    public static string GenerateJwtToken(UserDto userDto)
    {
        List<Claim> claims = new()
                             {
                                 new Claim(ClaimTypes.Name, $"{userDto.FirstName} {userDto.LastName}"),
                                 new Claim(ClaimTypes.Email, userDto.Email!)
                             };

        SymmetricSecurityKey secretKey = new(Encoding.UTF8.GetBytes(HelperConstants.Token));
        SigningCredentials credentials = new(secretKey, SecurityAlgorithms.HmacSha512Signature);

        JwtSecurityToken jwtSecurityToken = new(
                                                claims: claims,
                                                expires: DateTime.Now.AddDays(1),
                                                signingCredentials: credentials);
        string? strJwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return strJwtToken;
    }
    #endregion
}