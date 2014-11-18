CREATE TABLE [dbo].[Videos]
(
	[Id] NVARCHAR(250) NOT NULL PRIMARY KEY, 
    [Url] NVARCHAR(250) NOT NULL, 
	[Thumb] IMAGE NULL, 
	[Image] IMAGE NULL, 
	[Text] NTEXT  NULL, 
	[CreatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NOT NULL, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Version] VARBINARY(50) NULL, 
    [Name] NVARCHAR(250) NULL, 
    [ChannalName] NVARCHAR(250) NULL,
	[SourceId] NVARCHAR(250) NOT NULL
	CONSTRAINT [FK_Videos_Sources] FOREIGN KEY ([SourceId]) REFERENCES [Sources]([Id]), 
)
