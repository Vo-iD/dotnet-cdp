
-- Full procedure with parsing and selecting (First way)
CREATE PROCEDURE [dbo].[GetDriverInfoXmlParsingFirstWay]
	@XML XML
AS
	DECLARE @Parameters [dbo].[ParametersTableType]

	INSERT INTO @Parameters
		EXEC [dbo].[ParsingFirstWay] @XML = @XML

	EXEC [dbo].[GetDriverInfo] @Parameters
