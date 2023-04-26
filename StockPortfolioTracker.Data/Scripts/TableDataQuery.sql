USE [PortfolioTrackerDB]
GO

SET IDENTITY_INSERT [user].[Users] ON 
GO
INSERT [user].[Users] ([UserId], [UserRoleId], [FirstName], [LastName], [Email], [RegisterDate], [PasswordHash], [PasswordSalt]) VALUES (1008, 2, N'Mani', N'Raj', N'mani@gmail.com', CAST(N'2023-04-25T18:42:51.2186448' AS DateTime2), N'85FAEB8F574602C0E8ECA07D58AB630EC31F52125C95E10B6EF16F4BD83B619F05F801ABEA4677521AC83BEF0FE4E26AC7068035AA7087E59D710FA395003F08', 0xCD2C229C62978165D1EB1EFCD1C08699236AED0F952F77959498902A1DEA596A8FFE056558897287FC2C2A6899454ADCE43A263D4349AA8CEE6422C5E3641874)
GO
SET IDENTITY_INSERT [user].[Users] OFF
GO


INSERT [user].[UserRoles] ([RoleId], [RoleName]) VALUES (1, N'Super User')
GO
INSERT [user].[UserRoles] ([RoleId], [RoleName]) VALUES (2, N'User')
GO


SET IDENTITY_INSERT [stock].[PortfolioStocks] ON 
GO
INSERT [stock].[PortfolioStocks] ([PortfolioStockId], [Symbol], [Quantity], [BuyDate], [BuyPrice], [UserId]) VALUES (1, N'INFY', 100, CAST(N'2023-04-25T18:43:52.4362490' AS DateTime2), 1000, 1008)
GO
INSERT [stock].[PortfolioStocks] ([PortfolioStockId], [Symbol], [Quantity], [BuyDate], [BuyPrice], [UserId]) VALUES (2, N'INFY', 50, CAST(N'2023-04-25T18:44:02.7815518' AS DateTime2), 1100, 1008)
GO
INSERT [stock].[PortfolioStocks] ([PortfolioStockId], [Symbol], [Quantity], [BuyDate], [BuyPrice], [UserId]) VALUES (3, N'RELIANCE', 150, CAST(N'2023-04-25T18:44:36.0476300' AS DateTime2), 2500, 1008)
GO
SET IDENTITY_INSERT [stock].[PortfolioStocks] OFF
GO