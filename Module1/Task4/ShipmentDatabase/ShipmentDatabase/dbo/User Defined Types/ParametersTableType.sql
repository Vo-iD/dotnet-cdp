CREATE TYPE [dbo].[ParametersTableType] AS TABLE (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FieldName]  NVARCHAR (100) NULL,
    [FieldValue] NVARCHAR (100) NULL);

