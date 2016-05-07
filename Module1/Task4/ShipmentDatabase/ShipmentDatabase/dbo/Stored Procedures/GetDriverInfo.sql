
-- Selects info about drivers 
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

	-- End Creating Condition

	-- SELECT result
	   EXEC ('SELECT [dbo].[Driver].[FirstName],
				[dbo].[Driver].[LastName],
				[dbo].[Driver].[Birthdate]
				FROM [dbo].[Driver] 
				' + @SQLCondition)
