using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaMovimiento
    {
        public static void MovimientoAlta(Movimiento pMovimiento)
        {
            PersistenciaMovimiento.MovimientosAlta(pMovimiento);
        }

    }
}
