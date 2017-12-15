CREATE TABLE [dbo].[Transaction]
(
	[TransactionID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccountID] INT NOT NULL, 
    [Date] DATE NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Debit] DECIMAL(18, 2) NULL, 
    [Credit] DECIMAL(18, 2) NULL, 
    [Balance] DECIMAL(18, 2) NULL, 
    [Exchange] NVARCHAR(10) NULL, 
    CONSTRAINT [FK_Transaction_Accounts] FOREIGN KEY ([AccountID]) REFERENCES Accounts(AccountID) 
)
