using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
   public class Dueño
    {
       //atributos
       private string _Nombre;
       private List<Mascota> _MisMascotas;

       //propiedades
       public string Nombre
       {
           get { return _Nombre; }
           set { _Nombre = value; }
       }

       public List<Mascota> MisMascotas
       {
           get { return _MisMascotas; }
           set { _MisMascotas = value; }
       }

       public int CantMascotas
       {
           get { return MisMascotas.Count; }
       }
  


       //Constructor
       public Dueño(string pNom, List<Mascota> pMas)
       {
           Nombre = pNom;
           MisMascotas = pMas;
       }


       // operaciones
       public override string ToString()
       {
           return (Nombre.Trim() + " - " + CantMascotas.ToString().Trim() + " Mascotas");
       }


    }
}
