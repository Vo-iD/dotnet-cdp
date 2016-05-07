USE bohdan_simianyk_cdp2016q1
GO

SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRAN SecondTran
GO

UPDATE [dbo].[Route]
SET [dbo].[Route].[Distance] = ABS(Checksum(NewID()) % 10000)
WHERE [dbo].[Route].[Id] = 2
GO

COMMIT TRAN SecondTran
GO