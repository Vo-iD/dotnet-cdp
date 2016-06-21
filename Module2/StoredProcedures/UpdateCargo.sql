CREATE PROCEDURE [dbo].[UpdateCargo]
	@Id AS INT,
	@ShipmentId AS INT,
    @Weight AS REAL,
    @Volume AS REAL,
    @SenderId AS INT,
    @RecipientId AS INT,
    @RouteId AS INT,
    @Price AS REAL
AS
UPDATE [dbo].[Cargo] 
SET 
	[Weight] = @Weight,
	[Volume] = @Volume,
	[SenderId] = @SenderId,
	[RecepientId] = @RecipientId,
	[RouteId] = @RouteId,
	[Price] = @Price
WHERE [Id] = @Id;