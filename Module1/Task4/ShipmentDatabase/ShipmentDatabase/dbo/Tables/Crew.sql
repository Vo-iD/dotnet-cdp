CREATE TABLE [dbo].[Crew] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [TruckId]  INT NOT NULL,
    [DriverId] INT NOT NULL,
    CONSTRAINT [pk_Crew] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_Crew_Driver] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Driver] ([Id]),
    CONSTRAINT [fk_Crew_Truck] FOREIGN KEY ([TruckId]) REFERENCES [dbo].[Truck] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [fk_TruckId]
    ON [dbo].[Crew]([TruckId] ASC);


GO
CREATE NONCLUSTERED INDEX [fk_DriverId]
    ON [dbo].[Crew]([DriverId] ASC);

