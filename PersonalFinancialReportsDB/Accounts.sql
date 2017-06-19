CREATE TABLE [dbo].[Accounts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerNumber] INT NOT NULL, 
    [Password] VARCHAR(100) NOT NULL
)
