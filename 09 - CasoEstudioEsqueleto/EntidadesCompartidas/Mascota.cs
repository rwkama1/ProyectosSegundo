using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
   public class Mascota
    {
       //atributos
       private string _Nombre;
       private string _Raza;
       private int _Edad;


       //properties
       public string Nombre
       {
           get { return _Nombre; }
           set { _Nombre = value; }
       }

       public string Raza
       {
           get { return _Raza; }
           set { _Raza = value; }
       }

       public int Edad
       {
           get { return _Edad; }
           set {
               if (value >= 0)
                   _Edad = value;
               else
                   throw new Exception("Edad Invalida para la Mascota");
           }
       }


       //Constructores
       public Mascota(string pNom, string pRaza, int pEdad)
       {
           Edad = pEdad;
           Raza = pRaza;
           Nombre = pNom;
       }


    }
}
