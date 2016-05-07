CREATE TABLE [dbo].[Warehouse] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [OfficeNumber] INT DEFAULT ((1)) NOT NULL,
    [CityId]       INT NOT NULL,
    CONSTRAINT [pk_Warehouse] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_Warehouse_City] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id]),
    CONSTRAINT [ak_CityOfficeNumber] UNIQUE NONCLUSTERED ([OfficeNumber] ASC, [CityId] ASC)
);

