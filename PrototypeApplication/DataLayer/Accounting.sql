CREATE TABLE [dbo].[Accounting]
(
	[PurchaseId] INT NOT NULL PRIMARY KEY, 
    [PurchaseDate] DATE NOT NULL, 
    [TotalSpend] DECIMAL(10, 2) NOT NULL, 
    [NumberOfItems] INT NOT NULL
)
