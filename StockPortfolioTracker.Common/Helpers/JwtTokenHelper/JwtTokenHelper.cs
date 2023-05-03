using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
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
                                 new Claim(ClaimTypes.PrimarySid, $"{userDto.UserId}"),
                                 new Claim(ClaimTypes.Name, $"{userDto.FirstName} {userDto.LastName}"),
                                 new Claim(ClaimTypes.Email, userDto.Email!),
                                 new Claim(ClaimTypes.Role, userDto.UserRole!)
                             };

        SymmetricSecurityKey secretKey = GetSecretKey();
        SigningCredentials credentials = new(secretKey, SecurityAlgorithms.HmacSha512Signature);

        JwtSecurityToken jwtSecurityToken = new(
                                                claims: claims,
                                                expires: DateTime.Now.AddDays(1),
                                                signingCredentials: credentials);
        string? strJwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return strJwtToken;
    }

    public static SymmetricSecurityKey GetSecretKey()
    {
        SymmetricSecurityKey secretKey = new(Encoding.UTF8.GetBytes(EncryptionHelperConstants.JwtToken));

        return secretKey;
    }

    public static IEnumerable<Claim> ParseClaimsFromJwtToken(string jwtToken)
    {
        string payload = jwtToken.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }
    #endregion

    #region Privates
    private static byte[] ParseBase64WithoutPadding(string payload)
    {
        switch(payload.Length % 4)
        {
            case 2:
                payload += "==";
                break;
            case 3:
                payload += "=";
                break;
        }

        return Convert.FromBase64String(payload);
    }
    #endregion
}