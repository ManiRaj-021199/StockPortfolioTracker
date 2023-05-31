/****** Object:  Table [Portfolio].[PortfolioCategory]    Script Date: 31-05-2023 09:41:01 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[Portfolio].[PortfolioCategory]') AND type in (N'U'))

BEGIN
CREATE TABLE [Portfolio].[PortfolioCategory](
	[CategoryId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User].Users (UserId)
)
END


/* Add CategoryId Column for Holdings Table */
ALTER TABLE [Portfolio].[Holdings] 
ADD [CategoryId] [int] NOT NULL 
FOREIGN KEY(CategoryId) 
REFERENCES [Portfolio].[PortfolioCategory](CategoryId)
ON DELETE CASCADE
GO
