using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cuenta//la clase en este caso no es abstract porque no necesito en caso de listados saber que tipo de cuenta es
        //asi que no la hago abstract, la cuenta tiene los datos basicos que necesito, el saldo y el numero
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

       public virtual string TipoCuenta
       {
           get { return "No se";}
       }//es una propiedad que va a ser solamente reescrita por las derivadas y es de solo lectura


       //constructores
       public Cuenta(int pNumCta, Cliente pUnCliente, double pSaldoCuenta)
       {
           NumCta = pNumCta;
           UnCliente = pUnCliente;
           _SaldoCta = pSaldoCuenta;
       }

       public override string ToString()
       {
           return (this.NumCta.ToString().Trim() + " - " + this.UnCliente.NomCli + " - " + this.TipoCuenta);
       }
    }
}
