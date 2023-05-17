IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'User')) 
BEGIN
    EXEC ('CREATE SCHEMA [User] AUTHORIZATION [dbo]')
END

IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Portfolio')) 
BEGIN
    EXEC ('CREATE SCHEMA [Portfolio] AUTHORIZATION [dbo]')
END