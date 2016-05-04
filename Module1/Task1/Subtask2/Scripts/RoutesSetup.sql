USE ShippingDb
GO

INSERT INTO [dbo].[Route] (SourceId, DestinationId, Distance)
    SELECT SourceWarehouse.Id as SourceId, DestinationWarehouse.Id as DestinationId, ABS(Checksum(NewID()) % 2900) + 100
	FROM [dbo].[Warehouse] as SourceWarehouse
	INNER JOIN [dbo].[Warehouse] as DestinationWarehouse
	ON SourceWarehouse.Id != DestinationWarehouse.Id
GO
