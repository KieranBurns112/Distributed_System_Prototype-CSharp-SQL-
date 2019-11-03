CREATE TABLE [dbo].[Inventory]
(
	[ItemId] INT NOT NULL PRIMARY KEY, 
    [ItemName] NVARCHAR(50) NOT NULL, 
    [ItemPrice] DECIMAL(6, 2) NOT NULL, 
    [ItemStock] DECIMAL(6) NULL, 
    [StandardSpecialOffer] INT NULL, 
    [LoyaltySpecialOffer] INT NULL,
)
