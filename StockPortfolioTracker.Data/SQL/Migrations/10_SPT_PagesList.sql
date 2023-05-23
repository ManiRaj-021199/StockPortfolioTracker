/****** Object:  Table [SPT].[PagesList]    Script Date: 23-05-2023 11:01:45 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[SPT].[PagesList]') AND type in (N'U'))

BEGIN
CREATE TABLE [SPT].[PagesList](
	[PageId] [int] PRIMARY KEY NOT NULL,
	[PageRootName] [nvarchar](50) NOT NULL,
	[PageChildName] [nvarchar](50) NOT NULL
)

INSERT [SPT].[PagesList] ([PageId], [PageRootName], [PageChildName]) VALUES (1, N'Watchlist', N'Watchlist')
INSERT [SPT].[PagesList] ([PageId], [PageRootName], [PageChildName]) VALUES (2, N'Watchlist', N'Recommendation')
INSERT [SPT].[PagesList] ([PageId], [PageRootName], [PageChildName]) VALUES (3, N'Watchlist', N'Portfolio')
INSERT [SPT].[PagesList] ([PageId], [PageRootName], [PageChildName]) VALUES (4, N'Watchlist', N'Transactions')
INSERT [SPT].[PagesList] ([PageId], [PageRootName], [PageChildName]) VALUES (5, N'Admin', N'Users')
END