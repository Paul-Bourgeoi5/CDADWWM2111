CREATE DATABASE Plumbers;
GO

USE Plumbers;


CREATE TABLE Customers
(Customer_id INT NOT NULL IDENTITY(1,1),
Customer_name VARCHAR(50) NOT NULL,
Customer_address VARCHAR(255) NOT NULL,
CONSTRAINT PK_Customers_Customer_id PRIMARY KEY (Customer_id));


CREATE TABLE Interventions
(Intervention_id INT NOT NULL IDENTITY,
Intervention_date DATE NOT NULL,
Intervention_address VARCHAR(255) NOT NULL,
Intervention_start TIME NOT NULL,
Customer_id INT NOT NULL,
CONSTRAINT PK_Interventions_Intervention_id PRIMARY KEY (Intervention_id),
CONSTRAINT FK_Interventions_Customer_id FOREIGN KEY (Customer_id) REFERENCES Customers (Customer_id));


CREATE TABLE Workers
(Worker_id INT NOT NULL IDENTITY,
Worker_last_name VARCHAR(50) NOT NULL,
Worker_first_name VARCHAR(50) NOT NULL,
Worker_speciality VARCHAR(50) NOT NULL)

ALTER TABLE Workers
ADD CONSTRAINT PK_Workers_Worker_id PRIMARY KEY (Worker_id);

CREATE TABLE Need
(Need_worker_id INT NOT NULL,
Need_intervention_id INT NOT NULL,
CONSTRAINT PK_Need PRIMARY KEY (Need_worker_id, Need_intervention_id),
CONSTRAINT FK_Need_Worker_id FOREIGN KEY (Need_worker_id) REFERENCES Workers (Worker_id),
CONSTRAINT FK_Need_Intervention_id FOREIGN KEY (Need_intervention_id) REFERENCES Interventions (Intervention_id))

GO

INSERT INTO Customers (Customer_name, Customer_address)
VALUES ('Legrand', 'Quelque part Mulhouse'), ('Paul', 'Brunstatt')

INSERT INTO Interventions (Intervention_date, Intervention_start, Intervention_address, Customer_id)
VALUES ('2022-02-06', '10:30:00', 'Chez Cyril', 3)

INSERT INTO Workers (Worker_last_name, Worker_first_name, Worker_speciality)
VALUES ('Milletre', 'Juju', 'Ingénieur informaticien'), ('Boulier', 'Axelle', 'Bûcheron fromager')

INSERT INTO NEED (Need_intervention_id, Need_worker_id)
VALUES (2, (SELECT Worker_Id FROM Workers WHERE Worker_first_name = 'Juju'))

-- Selectionner tous les prénoms des ouvriers qui sont intervenus Chez Paul
SELECT w.Worker_first_name 
FROM Workers AS w INNER JOIN Need AS n
	ON (w.Worker_id = n.Need_worker_id)
LEFT JOIN Interventions AS i
	ON (n.Need_intervention_id = i.Intervention_id)
WHERE i.Intervention_address = 'Chez Paul';