using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using EntidadesCOmpartidas;
using Datos;

namespace Logica
{
    public class LogicaPublicaciones
    {
        public static bool Agregar(Publicacion pPublicacion)
        {
            if (pPublicacion is Papel)
            {
                return DatosPapel.Agregar((Papel)pPublicacion) == 1;
            }
            else
            {
                return DatosDigital.Agregar((Digital)pPublicacion) == 1;
            }
        }


        public static Publicacion Buscar(int pIsbn)
        {
            Publicacion p = null;
            p = (Publicacion)DatosPapel.Buscar(pIsbn);
            // si no se encuentra en papel busca en digital
            if (p == null)
            {
                //si no esta en papel lo busco en digital
                p = (Publicacion)DatosDigital.Buscar(pIsbn);
            }
            return p;
        }


        public static List<Publicacion> ListarPublicaciones()
        {
            List<Publicacion> oAux = DatosPapel.ListarPublicacionesPapel();
            oAux.AddRange(DatosDigital.ListarPublicacionesDigital());

            return oAux;
        }
    }

}
