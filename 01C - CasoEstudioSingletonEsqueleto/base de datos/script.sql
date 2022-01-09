--creo la base de datos de ventas
if exists(Select * FROM SysDataBases WHERE name='Ventas')
BEGIN
	DROP DATABASE Ventas
END
go

CREATE DATABASE Ventas
ON(
	NAME=Venta,
	FILENAME='C:\Ventas.mdf'
)
go

--pone en uso la bd
USE Ventas
go

--creo la tabla de Articulos
CREATE TABLE Articulos(
	CodArt int NOT NULL PRIMARY KEY ,
	NomArt varchar(20) NOT NULL,
	PreArt Money
) 
go
create table Factura
(
	NumFactura int not null primary key identity(1,1),
	fecha datetime not null,
	nombrecliente varchar(20) not null,
	totalbruto money ,
	totaliva money,
	totalfactura money
	)
	go
	create table Linea
	(
	
	NumFactura int Not Null  Foreign Key References Factura(NumFactura),
	CodArt int Not Null  Foreign Key References Articulos(CodArt),
	cant int not null,
	primary key(NumFactura,CodArt)

	)
	go


--CREAR ALTA FACTURA
Create Procedure AltaFactura  @fecha datetime, @nombrecliente varchar(20),@totalbruto money,
@totaliva money,@totalfactura money
 AS
Begin
		Insert Factura(fecha,nombrecliente,totalbruto,totaliva,totalfactura) Values (@fecha,@nombrecliente,@totalbruto,@totaliva,@totalfactura)
		return ident_current('Factura')
end
go
--CREAR ALTA LINEA
Create Procedure AltaLinea  @NumFactura int, @CodArticulo int,@cant int
as
Begin
	if (NOT exists(select * from Factura where NumFactura = @NumFactura))
		return -1
	if (exists(select * from Articulo where CodArt=@CodArticulo))
		return -2
		if (exists(select count() from Linea where cant>5)
			return -3
			
	
	begin
		Insert Linea(NumFactura,CodArt,cant) Values (@NumFactura,@CodArticulo,@cant)
		return 1
	end
end
go

--creo SP de alta

Create Procedure AltaArticulo @cod int, @nom varchar(20), @pre money AS
Begin
	if (exists(select * from Articulos where codArt = @cod))
		return -1
	else
	begin
		Insert Articulos(CodARt, NomArt, PreArt) Values (@cod, @nom, @pre)
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

--creo SP de listado
Create Procedure ListoArticulo AS
Begin
	Select *
	From Articulos
end
go

--ingreso datos de prueba
Exec AltaArticulo 23, "Licuadora", 2500
go
Exec AltaArticulo 48, "Maquina de Coser", 6700
go
Exec AltaArticulo 514, "Ventilador de Techo Vertical", 250
go
Exec AltaFactura "1-1-1","Clienteuno",111,222,333
go
exec AltaLinea 1,45,2
go

--NumFactura int not null primary key identity(1,1),
--	fecha datetime not null,
--	nombrecliente varchar(20) not null,
--	totalbruto money ,
--	totaliva money,
--	totalfactura money