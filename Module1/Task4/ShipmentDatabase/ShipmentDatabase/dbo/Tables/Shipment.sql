CREATE TABLE [dbo].[Shipment] (
    [Id]            INT  IDENTITY (1, 1) NOT NULL,
    [DepartureDate] DATE NOT NULL,
    [DeliveryDate]  DATE NULL,
    [CrewId]        INT  NULL,
    [RouteId]       INT  NOT NULL,
    CONSTRAINT [pk_Shipment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ck_DepartureDeliveryDate] CHECK ([DepartureDate]<=[DeliveryDate]),
    CONSTRAINT [fk_Shipment_Crew] FOREIGN KEY ([CrewId]) REFERENCES [dbo].[Crew] ([Id]),
    CONSTRAINT [fk_Shipmet_Route] FOREIGN KEY ([RouteId]) REFERENCES [dbo].[Route] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [fk_CrewId]
    ON [dbo].[Shipment]([CrewId] ASC);


GO
CREATE NONCLUSTERED INDEX [fk_RouteId]
    ON [dbo].[Shipment]([RouteId] ASC);

