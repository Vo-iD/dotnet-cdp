CREATE TABLE [dbo].[Truck] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Brand]              NVARCHAR (100) NOT NULL,
    [RegistrationNumber] NVARCHAR (100) NOT NULL,
    [Year]               INT            NOT NULL,
    [Payload]            INT            NOT NULL,
    [FuelConsumption]    FLOAT (53)     NOT NULL,
    [Volume]             FLOAT (53)     NOT NULL,
    CONSTRAINT [pk_Truck] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ck_YearRange] CHECK ([Year]>=(1901) AND [Year]<=(2016))
);

