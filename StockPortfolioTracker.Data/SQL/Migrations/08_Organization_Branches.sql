/****** Object:  Table [Organization].[Branches] Script Date: 22-05-2023 11:01:45 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[Organization].[Branches]') AND type in (N'U'))

BEGIN
CREATE TABLE [Organization].[Branches](
	[BranchId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](50) NOT NULL,
)
END