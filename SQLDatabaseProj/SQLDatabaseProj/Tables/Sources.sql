﻿CREATE TABLE [dbo].[Sources]
(
	[Id] NVARCHAR(250) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Image] IMAGE NULL, 
    [Url] NVARCHAR(250) NULL,
	[CreatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NOT NULL, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Version] VARBINARY(50) NULL, 
    [IsVideo] BIT NOT NULL DEFAULT 0
)
