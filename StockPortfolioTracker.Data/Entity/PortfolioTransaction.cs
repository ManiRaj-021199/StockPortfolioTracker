using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockPortfolioTracker.Data;

public class PortfolioTransaction
{
    [Key]
    public int TransactionId { get; set; }
    public int Quantity { get; set; }
    public double SellPrice { get; set; }

    public PortfolioStock PortfolioStock { get; set; }
}