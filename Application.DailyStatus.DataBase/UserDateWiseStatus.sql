CREATE TABLE [dbo].[UserDateWiseStatus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [StatusDate] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    CONSTRAINT [FK_UserDateWiseStatus_User] FOREIGN KEY (UserId) REFERENCES [User](Id)
)
