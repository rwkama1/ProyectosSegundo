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


        //constructores
        public CuentaCAhorro(int pNumCta, Cliente pUnCliente, double pSaldoCuenta, int pMovsCta, double pcostoMovsCta)
            : base(pNumCta, pUnCliente, pSaldoCuenta)
        {
            _movsCta = pMovsCta;
            _CostoMovsCta = pcostoMovsCta;
        }


        //operaciones
        protected override void VerificoPosibilidad(double pMonto)
        {
            if (MovsCta > 25)
                throw new Exception("Debe pagar el Movimiento");
        }

        public override void Deposito(double pMonto)
        {
            this.VerificoPosibilidad(pMonto);
            base.Deposito(pMonto);
        }

        public override void Retiro(double pMonto)
        {
            this.VerificoPosibilidad(pMonto);
            base.Retiro(pMonto);
        }
    }
}
