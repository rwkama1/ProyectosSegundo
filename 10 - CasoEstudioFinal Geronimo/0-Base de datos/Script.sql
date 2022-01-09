--si la base de datos existe la borro------------------------------------------------------
use master
go

if exists(Select * FROM SysDataBases WHERE name='Banco')
BEGIN
	DROP DATABASE Banco
END
go

--creo la base de datos---------------------------------------------------------------------
CREATE DATABASE Banco
ON(
	NAME=Banco,
	FILENAME='C:\Banco.mdf'
)
go


--pone en uso la bd-------------------------------------------------------------------------
USE Banco
go


--creo las tablas --------------------------------------------------------------------------
Create Table Empleado
(
	CiEmp int not null Primary Key Check(CiEmp > 500000 AND CiEmp < 9999999),
	NomEmp  varchar(30) not null,
	PassEmp varchar(6) not null
)
go

Create Table Cliente
(
	NumCli int Not Null Primary Key Identity(1,1),
	NomCli varchar(30) Not Null,
	DirCli varchar(30),
	UsuCli varchar(10) not null Unique,
	PassCli Varchar(6) not null
)
go

Create Table TelefonosCliente
(
	NumCli int Not Null Foreign Key References Cliente(NumCli),
	TelCli Varchar(10) not null,
	Primary Key (NumCli, TelCli)
)
go

Create Table Cuenta
(
	NumCta int Not Null Primary Key Identity(1,1),
	NumCli int Not Null Foreign Key References Cliente(NumCli),
	SaldoCta money Not Null Default 0
)
go

Create Table CuentaCorriente
(
	NumCta int Not Null Primary Key Foreign Key References Cuenta(NumCta),
	MinimoCta money Not Null Default 0
)
go

Create Table CuentaCAhorro
(
	NumCta int Not Null Primary Key Foreign Key References Cuenta(NumCta),
	MovsCta int Not Null Default 0,  -- cantida de movimientos gratis
	CostoMovCta money Not Null Default 25
)
go

Create Table Movimientos
(
	IdMov int Not Null Primary Key Identity(1,1),
	NumCta int Not Null Foreign Key References Cuenta(NumCta),
	FechaMov datetime Not Null Default GetDate(),
	MontoMov money Not Null,
	TipoMov varchar(1) Not Null Check(TipoMov ='R' OR TipoMov ='D')
)
go

Create Table Prestamo
(
	Codigo VARCHAR (20) check(Len(Codigo) >= 9) PRIMARY KEY,
	NumCli int Not Null Foreign Key References Cliente(NumCli),
	MontoPrestado money check (MontoPrestado > 0) Not null,
	Cuotas int check (Cuotas > 0 AND Cuotas <= 24) not null
)


---Doy de alta Datos de Prueba--------------------------------------------------------------
Insert Empleado values(2700700, 'Empleado Uno', 'Emp1')
Insert Empleado values(2800800, 'Empleado Dos', 'Emp2')
go

Insert Cliente (NomCli, DirCli, UsuCli, PassCli) Values ('Primer Cliente','Primer Direccion', 'Usu1', 'usu1')
Insert Cliente (NomCli, DirCli, UsuCli, PassCli) Values ('Segundo Cliente','Segunda Direccion', 'Usu2', 'usu2')
Insert Cliente (NomCli, DirCli, UsuCli, PassCli) Values ('Tercer Cliente','Tercera Direccion', 'Usu3', 'usu3')
go

Insert TelefonosCliente Values(1, '099565656')
Insert TelefonosCliente Values(2, '095747474')
Insert TelefonosCliente Values(2, '095232323')
Insert TelefonosCliente Values(3, '27111212')
Insert TelefonosCliente Values(3, '27115858')
Insert TelefonosCliente Values(3, '27113636')
go

Insert Cuenta(NumCli,SaldoCta) Values (1,1000)
Insert Cuenta(NumCli,SaldoCta) Values (2,2000)
Insert Cuenta(NumCli,SaldoCta) Values (3,3000)
go

Insert CuentaCorriente(NumCta) Values (1)
insert CuentaCorriente(NumCta,MinimoCta) Values (2,500)
go

Insert CuentaCAhorro(NumCta,MovsCta,CostoMovCta) Values (3,5,100)
go


Insert Movimientos(FechaMov, MontoMov, NumCta, TipoMov) Values ('20130701', 1000, 1, 'R')
Insert Movimientos(FechaMov, MontoMov, NumCta, TipoMov) Values ('20130702', 2000, 2, 'R')
Insert Movimientos(FechaMov, MontoMov, NumCta, TipoMov) Values ('20130703', 3000, 3, 'R')
Insert Movimientos(FechaMov, MontoMov, NumCta, TipoMov) Values ('20130704', 4000, 1, 'D')
Insert Movimientos(FechaMov, MontoMov, NumCta, TipoMov) Values ('20130705', 5000, 2, 'D')
Insert Movimientos(FechaMov, MontoMov, NumCta, TipoMov) Values ('20130706', 6000, 3, 'D')
go

INSERT Prestamo VALUES ('201617071',1,124214,12);
INSERT Prestamo VALUES ('201627072',2,12352,10);
INSERT Prestamo VALUES ('201610092',2,353512,8);
INSERT Prestamo VALUES ('201630043',3,12535,16);
INSERT Prestamo VALUES ('201615111',1,7584545,22);
GO

--SP Clientes -----------------------------------------------------------------------------------------
Create Procedure ClienteAlta @NomCli varchar(30), @DirCli varchar(30), @UsuCli varchar(10), @PassCli varchar(6)  As
Begin
		If (Exists(select * from Cliente where NomCli = @NomCli))
			return -1
					
		Insert Cliente (NomCli,DirCli, UsuCli, PassCli) values (@NomCli, @DirCli, @UsuCli, @PassCli)

		If @@ERROR = 0
			return @@Identity
		else
			return -2
End
go


Create Procedure ClienteBaja @NumCli int As
Begin
		if (Exists(Select * From Cuenta Where NumCli = @NumCli))
				return -1
				
		if NOT EXISTS (SELECT * FROM Cliente WHERE NumCli = @NumCli)
			return -4
		--Corregir: verificar si existe el cliente
				
		Begin Transaction

		Delete From TelefonosCliente where NumCli = @NumCli
		if (@@ERROR<>0)
		Begin
			RollBack Transaction
			return -2
		End

		Delete From Cliente where NumCli = @NumCli
		if (@@ERROR<>0)
		Begin
			RollBack Transaction
			return -3
		End

		Commit Transaction
		return 1
End
go


Create Procedure ClienteModificar @NumCli int, @NomCli varchar(30), @DirCli varchar(30), @UsuCli varchar(10), @PassCli varchar(6) As
Begin
		if (Not Exists(Select * From Cliente Where NumCli = @NumCli))
			return -1

		Update Cliente Set NomCli=@NomCli, DirCli=@DirCli, UsuCli=@UsuCli, PassCli=@PassCli Where NumCli = @NumCli

		If (@@ERROR = 0)
			return 1
		Else
			return -2
End
go


Create Procedure ListadoSoloClientes As 
Begin
	Select * From Cliente
End
go


Create Procedure BuscarCliente @NumCli int As
Begin
	Select * 
	From Cliente 
	where NumCli = @NumCli
End
go

Create Procedure ListadoCuentasCliente @NumCli int As
Begin
	Select  *
	From Cuenta
	Where NumCli = @NumCli
End
go



--SP Telefonos-----------------------------------------------------------------------------------------
Create Procedure AltaTelefono @NumCli int, @TelCli varchar(10) As
Begin
		If Not (Exists(select * from Cliente where NumCli = @NumCli))
			return -1

		Insert TelefonosCliente(NumCli, TelCli) Values (@NumCli, @TelCli)
		
		If @@ERROR = 0
			return 1
		else
			return -2
End
go


Create Procedure EliminoTelsDeCliente  @NumCLi int As
Begin
	
	Delete From TelefonosCliente Where NumCli = @NumCLi
	
	If @@ERROR = 0
			return 1
	else
			return -2
End
go


create Procedure ListadoTelefonosCliente @NumCli int AS
Begin
	Select * 
	From TelefonosCliente 
	Where NumCli=@NumCli
End
go



--SP Cuentas Corrientes ---------------------------------------------------------------------------------------
Create Procedure CuentaCorrienteAlta @NumCli int, @MinimoCta money As
Begin
	
	IF NOT EXISTS (SELECT * FROM Cliente WHERE NumCli = @NumCli)
		return -3
	--Verificar la FK, verificar que exista el cliente
	
		Begin Transaction
	
		Insert Cuenta (NumCli) Values (@NumCli)
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -1
		End

		Insert CuentaCorriente (NumCta, MinimoCta) Values(IDENT_CURRENT('Cuenta'), @MinimoCta)
		if (@@ERROR<>0)
		Begin
			RollBack Transaction
			return -2
		End

		Commit Transaction
		return 1
End
go


Create Procedure CuentaCorrienteBaja @NumCta int As
Begin

		--falta verificar la PK, falta verificar que exista la cuenta
		
		if NOT EXISTS (SELECT * FROM Cuenta WHERE NumCta = @NumCta)
			return -5

		if (Exists(Select * From Movimientos Where NumCta = @NumCta))
				return -1
		else
		Begin
			Declare @Saldo int
			Select @Saldo = SaldoCta From Cuenta Where NumCta = @NumCta
			If (@Saldo > 0)
				return -2-- verificamos que no tenga dinero,porque si tiene no la puedo elminar
		End
		
		
		
		Begin Transaction

		Delete From CuentaCorriente Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -3
		End

		Delete From Cuenta Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -4
		End

		Commit Transaction
		return 1

End
go


Create Procedure ListadoCuentaCorriente As
Begin
	Select * 
	From Cuenta C Inner Join CuentaCorriente CC on C.NumCta = CC.NumCta 
End
go


Create Procedure BuscarCuentaCorriente @NumCta int As
Begin
	Select * 
	From Cuenta C Inner Join CuentaCorriente CC on C.NumCta = CC.NumCta 
	Where CC.NumCta = @NumCta
End
go



--SP Cuentas Caja de Ahorro-------------------------------------------------------------------------------------
Create Procedure CuentaCAhorroAlta @NumCli int, @MovsCta int, @CostoMovCta money As
Begin

	if NOT EXISTS (SELECT * FROM Cliente WHERE NumCli = @NumCli)
			return -3
			
		Begin Transaction
	
		Insert Cuenta (NumCli) Values (@NumCli)
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -1
		End

		Insert CuentaCAhorro(NumCta, MovsCta, CostoMovCta) Values(IDENT_CURRENT('Cuenta'), @MovsCta, @CostoMovCta)
		if (@@ERROR<>0)
		Begin
			RollBack Transaction
			return -2
		End

		Commit Transaction
		return 1
End
go

Create Procedure CuentaCAhorroBaja @NumCta int As
Begin
	
	if NOT EXISTS (SELECT * FROM Cuenta WHERE NumCta = @NumCta)
			return -5

		if (Exists(Select * From Movimientos Where NumCta = @NumCta))
				return -1
		else
		Begin
			Declare @Saldo int
			Select @Saldo = SaldoCta From Cuenta Where NumCta = @NumCta
			If (@Saldo > 0)
				return -2
		End
		
		Begin Transaction

		Delete From CuentaCAhorro Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -3
		End

		Delete From Cuenta Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -4
		End

		Commit Transaction
		return 1

End
go


Create Procedure ListadoCuentaCAhorro As
Begin
	Select * 
	From Cuenta C Inner Join CuentaCAhorro CCA on C.NumCta = CCA.NumCta 
End
go


Create Procedure BuscarCuentaCAhorro @NumCta int As
Begin
	Select * 
	From Cuenta C Inner Join CuentaCAhorro CC on C.NumCta = CC.NumCta 
	Where CC.NumCta = @NumCta
End
go



--SP Movimientos -------------------------------------------------------------------------------------
Create Procedure MovimientosAlta @NumCta int, @MontoMov money, @TipoMov varchar(1) As
Begin
		--Verifico existencia de datos
		if (Not Exists(Select * From Cuenta where NumCta = @NumCta))
			return -1

		
		--verificar monto minimo segun que tipo de cuenta sea
		
		IF (@TipoMov = 'R')
		begin
			IF EXISTS (SELECT * FROM Cuenta WHERE NumCta = @NumCta AND SaldoCta < @MontoMov)
				return -4
			
			IF EXISTS (SELECT CuentaCorriente.NumCta 
			FROM CuentaCorriente inner join Cuenta 
				ON CuentaCorriente.NumCta = Cuenta.NumCta
			WHERE SaldoCta - @MontoMov = MinimoCta
			GROUP BY CuentaCorriente.NumCta )
			BEGIN
				RETURN -5 
			END
		end
		
		
		--Doy de alta el movimiento y actualizo saldos
		Begin Transaction
		
		Insert Movimientos (MontoMov, TipoMov, NumCta) Values (@MontoMov, @TipoMov, @NumCta)
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -2
		End																									

		If (@TipoMov = 'R')
		Begin
			Update Cuenta Set SaldoCta = SaldoCta - @MontoMov Where NumCta = @NumCta		
			if (@@ERROR <> 0)
			Begin
				RollBack Transaction
				return -3
			End	
		End
		Else
		Begin
			Update Cuenta Set SaldoCta = SaldoCta + @MontoMov Where NumCta = @NumCta		
			if (@@ERROR <> 0)
			Begin
				RollBack Transaction
				return -3
			End	
		End	
		
		Commit Transaction
		return 1
		
End
go


Create View TodosLosMovimientos As
	Select *--renombrar los campos del select de movimientos
	From Movimientos
go

Create Procedure TodosLosMovs As
Begin
	Select *
	From TodosLosMovimientos
End
go


--SP Empleados -------------------------------------------------------------------------------------
Create Procedure Logueo @CiEmp int, @PassEmp varchar (6) AS
Begin
	Select *
	From Empleado
	Where CiEmp=@CiEmp AND PassEmp=@PassEmp
End
go


--SP de administracion de la base de datos  -------------------------------------------------------
Create Procedure CrearIndice As
Begin
	if (exists(select * from sys.indexes where sys.indexes.name = 'MiIndice'))
		return -1
	
	Create NonClustered Index MiIndice On Movimientos(NumCta)
	if (@@ERROR = 0)
		return 1
	else
		return -2

End
go


Create Procedure DeshabilitarIndice As
Begin
	if Not(exists(select * from sys.indexes where sys.indexes.name = 'MiIndice'))
		return -1
		
	Alter Index MiIndice On Movimientos Disable
	if (@@ERROR = 0)
		return 1
	else
		return -2

End
go


Create Procedure NuevoUsuarioSql @nombre varchar(10), @pass varchar(10), @Rol varchar(30) AS
Begin
	
	--primero creo el usuario de logueo
	Declare @VarSentencia varchar(200)
	Set @VarSentencia = 'CREATE LOGIN [' +  @nombre + '] WITH PASSWORD = ' + QUOTENAME(@pass, '''')
	Exec (@VarSentencia)
	
	if (@@ERROR <> 0)
		return -1
		
	
	--segundo asigno rol especificao al usuario recien creado
	Exec sp_addsrvrolemember @loginame=@nombre, @rolename=@Rol
	
	if (@@ERROR = 0)
		return 1
	else
		return -2

End
go

Create Procedure NuevoUsuarioBD @nombre varchar(10), @Rol varchar(30), @logueo varchar(10) AS
Begin
	--primero creo el usuario 
	Declare @VarSentencia varchar(200)
	Set @VarSentencia = 'Create User [' +  @nombre + '] From Login [' + @logueo + ']'
	Exec (@VarSentencia)
	
	if (@@ERROR <> 0)
		return -1
		
	
	--segundo asigno rol especificao al usuario recien creado
	Exec sp_addrolemember @rolename=@rol, @membername=@nombre
	
	if (@@ERROR = 0)
		return 1
	else
		return -2
	

End
go


Create Procedure EliminarUsuarioSql @nombre varchar(10) As
Begin
	Declare @VarSentencia varchar(200)
	Set @VarSentencia = 'Drop Login [' +  @nombre + ']'
	Exec (@VarSentencia)
	
	if (@@ERROR = 0)
		return 1
	else
		return -1

End
go

Create Procedure QuitarPermisoUsuarioBD @nombre varchar(10), @permiso int AS
Begin
	Declare @VarSentencia varchar(200)
	
	if (@permiso = 1)
		Set @VarSentencia = 'Revoke Execute To ' + @nombre
	else if (@permiso = 2)
		Set @VarSentencia = 'Revoke Insert On Movimientos To ' + @nombre	
	else
		return -1
	
	
	Exec (@VarSentencia)
	
	if (@@ERROR = 0)
		return 1
	else
		return -2
End

GO
--ABM Prestamo--------------------

CREATE PROC BuscarPrestamo
@codigo varchar (20)
AS
BEGIN
	SELECT * FROM Prestamo WHERE Codigo = @codigo
END

go

CREATE PROC AltaPrestamo
@codigo varchar (20),
@numCli int,
@montoPrestado money,
@cuotas int
AS
BEGIN
	IF EXISTS(SELECT * FROM Prestamo WHERE Codigo = @codigo)
		return -1
		
	IF NOT EXISTS (SELECT * FROM Cliente WHERE NumCli = @numCli)
		return -2
		
	INSERT Prestamo
	VALUES(@codigo, @numCli, @montoPrestado, @cuotas)
	
	IF @@ERROR <> 0
	begin
		return -3
	end
	
	return 1
END
GO


CREATE PROC ModificarPrestamo
@codigo varchar(20),
@montoPrestado money,
@cuotas int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Prestamo WHERE Codigo = @codigo)
		return -1
		
	UPDATE Prestamo
	SET MontoPrestado = @montoPrestado, Cuotas = @cuotas
	
	IF @@ERROR <> 0
	begin
		return -2
	end
	
	return 1
END

go

CREATE PROC BajaPrestamo
@codigo varchar (20)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Prestamo WHERE Codigo = @codigo)
		return -1
		
	DELETE Prestamo
	WHERE Codigo = @codigo
	
	IF @@ERROR <> 0
	begin
		return -2
	end
	
	return 1
END
GO

CREATE PROC ListarPrestamos
AS
BEGIN
	SELECT * FROM Prestamo
END
GO