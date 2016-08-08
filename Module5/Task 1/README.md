Task:
	https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module5/Task%201/DoNeMP-HomeTask_Module5.1.docx
	
Script for creating database with guids as primary key:
	https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module5/Task%201/Scripts/CreateDatabase.sql

Perfomance results: 
	https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module5/Task%201/Performance%20measurement.xlsx
	
Cache configurations: 
	https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module5/Task%201/CargoWebAPI/CargosService.WebApi/Web.config
	where:
		Entity.LastUpdateTime + 'CacheExpirationTime' < Now means that entity in cache is outdated
		Entity.LastUpdateTime + 'CacheBlackZoneTime' < Now < Entity.LastUpdateTime + 'CacheExpirationTime' means that entity in cahce should be updated async
		Entity.LastUpdateTime + 'CacheBlackZoneTime' > Now means that entity in cache is okay
		
Cache service: 
	https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module5/Task%201/CargoWebAPI/CargosService.Business.Implementation/Services/CargoCacheService.cs
Cache storage:
	https://gitpct.epam.com/bohdan_simianyk/mentoring_program/blob/master/Module5/Task%201/CargoWebAPI/CargosService.DataAccess.Implementation/Cache/CargoCacheStorage.cs