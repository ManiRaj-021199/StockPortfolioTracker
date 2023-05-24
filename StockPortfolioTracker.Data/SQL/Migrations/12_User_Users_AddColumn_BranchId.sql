/****** Object:  Table [User].Users    Script Date: 24-05-2023 10:33:59 ******/

ALTER TABLE [User].Users 
ADD [BranchId] [int] NOT NULL 
FOREIGN KEY(BranchId) REFERENCES [User].Branches(BranchId)
CONSTRAINT DF_Users_BranchId DEFAULT 1