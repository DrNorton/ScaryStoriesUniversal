CREATE TABLE [dbo].[Categories]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Image] IMAGE NOT NULL, 
    [Thumb] IMAGE NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(250) NULL, 
    [CreatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NULL DEFAULT 0, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Version] VARBINARY(50) NULL
)
