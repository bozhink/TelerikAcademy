-- 01. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
---- Use a nested SELECT statement.
USE [TelerikAcademy]
SELECT [FirstName], [LastName], [MiddleName], [Salary]
	FROM [Employees]
	WHERE [Salary] = 
		(SELECT MIN([Salary]) FROM [Employees])
GO

-- 02. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
USE [TelerikAcademy]
DECLARE @MinSalary INT = (SELECT MIN([Salary]) FROM [Employees])
SELECT [FirstName], [LastName], [MiddleName], [Salary]
    FROM [Employees]
	WHERE [Salary] BETWEEN @MinSalary AND 1.1 * @MinSalary
	ORDER BY [Salary]
GO

-- 03. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
---- Use a nested SELECT statement.
USE [TelerikAcademy]
SELECT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [Full Name],
       e.[Salary],
	   d.[Name]
	FROM [Employees] e 
	JOIN [Departments] d
	    ON e.[DepartmentID] = d.[DepartmentID]
    WHERE e.[Salary] =
        (SELECT MIN(emp.[Salary]) FROM [Employees] emp
            WHERE emp.[DepartmentID] = d.[DepartmentID])
    ORDER BY [Salary]
GO

-- 04. Write a SQL query to find the average salary in the department #1.
USE [TelerikAcademy]
SELECT ROUND(AVG([Salary]), 2) AS [Average Salary]
	FROM [Employees]
	WHERE [DepartmentID] = 1
GO

-- 05.  Write a SQL query to find the average salary in the "Sales" department.
USE [TelerikAcademy]
SELECT ROUND(AVG([Salary]), 2) AS [Average Salary]
	FROM [Employees] e
	JOIN [Departments] d
		ON e.[DepartmentID] = d.[DepartmentID]
	WHERE d.[Name] = 'Sales'
GO

-- 06. Write a SQL query to find the number of employees in the "Sales" department.
USE [TelerikAcademy]
SELECT COUNT(*) AS [Employees Count]
	FROM [Employees] e
	JOIN [Departments] d
		ON e.[DepartmentID] = d.[DepartmentID]
	WHERE d.[Name] = 'Sales'
GO

-- 07. Write a SQL query to find the number of all employees that have manager.
USE [TelerikAcademy]
SELECT COUNT(*) AS [Managed Employees Count]
	FROM [Employees]
	WHERE [ManagerID] IS NOT NULL
GO

-- 08. Write a SQL query to find the number of all employees that have no manager.
USE [TelerikAcademy]
SELECT COUNT(*) AS [Managers Count]
	FROM [Employees]
	WHERE [ManagerID] IS NULL
GO

-- 09. Write a SQL query to find all departments and the average salary for each of them.
USE [TelerikAcademy]
SELECT d.[Name] AS [Department],
       ROUND(AVG([Salary]), 2) AS [Average Salary]
	FROM [Employees] e
	JOIN [Departments] d
		ON e.[DepartmentID] = d.[DepartmentID]
	GROUP BY d.[Name]
	ORDER BY [Average Salary]
GO

-- 10. Write a SQL query to find the count of all employees in each department and for each town.
USE [TelerikAcademy]
SELECT d.[Name] AS [Department],
       t.[Name] AS [Town],
       COUNT(e.[EmployeeID]) AS [Employees Count]
	FROM [Employees] e
	JOIN [Departments] d
		ON e.[DepartmentID] = d.[DepartmentID]
	JOIN [Addresses] a
		ON e.[AddressID] = a.[AddressID]
	JOIN [Towns] t
		ON a.[TownID] = t.[TownID]
	GROUP BY d.[Name], t.[Name]
	ORDER BY d.[Name]
GO

-- 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
USE [TelerikAcademy]
SELECT e.[FirstName], e.[LastName]
	FROM [Employees] e
	JOIN [Employees] emp
		ON emp.[ManagerID] = e.[EmployeeID]
	GROUP BY e.[EmployeeID], e.[FirstName], e.[LastName]
	HAVING COUNT(e.[EmployeeID]) = 5
GO

-- 12.  Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
USE [TelerikAcademy]
SELECT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [Employee Name],
	   COALESCE(m.[FirstName] + ' ' + m.[LastName], 'no manager') AS [Manager Name]
	FROM [Employees] e
	LEFT JOIN [Employees] m
		ON e.[ManagerID] = m.[EmployeeID]
GO

-- 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
USE [TelerikAcademy]
SELECT *
	FROM [Employees]
	WHERE LEN([LastName]) = 5
GO

-- 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
---- Search in Google to find how to format dates in SQL Server.
USE [TelerikAcademy]
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff')
GO

-- 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
---- Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
---- Define the primary key column as identity to facilitate inserting records.
---- Define unique constraint to avoid repeating usernames.
---- Define a check constraint to ensure the password is at least 5 characters long.
USE [TelerikAcademy]
IF OBJECT_ID ('Users') IS NOT NULL
	DROP TABLE [Users]
GO
CREATE TABLE [Users]
(
    [Id] int IDENTITY(1,1) PRIMARY KEY,
    [Username] nvarchar(50) NOT NULL UNIQUE,
    [Password] nvarchar(256) CHECK (LEN([Password]) > 5),
    [Full Name] nvarchar(50) NOT NULL,
    [Last Login Time] DATETIME
) 
GO

-- 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
---- Test if the view works correctly.
USE [TelerikAcademy]
IF OBJECT_ID ('Logged Users Today') IS NOT NULL
	DROP VIEW [Logged Users Today]
GO
CREATE VIEW [Logged Users Today]
AS 
	SELECT [Username]
		FROM [Users]
		WHERE DATEDIFF(DAY, [Last Login Time], GETDATE()) = 0
GO

-- 17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
---- Define primary key and identity column.
USE [TelerikAcademy]
IF OBJECT_ID ('Groups') IS NOT NULL
	DROP TABLE Groups
GO
CREATE TABLE [Groups]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(50) NOT NULL UNIQUE
)
GO

-- 18. Write a SQL statement to add a column GroupID to the table Users.
---- Fill some data in this new column and as well in the `Groups table.
---- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
USE [TelerikAcademy]
IF OBJECT_ID ('Users') IS NOT NULL
	ALTER TABLE [Users]
		ADD [GroupID] int NOT NULL
GO

IF OBJECT_ID ('Users') IS NOT NULL AND OBJECT_ID ('Groups') IS NOT NULL
	ALTER TABLE [Users]
		ADD CONSTRAINT [FK_Users_Groups]
		FOREIGN KEY ([GroupId])
		REFERENCES [Groups]([Id])
GO

-- 19. Write SQL statements to insert several records in the Users and Groups tables.
USE [TelerikAcademy]
-- This is slow. Use multiple INSERT queries instead
-- INSERT INTO [Groups] VALUES
--     ('Group 1'),
--     ('Group 2'),
--     ('Group 3'),
--     ('Group 4'),
--     ('Group 5'),
--     ('Group 6')
INSERT INTO [Groups] VALUES ('Group 1')
INSERT INTO [Groups] VALUES ('Group 2')
INSERT INTO [Groups] VALUES ('Group 3')
INSERT INTO [Groups] VALUES ('Group 4')
INSERT INTO [Groups] VALUES ('Group 5')
INSERT INTO [Groups] VALUES ('Group 6')

INSERT INTO [Users] VALUES ('username1', 'qwerty1', 'Unnamed1', '2015-10-06 00:00:00', 1)
INSERT INTO [Users] VALUES ('usernam09', 'qwerty1', 'Unnamed1', '2010-03-01 00:00:00', 1)
INSERT INTO [Users] VALUES ('usernam98', 'qwerty1', 'Unnamed1', '2010-03-01 00:00:00', 1)
INSERT INTO [Users] VALUES ('username2', 'qwerty2', 'Unnamed2', '2015-10-07 00:00:00', 2)
INSERT INTO [Users] VALUES ('username3', 'qwerty3', 'Unnamed3', '2015-10-08 00:00:00', 3)
INSERT INTO [Users] VALUES ('username4', 'qwerty4', 'Unnamed4', '2015-10-09 00:00:00', 4)
INSERT INTO [Users] VALUES ('username5', 'qwerty5', 'Unnamed5', '2015-10-10 00:00:00', 5)
INSERT INTO [Users] VALUES ('username6', 'qwerty6', 'Unnamed6', '2015-10-11 00:00:00', 6)
INSERT INTO [Users] VALUES ('username7', 'qwerty7', 'Unnamed7', '2015-10-12 00:00:00', 1)
INSERT INTO [Users] VALUES ('username8', 'qwerty8', 'Unnamed8', '2015-10-13 00:00:00', 2)
INSERT INTO [Users] VALUES ('username9', 'qwerty9', 'Unnamed9', '2015-10-14 00:00:00', 3)

GO

-- 20. Write SQL statements to update some of the records in the Users and Groups tables.
USE [TelerikAcademy]
UPDATE [Users]
	SET [Username] = REPLACE([Username], 'username', 'Username'),
		[Last Login Time] = GETDATE()
	WHERE [GroupID] > 3
GO

-- 21. Write SQL statements to delete some of the records from the Users and Groups tables.
USE [TelerikAcademy]
DELETE
    FROM [Users]
    WHERE [GroupID] IN (3, 4, 5)

DELETE
    FROM [Groups]
    WHERE [Id] IN (3, 4, 5)
GO

-- 22.  Write SQL statements to insert in the Users table the names of all employees from the Employees table.
---- Combine the first and last names as a full name.
---- For username use the first letter of the first name + the last name (in lowercase).
---- Use the same for the password, and NULL for last login time.
USE [TelerikAcademy]
INSERT INTO [Users] ([Username], [Full Name], [Password], [GroupID])
	(SELECT DISTINCT
	        --LOWER(CONCAT(LEFT([FirstName], 1), [LastName])),
			LOWER(CONCAT([FirstName], '.', [LastName])),
	        CONCAT([FirstName], ' ', [LastName]),
			--LOWER(CONCAT(LEFT([FirstName], 1), [LastName])),
			LOWER(CONCAT([FirstName], '.', [LastName])),
			1
        FROM [Employees])
GO

-- 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
USE [TelerikAcademy]
UPDATE [Users]
    SET [Password] = NULL
    WHERE DATEDIFF(day, [Last Login Time], '2010-03-10 00:00:00') > 0
GO

-- 24. Write a SQL statement that deletes all users without passwords (NULL password).
USE [TelerikAcademy]
DELETE FROM [Users] WHERE [Password] IS NULL
GO

-- 25. Write a SQL query to display the average employee salary by department and job title.
USE [TelerikAcademy]
SELECT d.[Name] AS [Department],
	   e.[JobTitle],
	   ROUND(AVG(e.[Salary]), 2) AS [Average Employee Salary]
    FROM [Employees] e
    JOIN [Departments] d
		ON e.[DepartmentID] = d.[DepartmentID]
    GROUP BY d.[Name], e.[JobTitle]
    ORDER BY d.[Name]
GO

-- 26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
USE [TelerikAcademy]
SELECT d.[Name] AS [Department],
       e.[JobTitle], 
	   ROUND(MIN(e.[Salary]), 2) AS [MinSalary],
	   MIN(CONCAT(e.[FirstName], ' ', e.[LastName])) AS [Employee]
    FROM [Employees] e 
    JOIN [Departments] d
		ON e.[DepartmentID] = d.[DepartmentID]
    GROUP BY d.[Name], e.[JobTitle]
    ORDER BY d.[Name]
GO

-- 27. Write a SQL query to display the town where maximal number of employees work.
USE [TelerikAcademy]
SELECT TOP 1 
		t.[Name] AS [Town],
		COUNT(e.[EmployeeID]) as [EmployeesCount]
    FROM [Employees] e 
    JOIN [Addresses] a
        ON e.[AddressID] = a.[AddressID]
    JOIN [Towns] t
        ON t.[TownID] = a.[TownID]
    GROUP BY t.[Name]
    ORDER BY [EmployeesCount] DESC
GO

-- 28. Write a SQL query to display the number of managers from each town.
USE [TelerikAcademy]
SELECT t.[Name],
       COUNT(emp.[EmployeeID]) AS [ManagersCount]
	FROM [Employees] emp
	JOIN (SELECT DISTINCT m.*
		FROM [Employees] m
		JOIN [Employees] e
			ON e.[ManagerID] = m.[EmployeeID]) manager
	ON manager.[EmployeeID] = emp.[EmployeeID]
	JOIN [Addresses] a
        ON manager.[AddressID] = a.[AddressID]
    JOIN [Towns] t
        ON t.[TownID] = a.[TownID]
	GROUP BY t.[Name]
	ORDER BY [ManagersCount] DESC
GO

-- 29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
---- Don't forget to define identity, primary key and appropriate foreign key.
---- Issue few SQL statements to insert, update and delete of some data in the table.
---- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
---- For each change keep the old record data, the new record data and the command (insert / update / delete).
USE [TelerikAcademy]

IF OBJECT_ID ('WorkHours') IS NOT NULL
	DROP TABLE [WorkHours]
GO
CREATE TABLE [WorkHours]
(
    [Id] INT IDENTITY,
    [EmployeeId] INT NOT NULL,
    [On Date] DATETIME NOT NULL,
    [Task] nvarchar(256) NOT NULL,
    [Hours] INT NOT NULL,
    [Comments] NVARCHAR(256),
    CONSTRAINT [PK_Id] PRIMARY KEY(Id),
    CONSTRAINT [FK_Employees_WorkHours]
        FOREIGN KEY ([EmployeeId])
        REFERENCES [Employees]([EmployeeId])
) 
GO

DECLARE @counter int;
SET @counter = 20;
WHILE @counter > 0
BEGIN
    INSERT INTO [WorkHours]([EmployeeId], [On Date], [Task], [Hours])
		VALUES (@counter, GETDATE(), 'TASK: ' + CONVERT(VARCHAR(10), @counter), @counter)
    SET @counter = @counter - 1
END
GO

UPDATE [WorkHours]
    SET [Comments] = 'Some comments.'
    WHERE [Hours] > 10
GO

DELETE FROM [WorkHours]
    WHERE [EmployeeId] IN (1, 3, 5, 7, 13)
GO

IF OBJECT_ID ('WorkHoursLogs') IS NOT NULL
	DROP TABLE [WorkHoursLogs]
GO
CREATE TABLE [WorkHoursLogs]
(
    [Id] INT,
    [EmployeeId] INT NOT NULL,
    [On Date] DATETIME NOT NULL,
    [Task] NVARCHAR(256) NOT NULL,
    [Hours] INT NOT NULL,
    [Comments] NVARCHAR(256),
    [Action] NVARCHAR(50) NOT NULL,
    CONSTRAINT [FK_Employees_WorkHoursLogs]
        FOREIGN KEY ([EmployeeId])
        REFERENCES [Employees]([EmployeeId]),
    CONSTRAINT [CC_WorkReportsLogs] CHECK ([Action] IN ('Insert', 'Delete', 'DeleteUpdate', 'InsertUpdate'))
) 
GO

IF OBJECT_ID ('TR_InsertWorkReports') IS NOT NULL
	DROP TRIGGER [TR_InsertWorkReports]
GO
CREATE TRIGGER [TR_InsertWorkReports]
ON [WorkHours]
FOR INSERT
AS
	INSERT INTO [WorkHoursLogs]([Id], [EmployeeId], [On Date], [Task], [Hours], [Comments], [Action])
		SELECT [Id], [EmployeeID], [On Date], [Task], [Hours], [Comments], 'Insert'
		FROM INSERTED
GO

IF OBJECT_ID ('TR_DeleteWorkReports') IS NOT NULL
	DROP TRIGGER [TR_DeleteWorkReports]
GO
CREATE TRIGGER [TR_DeleteWorkReports]
ON [WorkHours]
FOR DELETE
AS
	INSERT INTO [WorkHoursLogs]([Id], [EmployeeId], [On Date], [Task], [Hours], [Comments], [Action])
		SELECT [Id], [EmployeeID], [On Date], [Task], [Hours], [Comments], 'Delete'
		FROM DELETED
GO

IF OBJECT_ID ('TR_UpdateWorkReports') IS NOT NULL
	DROP TRIGGER [TR_UpdateWorkReports]
GO
CREATE TRIGGER [TR_UpdateWorkReports]
ON [WorkHours]
FOR UPDATE
AS
	INSERT INTO [WorkHoursLogs]([Id], [EmployeeId], [On Date], [Task], [Hours], [Comments], [Action])
		SELECT [Id], [EmployeeID], [On Date], [Task], [Hours], [Comments], 'InsertUpdate'
		FROM INSERTED

	INSERT INTO [WorkHoursLogs]([Id], [EmployeeId], [On Date], [Task], [Hours], [Comments], [Action])
		SELECT [Id], [EmployeeID], [On Date], [Task], [Hours], [Comments], 'DeleteUpdate'
		FROM DELETED
GO

DELETE FROM [WorkHoursLogs]

INSERT INTO [WorkHours]([EmployeeId], [On Date], [Task], [Hours]) VALUES (25, GETDATE(), 'TASK: 25', 25)

DELETE FROM [WorkHours] WHERE [EmployeeId] = 25

UPDATE [WorkHours]
    SET [Comments] = 'Updated'
    WHERE [EmployeeId] = 2

GO

-- 30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
---- At the end rollback the transaction.
USE [TelerikAcademy]
BEGIN TRANSACTION

    ALTER TABLE [Departments]
        DROP CONSTRAINT [FK_Departments_Employees]
    GO

    DELETE e
        FROM [Employees] e
        JOIN [Departments] d
            ON e.[DepartmentID] = d.[DepartmentID]
        WHERE d.[Name] = 'Sales'

ROLLBACK TRANSACTION
GO

-- 31. Start a database transaction and drop the table EmployeesProjects.
---- now how you could restore back the lost table data?
USE [TelerikAcademy]
BEGIN TRANSACTION

    DROP TABLE [EmployeesProjects]

ROLLBACK TRANSACTION
GO

-- 32. Find how to use temporary tables in SQL Server.
---- Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
USE [TelerikAcademy]
BEGIN TRANSACTION

    SELECT * 
        INTO #TempEmployeesProjects
        FROM [EmployeesProjects]

    DROP TABLE [EmployeesProjects]

    SELECT * 
        INTO [EmployeesProjects]
        FROM #TempEmployeesProjects

    DROP TABLE #TempEmployeesProjects

ROLLBACK TRANSACTION
GO