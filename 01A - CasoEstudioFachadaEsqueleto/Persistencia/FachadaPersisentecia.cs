using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
   public class FachadaPersisentecia
    {
       public static void AgregarArticulo(Articulo A)
       {
           PersistenciaArticulos AArticulos = new PersistenciaArticulos();
           AArticulos.AgregarArt(A);

       }
       public static Articulo BuscarArticulo(int B)
       {
           PersistenciaArticulos BArticulos = new PersistenciaArticulos();
          return BArticulos.BuscarArt(B);
   
       }
       public static void EliminarArticulo(Articulo C)
       {
           PersistenciaArticulos CArticulos = new PersistenciaArticulos();
           CArticulos.EliminarArt(C);

       }
       public static void ModificarArticulo(Articulo M)
       {
           PersistenciaArticulos MArticulos = new PersistenciaArticulos();
           MArticulos.ModificarArt(M);

       }
       public static List<Articulo> ListarArticulo()
       {
           PersistenciaArticulos LArticulos = new PersistenciaArticulos();
           return LArticulos.ListarArt();
 
       }
    }
}
