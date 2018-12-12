CREATE TABLE [dbo].[task]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [taskname] NVARCHAR(MAX) NULL, 
    [desc] NVARCHAR(MAX) NULL, 
    [priority] INT NULL, 
    [isDone] NVARCHAR(50) NULL
)
