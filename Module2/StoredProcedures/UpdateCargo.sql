USE bohdan_simianyk_cdp2016q1
GO

CREATE PROCEDURE [dbo].[UpdateCargo]
	@Id AS INT,
    @Weight AS REAL,
    @Volume AS REAL,
    @SenderId AS INT,
    @RecepientId AS INT,
    @RouteId AS INT,
    @Price AS REAL
AS
UPDATE [dbo].[Cargo] 
SET 
	[Weight] = @Weight,
	[Volume] = @Volume,
	[SenderId] = @SenderId,
	[RecepientId] = @RecepientId,
	[RouteId] = @RouteId,
	[Price] = @Price
WHERE [Id] = @Id;