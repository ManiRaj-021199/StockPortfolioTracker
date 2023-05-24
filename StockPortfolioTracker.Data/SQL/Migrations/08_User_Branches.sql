/****** Object:  Table [User].[Branches] Script Date: 24-05-2023 11:35:45 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[User].[Branches]') AND type in (N'U'))

BEGIN
CREATE TABLE [User].[Branches](
	[BranchId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](50) NOT NULL,
)

SET IDENTITY_INSERT [User].[Branches] ON 
INSERT [User].[Branches] ([BranchId], [BranchName]) VALUES (1, N'M&S')
SET IDENTITY_INSERT [User].[Branches] OFF
END