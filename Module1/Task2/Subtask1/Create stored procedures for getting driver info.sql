USE bohdan_simianyk_cdp2016q1
GO

CREATE PROCEDURE [dbo].[GetDriverInfoByString]
	@FieldName nvarchar(50),
    @FieldValue nvarchar(50)
AS 
	DECLARE @SQLString nvarchar(MAX);
	SET @SQLString = 
		'SELECT 
			[dbo].[Driver].[FirstName],
			[dbo].[Driver].[LastName],
			[dbo].[Driver].[Birthdate]
		FROM [dbo].[Driver]
		WHERE [dbo].[Driver].[' + @FieldName + ']' + 
			CASE @FieldName
				WHEN 'Birthdate' THEN ' between ''' + @FieldValue + ''' and '''+ @FieldValue + ' 23:59:59'''
				ELSE '=''' + @FieldValue + ''''
			END;
	EXECUTE SP_EXECUTESQL @SQLString
GO

CREATE PROCEDURE [dbo].[GetDriverInfoByExec]
	@FieldName nvarchar(50),
    @FieldValue nvarchar(50)
AS 
	DECLARE @SQLCondition nvarchar(MAX);
	SET @SQLCondition = 
		' WHERE [dbo].[Driver].[' + @FieldName + ']' + 
			CASE @FieldName
				WHEN 'Birthdate' THEN ' between ''' + @FieldValue + ''' and '''+ @FieldValue + ' 23:59:59'''
				ELSE '=''' + @FieldValue + ''''
			END;
			
	EXEC ('SELECT [dbo].[Driver].[FirstName],
			[dbo].[Driver].[LastName],
			[dbo].[Driver].[Birthdate]
			FROM [dbo].[Driver] 
			' + @SQLCondition)
GO