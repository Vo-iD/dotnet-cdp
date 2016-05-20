USE bohdan_simianyk_cdp2016q1
GO

DECLARE @FirstId INT = 8;
DECLARE @SecondId INT = 16;
DECLARE @ThirdId INT = 24;

BEGIN TRAN
-- First
	DECLARE @FirstWarehouseRoutes TABLE(
		Id INT NOT NULL
	); 

	INSERT INTO @FirstWarehouseRoutes
	SELECT Id
	FROM [dbo].[Route]
	WHERE [dbo].[Route].[SourceId] = @FirstId OR [dbo].[Route].DestinationId = @FirstId
	
	-- For deleting shipments, first need to delete cargo-shipment relations
	DELETE 
	FROM [dbo].[CargoShipment]
	WHERE [dbo].[CargoShipment].[CargoId] IN (
		SELECT Id
		FROM [dbo].[Cargo]
		WHERE RouteId IN (
			SELECT *
			FROM @FirstWarehouseRoutes
		)
	) OR [dbo].[CargoShipment].[ShipmentId] IN (
	    SELECT Id
		FROM [dbo].[Shipment]
		WHERE RouteId IN (
			SELECT *
			FROM @FirstWarehouseRoutes
		)
	)

	-- For deleting shipments, first need to delete Cargos related with routes, which related with warehouses
	DELETE
	FROM [dbo].[Cargo]
	WHERE RouteId IN (
		SELECT *
		FROM @FirstWarehouseRoutes
	)

	-- For deleting Routes, first need to delete Shipments, related with routes, which related with warehouses
	DELETE
	FROM [dbo].[Shipment]
	WHERE RouteId IN (
		SELECT *
		FROM @FirstWarehouseRoutes
	)	
	
	-- For deleting warehouses first need to delete routes, related with these warehouses
	DELETE
	FROM [dbo].[Route]
	WHERE [dbo].[Route].[SourceId] = @FirstId OR [dbo].[Route].DestinationId = @FirstId

	-- Finally we can delete warehouses
	DELETE 
	FROM [dbo].[Warehouse]
	WHERE [dbo].[Warehouse].Id = @FirstId
	SAVE TRAN FirstDeleting

-- Second
	DECLARE @SecondWarehouseRoutes TABLE(
		Id INT NOT NULL
	); 

	INSERT INTO @SecondWarehouseRoutes
	SELECT Id
	FROM [dbo].[Route]
	WHERE [dbo].[Route].[SourceId] = @SecondId OR [dbo].[Route].DestinationId = @SecondId
	
	-- For deleting shipments, first need to delete cargo-shipment relations
	DELETE 
	FROM [dbo].[CargoShipment]
	WHERE [dbo].[CargoShipment].[CargoId] IN (
		SELECT Id
		FROM [dbo].[Cargo]
		WHERE RouteId IN (
			SELECT *
			FROM @SecondWarehouseRoutes
		)
	) OR [dbo].[CargoShipment].[ShipmentId] IN (
	    SELECT Id
		FROM [dbo].[Shipment]
		WHERE RouteId IN (
			SELECT *
			FROM @SecondWarehouseRoutes
		)
	)

	-- For deleting shipments, first need to delete Cargos related with routes, which related with warehouses
	DELETE
	FROM [dbo].[Cargo]
	WHERE RouteId IN (
		SELECT *
		FROM @SecondWarehouseRoutes
	)

	-- For deleting Routes, first need to delete Shipments, related with routes, which related with warehouses
	DELETE
	FROM [dbo].[Shipment]
	WHERE RouteId IN (
		SELECT *
		FROM @SecondWarehouseRoutes
	)	
	
	-- For deleting warehouses first need to delete routes, related with these warehouses
	DELETE
	FROM [dbo].[Route]
	WHERE [dbo].[Route].[SourceId] = @SecondId OR [dbo].[Route].DestinationId = @SecondId

	-- Finally we can delete warehouses
	DELETE 
	FROM [dbo].[Warehouse]
	WHERE [dbo].[Warehouse].Id = @SecondId
	
-- Third
	DECLARE @ThirdWarehouseRoutes TABLE(
		Id INT NOT NULL
	); 

	INSERT INTO @ThirdWarehouseRoutes
	SELECT Id
	FROM [dbo].[Route]
	WHERE [dbo].[Route].[SourceId] = @ThirdId OR [dbo].[Route].DestinationId = @ThirdId

	-- For deleting shipments, first need to delete cargo-shipment relations
	DELETE 
	FROM [dbo].[CargoShipment]
	WHERE [dbo].[CargoShipment].[CargoId] IN (
		SELECT Id
		FROM [dbo].[Cargo]
		WHERE RouteId IN (
			SELECT *
			FROM @ThirdWarehouseRoutes
		)
	) OR [dbo].[CargoShipment].[ShipmentId] IN (
	    SELECT Id
		FROM [dbo].[Shipment]
		WHERE RouteId IN (
			SELECT *
			FROM @ThirdWarehouseRoutes
		)
	)

	-- For deleting shipments, first need to delete Cargos related with routes, which related with warehouses
	DELETE
	FROM [dbo].[Cargo]
	WHERE RouteId IN (
		SELECT *
		FROM @ThirdWarehouseRoutes
	)

	-- For deleting Routes, first need to delete Shipments, related with routes, which related with warehouses
	DELETE
	FROM [dbo].[Shipment]
	WHERE RouteId IN (
		SELECT *
		FROM @ThirdWarehouseRoutes
	)	
	
	-- For deleting warehouses first need to delete routes, related with these warehouses
	DELETE
	FROM [dbo].[Route]
	WHERE [dbo].[Route].[SourceId] = @ThirdId OR [dbo].[Route].DestinationId = @ThirdId

	-- Finally we can delete warehouses
	DELETE 
	FROM [dbo].[Warehouse]
	WHERE [dbo].[Warehouse].Id = @ThirdId

ROLLBACK TRAN FirstDeleting

COMMIT TRAN
