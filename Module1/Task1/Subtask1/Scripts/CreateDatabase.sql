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
	UsaState NVARCHAR (100) NOT NULL,
	CONSTRAINT pk_City PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT ak_CityState UNIQUE(Name, UsaState)
)
GO

CREATE TABLE [dbo].[Warehouse](
	Id INT IDENTITY (1,1) NOT NULL,
	OfficeNumber INT NOT NULL DEFAULT 1,
	CityId INT NOT NULL,
	CONSTRAINT pk_Warehouse PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_City FOREIGN KEY (CityId) REFERENCES [dbo].[City] (Id),
	CONSTRAINT ak_CityOfficeNumber UNIQUE(OfficeNumber, CityId)
)
GO

CREATE TABLE [dbo].[Driver](
	Id INT IDENTITY (1,1) NOT NULL,
	FirstName NVARCHAR (100) NOT NULL,
	LastName NVARCHAR (100) NOT NULL,
	BrithDate DATE NOT NULL,
	CONSTRAINT pk_Driver PRIMARY KEY CLUSTERED (Id)
)
GO

CREATE TABLE [dbo].[Truck](
	Id INT IDENTITY (1,1) NOT NULL,
	Brand NVARCHAR (100) NOT NULL,
	RegistrationNumber NVARCHAR (100) NOT NULL,
	Payload INT NOT NULL,
	FuelConsumption FLOAT NOT NULL,
	Volume FLOAT NOT NULL,
	IssueYear DATE NOT NULL,
	CONSTRAINT pk_Truck PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT ak_RegistrationNumber UNIQUE(RegistrationNumber) 
)
GO

CREATE TABLE [dbo].[TruckDriver](
	TruckId INT NOT NULL,
	DriverId INT NOT NULL,
	CONSTRAINT fk_TruckToDriver FOREIGN KEY (TruckId) REFERENCES [dbo].[Truck] (Id),
	CONSTRAINT fk_DriverToTruck FOREIGN KEY (DriverId) REFERENCES [dbo].[Driver] (Id)
)
GO

CREATE TABLE [dbo].[Route](
	Id INT IDENTITY(1,1) NOT NULL,
	Distance INT NOT NULL,
	SourceId INT NOT NULL,
	DestinationId INT NOT NULL,
	CONSTRAINT pk_Route PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_Source FOREIGN KEY (SourceId) REFERENCES [dbo].[Warehouse] (Id),
	CONSTRAINT fk_Destination FOREIGN KEY (DestinationId) REFERENCES [dbo].[Warehouse] (Id)
)
GO
  
CREATE TABLE [dbo].[Shipment](
	Id INT IDENTITY (1,1) NOT NULL,
	DepartureDate Date NOT NULL,
	DeliveryDate Date NULL,
	TruckId INT NULL,
	RouteId INT NOT NULL,
	CONSTRAINT pk_Shipment PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT fk_ShipmentTruck FOREIGN KEY (TruckId) REFERENCES [dbo].[Truck] (Id),
	CONSTRAINT fk_ShipmetRoute FOREIGN KEY (RouteId) REFERENCES [dbo].[Route] (Id)
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
	CONSTRAINT fk_Recipient FOREIGN KEY (RecepientId) REFERENCES [dbo].[Customer] (Id),
	CONSTRAINT fk_Sender FOREIGN KEY (SenderId) REFERENCES [dbo].[Customer] (Id),
	CONSTRAINT fk_CargoRoute FOREIGN KEY (RouteId) REFERENCES [dbo].[Route] (Id)
)
GO

CREATE TABLE [dbo].[CargoShipment](
	CargoId INT NOT NULL,
	ShipmentId INT NOT NULL
	CONSTRAINT fk_CargoToShipment FOREIGN KEY (CargoId) REFERENCES [dbo].[Cargo] (Id),
	CONSTRAINT fk_ShipmentToCargo FOREIGN KEY (ShipmentId) REFERENCES [dbo].[Shipment] (Id)
)