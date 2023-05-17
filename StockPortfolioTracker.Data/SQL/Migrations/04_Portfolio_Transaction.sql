/****** Object:  Table [stock].[PortfolioTransactions]    Script Date: 17-05-2023 11:10:23 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[Portfolio].[Transactions]') AND type in (N'U'))

BEGIN
CREATE TABLE [Portfolio].[Transactions](
	[TransactionId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Symbol] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[BuyPrice] [float] NOT NULL,
	[SellPrice] [float] NOT NULL,
	[SellDate] [datetime2](7) NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User].Users (UserId)
)
END
