using System.Security.Cryptography;

namespace StockPortfolioTracker.Common;

public static class HelperConstants
{
    #region Constants
    // Password Hasher
    public static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;
    public static readonly int KeySize = 64;
    public static readonly int Iterations = 350000;

    // JWT Token
    public static readonly string JwtToken = "DFOao2SfVUqcqTuiqKDtLFOjoTShVTymVTc1p3DtLFO3nKAbYt==";
    #endregion
}