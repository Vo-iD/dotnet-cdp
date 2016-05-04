IF EXISTS(SELECT * from sys.databases WHERE name='ShippingDb')
BEGIN
    DROP DATABASE ShippingDb;
END
	CREATE DATABASE ShippingDb;
GO

USE ShippingDb
GO

CREATE TABLE [dbo].[City](
   	Id INT IDENTITY (1,1) NOT NULL,
	Name NVARCHAR (100) NOT NULL,
	State NVARCHAR (100) NOT NULL,
	CONSTRAINT pk_City PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT ak_CityState UNIQUE(Name, State)
)
GO

CREATE TABLE [dbo].[Warehouse](
	Id INT IDENTITY (1,1) NOT NULL,
	OfficeNumber INT NOT NULL DEFAULT 1,
	CityId INT NOT NULL,
	CONSTRAINT pk_Warehouse PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Warehouse_City FOREIGN KEY (CityId) REFERENCES [dbo].[City] (Id),
	CONSTRAINT ak_CityOfficeNumber UNIQUE(OfficeNumber, CityId)
)
GO

CREATE TABLE [dbo].[Driver](
	Id INT IDENTITY (1,1) NOT NULL,
	FirstName NVARCHAR (100) NOT NULL,
	LastName NVARCHAR (100) NOT NULL,
	Brithdate DATE NOT NULL,
	CONSTRAINT pk_Driver PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE [dbo].[Truck](
	Id INT IDENTITY (1,1) NOT NULL,
	Brand NVARCHAR (100) NOT NULL,
	RegistrationNumber NVARCHAR (100) NOT NULL,
	Year INT NOT NULL,
	Payload INT NOT NULL,
	FuelConsumption FLOAT NOT NULL,
	Volume FLOAT NOT NULL,
	CONSTRAINT pk_Truck PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT ak_RegistrationNumber UNIQUE(RegistrationNumber),
	CONSTRAINT year_range_check
        CHECK(Year >= 1901 AND Year <= 2016), 
)
GO

CREATE TABLE [dbo].[Crew](
	Id INT IDENTITY (1,1) NOT NULL,
	TruckId INT NOT NULL,
	DriverId INT NOT NULL,
	CONSTRAINT pk_Crew PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Crew_Truck FOREIGN KEY (TruckId) REFERENCES [dbo].[Truck] (Id),
	CONSTRAINT fk_Crew_Driver FOREIGN KEY (DriverId) REFERENCES [dbo].[Driver] (Id)
)
GO

CREATE TABLE [dbo].[Route](
	Id INT IDENTITY(1,1) NOT NULL,
	Distance INT NOT NULL,
	SourceId INT NOT NULL,
	DestinationId INT NOT NULL,
	CONSTRAINT pk_Route PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Route_WarehouseSource FOREIGN KEY (SourceId) REFERENCES [dbo].[Warehouse] (Id),
	CONSTRAINT fk_Route_WarehouseDestination FOREIGN KEY (DestinationId) REFERENCES [dbo].[Warehouse] (Id),
    CONSTRAINT ak_Route UNIQUE(SourceId, DestinationId) 
)
GO
  
CREATE TABLE [dbo].[Shipment](
	Id INT IDENTITY (1,1) NOT NULL,
	DepartureDate Date NOT NULL,
	DeliveryDate Date NULL,
	CrewId INT NULL,
	RouteId INT NOT NULL,
	CONSTRAINT pk_Shipment PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Shipment_Crew FOREIGN KEY (CrewId) REFERENCES [dbo].[Crew] (Id),
	CONSTRAINT fk_Shipmet_Route FOREIGN KEY (RouteId) REFERENCES [dbo].[Route] (Id)
)
GO

CREATE TABLE [dbo].[Customer](
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	CONSTRAINT pk_Customer PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT ak_PhoneNumber UNIQUE(PhoneNumber) 
)
GO

CREATE TABLE [dbo].[Cargo](
	Id INT IDENTITY (1,1) NOT NULL, 
	Weight FLOAT NOT NULL,
	Volume FLOAT NOT NULL,
	Price MONEY NOT NULL,
	RecepientId INT NOT NULL,
	SenderId INT NOT NULL, 
	RouteId INT NOT NULL, 
	CONSTRAINT pk_Cargo PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Cargo_CustomerRecipient FOREIGN KEY (RecepientId) REFERENCES [dbo].[Customer] (Id),
	CONSTRAINT fk_Cargo_CustomerSender FOREIGN KEY (SenderId) REFERENCES [dbo].[Customer] (Id),
	CONSTRAINT fk_Cargo_Route FOREIGN KEY (RouteId) REFERENCES [dbo].[Route] (Id)
)
GO

CREATE TABLE [dbo].[CargoShipment](
	CargoId INT NOT NULL,
	ShipmentId INT NOT NULL
	CONSTRAINT fk_CargoShipment_Cargo FOREIGN KEY (CargoId) REFERENCES [dbo].[Cargo] (Id),
	CONSTRAINT fk_CargoShipment_Shipment FOREIGN KEY (ShipmentId) REFERENCES [dbo].[Shipment] (Id)
)