USE TP1_Franck;
GO
-- S'il n'y a aucune données dans les tablse DEPT et EMP alors je les remplis avec mes INSERT INTO
IF NOT EXISTS (SELECT * FROM DEPT, EMP)
BEGIN
	-- On commence par les INSERT dans la table département car elle n'a pas de clé étrangère
	INSERT INTO DEPT (DEPTNO, DNAME, LOC)
	VALUES (10, 'ACCOUNTING', 'NEW YORK'), (20, 'RESEARCH', 'DALLAS'), (30, 'SALES', 'CHICAGO'), (40, 'OPERATIONS', 'BOSTON');

	-- Pour les INSERT des employés, on prend soin de faire en sorte que les clés étrangères de manager existent déjà. C'est pour cela qu'on commence par insérer KING qui est manager de BLAKE et CLARK, qui sont manager de ...
	INSERT INTO EMP (EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO)
	VALUES
	(7839,	'KING',		'PRESIDENT',	NULL,	'1981-11-17',	5000,	NULL,	10),
	(7698,	'BLAKE',	'MANAGER',		7839,	'1981-05-01',	2850,	NULL,	30),
	(7782,	'CLARK',	'MANAGER',		7839,	'1981-06-09',	2450,	NULL,	10),
	(7566,	'JONES',	'MANAGER',		7839,	'1981-04-02',	2975,	NULL,	20),
	(7844,	'TURNER',	'SALESMAN',		7698,	'1981-09-08',	1500,	0,		30),
	(7900,	'JAMES',	'CLERK',		7698,	'1981-12-03',	950,	NULL,	30),
	(7521,	'WARD',		'SALESMAN',		7698,	'1981-02-22',	1250,	500,	30),
	(7654,	'MARTIN',	'SALESMAN',		7698,	'1981-09-28',	1250,	1400,	30),
	(7934,	'MILLER',	'CLERK',		7782,	'1982-01-23',	1300,	NULL,	10),
	(7788,	'SCOTT',	'ANALYST',		7566,	'1982-12-09',	3000,	NULL,	20),
	(7902,	'FORD',		'ANALYST',		7566,	'1981-12-03',	3000,	NULL,	20),
	(7876,	'ADAMS',	'CLERK',		7788,	'1983-01-12',	1100,	NULL,	20),
	(7369,	'SMITH',	'CLERK',		7902,	'1980-12-17',	800,	NULL,	20),
	(7499,	'ALLEN',	'SALESMAN',		7698,	'1981-02-20',	1600,	300,	30);
END

IF NOT EXISTS (SELECT * FROM PROJET)
BEGIN
INSERT INTO PROJET 

			(PROJNAME,		BUDGET) 
VALUES
			('ALPHA',		96000),
			('BETA',		82000),
			('GAMMA',		15000);
END


UPDATE EMP 
SET PROJNO = 101 
WHERE DEPTNO  = 30 AND JOB = 'SALESMAN';

UPDATE EMP 
SET PROJNO = 102 
WHERE DEPTNO  <> 30 AND JOB <> 'SALESMAN';

/* Mettre PROJNO à 102 pour chaque ligne où PROJNO est NULL
UPDATE EMP 
SET PROJNO = 102 
WHERE PROJNO IS NULL;
*/


/*
UPDATE EMP
SET PROJNO
= CASE DEPTNO
WHEN 30 THEN 101
ELSE 102
END
*/


IF EXISTS (SELECT 1 FROM sys.sysobjects WHERE name = 'IsSalGreaterThanCEOs' and xtype = 'P')
BEGIN
	DROP PROCEDURE IsSalGreaterThanCEOs;
END
GO
CREATE PROCEDURE IsSalGreaterThanCEOs
	@ComparedSal MONEY
AS
BEGIN
	DECLARE @result BIT;
	IF (@ComparedSal >= ALL (SELECT MIN(SAL) FROM EMP WHERE MGR IS NULL AND JOB = 'PRESIDENT'))
	BEGIN
		SET @Result = 1;
	END
	ELSE
	BEGIN
		SET @Result = 0;
	END
	RETURN @Result;
END
GO



IF EXISTS (SELECT 1 FROM sys.triggers WHERE Name = 'NewEmployeeHasSalLowerThanCeo')
BEGIN
	DROP TRIGGER NewEmployeeHasSalLowerThanCeo;
END
GO
CREATE TRIGGER NewEmployeeHasSalLowerThanCeo
ON EMP
AFTER INSERT
AS
BEGIN
	DECLARE @NewEmployeeSal MONEY;
	DECLARE @NewEmployeeMGR SMALLINT;
	DECLARE @IsNewEmployeeSalHigh BIT;
	SELECT @NewEmployeeSal = Inserted.SAL, 
		@NewEmployeeMGR = Inserted.MGR 
	FROM Inserted;
	EXEC @IsNewEmployeeSalHigh = IsSalGreaterThanCEOs @NewEmployeeSal;
	IF (@NewEmployeeMGR IS NOT NULL AND @IsNewEmployeeSalHigh = 1)
	BEGIN
		ROLLBACK TRANSACTION
		PRINT('Le nouvel employé ne peut pas avoir un salaire supérier à celui du plus haut manageur à moins d''être de même rang.');
	END
	ELSE
	BEGIN
		PRINT('Nouvel employé enregistré');
	END
END
GO

INSERT INTO EMP (EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO)
VALUES
(9998,	'Nouveau Employe',		'SALESMAN',	7839,	'1981-11-17',	2,	400,	10);

GO
DROP TRIGGER NewEmployeeCanNotHaveExistingName
GO
CREATE TRIGGER NewEmployeeCanNotHaveExistingName
ON EMP
FOR INSERT
AS
BEGIN
	DECLARE @NewEmployeeName VARCHAR(20);
	SELECT @NewEmployeeName = inserted.ENAME FROM inserted;
	PRINT(@NewEmployeeName);
	IF EXISTS (SELECT EMPNO FROM EMP WHERE ENAME = @NewEmployeeName)
	BEGIN
		PRINT('This employee name already exists !');
		ROLLBACK TRANSACTION;
	END

	ELSE
	BEGIN
		PRINT('New employee added.');
	END
END
GO

INSERT INTO EMP (EMPNO, ENAME, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO)
VALUES
(6670,	'TardTard',		'PRESIDENT',	NULL,	'0981-11-17',	5500,	NULL,	10)

SELECT * FROM EMP WHERE EMPNO < 7000;

DISABLE TRIGGER NewEmployeeHasSalLowerThanCeo ON EMP;