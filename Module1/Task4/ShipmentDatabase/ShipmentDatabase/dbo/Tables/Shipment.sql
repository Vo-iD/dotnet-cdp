CREATE TABLE [dbo].[Shipment] (
    [Id]            INT  IDENTITY (1, 1) NOT NULL,
    [DepartureDate] DATE NOT NULL,
    [DeliveryDate]  DATE NULL,
    [CrewId]        INT  NULL,
    [RouteId]       INT  NOT NULL,
    [ActualDistance] INT NULL, 
    [Status] INT NOT NULL DEFAULT 1,
    CONSTRAINT [pk_Shipment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ck_DepartureDeliveryDate] CHECK ([DepartureDate]<=[DeliveryDate]),
    CONSTRAINT [fk_Shipment_Crew] FOREIGN KEY ([CrewId]) REFERENCES [dbo].[Crew] ([Id]),
    CONSTRAINT [fk_Shipmet_Route] FOREIGN KEY ([RouteId]) REFERENCES [dbo].[Route] ([Id]),
    CONSTRAINT [fk_Shipment_Status] FOREIGN KEY ([Status]) REFERENCES [dbo].[Status] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [fk_CrewId]
    ON [dbo].[Shipment]([CrewId] ASC);


GO
CREATE NONCLUSTERED INDEX [fk_RouteId]
    ON [dbo].[Shipment]([RouteId] ASC);

