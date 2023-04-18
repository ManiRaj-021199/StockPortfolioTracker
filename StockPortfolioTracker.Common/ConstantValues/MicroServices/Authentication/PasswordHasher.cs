using System.Security.Cryptography;

namespace StockPortfolioTracker.Common;

public static class PasswordHasher
{
    #region Constants
    public static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;
    public static readonly int KeySize = 64;
    public static readonly int Iterations = 350000;
    #endregion
}