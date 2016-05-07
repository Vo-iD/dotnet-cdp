
-- Full procedure with parsing and selecting (Second way)
CREATE PROCEDURE [dbo].[GetDriverInfoXmlParsingSecondWay]
	@XML XML
AS
	DECLARE @Parameters [dbo].[ParametersTableType]

	INSERT INTO @Parameters
		EXEC [dbo].[ParsingSecondWay] @XML = @XML

	EXEC [dbo].[GetDriverInfo] @Parameters
