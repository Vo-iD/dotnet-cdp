USE [ShippingDb]
GO

BULK INSERT [dbo].[Customer]
FROM 'C:\data\CDP\Module1\Task1\Subtask2\Customers.csv'
WITH
(
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)
GO

INSERT INTO [dbo].[Cargo] (RecepientId, SenderId, RouteId, Weight, Volume, Price)
    SELECT TOP 10000 Recepient.Id AS RecepientId,
		Sender.Id AS SenderId,
		Route.Id AS RouteId,
		ABS(Checksum(NewID()) % 500 - 0.1) + 0.1 AS Weight,
		ABS(Checksum(NewID()) % 30 - 0.1) + 0.1 AS Volume,
		ABS(Checksum(NewID()) % 200 - 0.1) + 0.1 AS Price
	FROM [dbo].[Customer] as Recepient
	JOIN [dbo].[Customer] as Sender
	ON Recepient.Id != Sender.Id
	CROSS JOIN (
		SELECT TOP 1000 Id 
		FROM [dbo].[Route]
		ORDER BY NEWID()
		) as Route
GO