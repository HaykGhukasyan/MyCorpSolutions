CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_Customer_Unique] ON [dbo].[Customer] ([FirstName], [LastName])
