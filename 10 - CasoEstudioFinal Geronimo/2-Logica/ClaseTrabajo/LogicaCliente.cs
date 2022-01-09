using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaCliente:ILogicaCliente
    {
        //Singleton
        private static LogicaCliente _instancia = null;
        private LogicaCliente() { }
        public static LogicaCliente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaCliente();
            return _instancia;
        }

        //operaciones
        public void Alta(Cliente unCliente)
        {
            FabricaPersistencia.GetPersistenciaCliente().Alta(unCliente);
        }

        public void Baja(Cliente unCliente)
        {
            FabricaPersistencia.GetPersistenciaCliente().Baja(unCliente);
        }

        public void Modificar(Cliente unCliente)
        {
            FabricaPersistencia.GetPersistenciaCliente().Modificar(unCliente);
        }

        public List<Cliente> Listar()
        {
            return ( FabricaPersistencia.GetPersistenciaCliente().Listar());
        }

        public Cliente Buscar(int pNumCli)
        {
            return (FabricaPersistencia.GetPersistenciaCliente().Buscar(pNumCli));
        }

       public List<Cuenta> ListaCuentasDeCliente(Cliente pCLiente)
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaCliente().ListaCuentasDeCliente(pCLiente);
        }
    }
}
