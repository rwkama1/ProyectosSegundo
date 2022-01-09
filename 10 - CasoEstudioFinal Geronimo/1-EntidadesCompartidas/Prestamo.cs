using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Prestamo
    {
        private string _codigo;
        private Cliente _cliente;
        private double _monto;
        private int _cuotas;

        public string Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 9)
                {
                    throw new Exception("El codigo no tiene el formato correcto");
                }
                else
                {
                    _codigo = value;
                }
            }
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("El cliente no puede ser nulo");
                }
                else
                {
                    _cliente = value;
                }
            }
        }

        public double Monto
        {
            get
            {
                return _monto;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("El monto no puede ser menor o igual a 0");
                }
                else
                {
                    _monto = value;
                }
            }
        }

        public int Cuotas
        {
            get
            {
                return _cuotas;
            }
            set
            {
                if (value <= 0 || value > 24)
                {
                    throw new Exception("La catidad de cuotas no puede ser mayor a 24 o menor/igual a 0");
                }
                else

                {
                    _cuotas = value;
                }
            }
        }

        public Prestamo(string codigo, Cliente cliente, double monto, int cuotas)
        {
            Codigo = codigo;
            Cliente = cliente;
            Monto = monto;
            Cuotas = cuotas;
        }

    }
}
