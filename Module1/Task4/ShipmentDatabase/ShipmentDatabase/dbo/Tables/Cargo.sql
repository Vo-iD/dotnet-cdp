CREATE TABLE [dbo].[Cargo] (
    [Id]          INT        IDENTITY (1, 1) NOT NULL,
    [Weight]      FLOAT (53) NOT NULL,
    [Volume]      FLOAT (53) NOT NULL,
    [Price]       MONEY      NOT NULL,
    [RecepientId] INT        NOT NULL,
    [SenderId]    INT        NOT NULL,
    [RouteId]     INT        NOT NULL,
    CONSTRAINT [pk_Cargo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_Cargo_CustomerRecipient] FOREIGN KEY ([RecepientId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [fk_Cargo_CustomerSender] FOREIGN KEY ([SenderId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [fk_Cargo_Route] FOREIGN KEY ([RouteId]) REFERENCES [dbo].[Route] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [fk_RecepientId]
    ON [dbo].[Cargo]([RecepientId] ASC);


GO
CREATE NONCLUSTERED INDEX [fk_SenderId]
    ON [dbo].[Cargo]([SenderId] ASC);


GO
CREATE NONCLUSTERED INDEX [fk_RouteId]
    ON [dbo].[Cargo]([RouteId] ASC);


GO
CREATE NONCLUSTERED INDEX [Weight]
    ON [dbo].[Cargo]([Weight] ASC);


GO
CREATE NONCLUSTERED INDEX [Volume]
    ON [dbo].[Cargo]([Volume] ASC);

