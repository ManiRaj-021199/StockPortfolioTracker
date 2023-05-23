IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'User')) 
BEGIN
    EXEC ('CREATE SCHEMA [User] AUTHORIZATION [dbo]')
END

IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Portfolio')) 
BEGIN
    EXEC ('CREATE SCHEMA [Portfolio] AUTHORIZATION [dbo]')
END

IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Clients')) 
BEGIN
    EXEC ('CREATE SCHEMA [Clients] AUTHORIZATION [dbo]')
END

IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Stock')) 
BEGIN
    EXEC ('CREATE SCHEMA [Stock] AUTHORIZATION [dbo]')
END

IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Organization')) 
BEGIN
    EXEC ('CREATE SCHEMA [Organization] AUTHORIZATION [dbo]')
END

IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'SPT')) 
BEGIN
    EXEC ('CREATE SCHEMA [SPT] AUTHORIZATION [dbo]')
END