using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class Articulo
    {
        //atributos
        private int _codigo;
        private string _nombre;
        private decimal _precio;
        private Familia _miFamilia;
        
        //propiedades
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public Familia MiFamilia
        {
            get { return _miFamilia; }
            set { _miFamilia = value; }
        }

        //Contructor
        public Articulo(int pCodigo, string pNombre, decimal pPrecio, Familia pFamilia)
        {
            _codigo = pCodigo;
            _nombre = pNombre;
            _precio = pPrecio;
            _miFamilia = pFamilia;
        }
 
}
