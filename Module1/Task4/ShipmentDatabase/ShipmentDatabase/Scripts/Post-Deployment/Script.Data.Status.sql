/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT * FROM [dbo].[Status] 
                   WHERE [dbo].[Status].[Name] = 'Scheduled')
   BEGIN
       INSERT INTO [dbo].[Status]
       VALUES ('Scheduled');
   END

IF NOT EXISTS (SELECT * FROM [dbo].[Status] 
                   WHERE [dbo].[Status].[Name] = 'Departured')
   BEGIN
       INSERT INTO [dbo].[Status]
       VALUES ('Departured');
   END

IF NOT EXISTS (SELECT * FROM [dbo].[Status] 
                   WHERE [dbo].[Status].[Name] = 'Arrived')
   BEGIN
       INSERT INTO [dbo].[Status]
       VALUES ('Arrived');
   END

IF NOT EXISTS (SELECT * FROM [dbo].[Status] 
                WHERE [dbo].[Status].[Name] = 'Cancelled')
    BEGIN
        INSERT INTO [dbo].[Status]
        VALUES ('Cancelled');
    END;

IF NOT EXISTS (SELECT * FROM [dbo].[Status] 
                WHERE [dbo].[Status].[Name] = 'Completed')
    BEGIN
        INSERT INTO [dbo].[Status]
        VALUES ('Completed');
    END;