using System.Security.Cryptography;
using System.Text;

namespace StockPortfolioTracker.Common;

public static class PasswordHashingHelper
{
    #region Publics
    public static PasswordHasherDto EncryptPassword(string strPassword)
    {
        byte[] baSalt = RandomNumberGenerator.GetBytes(EncryptionHelperConstants.KeySize);
        byte[] baHash = Rfc2898DeriveBytes.Pbkdf2(
                                                  Encoding.UTF8.GetBytes(strPassword),
                                                  baSalt,
                                                  EncryptionHelperConstants.Iterations,
                                                  EncryptionHelperConstants.HashAlgorithm,
                                                  EncryptionHelperConstants.KeySize);

        PasswordHasherDto hasherDto = new()
                                      {
                                          PasswordSalt = baSalt,
                                          PasswordHash = Convert.ToHexString(baHash)
                                      };

        return hasherDto;
    }

    public static bool VerifyHashedPassword(string strPassword, PasswordHasherDto hasherDto)
    {
        byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(strPassword, hasherDto.PasswordSalt!, EncryptionHelperConstants.Iterations, EncryptionHelperConstants.HashAlgorithm, EncryptionHelperConstants.KeySize);

        return hashToCompare.SequenceEqual(Convert.FromHexString(hasherDto.PasswordHash!));
    }
    #endregion
}