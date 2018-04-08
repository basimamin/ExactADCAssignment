CREATE TABLE [dbo].[DropBoxExactOnline]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [DropBoxPath] NVARCHAR(500) NOT NULL, 
    [ExactOnlineGUID] NVARCHAR(50) NOT NULL, 
    [isFile] TINYINT NOT NULL DEFAULT 0
)

GO


CREATE INDEX [IX_DropBoxExactOnline_DropBoxPath] ON [dbo].[DropBoxExactOnline] ([DropBoxPath])
