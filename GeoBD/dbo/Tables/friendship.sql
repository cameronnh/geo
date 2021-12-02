CREATE TABLE [dbo].[friendship]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [requesterId] INT NOT NULL, 
	[addresseeId] INT NOT NULL, 
	CONSTRAINT [FK_freinds1] FOREIGN KEY ([requesterId]) REFERENCES [user]([userId]), 
    CONSTRAINT [FK_freinds2] FOREIGN KEY ([addresseeId]) REFERENCES [user]([userId])
)
