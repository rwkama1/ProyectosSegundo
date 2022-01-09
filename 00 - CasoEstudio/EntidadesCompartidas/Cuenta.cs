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
       //las propiedades que son objetos, tienen que validar que se pasen objetos cuando es obligatorio tenerlo, ya que un null pasa 
       //perfectamente por un tipo de objeto y no null,set siempre hay q preguntar si es distinto de null
       public Cliente UnCliente
       {
           get { return _unCliente; }
           set { _unCliente = value; }
       }

       public double SaldoCuenta
       {
           get { return _SaldoCta; }
       }

       //set es una propiedad de solo lectura, no se puede modificar el saldo asi como asi

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
       //public int CompareTo(Object obj)
       //{
       //    Cuenta _parametro = (Cuenta)obj;
       //    if (this == null)
       //        return 1;
       //    else if (_parametro == null)
       //        return -1;
       //    else
       //        return (this.NumCta.CompareTo(_parametro.NumCta));
       //}

    }
}
