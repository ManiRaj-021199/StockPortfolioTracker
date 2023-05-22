/****** Object:  Table [User].[UserRoles]    Script Date: 17-05-2023 11:01:45 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[User].[UserRoles]') AND type in (N'U'))

BEGIN
CREATE TABLE [User].[UserRoles](
	[UserRoleId] [int] PRIMARY KEY NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
)

INSERT [User].[UserRoles] ([UserRoleId], [RoleName]) VALUES (1, N'Super User')
INSERT [User].[UserRoles] ([UserRoleId], [RoleName]) VALUES (2, N'User')
INSERT [User].[UserRoles] ([UserRoleId], [RoleName]) VALUES (3, N'Application')
END