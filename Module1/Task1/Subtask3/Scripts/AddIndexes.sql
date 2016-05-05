USE bohdan_simianyk_cdp2016q1
GO 

-- Cargo Table
CREATE NONCLUSTERED INDEX fk_RecepientId
ON [dbo].[Cargo] (RecepientId)
GO 

CREATE NONCLUSTERED INDEX fk_SenderId
ON [dbo].[Cargo] (SenderId)
GO 

CREATE NONCLUSTERED INDEX fk_RouteId
ON [dbo].[Cargo] (RouteId)
GO

CREATE NONCLUSTERED INDEX Weight
ON [dbo].[Cargo] (Weight)
GO  

CREATE NONCLUSTERED INDEX Volume
ON [dbo].[Cargo] (Volume)
GO

-- CargoShipment Table
CREATE NONCLUSTERED INDEX fk_CargoId
ON [dbo].[CargoShipment] (CargoId)
GO 

CREATE NONCLUSTERED INDEX fk_ShipmentId
ON [dbo].[CargoShipment] (ShipmentId)
GO

-- Crew Table
CREATE NONCLUSTERED INDEX fk_TruckId
ON [dbo].[Crew] (TruckId)
GO 

CREATE NONCLUSTERED INDEX fk_DriverId
ON [dbo].[Crew] (DriverId)
GO

-- Shipment Table
CREATE NONCLUSTERED INDEX fk_CrewId
ON [dbo].[Shipment] (CrewId)
GO 

CREATE NONCLUSTERED INDEX fk_RouteId
ON [dbo].[Shipment] (RouteId)
GO