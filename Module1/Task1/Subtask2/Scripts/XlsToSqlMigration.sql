USE [ShippingDb]
GO

BULK INSERT [dbo].[City]
FROM 'C:\data\CDP\Module1\Task1\Subtask2\Cities.csv'
WITH
(
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)
GO

INSERT INTO [dbo].[Warehouse] (CityId)
    SELECT Id
	FROM [dbo].[City]
	ORDER BY Id
GO

BULK INSERT [dbo].[Driver]
FROM 'C:\data\CDP\Module1\Task1\Subtask2\Drivers.csv'
WITH
(
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)
GO

BULK INSERT [dbo].[TruckDriver]
FROM 'C:\data\CDP\Module1\Task1\Subtask2\TruckDrivers.csv'
WITH
(
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)
GO

BULK INSERT [dbo].[Truck]
FROM 'C:\data\CDP\Module1\Task1\Subtask2\Trucks.csv'
WITH
(
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)
GO