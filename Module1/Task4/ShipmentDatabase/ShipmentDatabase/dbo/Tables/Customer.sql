CREATE TABLE [dbo].[Customer] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50) NOT NULL,
    [LastName]    NVARCHAR (50) NOT NULL,
    [PhoneNumber] NVARCHAR (15) NOT NULL,
    CONSTRAINT [pk_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ak_PhoneNumber] UNIQUE NONCLUSTERED ([PhoneNumber] ASC)
);

