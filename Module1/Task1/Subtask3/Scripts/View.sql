USE [bohdan_simianyk_cdp2016q1]
GO

-- Simple joins
CREATE VIEW [dbo].[ShipmentInfoJoins]
AS 
	SELECT 
		ShipmentTable.DepartureDate AS ShipmentDepartureDate, 
		ShipmentTable.DeliveryDate AS ShipmentDeliveryDate, 
		RouteTable.Distance AS Distance, 
		SourceCity.Name AS SourceCity, 
		DestinationCity.Name AS DestinationCity,
		TruckTable.Brand AS Brand,
		SUM(CargoTable.Weight) AS TotalWeight,
		SUM(CargoTable.Volume) AS TotalVolume,
		TruckTable.FuelConsumption*RouteTable.Distance/100  AS TotalFuel
	
	FROM [dbo].[Shipment] AS ShipmentTable
	JOIN [dbo].[Route] AS RouteTable
	ON ShipmentTable.Id = RouteTable.Id
	JOIN [dbo].[Warehouse] AS SourceWarehouse
	ON RouteTable.SourceId = SourceWarehouse.Id
		JOIN [dbo].[City] AS SourceCity
		ON SourceWarehouse.CityId = SourceCity.Id 
	JOIN [dbo].[Warehouse] AS DestinationWarehouse
	ON RouteTable.DestinationId = DestinationWarehouse.Id
		JOIN [dbo].[City] AS DestinationCity
		ON DestinationWarehouse.CityId = DestinationCity.Id
	JOIN [dbo].[Crew] AS CrewTable
	ON ShipmentTable.CrewId = CrewTable.Id
		JOIN [dbo].[Truck] AS TruckTable
		ON TruckTable.Id = CrewTable.Id
	JOIN [dbo].[CargoShipment] AS CargoShipmentTable
	ON CargoShipmentTable.ShipmentId = ShipmentTable.Id
	JOIN [dbo].[Cargo] AS CargoTable
	ON CargoShipmentTable.CargoId = CargoTable.Id
	GROUP BY 
			ShipmentTable.DepartureDate, 
			ShipmentTable.DeliveryDate, 
			RouteTable.Distance, 
			SourceCity.Name, 
			DestinationCity.Name, 
			TruckTable.Brand,
			TruckTable.FuelConsumption


--;WITH cte AS
--(
--   SELECT 
--   	ShipmentTable.DepartureDate AS ShipmentDepartureDate, 
--	ShipmentTable.DeliveryDate AS ShipmentDeliveryDate, 
--	Route.Distance AS Distance, 
--	SourceCity.Name AS SourceCity, 
--	DestinationCity.Name AS DestinationCity,
--	TruckTable.Brand AS Brand,
--	--CargoTable.Id AS CargoId,
--	--ShipmentTable.Id AS ShipmentId
--	SUM(CargoTable.Weight) AS TotalWeight,
--	SUM(CargoTable.Volume) AS TotalVolume,
--         ROW_NUMBER() OVER (PARTITION BY
--			ShipmentTable.Id
--			ORDER BY ShipmentTable.Id
--		) AS rn
--		FROM [dbo].[Shipment] AS ShipmentTable
--		JOIN [dbo].[Route] AS Route
--		ON ShipmentTable.Id = Route.Id
--		JOIN [dbo].[Warehouse] AS SourceWarehouse
--		ON Route.SourceId = SourceWarehouse.Id
--			JOIN [dbo].[City] AS SourceCity
--			ON SourceWarehouse.CityId = SourceCity.Id 
--		JOIN [dbo].[Warehouse] AS DestinationWarehouse
--		ON Route.DestinationId = DestinationWarehouse.Id
--			JOIN [dbo].[City] AS DestinationCity
--			ON DestinationWarehouse.CityId = DestinationCity.Id
--		JOIN [dbo].[Crew] AS CrewTable
--		ON ShipmentTable.CrewId = CrewTable.Id
--			JOIN [dbo].[Truck] AS TruckTable
--			ON TruckTable.Id = CrewTable.Id
--		JOIN [dbo].[CargoShipment] AS CargoShipmentTable
--		ON CargoShipmentTable.ShipmentId = ShipmentTable.Id
--		JOIN [dbo].[Cargo] AS CargoTable
--		ON CargoShipmentTable.CargoId = CargoTable.Id
--)
--SELECT *
--FROM cte
--WHERE rn = 1
