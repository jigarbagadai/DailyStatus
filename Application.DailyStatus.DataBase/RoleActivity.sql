CREATE TABLE [dbo].[RoleActivity]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoleId] INT NOT NULL, 
    [ActivityId] INT NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedBy] INT NOT NULL, 
    CONSTRAINT [FK_RoleActivity_Role] FOREIGN KEY (RoleId) REFERENCES [Role](Id), 
    CONSTRAINT [FK_RoleActivity_Activity] FOREIGN KEY (ActivityId) REFERENCES Activity(Id)
)
