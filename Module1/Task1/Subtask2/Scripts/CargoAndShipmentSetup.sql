USE [bohdan_simianyk_cdp2016q1]
GO

-- Insert generated customers
BULK INSERT [dbo].[Customer]
FROM 'C:\data\CDP\Module1\Task1\Subtask2\Customers.csv'
WITH
(
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)
GO

-- Choose routes for work
DECLARE @routes TABLE (Id INT);         

INSERT INTO @routes 
SELECT TOP 100 Id
FROM [dbo].[Route]
ORDER BY NEWID()

-- Insert cargos
INSERT INTO [dbo].[Cargo] (RecepientId, SenderId, RouteId, Weight, Volume, Price)
    SELECT TOP 10000 Recepient.Id AS RecepientId,
		Sender.Id AS SenderId,
		CargoRoute.Id AS RouteId,
		ABS(Checksum(NewID()) % 500 - 0.1) + 0.1 AS Weight,
		ABS(Checksum(NewID()) % 30 - 0.1) + 0.1 AS Volume,
		ABS(Checksum(NewID()) % 200 - 0.1) + 0.1 AS Price
	FROM (
		SELECT TOP 20 *
		FROM [dbo].[Customer]
		ORDER BY NEWID()) AS Recepient
	JOIN (
		SELECT TOP 20 *
		FROM [dbo].[Customer]
		ORDER BY NEWID()) AS Sender
	ON Recepient.Id != Sender.Id
	CROSS JOIN @routes AS CargoRoute
	ORDER BY NEWID() 

-- Insert shipments
DECLARE @FromDepartureDate DATE = '2012-01-01';
DECLARE @ToDepartureDate DATE = '2012-01-07';

DECLARE @FromDeliveryDate DATE = '2012-01-07';
DECLARE @ToDeliveryDate DATE = '2012-01-12';

INSERT INTO [dbo].[Shipment] (CrewId, RouteId, DepartureDate, DeliveryDate)
    SELECT TOP 1000 
		Crew.Id AS CrewId,
		ShipmentRoute.Id AS RouteId,
		DATEADD(DAY, RAND(CHECKSUM(NEWID())) * (1 + DATEDIFF(DAY, @FromDepartureDate, @ToDepartureDate)), @FromDepartureDate) AS DepartureDate,
		DATEADD(DAY, RAND(CHECKSUM(NEWID())) * (1 + DATEDIFF(DAY, @FromDeliveryDate, @ToDeliveryDate)), @FromDeliveryDate)  AS DeliveryDate
	FROM (
		SELECT *
		FROM [dbo].[Crew]) as Crew
	CROSS JOIN @routes as ShipmentRoute
	ORDER BY NEWID()
GO

-- Create relations
INSERT INTO [dbo].[CargoShipment] (CargoId, ShipmentId)
	SELECT 
		CargoTable.Id AS CargoId,
		ShipmentTable.Id AS ShipmentId
	FROM [dbo].[Cargo] AS CargoTable
	JOIN [dbo].[Shipment] AS ShipmentTable
	ON ShipmentTable.RouteId = CargoTable.RouteId
