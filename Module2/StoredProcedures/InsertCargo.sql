CREATE PROCEDURE [dbo].[InsertCargo]
	@ShipmentId AS INT,
    @Weight AS REAL,
    @Volume AS REAL,
    @SenderId AS INT,
    @RecepientId AS INT,
    @RouteId AS INT,
    @Price AS REAL,
	@Id AS INT OUTPUT
AS
BEGIN 
	INSERT INTO [dbo].[Cargo] 
	VALUES (@Weight, @Volume, @SenderId, @RecepientId, @RouteId, @Price);
	SET @Id = SCOPE_IDENTITY();
END