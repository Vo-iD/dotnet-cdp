CREATE TABLE [dbo].[City] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (100) NOT NULL,
    [State] NVARCHAR (100) NOT NULL,
    CONSTRAINT [pk_City] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ak_CityState] UNIQUE NONCLUSTERED ([Name] ASC, [State] ASC)
);

