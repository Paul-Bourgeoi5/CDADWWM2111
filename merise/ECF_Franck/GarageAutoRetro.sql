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
ADD id_rea_temp INT NOT NULL IDENTITY;
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

