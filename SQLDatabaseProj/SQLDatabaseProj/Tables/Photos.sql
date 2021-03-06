﻿CREATE TABLE [dbo].[Photos]
(
	[Id] NVARCHAR(250) NOT NULL PRIMARY KEY, 
    [Image] IMAGE NULL, 
    [Thumb] IMAGE NULL, 
	[CreatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NOT NULL, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Version] VARBINARY(50) NULL

)
