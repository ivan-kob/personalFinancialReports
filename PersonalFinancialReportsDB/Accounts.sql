CREATE TABLE [dbo].[Accounts]
(
	[AccountID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerNumber] INT NOT NULL, 
    [Password] VARCHAR(100) NOT NULL
)
