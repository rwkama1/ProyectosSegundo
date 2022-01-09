

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public interface IPersistenciaCliente
    {
        void Alta(EntidadesCompartidas.Cliente unCliente);
        List<EntidadesCompartidas.Cliente> Listo();
        EntidadesCompartidas.Cliente Busco(int CodCli);
        void ModificarTelefonos(EntidadesCompartidas.Cliente unCliente);
    }
}
