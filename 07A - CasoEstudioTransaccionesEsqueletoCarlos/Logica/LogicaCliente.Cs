using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
   internal class LogicaCliente: ILogicaCliente
    {
        public void Alta(EntidadesCompartidas.Cliente unCliente)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaCliente().Alta(unCliente);
        }


        public List<EntidadesCompartidas.Cliente> Listo()
        {
            return (Persistencia.FabricaPersistencia.GetPersistenciaCliente().Listo());
        }


        public EntidadesCompartidas.Cliente Busco(int pCodCli)
        {
            return (Persistencia.FabricaPersistencia.GetPersistenciaCliente().Busco(pCodCli));        
        }


        public void ModificarTelefonos(EntidadesCompartidas.Cliente unCliente)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaCliente().ModificarTelefonos(unCliente);               
        }

    }
}
