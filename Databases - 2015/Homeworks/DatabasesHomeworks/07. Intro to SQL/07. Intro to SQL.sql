-- 01. What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
-- SQL (Structured Query Language) is a special-purpose programming language designed for managing data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management system (RDSMS).
-- Data Manipulation Language (DML): SELECT, INSERT, UPDATE, DELETE

-- 02. What is Transact-SQL (T-SQL)?
-- T-SQL (Transact SQL) is an extension to the standard SQL language. It is the standard language used in MS SQL Server. It supports if statements, loops, exceptions.

-- 03.  Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
--------

-- 04. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
USE [TelerikAcademy]
SELECT * FROM [dbo].[Departments]
GO

-- 05. Write a SQL query to find all department names.
USE [TelerikAcademy]
SELECT Name FROM [dbo].[Departments]
GO

-- 06. Write a SQL query to find the salary of each employee.
USE [TelerikAcademy]
SELECT [Salary] FROM [dbo].[Employees]
GO

-- 07. Write a SQL to find the full name of each employee.
USE [TelerikAcademy]
SELECT [FirstName] + ' ' + [LastName] AS [Full Name]
    FROM [dbo].[Employees]
GO

-- 08. Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
USE [TelerikAcademy]
SELECT [FirstName] + '.' + [LastName] + '@telerik.com' AS [Full Email Addresses]
    FROM [dbo].[Employees]
GO

-- 09. Write a SQL query to find all different employee salaries.
USE [TelerikAcademy]
SELECT DISTINCT [Salary]
    FROM [dbo].[Employees]
GO

-- 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
USE [TelerikAcademy]
SELECT *
    FROM [dbo].[Employees]
	WHERE [JobTitle] = 'Sales Representative'
GO

-- 11.  Write a SQL query to find the names of all employees whose first name starts with "SA".
USE [TelerikAcademy]
SELECT [FirstName], [LastName], [MiddleName]
    FROM [dbo].[Employees]
	WHERE [FirstName] LIKE 'SA%'
GO

-- 12. Write a SQL query to find the names of all employees whose last name contains "ei".
USE [TelerikAcademy]
SELECT [FirstName], [LastName], [MiddleName]
    FROM [dbo].[Employees]
	WHERE [LastName] LIKE '%ei%'
GO

-- 13.  Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
USE [TelerikAcademy]
SELECT [Salary]
    FROM [dbo].[Employees]
	WHERE [Salary] BETWEEN 20000 AND 30000
GO

-- 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
USE [TelerikAcademy]
SELECT [FirstName], [LastName], [MiddleName]--, [Salary]
    FROM [dbo].[Employees]
	WHERE [Salary] IN (25000, 14000, 12500, 23600)
GO

-- 15. Write a SQL query to find all employees that do not have manager.
USE [TelerikAcademy]
SELECT *
    FROM [dbo].[Employees]
	WHERE [ManagerID] IS NULL
GO

-- 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
USE [TelerikAcademy]
SELECT *
    FROM [dbo].[Employees]
	WHERE [Salary] > 50000
	ORDER BY [Salary] DESC
GO

-- 17. Write a SQL query to find the top 5 best paid employees.
USE [TelerikAcademy]
SELECT TOP 5 *
    FROM [dbo].[Employees]
	ORDER BY [Salary] DESC
GO

-- 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
USE [TelerikAcademy]
SELECT e.*, a.[AddressID], a.[AddressText]
    FROM [dbo].[Employees] e
	INNER JOIN [dbo].[Addresses] a
	ON e.AddressID = a.AddressID
GO

-- 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
USE [TelerikAcademy]
SELECT e.*, a.[AddressID], a.[AddressText]
    FROM [dbo].[Employees] e, [dbo].[Addresses] a
	WHERE e.[AddressID] = a.[AddressID]
GO

-- 20. Write a SQL query to find all employees along with their manager.
USE [TelerikAcademy]
SELECT e.[FirstName] + ' ' + e.[LastName] AS [Employee Full Name],
       m.[FirstName] + ' ' + m.[LastName] AS [Manager Full Name]
    FROM [dbo].[Employees] e
	JOIN [dbo].[Employees] m
	ON e.[ManagerID] = m.[EmployeeID]
GO

-- 21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
USE [TelerikAcademy]
SELECT e.[FirstName] + ' ' + e.[LastName] AS [Employee Full Name],
	   a.[AddressText] AS [Employee Address],
       m.[FirstName] + ' ' + m.[LastName] AS [Manager Full Name]
    FROM [dbo].[Employees] e
	JOIN [dbo].[Employees] m
	    ON e.[ManagerID] = m.[EmployeeID]
	JOIN [dbo].[Addresses] a
	    ON e.[AddressID] = a.[AddressID]
GO

-- 22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
USE [TelerikAcademy]
SELECT [Name] AS [Departments and Towns]
    FROM [dbo].[Departments]
	UNION
	    SELECT [Name] AS [Departments and Towns]
		FROM [dbo].[Towns]
GO

-- 23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
USE [TelerikAcademy]
SELECT e.[FirstName] + ' ' + e.[LastName] AS [Employee Full Name],
       m.[FirstName] + ' ' + m.[LastName] AS [Manager Full Name]
    FROM [dbo].[Employees] e
	RIGHT OUTER JOIN [dbo].[Employees] m
	ON e.[ManagerID] = m.[EmployeeID]
GO

USE [TelerikAcademy]
SELECT e.[FirstName] + ' ' + e.[LastName] AS [Employee Full Name],
       m.[FirstName] + ' ' + m.[LastName] AS [Manager Full Name]
    FROM [dbo].[Employees] e
	LEFT OUTER JOIN [dbo].[Employees] m
	ON e.[ManagerID] = m.[EmployeeID]
GO

-- 24.  Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
USE [TelerikAcademy]
SELECT e.[FirstName], e.[LastName], e.[MiddleName]--, e.[HireDate], d.[Name]
    FROM [dbo].[Employees] e
	JOIN [dbo].[Departments] d
	ON e.[DepartmentID] = d.[DepartmentID]
	WHERE (d.[Name] = 'Sales' OR d.[Name] = 'Finance') AND
	  (e.[HireDate] BETWEEN '1995-01-01 00:00:00' AND '2005-01-01 00:00:00')
GO
