USE master
go


------ Creacion base de datos -------------------------------------------------------------------------
IF exists(SELECT * FROM SysDataBases WHERE name='Veterinaria')
BEGIN
	DROP DATABASE Veterinaria
END
go

CREATE DATABASE Veterinaria
ON(
	NAME=Veterinaria,
	FILENAME='C:\Veterinaria.mdf'
)
go


------- Creacion de Tablas-------------------------------------------------------------------------------------
USE Veterinaria
go

CREATE TABLE Due�os(
	IdDue�o int not null Identity Primary Key,
	NomDue�o varchar (40) not null,
)
go

CREATE TABLE Mascotas(
	IDMas int not null Identity Primary Key,
	NomMas varchar(20) not null,
	RazaMas varchar(20) not null Default 'Perro',
	EdadMas int not null Check (EdadMas >=0 AND EdadMas <100),
	IdDue�o int not null Foreign Key References Due�os(IdDue�o)
)
go


---------Datos -------------------------------------------------------------------------------------------------
INSERT Due�os Values('Ana')
INSERT Due�os Values('Juan')
INSERT Due�os Values('Maria')
INSERT Due�os Values('Alejandro')
INSERT Due�os Values('Mauricio')
go

INSERT Mascotas(NomMas, RazaMas, EdadMas,IdDue�o) VALUES('Mi Tortugita','Tortuga',2,1)
INSERT Mascotas(NomMas, EdadMas,IdDue�o) VALUES('Mi perrito',14,1)
INSERT Mascotas(NomMas, RazaMas, EdadMas,IdDue�o) VALUES('Mi rino','Rinoceronte',25,2)
INSERT Mascotas(NomMas, RazaMas, EdadMas,IdDue�o) VALUES('Mi gatitus','Gato',15,2)
INSERT Mascotas(NomMas, RazaMas, EdadMas,IdDue�o) VALUES('Mi coco','Yacare',26,2)
go


----------SP -------------------------------------------------------------------------------------------------
CREATE PROC TodasLasMascotas As
Begin
	Select M.*, D.NomDue�o
	From Mascotas M inner join Due�os D on M.IdDue�o = D.IdDue�o
END
go


CREATE PROC LasMascotasDeUnDue�o @id int AS
Begin
	Select M.*, D.NomDue�o
	From Mascotas M inner join Due�os D on M.IdDue�o = D.IdDue�o
	Where d.IdDue�o = @id
End
go