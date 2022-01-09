using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaArticulo
    {
        internal void AgregarArticulos(Articulo A)
        {
            FachadaPersisentecia.AgregarArticulo(A);
        }
        internal void EliminarArticulos(Articulo E)
        {
            FachadaPersisentecia.EliminarArticulo(E);
        }
        internal void ModificarArticulos(Articulo M)
        {
            FachadaPersisentecia.ModificarArticulo(M);
        }
        internal  Articulo BuscarArt(int b)
        {
            return FachadaPersisentecia.BuscarArticulo(b);
           
        }
          internal  List<Articulo> ListarArt()
        {
            return FachadaPersisentecia.ListarArticulo();

        }
    }
}
