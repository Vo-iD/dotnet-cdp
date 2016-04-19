IF EXISTS(SELECT * from sys.databases WHERE name='ShippingDb')
BEGIN
    DROP DATABASE ShippingDb;
END
	CREATE DATABASE ShippingDb;
GO

USE ShippingDb
GO

CREATE TABLE dbo.Warehouses(
	Id INT IDENTITY (1,1) NOT NULL,
	City NVARCHAR (100) NOT NULL,
	UsaState NVARCHAR (100) NOT NULL,
	CONSTRAINT pk_Warehouses PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE dbo.Drivers(
	Id INT IDENTITY (1,1) NOT NULL,
	FirstName NVARCHAR (100) NOT NULL,
	LastName NVARCHAR (100) NOT NULL,
	BrithDate DATE NOT NULL,
	CONSTRAINT pk_Drivers PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE dbo.Trucks(
	Id INT IDENTITY (1,1) NOT NULL,
	Brand NVARCHAR (100) NOT NULL,
	RegistrationNumber NVARCHAR (100) NOT NULL,
	Payload INT NOT NULL,
	FuelConsumption INT NOT NULL,
	Volume INT NOT NULL,
	IssueYear DATE NOT NULL,
	CONSTRAINT pk_Trucks PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE dbo.Trucks_Drivers(
	TruckId INT NOT NULL,
	DriverId INT NOT NULL
	CONSTRAINT fk_TruckToDriver FOREIGN KEY (TruckId) REFERENCES dbo.Trucks (Id),
	CONSTRAINT fk_DriverToTruck FOREIGN KEY (DriverId) REFERENCES dbo.Drivers (Id)
)
GO

CREATE TABLE dbo.ShipmentRoutes(
	Id INT IDENTITY(1,1) NOT NULL,
	Distance INT NOT NULL,
	SourceId INT NOT NULL,
	DestinationId INT NOT NULL,
	CONSTRAINT pk_ShipmentRoutes PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Source FOREIGN KEY (SourceId) REFERENCES dbo.Warehouses (Id),
	CONSTRAINT fk_Destination FOREIGN KEY (DestinationId) REFERENCES dbo.Warehouses (Id)
)
GO
  
CREATE TABLE dbo.Shipments(
	Id INT IDENTITY (1,1) NOT NULL,
	DepartureDate Date NOT NULL,
	DeliveryDate Date NULL,
	Price INT NOT NULL,
	TruckId INT NULL,
	RouteId INT NOT NULL,
	CONSTRAINT pk_Shipments PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_ShipmentTruck FOREIGN KEY (TruckId) REFERENCES dbo.Trucks (Id),
	CONSTRAINT fk_Route FOREIGN KEY (RouteId) REFERENCES dbo.ShipmentRoutes (Id)
)
GO

CREATE TABLE dbo.Customers(
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	CONSTRAINT pk_Customers PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE dbo.Cargos(
	Id INT IDENTITY (1,1) NOT NULL, 
	Weight INT NOT NULL,
	Volume INT NOT NULL,
	RecepientId INT NOT NULL,
	SenderId INT NOT NULL, 
	ShipmentId INT NOT NULL, 
	CONSTRAINT pk_Cargos PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Recipient FOREIGN KEY (RecepientId) REFERENCES dbo.Customers (Id),
	CONSTRAINT fk_Sender FOREIGN KEY (SenderId) REFERENCES dbo.Customers (Id),
	CONSTRAINT fk_Shipment FOREIGN KEY (ShipmentId) REFERENCES dbo.Shipments (Id),
)