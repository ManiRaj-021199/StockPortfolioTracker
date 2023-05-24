/****** Object:  Table [SPT].[Logs]    Script Date: 23-05-2023 10:33:59 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[SPT].[Logs]') AND type in (N'U'))

BEGIN
CREATE TABLE [SPT].[Logs](
	[LogId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[PageId] [int] NOT NULL,
	[Severity] [nvarchar](10) NOT NULL,
	[Request] [nvarchar](max) NOT NULL,
	[Response] [nvarchar](max) NOT NULL,
	[LogDate] [datetime2](7) NOT NULL,
	FOREIGN KEY (PageId) REFERENCES [SPT].[PagesList] (PageId)
)
END