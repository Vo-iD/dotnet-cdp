USE bohdan_simianyk_cdp2016q1
GO

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO

BEGIN TRAN FirstTran
GO

SELECT *
FROM [dbo].[Route]
WHERE [dbo].[Route].[Id] = 2
GO 

COMMIT TRAN FirstTran
GO

SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO