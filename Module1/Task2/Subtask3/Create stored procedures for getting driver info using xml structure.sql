USE bohdan_simianyk_cdp2016q1
GO

CREATE TYPE [dbo].[ParametersTableType] AS TABLE 
(
	Id INT NOT NULL IDENTITY(1,1),
	FieldName NVARCHAR(100), 
	FieldValue NVARCHAR(100)
)
GO

CREATE PROCEDURE [dbo].[ParsingFirstWay]
	@XML XML
AS
	SELECT  
		Tbl.Col.value('FieldName[1]', 'varchar(100)') AS FieldName,  
		Tbl.Col.value('FieldValue[1]', 'varchar(100)') AS FieldValue
	FROM   @XML.nodes('//pair') Tbl(Col) 
GO

CREATE PROCEDURE [dbo].[GetDriverInfo]
  @Parameters [dbo].[ParametersTableType] READONLY
AS
	DECLARE  @FieldName VARCHAR(100)
	DECLARE @FieldValue VARCHAR(100)

	SELECT TOP 1 
		@FieldName = FieldName, 
		@FieldValue=FieldValue 
	FROM @Parameters

	DECLARE @SQLCondition VARCHAR(MAX) = 'WHERE ';
	DECLARE @FirstCondition BIT = 1;
	DECLARE @Counter INT = 1;

	WHILE (@Counter <= @@rowcount)
	BEGIN
		IF (@Counter != 1)
			BEGIN
				SET @SQLCondition = @SQLCondition + ' AND '
			END		

		SET @SQLCondition = @SQLCondition + 
			' [dbo].[Driver].[' + @FieldName + ']' + 
				CASE @FieldName
					WHEN 'Birthdate' THEN ' between ''' + @FieldValue + ''' and '''+ @FieldValue + ' 23:59:59'''
					ELSE '=''' + @FieldValue + ''''
				END;

		SELECT @FieldName = FieldName, @FieldValue = FieldValue 
		FROM @Parameters
		ORDER BY Id
		OFFSET @Counter ROWS
		FETCH NEXT 1 ROWS ONLY; 

		SET @Counter = @Counter + 1;
	END

	EXEC ('SELECT [dbo].[Driver].[FirstName],
			[dbo].[Driver].[LastName],
			[dbo].[Driver].[Birthdate]
			FROM [dbo].[Driver] 
			' + @SQLCondition)
GO

CREATE PROCEDURE [dbo].[GetDriverInfoXmlParsingFirstWay]
	@XML XML
AS
	DECLARE @Parameters [dbo].[ParametersTableType]

	INSERT INTO @Parameters
		EXEC [dbo].[ParsingFirstWay] @XML = @XML

	EXEC [dbo].[GetDriverInfo] @Parameters
GO

-- First procedure example
DECLARE @XML XML = '
<pair>
	<FieldName>FirstName</FieldName>
	<FieldValue>John</FieldValue>
</pair>
<pair>
	<FieldName>LastName</FieldName>
	<FieldValue>Doe</FieldValue>
</pair>
<pair>
	<FieldName>Birthdate</FieldName>
	<FieldValue>1967-01-23</FieldValue>
</pair>'

EXEC [dbo].[GetDriverInfoXmlParsingFirstWay] @XML = @XML