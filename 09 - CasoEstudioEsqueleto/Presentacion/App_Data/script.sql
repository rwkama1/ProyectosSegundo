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

CREATE TABLE Dueños(
	IdDueño int not null Identity Primary Key,
	NomDueño varchar (40) not null,
)
go

CREATE TABLE Mascotas(
	IDMas int not null Identity Primary Key,
	NomMas varchar(20) not null,
	RazaMas varchar(20) not null Default 'Perro',
	EdadMas int not null Check (EdadMas >=0 AND EdadMas <100),
	IdDueño int not null Foreign Key References Dueños(IdDueño)
)
go


---------Datos -------------------------------------------------------------------------------------------------
INSERT Dueños Values('Ana')
INSERT Dueños Values('Juan')
INSERT Dueños Values('Maria')
INSERT Dueños Values('Alejandro')
INSERT Dueños Values('Mauricio')
go

INSERT Mascotas(NomMas, RazaMas, EdadMas,IdDueño) VALUES('Mi Tortugita','Tortuga',2,1)
INSERT Mascotas(NomMas, EdadMas,IdDueño) VALUES('Mi perrito',14,1)
INSERT Mascotas(NomMas, RazaMas, EdadMas,IdDueño) VALUES('Mi rino','Rinoceronte',25,2)
INSERT Mascotas(NomMas, RazaMas, EdadMas,IdDueño) VALUES('Mi gatitus','Gato',15,2)
INSERT Mascotas(NomMas, RazaMas, EdadMas,IdDueño) VALUES('Mi coco','Yacare',26,2)
go


----------SP -------------------------------------------------------------------------------------------------
CREATE PROC TodasLasMascotas As
Begin
	Select M.*, D.NomDueño
	From Mascotas M inner join Dueños D on M.IdDueño = D.IdDueño
END
go


CREATE PROC LasMascotasDeUnDueño @id int AS
Begin
	Select M.*, D.NomDueño
	From Mascotas M inner join Dueños D on M.IdDueño = D.IdDueño
	Where d.IdDueño = @id
End
go