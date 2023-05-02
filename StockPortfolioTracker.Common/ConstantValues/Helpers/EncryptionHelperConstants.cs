using System.Security.Cryptography;

namespace StockPortfolioTracker.Common;

public static class EncryptionHelperConstants
{
    #region Constants
    // Password Hasher
    public static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;
    public static readonly int KeySize = 64;
    public static readonly int Iterations = 350000;

    // JWT Token - ROT13 + Base64
    public static readonly string JwtToken = "DFOao2SfVUqcqTuiqKDtLFOjoTShVTymVTc1p3DtLFO3nKAbYt==";
    #endregion
}