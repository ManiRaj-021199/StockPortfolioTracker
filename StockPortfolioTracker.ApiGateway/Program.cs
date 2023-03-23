namespace StockPortfolioTracker.ApiGateway
{
    public class Program
    {
        #region Publics
        public static void Main(string[] args)
        {
            Startup.BuildWebHost(args).Run();
        }
        #endregion
    }
}