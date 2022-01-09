using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
   public abstract class Cuenta
    {

       // atributos
       private int _NumCta;
       private Cliente _unCliente;
       private double _SaldoCta;


       //propiedades
       public int NumCta
       {
           get { return _NumCta; }
           set { _NumCta = value; }
       }

       public Cliente UnCliente
       {
           get { return _unCliente; }
           set { _unCliente = value; }
       }

       public double SaldoCuenta
       {
           get { return _SaldoCta; }
       }


       //constructores
       public Cuenta(int pNumCta, Cliente pUnCliente, double pSaldoCuenta)
       {
           NumCta = pNumCta;
           UnCliente = pUnCliente;
           _SaldoCta = pSaldoCuenta;
       }

       //operaciones
       protected abstract void VerificoPosibilidad(double pMonto);

       public virtual void Retiro(double pMonto)
       {
           if ((SaldoCuenta - pMonto) < 0)
               throw new Exception("Error en Saldo");
           else
               _SaldoCta = _SaldoCta - pMonto;
       }

       public virtual void Deposito(double pMonto)
       {
               _SaldoCta = _SaldoCta + pMonto;
       }


    }
}
