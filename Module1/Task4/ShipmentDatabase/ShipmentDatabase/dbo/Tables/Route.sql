CREATE TABLE [dbo].[Route] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [Distance]      INT NOT NULL,
    [SourceId]      INT NOT NULL,
    [DestinationId] INT NOT NULL,
    CONSTRAINT [pk_Route] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_Route_WarehouseDestination] FOREIGN KEY ([DestinationId]) REFERENCES [dbo].[Warehouse] ([Id]),
    CONSTRAINT [fk_Route_WarehouseSource] FOREIGN KEY ([SourceId]) REFERENCES [dbo].[Warehouse] ([Id]),
    CONSTRAINT [ak_SourceDestination] UNIQUE NONCLUSTERED ([SourceId] ASC, [DestinationId] ASC)
);

