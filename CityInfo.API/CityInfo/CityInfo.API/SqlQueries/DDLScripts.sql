--SELECT * FROM sys.databases;  --list all db

--EXEC sp_databases; -- list all db

--BACKUP DATABASE CityInfoDB
--TO disk = 'D:\MHM\Preps\.NET\WebAPI\CityInfoApp\CityInfo.API\CityInfo\CityInfo.API\SqlQueries'
--GO
-- mysqldump -u username -p"password" -R testDB > testDB.sql


--CREATE TABLE UserType (
--    id INT IDENTITY PRIMARY KEY,
--    type VARCHAR(255) NOT NULL,
--);

--CREATE TABLE Users (
--    id INT IDENTITY PRIMARY KEY,
--    Name VARCHAR(255) NOT NULL,
--	TypeId INT REFERENCES UserType(id), 
--    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
--);

--SELECT * FROM SYS.TABLES;

--SELECT table_name, table_type FROM INFORMATION_SCHEMA.TABLES;

--EXEC sp_rename 'UserType', 'UserTypes'


--ALTER TABLE Users
--ADD CONSTRAINT fk_Users_UserTypes
--FOREIGN KEY (TypeId) REFERENCES UserTypes(id);

--cloning simple + shallo + deep cloning
--CREATE TABLE new_table SELECT * FROM original_table;
--CREATE TABLE new_table LIKE original_table; 
--INSERT INTO new_table SELECT * FROM original_table;


--SELECT * INTO new_table FROM original_table;

--CREATE TABLE #CUSTOMERS(
--   ID   INT              NOT NULL,
--   NAME VARCHAR (20)     NOT NULL,
--   AGE  INT              NOT NULL,
--   ADDRESS  CHAR (25) ,
--   SALARY   DECIMAL (18, 2),
--   PRIMARY KEY (ID)
--);

--Alter table Users add Sex char(1);

-- add index
--ALTER TABLE CUSTOMERS ADD INDEX name_index (NAME);

--DELETE FROM CUSTOMERS;

--DELETE FROM CUSTOMERS 
--WHERE NAME='Komal' OR ADDRESS='Mumbai';