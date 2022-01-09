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
Create Table Cliente
(
	NumCli int Not Null Primary Key Identity(1,1),
	NomCli varchar(30) Not Null,
	DirCli varchar(30)
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
	FechaMov datetime Not Null Default GetDate(),
	MontoMov money Not Null,
	TipoMov varchar(1) Not Null,	--R es un retiro y D es un Deposito
	NumCta int Not Null Foreign Key References Cuenta(NumCta)	
)
go


---Doy de alta Datos de Prueba--------------------------------------------------------------
Insert Cliente (NomCli, DirCli) Values ('Primer Cliente','Primer Direccion')
Insert Cliente (NomCli, DirCli) Values ('Segundo Cliente','Segunda Direccion')
Insert Cliente (NomCli, DirCli) Values ('Tercer Cliente','Tercera Direccion')
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


--SP basicos para manejo del ejemplo------------------------------------------------------
Create Procedure ClienteAlta @NomCli varchar(30), @DirCli varchar(30) As
Begin
--hay q devolver un valor si esta todo bien!!

		Insert Cliente (NomCli,DirCli) values (@NomCli, @DirCli)
		if(@@error=0)
			return 1
		else
			return -2
			
End
go


Create Procedure ClienteBaja @NumCli int As
Begin
		if (Exists(Select * From Cuenta Where NumCli = @NumCli))
			Begin
				return -1
			end
		Else
			Begin
				Delete From Cliente where NumCli = @NumCli
				If (@@ERROR = 0)
					return 1
				Else
					return -2
			End
End
go


Create Procedure ClienteModificar @NumCli int, @NomCli varchar(30), @DirCli varchar(30) As
Begin
		if (Not Exists(Select * From Cliente Where NumCli = @NumCli))
			Begin
				return -1
			end
		Else
			Begin
				Update Cliente Set NomCli=@NomCli, DirCli=@DirCli Where NumCli = @NumCli
				If (@@ERROR = 0)
					return 1
				Else
					return -2
			End
End
go


Create Procedure ClienteListado As 
Begin
	Select * From Cliente
End
go


Create Procedure ClienteBuscar @NumCli int As
Begin
	Select * From Cliente where NumCli = @NumCli
End
go


Create Procedure CuentaCorrienteAlta @NumCli int, @MinimoCta money As
Begin
--hay q preguntar si existe el cliente.....
if ( Exists(Select * From Cliente Where NumCli = @NumCli))
			Begin
				return -1
			end
			
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
		if (Exists(Select * From Movimientos Where NumCta = @NumCta))
				return -1

		Begin Transaction

		Delete From CuentaCorriente Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -2
		End

		Delete From Cuenta Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -3
		End

		Commit Transaction
		return 1

End
go


Create Procedure CuentaCorrienteListado As
Begin
	Select * From Cuenta Cta Inner Join CuentaCorriente CC on Cta.NumCta = CC.NumCta 
End
go


Create Procedure CuentaCorrienteBuscar @NumCta int As
Begin
	Select * 
	From Cuenta Cta Inner Join CuentaCorriente CC on Cta.NumCta = CC.NumCta 
	Where cc.NumCta = @NumCta
End
go


Create Procedure CuentaCAhorroAlta @NumCli int, @MovsCta int, @CostoMovCta money As
Begin
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
		if (Exists(Select * From Movimientos Where NumCta = @NumCta))
				return -1

		Begin Transaction

		Delete From CuentaCAhorro Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -2
		End

		Delete From Cuenta Where NumCta = @NumCta
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -3
		End

		Commit Transaction
		return 1

End
go


Create Procedure CuentaCAhorroListado As
Begin
	Select * From Cuenta Cta Inner Join CuentaCAhorro CCA on Cta.NumCta = CCA.NumCta 
End
go


Create Procedure CuentaCAhorroBuscar @NumCta int As
Begin
	Select * 
	From Cuenta Cta Inner Join CuentaCAhorro CC on Cta.NumCta = CC.NumCta 
	Where cc.NumCta = @NumCta
End
go


Create Procedure MovimientosAlta @NumCta int, @MontoMov money, @TipoMov varchar(1), @SaldoCta money As
Begin
		--Verifico existencia de datos
		if (Not Exists(Select * From Cuenta where NumCta = @NumCta))
			return -1
			
		--falta verificar en caso de retiro, el saldo adecuado
		--falta verificar si es R o D
		--Doy de alta el movimiento y actualizo saldos
		Begin Transaction
		
		Insert Movimientos (MontoMov, TipoMov, NumCta) Values (@MontoMov, @TipoMov, @NumCta)
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -2
		End																									

		Update Cuenta Set SaldoCta = @SaldoCta Where NumCta = @NumCta		
		if (@@ERROR <> 0)
		Begin
			RollBack Transaction
			return -3
		End	
		
		Commit Transaction
		return 1
		
End
go
--se puede modificar solo el minimo de una cuenta corriente
--hacer modificar cuentaCahorro global para el movimiento de CostoMovCta
create procedure ListaCuentaAhorroCliente @numcli int
as
begin
	select * from 
    Cuenta inner join CuentaCAhorro on Cuenta.Numcli=@numcli

end 
go
--declare @s int
--exec @s=ListaCuentaAhorroCliente 1
--select @s
create procedure ListaCuentaCorrienteCliente @numcli int
as
begin
	select * from 
    Cuenta inner join CuentaCorriente on Cuenta.Numcli=@numcli

end 
go
