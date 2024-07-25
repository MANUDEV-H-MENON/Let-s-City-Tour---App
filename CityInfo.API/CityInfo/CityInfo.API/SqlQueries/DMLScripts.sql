--select * from Cities
--select * from PointOfInterests
select * from Tourcoordinators

declare @maxcityId int
select @maxcityId  = max(CityId) from Tourcoordinators
print @maxcityId

--select * from Users


--1 N - Duplicates, 2N- partial dependecy, 3N -transitive dependency - ZIP,CITY


--Insert into Users (Name, TypeId, Sex) values ('Manudev', 1 ,'M');
--Insert into Users (Name, TypeId, Sex) values ('Swati', 2 ,'F');
--Insert into Users (Name, TypeId, Sex) values ('Danush', 2 ,'F');

--select CityId from TourCoordinators where cityId =  ANY(select Id from Cities)

--select top 4 *, Id+2 as plustwo from Tourcoordinators order by Name desc

--select  Name, count(CityId) from Tourcoordinators 
--group by name

--select CityId , case 
--when cityId %2 = 0 then 'odd' 
--else 'even' 
--end as oddOrEven
--from TourCoordinators


--create nonclustered index tourcords_index on TourCoordinators(Id,Name);
--drop index tourcords_index on TourCoordinators
--show index from tourcoordinators

--SELECT *
--FROM sys.indexes
--WHERE object_id = OBJECT_ID('tourcoordinators');

--EXEC sys.sp_helpindex @objname = N'tourcoordinators';


--CREATE PROCEDURE GetCItyInfo
--@CityId int
--as 
--BEGIN
--SELECT * FROM TourCoordinators where CityId = CityId;
--END

--DROP PROCEDURE GetCItyInfo;

--CREATE PROCEDURE GetCityInfo
--    @cityid INT
--AS
--BEGIN
--    SELECT * FROM TourCoordinators WHERE CityId = @cityid;
--END;

--EXEC GetCityInfo @CityId=12;


create function calculatearea(@Radicus float) returns float
as
begin
	declare @area float;
	set @area = @Radicus * @Radicus;
	return @area;
end

SELECT dbo.CalculateArea(2.4) AS Area;
