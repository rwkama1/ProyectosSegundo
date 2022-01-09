using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;
namespace Logica
{
    internal class LogicaArticulo:ILogicaArticulo
    {

         //singleton
        private static LogicaArticulo instancia = null;
        private LogicaArticulo() { }
        public static LogicaArticulo GetInstancia()
        {
            if (instancia == null)
               instancia = new LogicaArticulo();
            return instancia;
        }
        public void AgregarArticulo(Articulo A)
        {
            FabricaPersistencia.getPersistenciaArticulos().AgregarArticulo(A);
            
        }
        public void EliminarArticulo(Articulo E)
        {
            FabricaPersistencia.getPersistenciaArticulos().EliminarArticulo(E);
        }
        public void ModificarArticulo(Articulo M)
        {
            FabricaPersistencia.getPersistenciaArticulos().ModificarArticulo(M);
        }
        public Articulo BuscarArticulo(int b)
        {
            return FabricaPersistencia.getPersistenciaArticulos().BuscarArticulo(b);
        }
        public List<Articulo> ListarArticulo()
        {
            return FabricaPersistencia.getPersistenciaArticulos().ListarArticulo();
        }
    }
}
