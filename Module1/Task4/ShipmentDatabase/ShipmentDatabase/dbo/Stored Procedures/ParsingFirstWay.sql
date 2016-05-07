
-- First way of parsing
CREATE PROCEDURE [dbo].[ParsingFirstWay]
	@XML XML
AS
	SELECT  
		Tbl.Col.value('FieldName[1]', 'varchar(100)') AS FieldName,  
		Tbl.Col.value('FieldValue[1]', 'varchar(100)') AS FieldValue
	FROM   @XML.nodes('//pair') Tbl(Col) 
