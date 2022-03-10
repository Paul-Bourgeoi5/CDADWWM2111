USE TP2_FRANCK;

--1	Quels sont les vols au départ de Paris entre 12h et 14h ?
SELECT vd, hd FROM vols
WHERE vd = 'PARIS' AND hd BETWEEN 12 AND 14;  
--BETWEEN donne toutes les valeurs entre 12 et 14 
SELECT vd, hd FROM vols
WHERE vd = 'PARIS' AND hd >=12 AND hd <=14;

--2	Quels sont les pilotes dont le nom commence par "S" ?
SELECT nom FROM pilotes 
WHERE nom LIKE'S%'; 


--3	Pour chaque ville, donner le nombre et les capacités minimum et maximum des avions qui s'y trouvent.
SELECT localisation, count(capacite)AS COMPTE, min(capacite)AS MINIMUM , max(capacite)AS MAXIMUM
FROM avions
GROUP BY localisation

--4	Pour chaque ville, donner la capacité moyenne des avions qui s'y trouvent et cela par type d'avion.
SELECT avType, localisation , AVG(capacite) AS capaciteMoyenne
FROM avions
GROUP BY localisation, avType ;

--5 Quelle est la capacité moyenne des avions pour chaque ville ayant plus de 1 avion ?
SELECT AVG(capacite) AS capaciteMoyenne, localisation, COUNT(*) AS nombreAvions FROM avions 
GROUP BY localisation
HAVING COUNT(av) > 1;

-- 6	Quels sont les noms des pilotes qui habitent dans la ville de localisation d'un Airbus

-- Utilisation d'une sous requête
SELECT p.nom FROM pilotes AS p
	 WHERE p.adresse IN (SELECT a.localisation FROM avions AS a WHERE a.marque = 'AIRBUS');

-- Utilisation d'une jointure, même résultat
SELECT DISTINCT p.nom FROM pilotes AS p
	INNER JOIN avions AS a ON p.adresse = a.localisation
	WHERE a.marque = 'AIRBUS';

-- Décomposition de la requêtes pour la jointure
-- étape 1 : afficher la jointure complete,
--           On join les pilotes et les avions par leur adresses
--           (avion.localisation et pilotes.adresse)
SELECT DISTINCT p.*, a.* FROM pilotes AS p
	INNER JOIN avions AS a ON p.adresse = a.localisation;
	
-- étape 2 : Limiter aux avions de marque AIRBUS
SELECT DISTINCT p.*, a.* FROM pilotes AS p
	INNER JOIN avions AS a ON p.adresse = a.localisation
	WHERE a.marque = 'AIRBUS';

-- étape 3 : On affiche uniquement les noms des pilotes
SELECT DISTINCT p.nom FROM pilotes AS p
	INNER JOIN avions AS a ON p.adresse = a.localisation
	WHERE a.marque = 'AIRBUS';

-- 7 Quels sont les noms des pilotes qui conduisent un Airbus et qui habitent dans la ville de localisation d'un Airbus ?
select distinct nom, localisation
from vols 
inner join pilotes on vols.pilote=pilotes.pil
inner join avions on vols.avion= avions.av
where marque='AIRBUS' and pilotes.adresse =avions.localisation


--8	Quels sont les noms des pilotes qui conduisent un Airbus ou qui habitent dans la ville de localisation d'un Airbus ?

select distinct nom, localisation
from vols 
inner join pilotes on vols.pilote=pilotes.pil
inner join avions on vols.avion= avions.av
where marque='AIRBUS'  or pilotes.adresse =avions.localisation

--9	Quels sont les noms des pilotes qui conduisent un Airbus sauf ceux qui habitent dans la ville de localisation d'un Airbus ?

--Version Axel
SELECT DISTINCT nom, localisation
FROM vols 
INNER JOIN pilotes on vols.pilote=pilotes.pil
INNER JOIN avions on vols.avion= avions.av
WHERE marque='AIRBUS' 
EXCEPT
SELECT DISTINCT nom, localisation
FROM vols
INNER JOIN pilotes on vols.pilote=pilotes.pil
INNER JOIN avions on vols.avion= avions.av
WHERE pilotes.adresse = avions.localisation


--Version Paul
select distinct nom
from vols 
inner join pilotes on vols.pilote=pilotes.pil
inner join avions on vols.avion= avions.av
where marque='AIRBUS' and pilotes.adresse <> avions.localisation

-- 10	Quels sont les vols ayant un trajet identique ( VD, VA ) à ceux assurés par Serge ?

-- Cette version est incomplète car un vol de Paris à Paris serait accepté alors que Serge ne fait pas ce trajet
SELECT vols.vol, vols.vd, vols.va 
FROM vols 
WHERE vd IN (
	SELECT vols.vd 
	FROM vols INNER JOIN pilotes 
	ON pilotes.pil = vols.pilote 
	WHERE pilotes.nom = 'serge')
AND va IN (
	SELECT vols.va 
	FROM vols INNER JOIN pilotes 
	ON pilotes.pil = vols.pilote 
	WHERE pilotes.nom = 'serge');


-- Version avec double jointure interne
DECLARE @SergeNumber VARCHAR(10);
SELECT @SergeNumber=pil from pilotes where nom = 'serge' 
SELECT main.vol, main.vd, main.va 
FROM vols as main
INNER JOIN vols AS depart ON depart.vd = main.vd
INNER JOIN vols AS arrivee ON arrivee.va = main.va
WHERE depart.pilote = @SergeNumber
AND arrivee.pilote = @SergeNumber
AND arrivee.vol = depart.vol

-- version avec jointure croisée où on ne gardera que les lignes avec les vols de Serge dans la seconde table
SELECT main.vol, main.vd, main.va 
FROM vols as main
CROSS JOIN vols as VolsSerge
WHERE VolsSerge.pilote = (SELECT pil FROM pilotes WHERE nom = 'SERGE')
AND main.vd = VolsSerge.vd 
AND main.va = VolsSerge.va


-- 11	Donner toutes les paires de pilotes habitant la même ville ( sans doublon ).
SELECT a.nom, b.nom FROM pilotes as a INNER JOIN pilotes AS b ON a.adresse = b.adresse 
WHERE a.pil <> b.pil AND a.nom < b.nom

SELECT a.nom, b.nom FROM pilotes as a INNER JOIN pilotes AS b ON a.adresse = b.adresse 
WHERE a.pil < b.pil 

-- 12	Quels sont les noms des pilotes qui conduisent un avion que conduit aussi le pilote n°1 ?
SELECT DISTINCT nom,pil FROM pilotes AS p INNER JOIN vols AS v ON p.pil = v.pilote WHERE v.avion in 
(SELECT avion FROM vols WHERE pilote=1);

-- 13	Donner toutes les paires de villes telles qu'un avion localisé dans la ville de départ soit conduit par un pilote résidant dans la ville d'arrivée.

SELECT
	v.vd AS ville_depart,
	v.va AS ville_arrivee
	FROM vols AS v
	INNER JOIN avions AS a ON v.avion = a.av
	INNER JOIN pilotes AS p ON v.pilote = p.pil
	WHERE a.localisation = v.vd AND p.adresse = v.va;
	 

-- 14	Sélectionner les numéros des pilotes qui conduisent tous les Airbus ?
Select vols.pilote 
From VOLs
WHERE VOLs.avion in(SELECT avions.av FROM AVIONs WHERE avions.marque='airbus') -- que les airbus
group By Vols.pilote 
having (((count(distinct vols.avion))=(SELECT count(av) from avions where avions.marque='airbus'))) -- On compare le nombre d'avions pilotés par un pilote par rapport au nombre total d'airbus

-- Sélectionner les numéros des pilotes qui ne conduisent que des Airbus ?
SELECT pilote
FROM vols
EXCEPT
SELECT pilote
FROM vols
WHERE avion IN (SELECT av FROM avions WHERE marque <> 'AIRBUS')


-- Sélectionner les numéros des pilotes qui conduisent au moins 1 Airbus ?
SELECT DISTINCT pilote
FROM vols
WHERE avion IN (SELECT av FROM avions WHERE marque ='AIRBUS')


