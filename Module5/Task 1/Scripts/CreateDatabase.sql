IF EXISTS(SELECT * from sys.databases WHERE name='CdpDatabaseForCacheTask')
BEGIN
    DROP DATABASE CdpDatabaseForCacheTask;
END
	CREATE DATABASE CdpDatabaseForCacheTask;
GO

USE [CdpDatabaseForCacheTask]
GO

CREATE TABLE [dbo].[City](
   	Id UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR (100) NOT NULL,
	State NVARCHAR (100) NOT NULL,
	CONSTRAINT pk_City PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT ak_CityState UNIQUE(Name, State)
)
GO

CREATE TABLE [dbo].[Warehouse](
	Id UNIQUEIDENTIFIER NOT NULL,
	OfficeNumber INT NOT NULL DEFAULT 1,
	CityId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT pk_Warehouse PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Warehouse_City FOREIGN KEY (CityId) REFERENCES [dbo].[City] (Id),
	CONSTRAINT ak_CityOfficeNumber UNIQUE(OfficeNumber, CityId)
)
GO

CREATE TABLE [dbo].[Driver](
	Id UNIQUEIDENTIFIER NOT NULL,
	FirstName NVARCHAR (100) NOT NULL,
	LastName NVARCHAR (100) NOT NULL,
	Birthdate DATE NOT NULL,
	CONSTRAINT pk_Driver PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE [dbo].[Truck](
	Id UNIQUEIDENTIFIER NOT NULL,
	Brand NVARCHAR (100) NOT NULL,
	RegistrationNumber NVARCHAR (100) NOT NULL,
	Year INT NOT NULL,
	Payload INT NOT NULL,
	FuelConsumption FLOAT NOT NULL,
	Volume FLOAT NOT NULL,
	CONSTRAINT pk_Truck PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT ck_YearRange
        CHECK(Year >= 1901 AND Year <= 2016), 
)
GO

CREATE TABLE [dbo].[Crew](
	Id UNIQUEIDENTIFIER NOT NULL,
	TruckId UNIQUEIDENTIFIER NOT NULL,
	DriverId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT pk_Crew PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Crew_Truck FOREIGN KEY (TruckId) REFERENCES [dbo].[Truck] (Id),
	CONSTRAINT fk_Crew_Driver FOREIGN KEY (DriverId) REFERENCES [dbo].[Driver] (Id)
)
GO

CREATE TABLE [dbo].[Route](
	Id UNIQUEIDENTIFIER NOT NULL,
	Distance INT NOT NULL,
	SourceId UNIQUEIDENTIFIER NOT NULL,
	DestinationId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT pk_Route PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Route_WarehouseSource FOREIGN KEY (SourceId) REFERENCES [dbo].[Warehouse] (Id),
	CONSTRAINT fk_Route_WarehouseDestination FOREIGN KEY (DestinationId) REFERENCES [dbo].[Warehouse] (Id),
    CONSTRAINT ak_SourceDestination UNIQUE(SourceId, DestinationId) 
)
GO
  
CREATE TABLE [dbo].[Shipment](
	Id UNIQUEIDENTIFIER NOT NULL,
	DepartureDate Date NOT NULL,
	DeliveryDate Date NULL,
	CrewId UNIQUEIDENTIFIER NULL,
	RouteId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT pk_Shipment PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Shipment_Crew FOREIGN KEY (CrewId) REFERENCES [dbo].[Crew] (Id),
	CONSTRAINT fk_Shipmet_Route FOREIGN KEY (RouteId) REFERENCES [dbo].[Route] (Id),
	CONSTRAINT ck_DepartureDeliveryDate
		CHECK (DepartureDate <= DeliveryDate)
)
GO

CREATE TABLE [dbo].[Customer](
	Id UNIQUEIDENTIFIER NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	CONSTRAINT pk_Customer PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT ak_PhoneNumber UNIQUE(PhoneNumber) 
)
GO

CREATE TABLE [dbo].[Cargo](
	Id UNIQUEIDENTIFIER NOT NULL, 
	Weight FLOAT NOT NULL,
	Volume FLOAT NOT NULL,
	Price MONEY NOT NULL,
	RecepientId UNIQUEIDENTIFIER NOT NULL,
	SenderId UNIQUEIDENTIFIER NOT NULL, 
	RouteId UNIQUEIDENTIFIER NOT NULL, 
	RegisterDate DATE NOT NULL
	CONSTRAINT pk_Cargo PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Cargo_CustomerRecipient FOREIGN KEY (RecepientId) REFERENCES [dbo].[Customer] (Id),
	CONSTRAINT fk_Cargo_CustomerSender FOREIGN KEY (SenderId) REFERENCES [dbo].[Customer] (Id),
	CONSTRAINT fk_Cargo_Route FOREIGN KEY (RouteId) REFERENCES [dbo].[Route] (Id)
)
GO

CREATE TABLE [dbo].[CargoShipment](
	CargoId UNIQUEIDENTIFIER NOT NULL,
	ShipmentId UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT fk_CargoShipment_Cargo FOREIGN KEY (CargoId) REFERENCES [dbo].[Cargo] (Id),
	CONSTRAINT fk_CargoShipment_Shipment FOREIGN KEY (ShipmentId) REFERENCES [dbo].[Shipment] (Id)
)