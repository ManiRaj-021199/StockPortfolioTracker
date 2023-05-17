/****** Object:  Table [stock].[PortfolioStocks]    Script Date: 17-05-2023 11:10:23 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[Portfolio].[Holdings]') AND type in (N'U'))

BEGIN
CREATE TABLE [Portfolio].[Holdings](
	[HoldingStockId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Symbol] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[BuyPrice] [real] NOT NULL,
	[BuyDate] [datetime2](7) NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User].Users (UserId)
)
END