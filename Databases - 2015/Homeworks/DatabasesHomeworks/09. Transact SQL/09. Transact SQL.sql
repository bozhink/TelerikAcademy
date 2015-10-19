USE [master]
GO
-- 01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
IF OBJECT_ID ('BankAccounts') IS NOT NULL
	DROP DATABASE [BankAccounts]
GO
CREATE DATABASE [BankAccounts]
GO

USE [BankAccounts]
GO

IF OBJECT_ID ('FK_Accounts_PersonId_Person_Id') IS NOT NULL
	ALTER TABLE [dbo].[Accounts]
		DROP CONSTRAINT [FK_Accounts_PersonId_Person_Id]
GO
IF OBJECT_ID ('dbo.Persons') IS NOT NULL
	DROP TABLE [dbo].[Persons]
GO
CREATE TABLE [dbo].[Persons]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[SSN] NVARCHAR(50) NOT NULL
)
GO

IF OBJECT_ID ('FK_Logs_AccountId_Account_Id') IS NOT NULL
	ALTER TABLE [dbo].[Logs]
		DROP CONSTRAINT [FK_Logs_AccountId_Account_Id]
GO
IF OBJECT_ID ('dbo.Accounts') IS NOT NULL
	DROP TABLE [dbo].[Accounts]
GO
CREATE TABLE [dbo].[Accounts]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PersonId] INT NOT NULL,
	[Balance] MONEY NOT NULL
)
GO

ALTER TABLE [dbo].[Accounts]
	ADD CONSTRAINT [FK_Accounts_PersonId_Person_Id]
	FOREIGN KEY ([PersonId])
	REFERENCES [dbo].[Persons] ([Id])
GO

---- Insert few records for testing.
DECLARE @counter TINYINT
SET @counter = 20
WHILE @counter > 0
	BEGIN
		DECLARE @counterString AS VARCHAR(10)
		SET @counterString = CAST(@counter AS VARCHAR(10))
		INSERT INTO [dbo].[Persons] ([FirstName], [LastName], [SSN])
		VALUES (CONCAT('John', @counterString), CONCAT('Smith', @counterString), @counter + 1000000)
		SET @counter = @counter - 1
	END
GO

DECLARE @counter TINYINT
SET @counter = 20
WHILE @counter > 0
	BEGIN
		DECLARE @randomNumber INT
		SELECT @randomNumber = ABS(CAST(NEWID() AS BINARY(6)) % 10000) + 1
		
		INSERT INTO [dbo].[Accounts] ([PersonId], [Balance])
		VALUES (@counter, @randomNumber)
		SET @counter = @counter - 1
	END
GO

---- Write a stored procedure that selects the full names of all persons.
IF OBJECT_ID ('dbo.usp_SelectFullNames') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectFullNames]
GO
CREATE PROCEDURE [dbo].[usp_SelectFullNames]
AS 
	SELECT CONCAT([FirstName], ' ', [LastName]) AS [FullName]
	FROM [dbo].[Persons]
GO

EXEC [dbo].[usp_SelectFullNames]
GO


-- 02. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
IF OBJECT_ID ('dbo.usp_SelectPersonsWithGreatherBalanceThan') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectPersonsWithGreatherBalanceThan]
GO
CREATE PROCEDURE [dbo].[usp_SelectPersonsWithGreatherBalanceThan]
(
	@minBalance MONEY = 1000
)
AS 
	SELECT *
	FROM [dbo].[Persons] p
	JOIN [dbo].[Accounts] a
		ON p.[Id] = a.[PersonId]
	WHERE a.[Balance] > @minBalance
	ORDER BY a.[Balance]
GO

EXEC [dbo].[usp_SelectPersonsWithGreatherBalanceThan] 2000;
GO


-- 03. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
---- It should calculate and return the new sum.
---- Write a SELECT to test whether the function works as expected.
IF OBJECT_ID ('dbo.ufn_CalculateCompoundInterest') IS NOT NULL
	DROP FUNCTION [dbo].[ufn_CalculateCompoundInterest]
GO
CREATE FUNCTION [dbo].[ufn_CalculateCompoundInterest]
(
	@sum MONEY,
	@yearlyInterestRate FLOAT,
	@numberOfMonths TINYINT
)
RETURNS MONEY
AS
	BEGIN
		RETURN @sum * (1 + @yearlyInterestRate / 12) * @numberOfMonths
	END
GO

SELECT [Balance],
       ROUND([dbo].[ufn_CalculateCompoundInterest] ([Balance], 0.12, 10), 2) AS [Bonus]
	FROM [dbo].[Accounts]
GO


-- 04. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
---- It should take the AccountId and the interest rate as parameters.
IF OBJECT_ID ('dbo.usp_CalculateCompoundInterestForOneMonth') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_CalculateCompoundInterestForOneMonth]
GO
CREATE PROCEDURE [dbo].[usp_CalculateCompoundInterestForOneMonth]
(
	@accountId INT,
	@yearlyInterestRate FLOAT
)
AS
	DECLARE @balance MONEY
	SELECT @balance = [Balance]
		FROM [dbo].[Accounts]
		WHERE [Id] = @accountId
	
	DECLARE @newBalance MONEY
	SELECT @newBalance = [dbo].[ufn_CalculateCompoundInterest] (@balance, @yearlyInterestRate, 1)
	
	SELECT p.[FirstName], p.[LastName], a.[Balance], @newBalance AS [New Balance]
	FROM [dbo].[Persons] p
	JOIN [dbo].[Accounts] a
		ON p.[Id] = a.[PersonId]
	WHERE a.[Id] = @accountId
GO

EXEC [dbo].[usp_CalculateCompoundInterestForOneMonth] 1, 0.1
GO


-- 05. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
IF OBJECT_ID ('dbo.usp_WithdrawMoney') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_WithdrawMoney]
GO
CREATE PROCEDURE [dbo].[usp_WithdrawMoney]
(
	@accountId INT,
	@money MONEY
)
AS
    BEGIN TRANSACTION
        UPDATE [dbo].[Accounts]
			SET [Balance] -= @money
			WHERE [Id] = @accountId
    COMMIT TRANSACTION
GO

IF OBJECT_ID ('dbo.usp_DepositMoney') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DepositMoney]
GO
CREATE PROCEDURE [dbo].[usp_DepositMoney]
(
	@accountId INT,
	@money MONEY
)
AS
    BEGIN TRANSACTION
        UPDATE [dbo].[Accounts]
			SET [Balance] += @money
			WHERE [Id] = @accountId
    COMMIT TRANSACTION
GO

EXEC [dbo].[usp_WithdrawMoney] 1, 1000
GO

EXEC [dbo].[usp_DepositMoney] 2, 2000
GO


-- 06. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
---- Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
IF OBJECT_ID ('dbo.Logs') IS NOT NULL
	DROP TABLE [dbo].[Logs]
GO
CREATE TABLE [dbo].[Logs]
(
	[LogId] INT IDENTITY(1,1) PRIMARY KEY,
	[AccountId] INT NOT NULL,
	[OldSum] MONEY NOT NULL,
	[NewSum] MONEY NOT NULL
)
GO

ALTER TABLE [dbo].[Logs]
	ADD CONSTRAINT [FK_Logs_AccountId_Account_Id]
	FOREIGN KEY ([AccountId])
	REFERENCES [dbo].[Accounts] ([Id])
GO

IF OBJECT_ID ('dbo.tr_UpdateAccountBalance') IS NOT NULL
	DROP TRIGGER [dbo].[tr_UpdateAccountBalance]
GO
CREATE TRIGGER [dbo].[tr_UpdateAccountBalance]
ON [dbo].[Accounts]
FOR UPDATE
AS
	DECLARE @oldSum MONEY
	SELECT @oldSum = [Balance]
		FROM DELETED

	INSERT INTO [dbo].[Logs] ([AccountId], [OldSum], [NewSum])
		SELECT [Id], @oldSum, [Balance]
			FROM INSERTED
GO

EXEC [dbo].[usp_WithdrawMoney] 1, 1000
GO

EXEC [dbo].[usp_DepositMoney] 2, 2000
GO


-- 07. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
---- Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
USE [TelerikAcademy]
GO

IF OBJECT_ID ('dbo.ufn_SearchForWordsInGivenPattern') IS NOT NULL
	DROP FUNCTION [dbo].[ufn_SearchForWordsInGivenPattern]
GO
CREATE FUNCTION [dbo].[ufn_SearchForWordsInGivenPattern]
(
	@pattern NVARCHAR(255)
)
RETURNS @MatchedNames TABLE ([Name] NVARCHAR(50))
AS
BEGIN
	INSERT @MatchedNames
	SELECT *
		FROM
			(SELECT e.[FirstName]
				FROM [dbo].[Employees] e
				UNION
					SELECT em.[LastName]
						FROM [dbo].[Employees] em
						UNION
							SELECT t.[Name]
							FROM [dbo].[Towns] t)
			AS TEMP(name)
		WHERE PATINDEX('%[' + @pattern + ']', [Name]) > 0
	RETURN
END
GO

SELECT * FROM [dbo].[ufn_SearchForWordsInGivenPattern] ('oistmiahf')
GO


-- 08. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
DECLARE [EmployeeCursor] CURSOR
READ_ONLY
FOR
	SELECT t1.[Name],
	       CONCAT(e1.[FirstName] , ' ', e1.[LastName]) AS [FullName1],
		   CONCAT(e2.[FirstName] , ' ', e2.[LastName]) AS [FullName2]
	FROM
		[dbo].[Employees] e1
			JOIN [dbo].[Addresses] a1
				ON e1.[AddressID] = a1.[AddressID]
			JOIN [dbo].[Towns] t1
				ON a1.[TownID] = t1.[TownID],
		[dbo].[Employees] e2
			JOIN [dbo].[Addresses] a2
				ON e2.[AddressID] = a2.[AddressID]
			JOIN [dbo].[Towns] t2
				ON a2.[TownID] = t2.[TownID]
	WHERE t1.[TownID] = t2.[TownID] AND e1.[EmployeeID] != e2.[EmployeeID]
    ORDER BY e1.[FirstName], e2.[FirstName]

OPEN [EmployeeCursor]

DECLARE @fullName1 NVARCHAR(100)
DECLARE @fullName2 NVARCHAR(100)
DECLARE @townName NVARCHAR(100)

FETCH NEXT FROM [EmployeeCursor]
	INTO @townName, @fullName1, @fullName2

DECLARE @counter INT
SET @counter = 0

WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @counter = @counter + 1;

		PRINT @townName + '    ' + @fullName1 + '    ' +  @fullName2
		FETCH NEXT FROM [EmployeeCursor]
			INTO @townName, @fullName1, @fullName2
	END

PRINT 'Total records: ' + CAST(@counter AS VARCHAR(10));

CLOSE [EmployeeCursor]
DEALLOCATE [EmployeeCursor]


-- 09. Write a T-SQL script that shows for each town a list of all employees that live in it.
---- Sample output:
----     Sofia -> Martin Kulov, George Denchev
----     Ottawa -> Jose Saraiva
----     …
IF NOT EXISTS (SELECT [value] FROM [sys].[configurations] WHERE [name] = 'clr enabled' AND [value] = 1)
BEGIN
	EXEC sp_configure @configname = clr_enabled, @configvalue = 1
	RECONFIGURE
END
GO

IF OBJECT_ID ('dbo.concat') IS NOT NULL
	DROP AGGREGATE [dbo].[concat]
GO
IF EXISTS (SELECT * FROM [sys].[assemblies] WHERE [name] = 'concat_assembly')
	DROP ASSEMBLY concat_assembly
GO
CREATE ASSEMBLY concat_assembly 
	AUTHORIZATION [dbo]
	FROM 'C:\temp\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
	WITH PERMISSION_SET = SAFE
GO

CREATE AGGREGATE [dbo].[concat]
( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
)
RETURNS NVARCHAR(MAX) 
	EXTERNAL Name concat_assembly.concat
GO

DECLARE [EmployeeCursor] CURSOR
READ_ONLY
FOR
	SELECT t.[Name], [dbo].[concat] (e.[FirstName] + ' ' + e.[LastName], ', ')
		FROM [dbo].[Towns] t
		JOIN [dbo].[Addresses] a
			ON t.[TownID] = a.[TownID]
		JOIN [dbo].[Employees] e
			ON a.[AddressID] = e.[AddressID]
		GROUP BY t.[Name]
		ORDER BY t.[Name]

OPEN [EmployeeCursor]

DECLARE @townName NVARCHAR(50)
DECLARE @employeesNames NVARCHAR(max)

FETCH NEXT FROM [EmployeeCursor]
	INTO @townName, @employeesNames

WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT @townName + ' -> ' + @employeesNames

	FETCH NEXT FROM [EmployeeCursor]
		INTO @townName, @employeesNames
END

CLOSE [EmployeeCursor]
DEALLOCATE [EmployeeCursor]
GO

DROP AGGREGATE [dbo].[concat]
DROP ASSEMBLY concat_assembly
GO


-- 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','.
---- For example the following SQL statement should return a single string:
----     SELECT StrConcat(FirstName + ' ' + LastName)
----     FROM Employees
IF NOT EXISTS (SELECT [value] FROM [sys].[configurations] WHERE [name] = 'clr enabled' AND [value] = 1)
BEGIN
	EXEC sp_configure @configname = clr_enabled, @configvalue = 1
	RECONFIGURE
END
GO

IF OBJECT_ID('dbo.StrConcat') IS NOT NULL
    DROP AGGREGATE [dbo].[StrConcat]
GO
IF EXISTS (SELECT * FROM [sys].[assemblies] WHERE [name] = 'concat_assembly')
	DROP ASSEMBLY concat_assembly
GO      
CREATE ASSEMBLY concat_assembly
	AUTHORIZATION [dbo]
	FROM 'C:\temp\SqlStringConcatenation.dll' --- CHANGE THE LOCATION
	WITH PERMISSION_SET = SAFE
GO

CREATE AGGREGATE [dbo].[StrConcat]
(
	@value NVARCHAR(MAX),
    @delimiter NVARCHAR(10)
) 
RETURNS NVARCHAR(MAX)
	EXTERNAL Name concat_assembly.concat
GO

SELECT [dbo].[StrConcat] ([FirstName] + ' ' + [LastName], ', ')
	FROM [Employees]
GO

DROP AGGREGATE [dbo].[StrConcat]
DROP ASSEMBLY [concat_assembly]
GO
