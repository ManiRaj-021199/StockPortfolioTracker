/****** Object:  Table [Stock].[Recommendations] Script Date: 22-05-2023 11:01:45 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[Stock].[Recommendations]') AND type in (N'U'))

BEGIN
CREATE TABLE [Stock].[Recommendations](
	[RecommendationId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NOT NULL,
	[Symbol] [nvarchar](50) NOT NULL,
	[RecommendedBuyPrice] [int] NOT NULL,
	[TargetPrice] [int] NOT NULL,
	[RegisterDate] [datetime2](7) NOT NULL,
	FOREIGN KEY (BranchId) REFERENCES [Organization].[Branches] (BranchId)
)
END