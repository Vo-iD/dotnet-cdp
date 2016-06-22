USE bohdan_simianyk_cdp2016q1
GO

CREATE PROCEDURE [dbo].[DeleteCargo]
	@Id AS INT 
AS
DELETE FROM [dbo].[Cargo] WHERE [Id] = @Id;