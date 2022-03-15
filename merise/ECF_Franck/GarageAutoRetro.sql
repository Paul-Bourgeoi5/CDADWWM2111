-- CREATE DATABASE ECF_FRANCK_1

USE ECF_FRANCK_1;


CREATE TABLE realisations(
id_rea int  NOT NULL,
titre_rea nvarchar(255) NOT NULL,
date_rea date NOT NULL,
texte_rea nvarchar(max) NOT NULL);


CREATE TABLE images 
(id_img int NOT NULL,
url_img nvarchar(250) NOT NULL,
nom_img nvarchar(100)NOT NULL,
text_img nvarchar(max)NOT NULL,
ext_img nvarchar(5)NOT NULL);


-- Rajouter une modification de la table, pour que le champs «id_rea»   soit en auto-incrément avec contrainte de clé primaire
ALTER TABLE realisations
DROP COLUMN id_rea
ALTER TABLE realisations
ADD id_rea INT NOT NULL IDENTITY;
ALTER TABLE realisations
ADD CONSTRAINT PK_id_rea PRIMARY KEY (id_rea);

--------------------------------- VERSION DROP TABLE

--PERMETTRE L'INSERTION DANS LA PRIMARY KEY IDENTITY DE LA TABLE PROVISOIRE
--SET IDENTITY_INSERT realisations_temp ON
--CONDITION
--SET IDENTITY_INSERT realisations_temp OFF

--CREATION D'UNE TABLE PROVISOIRE
CREATE TABLE realisations_temp (
id_rea INT IDENTITY NOT NULL PRIMARY KEY,
titre_rea VARCHAR(255) NOT NULL,
date_rea DATE NOT NULL,
texte_rea TEXT NOT NULL
);

--INSERER LES DONNEES D'UNE TABLE VERS UNE AUTRE TABLE
--1/
SET IDENTITY_INSERT realisations_temp ON;
--2/
INSERT INTO realisations_temp(id_rea , titre_rea,date_rea ,texte_rea)
SELECT id_rea , titre_rea,date_rea ,texte_rea
FROM realisations
SET IDENTITY_INSERT realisations_temp OFF;

--DETRUIRE LA TABLE D'ORIGINE 
DROP TABLE realisations;
--RENOMMER MA TABLE TEMPORAIRE
EXEC sp_rename 'realisations_temp ', 'realisations';

-- Rajouter une modification de la table, pour que le champs «id_img»  soit en auto-incrément avec contrainte de clé primaire
ALTER TABLE IMAGES 
DROP COLUMN id_img
ALTER TABLE images
ADD id_img int NOT NULL IDENTITY;
ALTER TABLE images
ADD CONSTRAINT PK_Images_id PRIMARY KEY (id_img);



-- RAPPEL modification d'une colonne autre que pour auto incrémentation (ajouter not null par exemple):
-- ALTER TABLE nom_table_a_modifier
-- ALTER COLUMN nom_colonne_a_modifier nouveau_de_donnees NOT NULL;



-- Vous proposerez la partie du MCD et un MLD qui concerne la gestion des images dans le cas suivant :
--	Une réalisation sera associée avec 1 seule image qui apparaîtra sous le titre en grande
--	dimension,   mais   attention, la  même   image   peut   être   utilisée   pour  plusieurs réalisations.
--	(exemple: la photo générale du garage ou de l’atelier du garage serviraplusieurs fois...) 
SELECT *
FROM realisations;
ALTER TABLE realisations
ADD img_id INT NOT NULL;   
ALTER TABLE realisations
ADD CONSTRAINT FK_realisations_img_id FOREIGN KEY (img_id) REFERENCES images (id_img); 



--5) Donner en sql (SQL server) les commandes qui permettent de modifier ou créer les tables nécessaires avec les contraintes éventuelles de clésprimaires et étrangères. (id réalisation auto incrément)

-- Creation de la table illustrer.
CREATE TABLE illustrer
( id_rea INT NOT NULL,
id_img INT NOT NULL,
CONSTRAINT PK_illustrer_id PRIMARY KEY (id_rea, id_img),
CONSTRAINT FK_illustrer_id_rea FOREIGN KEY (id_rea)
REFERENCES realisations(id_rea),
CONSTRAINT FK_illustrer_id_img FOREIGN KEY (id_img)
REFERENCES images(id_img));

-- suppression dans la table realisation de la clé étrangère vers Images et de la colonne img_id.
ALTER TABLE realisations
DROP CONSTRAINT FK_realisations_img_id;
ALTER TABLE realisations
DROP COLUMN img_id;

--1)   Donner   dans   ce   cas   la   requête   qui   pour   une   réalisation   données(«id_rea» fixée) permet  de trouver toutes les images associées...

DECLARE @id_rea_fixee INT;
SET @id_rea_fixee = 42;

SELECT images.id_img, url_img, nom_img, ext_img, text_img
FROM images
	INNER JOIN illustrer ON illustrer.id_img = images.id_img
WHERE id_rea = @id_rea_fixee;

--Alternative
SELECT images.id_img, url_img, nom_img, ext_img, text_img
FROM images
WHERE id_img = (SELECT id_img FROM illustrer WHERE id_rea = 42);

GO
CREATE PROCEDURE afficheImg
	@afficheUnTruc INT
AS
SELECT images.nom_img, illustrer.id_img
FROM illustrer
	INNER JOIN images ON illustrer.id_img = images.id_img
WHERE id_rea = @afficheUnTruc;

--2) Donner la procédure stockée qui permet de savoir combien de fois une image est utilisée dans les différentes réalisations en fonction du nom de l’image (nom_img)
GO
CREATE PROCEDURE nb_utilisation_image
	@nom_image_a_compter NVARCHAR(100)
AS
SELECT COUNT(nom_img) AS NOMBRE_IMAGES
FROM images
	INNER JOIN illustrer ON illustrer.id_img = images.id_img
WHERE nom_img = @nom_image_a_compter;
GO

EXEC nb_utilisation_image N'MonImageAuPif';

GO

