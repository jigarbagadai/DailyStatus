CREATE TABLE [dbo].[TimeZone]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(200) NOT NULL, 
    [OffSetDifference] INT NOT NULL
)
