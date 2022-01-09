using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaCuenta:ILogicaCuenta
    {
        //Singleton
        private static LogicaCuenta _instancia = null;
        private LogicaCuenta() { }
        public static LogicaCuenta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaCuenta();
            return _instancia;
        }

        //operaciones
        public void Alta(Cuenta unaCuenta)
        {
            if (unaCuenta is CuentaCorriente)
                FabricaPersistencia.GetPersistenciaCuentaCorriente().Alta((CuentaCorriente)unaCuenta);
            else
               FabricaPersistencia.GetPersitenciaCuentaCAhorro().Alta((CuentaCAhorro)unaCuenta);
        }

        public void Baja(Cuenta unaCuenta)
        {
            if (unaCuenta is CuentaCorriente)
                FabricaPersistencia.GetPersistenciaCuentaCorriente().Baja((CuentaCorriente)unaCuenta);
            else
                FabricaPersistencia.GetPersitenciaCuentaCAhorro().Baja((CuentaCAhorro)unaCuenta);
        }

        public Cuenta Buscar(int pNumCta)
        {
            Cuenta _unaCuenta = null;
            _unaCuenta = FabricaPersistencia.GetPersistenciaCuentaCorriente().Buscar(pNumCta);
            if (_unaCuenta == null)
                _unaCuenta = FabricaPersistencia.GetPersitenciaCuentaCAhorro().Buscar(pNumCta);
            return _unaCuenta;
        }

        public List<Cuenta> ListarTodas()
        {
            List<Cuenta> _lista = new List<Cuenta>();
            _lista.AddRange(FabricaPersistencia.GetPersistenciaCuentaCorriente().Listado());
            _lista.AddRange(FabricaPersistencia.GetPersitenciaCuentaCAhorro().Listado());
            return _lista;
        }

        public List<CuentaCorriente> ListarCuentaCorriente()
        {
           return (FabricaPersistencia.GetPersistenciaCuentaCorriente().Listado()); 
        }
 
    }
}
