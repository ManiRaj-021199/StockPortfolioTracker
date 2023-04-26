using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockPortfolioTracker.Data;

public class PortfolioTransaction
{
    #region Properties
    [Key]
    public int TransactionId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    public string Symbol { get; set; }
    public int Quantity { get; set; }
    public double SellPrice { get; set; }
    public DateTime SellDate { get; set; }
    #endregion
}