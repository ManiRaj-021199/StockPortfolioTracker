/****** Object:  Table [User].[Users]    Script Date: 17-05-2023 10:33:59 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[User].[Users]') AND type in (N'U'))

BEGIN
CREATE TABLE [User].[Users](
	[UserId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserRoleId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](75) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[RegisterDate] [datetime2](7) NOT NULL,
	FOREIGN KEY (UserRoleId) REFERENCES [User].UserRoles (UserRoleId)
)

SET IDENTITY_INSERT [User].[Users] ON 
INSERT [User].[Users] ([UserId], [UserRoleId], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [RegisterDate]) VALUES (1008, 1, N'Mani', N'Raj', N'mani@gmail.com', N'85FAEB8F574602C0E8ECA07D58AB630EC31F52125C95E10B6EF16F4BD83B619F05F801ABEA4677521AC83BEF0FE4E26AC7068035AA7087E59D710FA395003F08', 0xCD2C229C62978165D1EB1EFCD1C08699236AED0F952F77959498902A1DEA596A8FFE056558897287FC2C2A6899454ADCE43A263D4349AA8CEE6422C5E3641874, CAST(N'2023-04-25T18:42:51.2186448' AS DateTime2))
SET IDENTITY_INSERT [User].[Users] OFF
END