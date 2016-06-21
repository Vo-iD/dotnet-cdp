CREATE PROCEDURE [dbo].[DeleteCargo]
	@Id AS INT 
AS
DELETE FROM [dbo].[Cargo] WHERE [Id] = @Id;