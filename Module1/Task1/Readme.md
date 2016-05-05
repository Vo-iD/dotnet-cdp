Subtask 1: 
	Physical model: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task1/Subtask1/Physical%20model.png
	Logical model: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task1/Subtask1/Logical%20model.png
	
Subtask 2: 
	All scripts you can find at folder: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/tree/master/Module1/Task1/Subtask2/Scripts
	All csv files you can find here: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/tree/master/Module1/Task1/Subtask2
	1) Import. Script for import test data from (csv files have been created and puted here: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/tree/master/Module1/Task1/Subtask2.
		Also has been used BULK INSERT for it) lecturer you can find here:https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task1/Subtask2/Scripts/XlsToSqlMigration.sql 
	2) Route table. Script for setup Route table is here: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task1/Subtask2/Scripts/RoutesSetup.sql
	3-4) Cargo and Shipment table.
	Script for setup Cargo, Shipment and CargoShipment table is here:https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task1/Subtask2/Scripts/CargoAndShipmentSetup.sql
		Also at due requirements at this task has been changed database structure: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/commit/c219195079784ae4da55e17d686c660831ad5896.
		(Changed table TruckDriver to Crew and changed reference from Shipment-to-Truck to Shipment-to-Crew)
			
Subtask 3: 
	Script for crating views you can find here: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task1/Subtask3/Scripts/ShipmentView.sql
	Script for adding indexes here: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task1/Subtask3/Scripts/AddIndexes.sql
	Note: On my local machine, indexes did not show a significant result.