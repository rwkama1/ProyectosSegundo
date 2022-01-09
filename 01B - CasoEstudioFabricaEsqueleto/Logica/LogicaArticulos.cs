using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;
namespace Logica
{
    internal class LogicaArticulos:ILogicaArticulo
    {
        public void AgregarArticulo(Articulo A)
        {
            IPersistenciaArticulo FArticulo = FabricaPersistencia.getPersistenciaArticulo();
            FArticulo.AgregarArticulo(A);
        }
        public void EliminarArticulo(Articulo E)
        {
            IPersistenciaArticulo EArticulo = FabricaPersistencia.getPersistenciaArticulo();
            EArticulo.EliminarArticulo(E);
        }
        public void ModificarArticulo(Articulo M)
        {
            IPersistenciaArticulo MArticulo = FabricaPersistencia.getPersistenciaArticulo();
            MArticulo.ModificarArticulo(M);
        }
        public  Articulo BuscarArticulo(int b)
        {
            IPersistenciaArticulo BArticulo = FabricaPersistencia.getPersistenciaArticulo();
            return BArticulo.BuscarArticulo(b);
        }
        public  List<Articulo> ListarArticulo()
        {
            IPersistenciaArticulo LArticulo = FabricaPersistencia.getPersistenciaArticulo();
            return LArticulo.ListarArticulo();
        }
    }
}
