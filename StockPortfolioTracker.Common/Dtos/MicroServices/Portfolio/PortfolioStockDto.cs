﻿namespace StockPortfolioTracker.Common;

public class PortfolioStockDto
{
    #region Properties
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string? Symbol { get; set; }
    public int Quantity { get; set; }
    public double BuyPrice { get; set; }
    #endregion
}