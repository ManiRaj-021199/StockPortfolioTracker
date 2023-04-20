using System.Security.Cryptography;
using System.Text;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Logic;

public static class PasswordHashingHelper
{
    #region Publics
    public static PasswordHasherDto EncryptPassword(string strPassword)
    {
        byte[] baSalt = RandomNumberGenerator.GetBytes(HelperValues.KeySize);
        byte[] baHash = Rfc2898DeriveBytes.Pbkdf2(
                                                  Encoding.UTF8.GetBytes(strPassword),
                                                  baSalt,
                                                  HelperValues.Iterations,
                                                  HelperValues.HashAlgorithm,
                                                  HelperValues.KeySize);

        PasswordHasherDto hasherDto = new()
                                      {
                                          PasswordSalt = baSalt,
                                          PasswordHash = Convert.ToHexString(baHash)
                                      };

        return hasherDto;
    }

    public static bool VerifyHashedPassword(string strPassword, PasswordHasherDto hasherDto)
    {
        byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(strPassword, hasherDto.PasswordSalt!, HelperValues.Iterations, HelperValues.HashAlgorithm, HelperValues.KeySize);

        return hashToCompare.SequenceEqual(Convert.FromHexString(hasherDto.PasswordHash!));
    }
    #endregion
}