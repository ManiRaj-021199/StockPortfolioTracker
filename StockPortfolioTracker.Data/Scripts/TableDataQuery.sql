﻿USE [PortfolioTrackerDB]
GO

INSERT [User].[UserRoles] ([RoleId], [RoleName]) VALUES (1, N'Super User')
GO
INSERT [User].[UserRoles] ([RoleId], [RoleName]) VALUES (2, N'User')
GO

SET IDENTITY_INSERT [User].[Users] ON 
GO
INSERT [User].[Users] ([UserId], [UserRoleId], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt]) VALUES (2, 1, N'Super', N'User', N'superuser@gmail.com', N'F6ABDD36883080D14B1857E3EB7E43A037CBF724516446127DE21322D053391B6F90224C31D2EE4CEC6BF8EEA9A8D7722C689E3B9928D7845AC2392BD6CCB219', 0x4E18861299C4A6E279AC30311DEA31FD6EFEBD26A351A8A8179791B636CEE7E00DC4203812525ED014CD9FA30AC6A6CDF6DDBFDB5C88D058F58D5EEDC57CF2D4)
GO
INSERT [User].[Users] ([UserId], [UserRoleId], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt]) VALUES (1003, 2, N'Mani', N'Raj', N'mani@gmail.com', N'CE168118AC49EB37D500523F21FF7467CD5FFC4DD6044A7A5F3A2153CEE935F646B1974088114535726AC1086B7F1862AB1A4289ACA05A536F2EB5F6902E4869', 0xF22C4B317AC52F8709100226C44752867AAFBA2CE09267B29AF09FE3BB7F6689B7896BB9705D810C9E259349549EB82CCA345357E284294DB53E6950F68AF8F4)
GO
INSERT [User].[Users] ([UserId], [UserRoleId], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt]) VALUES (1005, 2, N'anbu', N'anbu', N'anbu@gmail.com', N'7F1E9918F4F9130C861B6CD03177E0B492248A77B36F740D7A39FACF3E24B5E898513E46F13B1551A8B33C2EDCA91F2256940607DE4C0663D9D18AC035347638', 0x56F879EE26FB747C6763BABEE606BD93A845286A9310C2EFB6E80D65DB338E38E452EB0ABC9A881F1060C46B3D65C86CDD6E785A128E823C727AA49C7A89514C)
GO
INSERT [User].[Users] ([UserId], [UserRoleId], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt]) VALUES (1007, 2, N'Ajith', N'Kumar', N'ajith@gmail.com', N'0FBB6C8E90E5E5DF578997001DDB899C6B32C69DD206C8F3A30A690BC945167B4A7883DD5BF7F9E3FC1BC85F82E1F9A372F4EC4A87F44BDE374FE78AE8EB7CC3', 0x31585ED6842DDABA193533F80C0717B0E95F76F128E1CB9104836A654B8F929EF143823E10B11D01D4A109F687EE3015842AE7FE83443208D393BF030F70C401)
GO
SET IDENTITY_INSERT [User].[Users] OFF
GO