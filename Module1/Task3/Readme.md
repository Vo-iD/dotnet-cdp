Subtask 1: 
	Script with describing comments you can find here: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task3/Subtask1/Delete%20transaction.sql
Subtask 2: 
	(1) Script for first (select) transaction: 
		(1.1) READ COMMITED: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task3/Subtask2/First%20transaction%20(read%20committed).sql
		(1.2) SERIALIZABLE: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task3/Subtask2/First%20transaction%20(serializable).sql
	(2) Scripts for second transaction:
		(2.1) REPEATABLE READ level: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task3/Subtask2/Second%20trasaction%20(repeatable%20read).sql
		(2.2) SNAPSHOT level: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task3/Subtask2/Second%20trasaction%20(serializable).sql
		(2.3) READ COMMITED: https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module1/Task3/Subtask2/Second%20trasaction%20(read%20committed).sql
		Note: SNAPSHOT level was not allowed in by database, so for ability to use it, need first set ALLOW_SNAPSHOT_ISOLATION on. 
		
	Note: for check this task first you need to run lines 1-13 from (1) and then run (2). You'll see, that second transaction waits the first one. 
	Possible pairs: 
		1.1 - 2.1 
		1.1 - 2.2
		1.2 - 2.*
		