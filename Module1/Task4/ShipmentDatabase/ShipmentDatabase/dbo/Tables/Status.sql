﻿CREATE TABLE [dbo].[Status]
(
    [Id] INT NOT NULL IDENTITY (1, 1), 
    [Name] NCHAR(20) NOT NULL,
    CONSTRAINT [pk_Status] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO 
