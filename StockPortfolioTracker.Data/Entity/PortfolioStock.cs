using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockPortfolioTracker.Data;

[Table("PortfolioStocks", Schema = "Stock")]
public class PortfolioStock
{
    #region Properties
    [Key]
    public int PortfolioStockId { get; set; }
    public string? StockSymbol { get; set; }
    public string? StockName { get; set; }
    public int StockQuantity { get; set; }
    [Precision(18, 2)]
    public decimal StockBuyPrice { get; set; }
    [Precision(18, 2)]
    public decimal TotalPrice { get; set; }

    public User? User { get; set; }
    #endregion
}