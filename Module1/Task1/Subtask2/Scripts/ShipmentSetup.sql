USE [bohdan_simianyk_cdp2016q1]
GO 

declare @FromDate date = '2010-01-01'
declare @ToDate date = '2015-12-31'

INSERT INTO [dbo].[Shipment] (CrewId, RouteId, DepartureDate)
    SELECT TOP 1000 
		Crew.Id AS CrewId,
		Route.Id AS RouteId,
		dateadd(day, rand(checksum(newid())) * (1 + datediff(day, @FromDate, @ToDate)), @FromDate) AS DepartureDate
	FROM (
		SELECT *
		FROM [dbo].[Crew]) as Crew
	CROSS JOIN (SELECT TOP 100 *
				FROM [dbo].[Route]
				ORDER BY NEWID()) as Route
GO