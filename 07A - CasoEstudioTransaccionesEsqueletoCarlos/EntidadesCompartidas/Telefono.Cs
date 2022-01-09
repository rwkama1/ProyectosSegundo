using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Telefono
    {
        //atributos
        private string _UnTelefono;

        //Propiedades
        public string UnTelefono
        {
            get { return _UnTelefono; }
            set {
                if (value.Trim().Length > 12)
                    throw new Exception("Muchos Numeros para el Telefono");

                if (value.Trim().Length == 0)
                    throw new Exception("El telefono debe tener algo");

                try
                {
                    Convert.ToInt64(value);
                }
                catch
                {
                    throw new Exception("El telefono solo puede tener numeros");
                }

                _UnTelefono = value;
            }
        }

        //constructor
        public Telefono(string pUnTelefono)
        {
            UnTelefono = pUnTelefono;
        }
    }
}
