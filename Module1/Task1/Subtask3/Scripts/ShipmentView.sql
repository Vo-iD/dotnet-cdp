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
GO

-- CTE 
CREATE VIEW [dbo].[ShipmentInfoCTE]
AS 
WITH cte AS
(
	SELECT 
	ShipmentTable.DepartureDate AS ShipmentDepartureDate, 
	ShipmentTable.DeliveryDate AS ShipmentDeliveryDate, 
	RouteTable.Distance AS Distance, 
	SourceCity.Name AS SourceCity, 
	DestinationCity.Name AS DestinationCity,
	TruckTable.Brand AS Brand,
	SUM(CargoTable.Weight) AS TotalWeight,
	SUM(CargoTable.Volume) AS TotalVolume,
	TruckTable.FuelConsumption*RouteTable.Distance/100  AS TotalFuel,
	ROW_NUMBER() OVER (PARTITION BY
		ShipmentTable.Id
		ORDER BY ShipmentTable.Id
	) AS rn
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
		TruckTable.FuelConsumption,
		ShipmentTable.Id
)
SELECT 
	ShipmentDepartureDate, 
	ShipmentDeliveryDate, 
	Distance, 
	SourceCity, 
	DestinationCity,
	Brand,
	TotalWeight,
	TotalVolume,
	TotalFuel
FROM cte
WHERE rn = 1

-- Cross Apply	 (THe best way, but difference is minimal)
CREATE VIEW [dbo].[ShipmentInfoCrossApply]
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
	CROSS APPLY(
		SELECT * 
		FROM  [dbo].[Route] 
		WHERE ShipmentTable.Id = [dbo].[Route].Id) AS RouteTable
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
GO
