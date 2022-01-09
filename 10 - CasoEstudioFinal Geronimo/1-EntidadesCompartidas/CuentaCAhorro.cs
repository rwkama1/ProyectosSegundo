using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class CuentaCAhorro: Cuenta
    {
               //atributos
        private int _movsCta;
        private double _CostoMovsCta;

        //propiedades
        public int MovsCta
        {
            get { return _movsCta; }
        }

        public double CostoMovsCta
        {
            get { return _CostoMovsCta;}
        }

        public override string TipoCuenta
        {
            get{ return ("Caja Ahorro"); }
        }


        //constructores
        public CuentaCAhorro(int pNumCta, Cliente pUnCliente, double pSaldoCuenta, int pMovsCta, double pcostoMovsCta)
            : base(pNumCta, pUnCliente, pSaldoCuenta)
        {
            _movsCta = pMovsCta;
            _CostoMovsCta = pcostoMovsCta;
        }

    }
}
