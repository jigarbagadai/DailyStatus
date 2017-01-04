CREATE TABLE [dbo].[AuditDetails]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TableName] VARCHAR(500) NOT NULL, 
    [OldData] XML NULL, 
    [NewData] XML NULL, 
    [OperationType] VARCHAR(50) NOT NULL, 
    [OperationDate] DATETIME NOT NULL DEFAULT GETUTCDATE()
)
