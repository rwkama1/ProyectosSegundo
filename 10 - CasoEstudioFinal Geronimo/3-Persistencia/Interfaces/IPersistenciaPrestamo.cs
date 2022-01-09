using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaPrestamo
    {
        Prestamo Buscar(string codigo);
        void Alta(Prestamo prestamo);
        void Modificacion(Prestamo prestamo);
        void Baja(Prestamo prestamo);
        List<Prestamo> Listar();
    }
}
