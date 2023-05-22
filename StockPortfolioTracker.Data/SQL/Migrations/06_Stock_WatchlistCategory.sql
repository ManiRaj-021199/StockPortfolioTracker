/****** Object:  Table [Stock].[WatchlistCategory] Script Date: 22-05-2023 11:01:45 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[Stock].[WatchlistCategory]') AND type in (N'U'))

BEGIN
CREATE TABLE [Stock].[WatchlistCategory](
	[CategoryId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User].Users (UserId)
)
END