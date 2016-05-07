
-- Second way of parsing
CREATE PROCEDURE [dbo].[ParsingSecondWay]
	@XML XML
AS
	DECLARE @Temp [dbo].[ParametersTableType];
	DECLARE @NodesCount INT = (SELECT @XML.value('count(/pair)', 'int') AS 'Count');
	DECLARE @RowsCount INT = 0;

	WHILE (@RowsCount < @NodesCount)
	BEGIN
		DECLARE @NeededRow INT = @RowsCount + 1;
		DECLARE @Xpath VARCHAR(100) = '(/pair/FieldName/text())[sql:variable("@NeededRow")]'; 

		INSERT INTO @Temp
		SELECT @XML.value('sql:variable("@Xpath")', 'nvarchar(100)') AS FieldName,
			@XML.value('sql:variable("@Xpath")', 'nvarchar(100)') AS FieldValue

		SET @RowsCount = @RowsCount + 1;  
	END

	SELECT * 
	FROM @Temp
