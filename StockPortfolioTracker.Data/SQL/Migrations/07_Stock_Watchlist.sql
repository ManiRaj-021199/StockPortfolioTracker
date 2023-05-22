/****** Object:  Table [Stock].[Watchlist] Script Date: 22-05-2023 11:01:45 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[Stock].[Watchlist]') AND type in (N'U'))

BEGIN
CREATE TABLE [Stock].[Watchlist](
	[WatchlistId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Symbol] [nvarchar](50) NOT NULL,
	FOREIGN KEY (CategoryId) REFERENCES [Stock].[WatchlistCategory] (CategoryId)
)
END