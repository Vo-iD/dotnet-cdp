USE bohdan_simianyk_cdp2016q1
GO 

-- First variant
DELETE FROM [Truck]
WHERE Id NOT IN (
	SELECT MIN(Id) 
	FROM [Truck] 
	GROUP BY RegistrationNumber
	)			

-- Second variant
DELETE FirstTable 
FROM [Truck] FirstTable, [Truck] SecondTable 
WHERE FirstTable.id > SecondTable.id 
		AND FirstTable.RegistrationNumber = SecondTable.RegistrationNumber