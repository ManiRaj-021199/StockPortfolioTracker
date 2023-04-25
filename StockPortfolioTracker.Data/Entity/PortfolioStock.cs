using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockPortfolioTracker.Data;

public class PortfolioStock
{
    #region Properties
    [Key]
    public int PortfolioStockId { get; set; }
    public string StockSymbol { get; set; }
    public string StockName { get; set; }
    public int StockQuantity { get; set; }
    [Precision(18, 2)]
    public double StockBuyPrice { get; set; }

    public User User { get; set; }
    public ICollection<PortfolioTransaction>? PortfolioTransaction { get; set; }
    #endregion
}