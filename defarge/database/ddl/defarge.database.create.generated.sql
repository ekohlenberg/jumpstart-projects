
SET NOCOUNT ON;
SET ANSI_WARNINGS OFF;
SET ANSI_PADDING OFF;
SET QUOTED_IDENTIFIER OFF;
USE [master];
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'defarge')
BEGIN
    -- Set the database to single-user mode to disconnect existing connections
    ALTER DATABASE [defarge] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

    -- Drop the database
    DROP DATABASE [defarge];
END
GO

-- Create the database
CREATE DATABASE [defarge];
GO

-- Create a user in the database for the login
USE [defarge];
IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'defarge')
BEGIN
    CREATE USER [defarge] FOR LOGIN [defarge];
END

-- Grant db_owner role to the user
ALTER ROLE db_owner ADD MEMBER [defarge];


