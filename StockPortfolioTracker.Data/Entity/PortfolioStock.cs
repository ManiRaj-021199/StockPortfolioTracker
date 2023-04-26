using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockPortfolioTracker.Data;

public class PortfolioStock
{
    #region Properties
    [Key]
    public int PortfolioStockId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    public string Symbol { get; set; }
    public int Quantity { get; set; }

    [Precision(18, 2)]
    public double BuyPrice { get; set; }

    public DateTime BuyDate { get; set; }
    #endregion
}