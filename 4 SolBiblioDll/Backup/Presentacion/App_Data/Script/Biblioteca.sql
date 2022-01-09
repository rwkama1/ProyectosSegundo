
use master
go
--Determina si esta la base de datos Biblioteca y la borra
if exists(Select * FROM SysDataBases WHERE name='Biblioteca')
BEGIN
	DROP DATABASE Biblioteca
END
go
--Crea la base de datos Biblioteca en el lugar especificado
CREATE DATABASE Biblioteca
ON(
	NAME=Biblioteca,
	FILENAME='E:\leo\Biblioteca.mdf'
)

go
--pone en uso la bd
USE Biblioteca
go
--Creacion de tablas
CREATE TABLE Publicaciones(
	ISBN int NOT NULL PRIMARY KEY ,
	Titulo varchar(20) NULL
) 
go
CREATE TABLE Papel(
	ISBN int NOT NULL PRIMARY KEY ,
	Peso int NULL,
	FOREIGN KEY (ISBN) REFERENCES Publicaciones(ISBN)
) 
go
CREATE TABLE Digital(
	ISBN int NOT NULL PRIMARY KEY ,
	Formato varchar(20) NULL,
	Protegida bit NULL,
	FOREIGN KEY (ISBN) REFERENCES Publicaciones(ISBN)
) 
go
CREATE TABLE Prestamos(
	Numero int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Fecha datetime NULL,
	Dias int NULL,
	Nombre varchar(20) NULL,
	ISBN int NOT NULL,
	Devuelto bit NOT NULL,
	FOREIGN KEY (ISBN) REFERENCES Publicaciones(ISBN)
 )
go
--datos de prueba
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (1,'T 1');
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (2,'T 2');
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (3,'T 3');
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (4,'T 4');
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (5,'T 5');
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (6,'T 6');
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (7,'T 7');
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (8,'T 8');
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (9,'T 7');
INSERT INTO Publicaciones(ISBN ,Titulo)VALUES (10,'T 8');
go
INSERT INTO Papel(ISBN ,Peso ) VALUES (2,22);
INSERT INTO Papel(ISBN ,Peso ) VALUES (4,44);
INSERT INTO Papel(ISBN ,Peso ) VALUES (6,66);
INSERT INTO Papel(ISBN ,Peso ) VALUES (8,88);
INSERT INTO Papel(ISBN ,Peso ) VALUES (10,1010);
go
INSERT INTO Digital(ISBN ,Formato ,Protegida ) VALUES (1,'DOC',1);
INSERT INTO Digital(ISBN ,Formato ,Protegida ) VALUES (3,'PDF',0);
INSERT INTO Digital(ISBN ,Formato ,Protegida ) VALUES (5,'DOC',0);
INSERT INTO Digital(ISBN ,Formato ,Protegida ) VALUES (7,'DOC',1);
INSERT INTO Digital(ISBN ,Formato ,Protegida ) VALUES (9,'PDF',1);
go
--DEVUELTOS
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('13-06-2000',1,'ana sosa',1,1);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES(getdate(),10,'lia sosa',1,1);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('13-06-2000',1,'ana rocha',2,1);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES(getdate(),10,'lia rocha',2,1);
go
--no DEVUELTOS
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('13-06-2000',1,'jose rocha',3,0);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES(getdate(),10,'mario sosa',5,0);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('13-06-2000',1,'mario rocha',4,0);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES(getdate(),10,'jose sosa',6,0);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('20070920',10,'jose sosa',6,0);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('20071001',300,'jose sosa',6,0);
go
-------- PRESTADO DOS VECES
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('13-06-2000',1,'ana sosa',7,1);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('13-06-2001',1,'ana sosa',7,1);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES(getdate(),10,'ana sosa',7,0);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('13-06-2000',1,'ana sosa',8,1);
INSERT INTO Prestamos(Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES('13-06-2001',1,'ana sosa',8,0);

go
--PUBLICACION

--Elimina una publicacion digital retorna 1 si la puede eliminar 0 si no esta y -1 si NO lA puede eliminar
CREATE PROCEDURE EliminarPublicacion @ISBN int  AS
BEGIN 
	
	IF (NOT EXISTS (SELECT ISBN FROM Publicaciones WHERE ISBN =@ISBN ))
	BEGIN 
		RETURN 0;
	END
	ELSE 
	BEGIN
		IF (EXISTS (SELECT ISBN FROM Prestamos WHERE ISBN =@ISBN ))
		BEGIN 
			RETURN -1;
		END
		ELSE 
		BEGIN 
			DECLARE @Error int
			BEGIN TRAN
			DELETE Papel WHERE  ISBN =@ISBN 
			SET @Error=@@ERROR;
			DELETE Digital	WHERE  ISBN =@ISBN ;
			SET @Error=@@ERROR+@Error;
			DELETE Publicaciones WHERE  ISBN =@ISBN;
			SET @Error=@@ERROR+@Error;
			IF(@Error=0)
			BEGIN
				COMMIT TRAN;
				RETURN 1;
			END
			ELSE
			BEGIN
				ROLLBACK TRAN;
				RETURN -1;
			END	
		END
	END
end
go
--Selecciona ISBN ,Titulo de todas las publicaciones 
CREATE PROCEDURE ListarPublicaciones 	@ISBN int AS
BEGIN 
	SELECT ISBN ,Titulo
	FROM Publicaciones ;
END

go
-- PAPEL

--Agrega una publicacion en Papel y retorna 1 si la puede agregar o 0 si NO lA puede agregar
CREATE  PROCEDURE AgregarPublicacionPapel 	@ISBN int ,@Titulo varchar(20), @Peso int AS
BEGIN 
	if (EXISTS (SELECT ISBN FROM Publicaciones WHERE ISBN=@ISBN))
	BEGIN
		RETURN 0;
	END	
	ELSE
	BEGIN
		DECLARE @Error int
		BEGIN TRAN
		INSERT Publicaciones( ISBN ,Titulo ) VALUES( @ISBN ,@Titulo );
		SET @Error=@@ERROR;
		INSERT Papel( ISBN ,Peso ) VALUES( @ISBN , @Peso );
		SET @Error=@@ERROR+@Error;
		IF(@Error=0)
		BEGIN
			COMMIT TRAN;
			RETURN 1;
		END
		ELSE
		BEGIN
			ROLLBACK TRAN;
			RETURN -1;
		END	
	END
END
go
--Dado el ISBN Busca una publicacion en Papel 
CREATE  PROCEDURE BuscarPublicacionPapel 	@ISBN int AS
BEGIN 
	SELECT p.ISBN ,Titulo, Peso  
	FROM Papel AS pp INNER JOIN Publicaciones AS p ON pp.ISBN=p.ISBN AND p.ISBN=@ISBN;
END
go
--Dado el isbn anterior y el nuevo el titulo y el peso 
--Modifica la publicacion del isbn dado y retorna 1 si lo pudo hacer o 0 si NO lo pudo hacer
CREATE PROCEDURE ModificarPublicacionPapel 	@ISBN int ,@NuevoISBN int ,@Titulo varchar(20), @Peso int AS
BEGIN 
	DECLARE @Error int
	if (NOT EXISTS (SELECT ISBN FROM Papel WHERE ISBN=@ISBN))
	BEGIN
		RETURN 0;
	END	
	ELSE
	BEGIN
		BEGIN TRAN
		UPDATE Papel SET ISBN = @NuevoISBN, Peso =@Peso	WHERE ISBN =  @ISBN;
		SET @Error=@@ERROR;
		UPDATE Publicaciones SET ISBN = @NuevoISBN,	Titulo =@Titulo	WHERE ISBN = @ISBN;
		SET @Error=@@ERROR+@Error;
		IF(@Error=0)
		BEGIN
			COMMIT TRAN;
			RETURN 1;
		END
		ELSE
		BEGIN
			ROLLBACK TRAN;
			RETURN 0;
		END	
	END
END

go
--Selecciona ISBN ,Titulo, Peso  de todas las publicaciones en papel
CREATE  PROCEDURE ListarPublicacionesPapel 	AS
BEGIN 
	SELECT p.ISBN ,Titulo, Peso  
	FROM Papel AS pp INNER JOIN Publicaciones AS p ON pp.ISBN=p.ISBN;
END

go
-- DIGITAL

--Agrega una publicacion digital retorna 1 si la puede agregar o 0 si NO lA puede agregar
CREATE  PROCEDURE AgregarPublicacionDigital @ISBN int ,@Titulo varchar(20), @Formato varchar(3), @Protegida bit AS
BEGIN 
	if (EXISTS (SELECT ISBN FROM Publicaciones WHERE ISBN=@ISBN))
	BEGIN
		RETURN 0;
	END	
	ELSE
	BEGIN
		DECLARE @Error int
		BEGIN TRAN
		INSERT Publicaciones( ISBN ,Titulo ) VALUES( @ISBN ,@Titulo );
		SET @Error=@@ERROR;
		INSERT Digital ( ISBN ,Formato, Protegida) VALUES( @ISBN , @Formato, @Protegida);
		SET @Error=@@ERROR+@Error;
		IF(@Error=0)
		BEGIN
			COMMIT TRAN;
			RETURN 1;
		END
		ELSE
		BEGIN
			ROLLBACK TRAN;
			RETURN 0;
		END	
	END
END
go
--Dado el ISBN Busca una publicacion digital y selecciona ISBN ,Titulo, Formato, Protegida si la encuentra o null si NO lo encuentra
CREATE PROCEDURE BuscarPublicacionDigital	@ISBN int AS
BEGIN 
	SELECT p.ISBN ,Titulo, Formato, Protegida
	FROM Digital AS pd INNER JOIN Publicaciones AS p ON pd.ISBN=p.ISBN AND p.ISBN=@ISBN;
END

go
--Dado el isbn anterior y el nuevo el formato y si esta Protegida
--Modifica la publicacion del isbn dado y retorna 1 si lo pudo hacer o 0 si NO lo pudo hacer
CREATE PROCEDURE ModificarPublicacionDigital 	@ISBN int,@NuevoISBN int, @Titulo varchar(20) ,@Formato varchar(3), @Protegida bit AS
BEGIN 
	DECLARE @Error int
	if (NOT EXISTS (SELECT ISBN FROM Digital WHERE ISBN=@ISBN))
	BEGIN
		RETURN 0;
	END	
	ELSE
	BEGIN
		BEGIN TRAN
		UPDATE Digital SET ISBN = @NuevoISBN, Formato=@Formato, Protegida=@Protegida WHERE ISBN =  @ISBN;
		SET @Error=@@ERROR;
		UPDATE Publicaciones SET  ISBN =  @NuevoISBN, Titulo =@Titulo WHERE ISBN =  @ISBN;
		SET @Error=@@ERROR+@Error;
		IF(@Error=0)
		BEGIN
			COMMIT TRAN;
			RETURN 1;
		END
		ELSE
		BEGIN
			ROLLBACK TRAN;
			RETURN 0;
		END	
	END
END
go
--Selecciona ISBN ,Titulo, Formato y Protegida de todas las publicaciones en papel
CREATE PROCEDURE ListarPublicacionesDigital AS
BEGIN 
	SELECT p.ISBN ,Titulo,  Formato, Protegida
	FROM Digital AS pd INNER JOIN Publicaciones AS p ON pd.ISBN=p.ISBN;
END
go

-- PRESTAMO

--Agrega un prestamo y retorna el numero que es autogenerado o -1 si no lo pudo agregar
CREATE PROCEDURE AgregarPrestamo @Fecha datetime ,@Dias int ,@Nombre varchar(20),@ISBN int  AS
BEGIN 
	if (NOT EXISTS (SELECT ISBN FROM Publicaciones WHERE ISBN=@ISBN))
	BEGIN
		RETURN -1;
	END	
	ELSE
	BEGIN
		INSERT INTO Prestamos (Fecha ,Dias ,Nombre ,ISBN, Devuelto) VALUES(@Fecha ,@Dias ,@Nombre ,@ISBN , 0 );
		IF(@@Error=0)
		BEGIN
			RETURN ident_current('Prestamos');
		END
		ELSE
		BEGIN
			RETURN -1;
		END	
	END
END

go
--Dado el Numero de prestamo busca un prestamo selecciona Fecha ,Dias ,Nombre ,ISBN, Devuelto si la encuentra o null si NO lo encuentra
CREATE  PROCEDURE BuscarPrestamo	@Numero int AS
BEGIN 
	SELECT Fecha ,Dias ,Nombre ,ISBN, Devuelto
	FROM Prestamos 
	WHERE Numero=@Numero;
END
go
--Dado el numero de prestamo realiza la devolucion del prestamo y retorna 1 si lo pudo hacer o 0 si esta devuelto y -1 si NO esta el numero 
CREATE PROCEDURE DevolverPrestamo	@Numero int AS
BEGIN 
	DECLARE @Error int
	if (NOT EXISTS (SELECT Numero FROM Prestamos WHERE Numero=@Numero))
	BEGIN
		RETURN -1;
	END	
	ELSE
	BEGIN
		UPDATE Prestamos SET  Devuelto=  1	WHERE Numero=  @Numero;
		return @@rowcount;
	END
END
go
--Selecciona Numero, Fecha ,Dias ,Nombre ,ISBN, Devuelto de todos los prestamos
CREATE  PROCEDURE ListarPrestamos AS
BEGIN 
	SELECT Numero, Fecha ,Dias ,Nombre ,ISBN, Devuelto   
	FROM Prestamos
END
go
--Selecciona Numero, Fecha ,Dias ,Nombre ,ISBN, Devuelto de todos los prestamos
CREATE  PROCEDURE ListarPrestamosNodevueltos AS
BEGIN 
	SELECT Numero, Fecha ,Dias ,Nombre ,ISBN, Devuelto   
	FROM Prestamos
	WHERE Devuelto=0;
END
go
--Selecciona Numero, Fecha ,Dias ,Nombre ,ISBN, Devuelto de todos los prestamos que estan pasados de la fecha dada
CREATE PROCEDURE ListarPrestamosVencidos @FechaLimite as varchar(15)AS
BEGIN 
	SELECT Numero, Fecha ,Dias ,Nombre ,ISBN, Devuelto  
	FROM Prestamos
	WHERE DateAdd(d,Dias,Fecha)<@FechaLimite and Devuelto=0;
END


