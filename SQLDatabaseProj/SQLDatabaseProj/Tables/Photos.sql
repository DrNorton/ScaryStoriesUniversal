CREATE TABLE [dbo].[Photos]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Image] IMAGE NULL, 
    [Thumb] IMAGE NULL, 
	[CreatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NULL, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Version] VARBINARY(50) NULL

)
