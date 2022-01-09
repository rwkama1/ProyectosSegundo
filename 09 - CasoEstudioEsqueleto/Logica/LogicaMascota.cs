using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class LogicaMascota
    {

        public static List<EntidadesCompartidas.Mascota> ListarMascotasManual()
        {
            EntidadesCompartidas.Mascota _unaMascota;
            List<EntidadesCompartidas.Mascota> _Lista = new List<EntidadesCompartidas.Mascota>();
 

            _unaMascota = new EntidadesCompartidas.Mascota("Mascota 1", "Raza Perro", 2);
            _Lista.Add(_unaMascota);
            _unaMascota = new EntidadesCompartidas.Mascota("Mascota 2", "Raza Gato", 5);
            _Lista.Add(_unaMascota);
            _unaMascota = new EntidadesCompartidas.Mascota("Mascota 3", "Raza Perro", 1);
            _Lista.Add(_unaMascota);
            _unaMascota = new EntidadesCompartidas.Mascota("Mascota 4", "Raza Gato", 2);
            _Lista.Add(_unaMascota);
            _unaMascota = new EntidadesCompartidas.Mascota("Mascota 5", "Raza Pajaro", 1);
            _Lista.Add(_unaMascota);
            _unaMascota = new EntidadesCompartidas.Mascota("Mascota 6", "Raza Lagartija", 3);
            _Lista.Add(_unaMascota);
            _unaMascota = new EntidadesCompartidas.Mascota("Mascota 7", "Raza Tortuga", 15);
            _Lista.Add(_unaMascota);
             _unaMascota = new EntidadesCompartidas.Mascota("Mascota 8", "Raza Tortuga", 25);
             _Lista.Add(_unaMascota);
            _unaMascota = new EntidadesCompartidas.Mascota("Mascota 9", "Raza Ratoncito", 2);
            _Lista.Add(_unaMascota);
            _unaMascota = new EntidadesCompartidas.Mascota("Mascota 10", "Raza Araña", 1);
            _Lista.Add(_unaMascota);
 
            return (_Lista);
        }
    }
}
