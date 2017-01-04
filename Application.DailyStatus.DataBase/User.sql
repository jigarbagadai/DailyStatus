CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(200) NOT NULL, 
    [Email] NVARCHAR(200) NOT NULL, 
    [Password] NVARCHAR(300) NOT NULL, 
    [LoginId] NVARCHAR(50) NOT NULL, 
    [MobileNumber] NVARCHAR(50) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedBy] INT NOT NULL, 
    [ModifiedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [UserRoleId] INT NOT NULL, 
    [TimeZoneId] INT NOT NULL, 
    CONSTRAINT [FK_User_Role] FOREIGN KEY (UserRoleId) REFERENCES [Role](Id), 
    CONSTRAINT [FK_User_TimeZone] FOREIGN KEY (TimeZoneId) REFERENCES TimeZone(Id)
)
