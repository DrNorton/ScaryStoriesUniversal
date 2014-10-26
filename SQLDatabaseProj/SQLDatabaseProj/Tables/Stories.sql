CREATE TABLE [dbo].[Stories]
(
	[Id] NVARCHAR(250) NOT NULL PRIMARY KEY, 
    [CategoryId] NVARCHAR(250) NOT NULL, 
    [Name] NVARCHAR(250) NOT NULL, 
    [Text] NTEXT NOT NULL, 
    [Url] NVARCHAR(300) NULL, 
    [SourceId] NVARCHAR(250) NOT NULL, 
    [PhotoId] NVARCHAR(250) NOT NULL, 
	[CreatedAt] DATETIMEOFFSET NULL, 
    [Deleted] BIT NOT NULL, 
    [UpdatedAt] DATETIMEOFFSET NULL, 
    [Version] VARBINARY(50) NULL
    CONSTRAINT [FK_Stories_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]),
	CONSTRAINT [FK_Stories_Sources] FOREIGN KEY ([SourceId]) REFERENCES [Sources]([Id]), 
    CONSTRAINT [FK_Stories_ToPhoto] FOREIGN KEY ([PhotoId]) REFERENCES [Photos]([Id])
)
