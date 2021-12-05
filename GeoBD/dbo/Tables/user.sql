CREATE TABLE [dbo].[user]
(
	[userID] INT NOT NULL PRIMARY KEY IDENTITY UNIQUE, 
    [username] NVARCHAR(50) NOT NULL UNIQUE, 
    [password] NVARCHAR(50) NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [bgGlobal] INT NULL, 
    [bgWorld] INT NULL, 
    [bgFamous] INT NULL, 
    [numCorrect] INT NULL 
)
