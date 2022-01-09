using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaPrestamo:ILogicaPrestamo
    {
        private static LogicaPrestamo _instancia = null;
        private LogicaPrestamo() { }
        public static LogicaPrestamo GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaPrestamo();
            return _instancia;
        }


        public Prestamo Buscar(string codigo)
        {
            return (FabricaPersistencia.GetPersistenciaPrestamo().Buscar(codigo));
        }

        public void Alta(Prestamo prestamo)
        {
            FabricaPersistencia.GetPersistenciaPrestamo().Alta(prestamo);
        }

        public void Modificacion(Prestamo prestamo)
        {
            FabricaPersistencia.GetPersistenciaPrestamo().Modificacion(prestamo);
        }

        public void Baja(Prestamo prestamo)
        {
            FabricaPersistencia.GetPersistenciaPrestamo().Baja(prestamo);
        }

        public List<Prestamo> Listar()
        {
            return (FabricaPersistencia.GetPersistenciaPrestamo().Listar());
        }
    }
}
