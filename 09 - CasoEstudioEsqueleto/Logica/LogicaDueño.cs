using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
   public class LogicaDueño
    {
         public static List<EntidadesCompartidas.Dueño> ListarDueñosManual()
       {
           EntidadesCompartidas.Mascota _unaMascota;
           EntidadesCompartidas.Dueño _unDueño;
           List<EntidadesCompartidas.Mascota> _Listita;
           List<EntidadesCompartidas.Dueño> _Lista = new List<EntidadesCompartidas.Dueño>();


           //Duenio 1 con 2 Mascotas
           _Listita = new List<EntidadesCompartidas.Mascota>();
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 1", "Raza Perro", 2);
           _Listita.Add(_unaMascota);
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 2", "Raza Gato", 5);
           _Listita.Add(_unaMascota);
           _unDueño = new EntidadesCompartidas.Dueño("Andrea", _Listita);
           _Lista.Add(_unDueño);


           //Duenio 2 con 5 Mascotas
          _Listita = new List<EntidadesCompartidas.Mascota>();
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 21", "Raza Perro", 1);
           _Listita.Add(_unaMascota);
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 22", "Raza Gato", 2);
           _Listita.Add(_unaMascota);
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 23", "Raza Pajaro", 1);
           _Listita.Add(_unaMascota);
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 24", "Raza Lagartija", 3);
           _Listita.Add(_unaMascota);
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 25", "Raza Tortuga", 15);
           _Listita.Add(_unaMascota);
           _unDueño = new EntidadesCompartidas.Dueño("Juan", _Listita);
           _Lista.Add(_unDueño);


           //Duenio 3 con 3 Mascotas
           _Listita = new List<EntidadesCompartidas.Mascota>();
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 31", "Raza Tortuga", 25);
           _Listita.Add(_unaMascota);
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 32", "Raza Ratoncito", 2);
           _Listita.Add(_unaMascota);
           _unaMascota = new EntidadesCompartidas.Mascota("Mascota 33", "Raza Araña", 1);
           _Listita.Add(_unaMascota);
           _unDueño = new EntidadesCompartidas.Dueño("Maria", _Listita);
           _Lista.Add(_unDueño);

           return (_Lista);
       }

    }
}
