using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCliente
    {
        public static void ClienteAlta(Cliente unCliente)
        {
            PersistenciaCliente.ClienteAlta(unCliente);
        }

        public static void ClienteBaja(Cliente unCliente)
        {
            PersistenciaCliente.ClienteBaja(unCliente);
        }

        public static void ClienteModificar(Cliente unCliente)
        {
            PersistenciaCliente.ClienteModificar(unCliente);
        }

        public static List<Cliente> ClienteListar()
        {
            return (PersistenciaCliente.ClienteListar());
        }

        public static Cliente ClienteBuscar(int pNumCli)
        {
            return (PersistenciaCliente.ClienteBuscar(pNumCli));
        }
 
    }
}
