using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCuenta
    {
        public static void CuentaAlta(Cuenta unaCuenta)
        {
            if (unaCuenta is CuentaCorriente)
                PersistenciaCuentaCorriente.Alta((CuentaCorriente)unaCuenta);
            else
                PersistenciaCuentaCAhorro.Alta((CuentaCAhorro)unaCuenta);
        }

        public static void CuentaBaja(Cuenta unaCuenta)
        {
            if (unaCuenta is CuentaCorriente)
                PersistenciaCuentaCorriente.Baja((CuentaCorriente)unaCuenta);
            else
                PersistenciaCuentaCAhorro.Baja((CuentaCAhorro)unaCuenta);
        }

        public static Cuenta CuentaBuscar(int pNumCta)
        {
            Cuenta _unaCuenta = null;
            _unaCuenta = PersistenciaCuentaCorriente.Buscar(pNumCta);
            if (_unaCuenta == null)
                _unaCuenta = PersistenciaCuentaCAhorro.Buscar(pNumCta);
            return _unaCuenta;
        }

        public static List<Cuenta> CuentaListarTodas()
        {
            List<Cuenta> _lista = new List<Cuenta>();
            _lista.AddRange(PersistenciaCuentaCorriente.CuentaCorrienteListado());
            _lista.AddRange(PersistenciaCuentaCAhorro.CuentaCAhorroListado());
            return _lista;
        }

        public static List<CuentaCorriente> CuentaCorrienteListar()
        {
            return (PersistenciaCuentaCorriente.CuentaCorrienteListado());
        }

        public static List<CuentaCorriente> BuscarCuentaCorrienteporcliente(Cliente numcli)
        {

            return PersistenciaCuentaCorriente.CuentaCorrienteListadoporCliente(numcli);
        }
        public static List<CuentaCAhorro> BuscarCuentaAhorroporcliente(Cliente numcli)
        {

            return PersistenciaCuentaCAhorro.CuentaAhorroListadoporCliente(numcli);
        }
    }
}
