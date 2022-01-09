--creo la base de datos de ventas
use master
go

if exists(Select * FROM SysDataBases WHERE name='Ventas')
BEGIN
	DROP DATABASE Ventas
END
go

CREATE DATABASE Ventas
ON(
	NAME=Ventas,
	FILENAME='C:\Ventas.mdf'
)
go

--pone en uso la bd
USE Ventas
go

--creo la tabla de Familias
CREATE TABLE Familias(
	CodFam int NOT NULL PRIMARY KEY,
	NomFam varchar(20)
)
go
	
--creo la tabla de Articulos
CREATE TABLE Articulos(
	CodArt int NOT NULL PRIMARY KEY ,
	NomArt varchar(20) NOT NULL,
	PreArt Money,
	CodFam int Foreign Key References Familias(CodFam)
) 
go

--creo SP de alta
Create Procedure AltaArticulo @cod int, @nom varchar(20), @pre money, @fam int AS
Begin
	if (exists(select * from Articulos where codArt = @cod))
		return -1
	else
	begin
		Insert Articulos(CodARt, NomArt, PreArt, CodFam) Values (@cod, @nom, @pre, @fam)
		return 1
	end
end
go

--creo SP de Baja
Create Procedure BajaArticulo @cod int AS
Begin
	if (not exists(select * from Articulos where codArt = @cod))
		return -1
	else
	begin
		Delete From Articulos where codArt = @cod
		return 1
	end
end
go

--creo SP de modificacion
Create Procedure ModArticulo @cod int, @nom varchar(20), @pre money AS
Begin
	if (not exists(select * from Articulos where codArt = @cod))
		return -1
	else
	begin
		Update Articulos Set NomArt=@nom, PreArt=@pre where codArt = @cod
		return 1
	end
end
go

--creo SP de busqueda
Create Procedure BuscoArticulo @cod int AS
Begin
	Select *
	From Articulos
	where codArt = @cod
end
go

Create Procedure BuscoFamilia @cod int AS
Begin
	Select *
	From Familias
	where CodFam = @cod
end
go

--creo SP de listado
Create Procedure ListoArticulo AS
Begin
	Select *
	From Articulos
end
go

Create Procedure ListoFamilia AS
Begin
	Select *
	From Familias
end
go

Create Procedure ListoArticuloXfamilia @cod int AS
Begin
	Select A.*
	From Articulos A Inner Join Familias F on A.CodFam = F.CodFam
	Where F.CodFam = @cod
end
go

--ingreso datos de prueba Familias
Insert Familias (CodFam, NomFam) Values (1,'Electrodomesticos')
Insert Familias (CodFam, NomFam) Values (2,'Alimentos')

--ingreso datos de prueba Articulos
Exec AltaArticulo 23, "Licuadora", 2500, 1
go
Exec AltaArticulo 48, "Maquina de Coser", 6700, 1
go
Exec AltaArticulo 514, "Ventilador de Techo Vertical", 250, 1
go
