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


        //constructores
        public CuentaCorriente(int pNumCta, Cliente pUnCliente, double pSaldoCuenta, double pMinimoCta)
            : base(pNumCta, pUnCliente, pSaldoCuenta)
        {
            _minimoCta = pMinimoCta;
        }


        //operaciones
        protected override void VerificoPosibilidad(double pMonto)
        {
            if ((base.SaldoCuenta - pMonto) < MinimoCta)
                throw new Exception("Se pasa del monto minimo");
        }

        public override void Deposito(double pMonto)
        {
            base.Deposito(pMonto);
        }

        public override void Retiro(double pMonto)
        {
            this.VerificoPosibilidad(pMonto);
            base.Retiro(pMonto);
        }

    }
}
