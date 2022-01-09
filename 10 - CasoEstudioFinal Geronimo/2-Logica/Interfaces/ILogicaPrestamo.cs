using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaPrestamo
    {
        Prestamo Buscar(string codigo);
        void Alta(Prestamo prestamo);
        void Modificacion(Prestamo prestamo);
        void Baja(Prestamo prestamo);
        List<Prestamo> Listar();
    }
}
