CREATE TABLE [dbo].[friendship]
(
	[requesterId] INT NOT NULL, 
    [addresseeId] INT NOT NULL, 
    CONSTRAINT Friendship_PK            PRIMARY KEY (RequesterId, AddresseeId),
    CONSTRAINT FriendshipToRequester_FK FOREIGN KEY (RequesterId)
        REFERENCES [dbo].[user] (userId),
    CONSTRAINT FriendshipToAddressee_FK FOREIGN KEY (AddresseeId)
        REFERENCES [dbo].[user] (userId)
)
