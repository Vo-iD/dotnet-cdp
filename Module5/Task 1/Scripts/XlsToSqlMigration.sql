USE [bohdan_simianyk_cdp2016q1]
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

BULK INSERT [dbo].[Crew]
FROM 'C:\data\CDP\Module1\Task1\Subtask2\Crews.csv'
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