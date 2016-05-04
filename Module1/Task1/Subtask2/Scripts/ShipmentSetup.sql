USE ShippingDb
GO 

declare @FromDate date = '2010-01-01'
declare @ToDate date = '2015-12-31'

INSERT INTO [dbo].[Shipment] (TruckId, RouteId, DepartureDate)
    SELECT TOP 1000 
		Truck.Id AS TruckId,
		Route.Id AS RouteId,
		dateadd(day, rand(checksum(newid())) * (1 + datediff(day, @FromDate, @ToDate)), @FromDate) AS DepartureDate
	FROM (
		SELECT TOP 30 *
		FROM [dbo].[Truck]
		ORDER BY NEWID()) as Truck
	CROSS JOIN (SELECT TOP 100 *
				FROM [dbo].[Route]
				ORDER BY NEWID()) as Route
GO