using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;
namespace Logica
{
    public class FachadaLogica
    {
        public static void AgregarArticulo(Articulo A)
        {
            LogicaArticulo LArticulo = new LogicaArticulo();
            LArticulo.AgregarArticulos(A);
        }
        public static void EliminarArticulo(Articulo E)
        {
            LogicaArticulo EArticulo = new LogicaArticulo();
           EArticulo.EliminarArticulos(E);
        }
        public static void ModificarArticulo(Articulo M)
        {
            LogicaArticulo MArticulo = new LogicaArticulo();
            MArticulo.ModificarArticulos(M);
        }
        public static Articulo BuscarArticulo(int B)
        {
            LogicaArticulo BArticulos = new LogicaArticulo();
            return BArticulos.BuscarArt(B);
        }
        public static List<Articulo> ListarArticulo()
        {
            LogicaArticulo LArticulos = new LogicaArticulo();
            return LArticulos.ListarArt();

        }
    }
}
