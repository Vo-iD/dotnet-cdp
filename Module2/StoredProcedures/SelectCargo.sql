USE bohdan_simianyk_cdp2016q1
GO

CREATE PROCEDURE [dbo].[SelectCargo]
	@Id AS INT
AS
SELECT [Id], [Weight], [Volume], [SenderId], [RecepientId], [RouteId], [Price]
FROM [dbo].[Cargo]
WHERE Id = @Id;
