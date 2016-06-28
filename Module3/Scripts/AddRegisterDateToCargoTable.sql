USE bohdan_simianyk_cdp2016q1
GO

ALTER TABLE [dbo].[Cargo]
ADD RegisterDate Date NOT NULL
CONSTRAINT df_RegisterDate DEFAULT GETDATE()