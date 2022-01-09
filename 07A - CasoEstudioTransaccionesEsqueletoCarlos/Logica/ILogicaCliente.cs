using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
   public interface ILogicaCliente
    {
       void Alta(EntidadesCompartidas.Cliente unCliente);
        List<EntidadesCompartidas.Cliente> Listo();
        EntidadesCompartidas.Cliente Busco(int CodCli);
        void ModificarTelefonos(EntidadesCompartidas.Cliente unCliente);
    }
}
