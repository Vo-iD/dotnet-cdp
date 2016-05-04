USE [bohdan_simianyk_cdp2016q1]
GO 

DECLARE @FromDepartureDate DATE = '2012-01-01';
DECLARE @ToDepartureDate DATE = '2012-01-07';

DECLARE @FromDeliveryDate DATE = '2012-01-07';
DECLARE @ToDeliveryDate DATE = '2012-01-12';

INSERT INTO [dbo].[Shipment] (CrewId, RouteId, DepartureDate, DeliveryDate)
    SELECT TOP 1000 
		Crew.Id AS CrewId,
		Route.Id AS RouteId,
		DATEADD(DAY, RAND(CHECKSUM(NEWID())) * (1 + DATEDIFF(DAY, @FromDepartureDate, @ToDepartureDate)), @FromDepartureDate) AS DepartureDate,
		DATEADD(DAY, RAND(CHECKSUM(NEWID())) * (1 + DATEDIFF(DAY, @FromDeliveryDate, @ToDeliveryDate)), @FromDeliveryDate)  AS DeliveryDate
	FROM (
		SELECT *
		FROM [dbo].[Crew]) as Crew
	CROSS JOIN (SELECT TOP 100 *
				FROM [dbo].[Route]
				ORDER BY NEWID()) as Route
GO