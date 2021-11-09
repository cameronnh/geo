CREATE TABLE [dbo].[user]
(
	[userID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [bgGlobal] INT NULL, 
    [bgWorld] INT NULL, 
    [bgFamous] INT NULL, 
    [numCorrect] INT NULL 
)
