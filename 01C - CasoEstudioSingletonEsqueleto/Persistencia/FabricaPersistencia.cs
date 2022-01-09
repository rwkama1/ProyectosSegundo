using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaArticulo getPersistenciaArticulos()
        {
            return (PersistenciaArticulos.GetInstancia());
        }
    }
}
