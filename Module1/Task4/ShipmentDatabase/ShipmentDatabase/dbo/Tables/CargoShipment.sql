CREATE TABLE [dbo].[CargoShipment] (
    [CargoId]    INT NOT NULL,
    [ShipmentId] INT NOT NULL,
    CONSTRAINT [fk_CargoShipment_Cargo] FOREIGN KEY ([CargoId]) REFERENCES [dbo].[Cargo] ([Id]),
    CONSTRAINT [fk_CargoShipment_Shipment] FOREIGN KEY ([ShipmentId]) REFERENCES [dbo].[Shipment] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [fk_CargoId]
    ON [dbo].[CargoShipment]([CargoId] ASC);


GO
CREATE NONCLUSTERED INDEX [fk_ShipmentId]
    ON [dbo].[CargoShipment]([ShipmentId] ASC);

