-- Créer la base uniquement si inexistante
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TP1_Franck')
BEGIN
	CREATE DATABASE TP1_Franck;
END

GO

USE TP1_Franck;
GO

-- Créer la table DEPT si inexistante
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'DEPT' AND xtype = 'U')
BEGIN
	CREATE TABLE DEPT
	(DEPTNO TINYINT NOT NULL,
	DNAME NVARCHAR(50) NOT NULL,
	LOC NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_DEPT PRIMARY KEY (DEPTNO)
	)
END


-- Créer la table EMP si inexistante
IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'EMP' AND xtype = 'U') -- xtype = 'U' => le type des objets cherchés est le type Table
BEGIN
	CREATE TABLE EMP
	(EMPNO SMALLINT NOT NULL,
	ENAME NVARCHAR(50) NOT NULL,
	JOB NVARCHAR(50) NOT NULL,
	HIREDATE DATE NOT NULL,
	SAL MONEY NOT NULL,
	COMM MONEY,
	MGR SMALLINT,
	DEPTNO TINYINT NOT NULL,
	CONSTRAINT PK_EMP PRIMARY KEY (EMPNO),
	CONSTRAINT FK_EMP_DEPT FOREIGN KEY (DEPTNO) REFERENCES DEPT (DEPTNO),
	CONSTRAINT FK_EMP_MGR FOREIGN KEY (MGR) REFERENCES EMP (EMPNO)
	);
END


-- Ajout d'une contrainte check sur les job des employés. Cela force les entrées de job à avoir les valeurs spécifiées
IF NOT EXISTS (SELECT * from sys.sysobjects WHERE name = 'CK_EMP_JOB' AND xtype = 'C')  -- xtype = 'C' => le type des objets cherchés est le type contrainte de type check
BEGIN
	ALTER TABLE EMP
	ADD CONSTRAINT CK_EMP_JOB CHECK (JOB IN ('SALESMAN', 'PRESIDENT', 'MANAGER', 'ANALYST', 'CLERK'));
END

IF NOT EXISTS ( SELECT * FROM sys.sysobjects where name = 'PROJET' AND xtype = 'U')
BEGIN 
	CREATE TABLE PROJET(
	PROJNO INT IDENTITY(101,1),
	PROJNAME VARCHAR(5) NOT NULL,
	BUDGET INT NOT NULL);
END

IF NOT EXISTS (SELECT * from sys.sysobjects WHERE name = 'PK_PROJET' AND xtype = 'PK')  -- xtype = 'PK' => le type des objets cherchés est le type contrainte de type clé primaire
BEGIN
	ALTER TABLE PROJET
	ADD CONSTRAINT PK_PROJET PRIMARY KEY (PROJNO);
END