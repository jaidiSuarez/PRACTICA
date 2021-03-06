CREATE TABLE Proyecto(
	Codigo varchar(5) PRIMARY KEY,
	Nombre varchar(20)
);

INSERT INTO Proyecto (Codigo, Nombre) VALUES ('P001', 'Las Flores');
INSERT INTO Proyecto (Codigo, Nombre) VALUES ('P002', 'Los Rosales');
INSERT INTO Proyecto (Codigo, Nombre) VALUES ('P003', 'Los Trigos');

CREATE TABLE Cargo(
	Codigo varchar(5) PRIMARY KEY,
	Nombre varchar(20),
	ValorHora bigint 
);
INSERT INTO Cargo (Codigo, Nombre, ValorHora) VALUES ('C001', 'Obrero', 10000);
INSERT INTO Cargo (Codigo, Nombre, ValorHora) VALUES ('C002', 'Secretaría', 20000);
INSERT INTO Cargo (Codigo, Nombre, ValorHora) VALUES ('C003', 'Oficios Varios', 15000);
INSERT INTO Cargo (Codigo, Nombre, ValorHora) VALUES ('C004', 'Arquitecto', 30000);

CREATE TABLE Liquidacion (
	CodigoProyecto varchar(5), 
	CodigoCargo varchar(5), 
	Identificacion varchar(15),
	Nombre varchar(80), 
	HorasTrabajadas bigint,
	ValorPagar bigint
);

SELECT * FROM Proyecto;
SELECT * FROM Cargo;
SELECT * FROM Liquidacion;

drop table Cargo;