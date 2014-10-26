CREATE TABLE [dbo].[Categories]
(
	[Id] NVARCHAR(250) NOT NULL PRIMARY KEY, 
    [Image] IMAGE NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(250) NULL, 
    [CreatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Version] VARBINARY(50) NULL
)
