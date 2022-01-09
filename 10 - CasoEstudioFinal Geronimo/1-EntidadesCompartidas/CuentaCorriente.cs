using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class CuentaCorriente : Cuenta
    {
        //atributos
        private double _minimoCta;


        //propiedades
        public double MinimoCta
        {
            get { return _minimoCta; }
        }

        public override string TipoCuenta
        {
            get { return ("CUenta Corriente"); }
        }



        //constructores
        public CuentaCorriente(int pNumCta, Cliente pUnCliente, double pSaldoCuenta, double pMinimoCta)
            : base(pNumCta, pUnCliente, pSaldoCuenta)
        {
            _minimoCta = pMinimoCta;
        }

    }
}
