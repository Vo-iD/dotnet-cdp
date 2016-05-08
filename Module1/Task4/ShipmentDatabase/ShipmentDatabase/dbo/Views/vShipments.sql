CREATE VIEW [dbo].[vShipments]
AS 
	SELECT 
		ShipmentTable.DepartureDate AS ShipmentDepartureDate, 
		ShipmentTable.DeliveryDate AS ShipmentDeliveryDate, 
		RouteTable.Distance AS Distance, 
		SourceCity.Name AS SourceCity, 
		DestinationCity.Name AS DestinationCity,
		TruckTable.Id AS TruckId,
		TruckTable.Brand AS Brand,
		StatusTable.Name AS Status,
		SUM(CargoTable.Weight) AS TotalWeight,
		SUM(CargoTable.Volume) AS TotalVolume,
		COUNT(CargoTable.Id) AS CargoCount,
		SUM(CargoTable.Volume)/TruckTable.Volume * 100 AS UtilizedTruckCapacity,
		SUM(CargoTable.Weight)/TruckTable.Payload * 100 AS UtilizedTruckPayload
	
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
	JOIN [dbo].[Status] AS StatusTable
	ON StatusTable.Id = ShipmentTable.Status
	GROUP BY 
			ShipmentTable.DepartureDate, 
			ShipmentTable.DeliveryDate, 
			RouteTable.Distance, 
			SourceCity.Name, 
			DestinationCity.Name, 
			TruckTable.Id,
			TruckTable.Brand,
			TruckTable.FuelConsumption,
			StatusTable.Name,
			TruckTable.Volume,
			TruckTable.Payload
