CREATE TABLE [dbo].[DailyWorkStatus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserDateWiseId] INT NOT NULL, 
    [CaseNo] NVARCHAR(50) NOT NULL, 
    [Title] NVARCHAR(500) NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL, 
    [OtherStatus] NVARCHAR(50) NULL, 
    [Comments] NVARCHAR(1000) NULL, 
    CONSTRAINT [FK_DailyWorkStatus_UserDateWise] FOREIGN KEY (UserDateWiseId) REFERENCES [UserDateWiseStatus](Id)
)
