USE TP1_Franck;

-- 1.	Donner nom, job, numéro et salaire de tous les employés, puis seulement des employés du département 10

-- selectionne les attribut suivant à afficher : EMPNO, ENAME, JOB, SAL depuis la table EMP
SELECT EMPNO, ENAME, JOB, SAL 
FROM EMP;

-- selectionne les mêmes attributs uniquement pour les employé du département 10 (DEPTNO = 10)
SELECT EMPNO, ENAME, JOB, SAL 
FROM EMP WHERE DEPTNO = 10;


-- 2.	Donner nom, job et salaire des employés de type MANAGER dont le salaire est supérieur à 2800
SELECT ENAME, JOB, SAL 
FROM EMP 
WHERE JOB = 'MANAGER' AND SAL > 2800;

-- "WHERE JOB = 'MANAGER'" : condition pour selectionner les managers
-- "AND" : pour ajouter une deuxième condition
-- "SAL > 2800" : pour la condition du salaire minimal 


-- 3.	Donner la liste des MANAGER n'appartenant pas au département 30
SELECT ENAME, JOB, DEPTNO 
FROM EMP 
WHERE JOB = 'MANAGER' AND DEPTNO <> 30.

-- 4.	Liste des employés de salaire compris entre 1200 et 1400
SELECT * 
FROM  EMP 
WHERE SAL > 1200 AND SAL < 1400;

-- 5.	Liste des employés des départements 10 et 30 classés dans l'ordre alphabétique
SELECT * 
FROM EMP 
WHERE DEPTNO  = 10 OR DEPTNO  =  30 
ORDER BY ENAME;
--ORDER BY : permet de définir une colonne dont on veut l'ordre alphabétique.

-- Alternative
SELECT * 
FROM EMP 
WHERE DEPTNO  IN (10,30)  -- IN : permet de lister toutes les valeurs attendues
ORDER BY ENAME;




-- 6.	Liste des employés du département 30 classés dans l'ordre des salaires croissants

SELECT *
FROM EMP
WHERE DEPTNO IN (30) 
ORDER BY SAL ASC;
-- Ordre des salaires dans l'ordre croissant ASC = ordre croissant DESC = ordre décroissant

-- 7.	Liste de tous les employés classés par emploi et salaires décroissants

SELECT *
FROM EMP
ORDER BY JOB DESC,SAL DESC;

-- 8.	Liste des différents emplois
SELECT DISTINCT JOB
FROM EMP

-- DISTINCT sert à lister une seule occurrence dans une colonne. 

-- Autre soloution acceptée :
SELECT JOB
FROM EMP
GROUP BY JOB;


-- 9.	Donner le nom du département où travaille ALLEN

SELECT DEPT.DNAME 
FROM DEPT
INNER JOIN EMP ON EMP.DEPTNO = DEPT.DEPTNO
WHERE EMP.ENAME = 'ALLEN';
-- Je fais une jointure avec mon 'INNER JOIN' pour accéder au nom du département.

SELECT DEPT.DNAME 
FROM DEPT
WHERE DEPTNO = (SELECT EMP.DEPTNO 
					FROM EMP
					WHERE ENAME = 'ALLEN')

-- Deuxième version avec une sous-requête à la place d'une jointure.



-- 10.	Liste des employés avec nom du département, nom, job, salaire classés par noms de départements et par salaires décroissants.
SELECT ENAME, DNAME, JOB, SAL 
FROM EMP 
INNER JOIN DEPT ON EMP.DEPTNO = DEPT.DEPTNO 
ORDER BY DNAME DESC, SAL DESC


-- 11.	Liste des employés vendeurs (SALESMAN) avec affichage de nom, salaire, commissions, salaire + commissions

Select ENAME, SAL, COMM, (SAL + COMM) AS CALCUL 
From EMP
WHERE JOB = 'SALESMAN';

-- On peut faire n'importe quels calculs sur n'importe quelle colonne qui utilise des valeurs de type numérique.


-- 12.	Liste des employés du département 20: nom, job, date d'embauche sous forme VEN 28 FEV 1997'

Select ENAME, JOB, FORMAT(HIREDATE, 'ddd dd MMM yyyy') 
FROM EMP
WHERE DEPTNO = 20;


-- 13.	Donner le salaire le plus élevé par département
SELECT MAX (SAL) AS SALMAX, DEPTNO 
FROM EMP 
GROUP BY DEPTNO;  
-- max pour déterminer le salaire max as=alias group by pour grouper 

-- 14.	Donner département par département masse salariale, nombre d'employés, salaire moyen par type d'emploi.
     select deptno, SUM(sal) AS SumSal, AVG(sal) AS AverageSal, count (ename) AS EmployeeCount,job
	 from emp
	 group by deptno,job
	 order by deptno;



-- 15.	Même question mais on se limite aux sous-ensembles d'au moins 2 employés
	SELECT DNAME, JOB, SUM(SAL), COUNT(*) AS NBRPERSON, AVG(SAL) AS AVERAGESAL 
	FROM EMP
	INNER JOIN DEPT ON DEPT.DEPTNO = EMP.DEPTNO
	GROUP BY DNAME, JOB 
	HAVING COUNT(*) > 1;

	-- HAVING permet d'ajouter des conditions sur des valeurs agrégée (avec un GROUP BY)

-- 16.	Liste des employés (Nom, département, salaire) de même emploi que JONES
SELECT EMP.ENAME, EMP.DEPTNO, EMP.SAL 
FROM EMP 
WHERE EMP.JOB = (SELECT EMP.JOB FROM EMP  WHERE ENAME ='JONES');

-- j'ai affiché la liste des employés (Nom, département, salaire) de même emploi que JONES

-- 17.	Liste des employés (nom, salaire) dont le salaire est supérieur à la moyenne globale des salaires
SELECT ENAME, SAL 
FROM EMP
WHERE SAL > (SELECT AVG(SAL)FROM EMP)

-- 18.	Création d'une table PROJET avec comme colonnes numéro de projet (3 chiffres), nom de projet(5 caractères), budget. Entrez les valeurs suivantes:
-- 101, ALPHA,	96000
-- 102, BETA,	82000
-- 103, GAMMA,	15000

--VOIR AUTRES FICHIERS
 
-- 19.	Ajouter l'attribut numéro de projet à la table EMP et affecter tous les vendeurs du département 30 au projet 101, et les autres au projet 102

-- VOIR AUTRES FICHIERS

-- 20.	 Créer une vue comportant tous les employés avec nom, job, nom de département et nom de projet

USE TP1_Franck;

CREATE VIEW employees_info AS
	SELECT e.ENAME, e.JOB, d.DNAME, p.PROJNAME FROM EMP AS e
	INNER JOIN DEPT AS d ON d.DEPTNO = e.DEPTNO
	INNER JOIN PROJET AS p ON p.PROJNO = e.PROJNO;

-- 21.	A l'aide de la vue créée précédemment, lister tous les employés avec nom, job, nom de département et nom de projet triés sur nom de département et nom de projet

SELECT * FROM employees_info
	ORDER BY DNAME, PROJNAME;


-- 22.	Donner le nom du projet associé à chaque manager
SELECT PROJNAME FROM employees_info WHERE JOB = 'MANAGER';

