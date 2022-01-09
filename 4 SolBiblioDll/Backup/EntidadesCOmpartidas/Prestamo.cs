using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCOmpartidas
{
    public class Prestamo
    {
        private int numero;
        private DateTime fecha;
        private int dias;
        private string nombreUsuario;
        private bool devuelto;
        private Publicacion pub;


        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public int Dias
        {
            get { return dias; }
            set { dias = value; }
        }
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        public bool Devuelto
        {
            get { return devuelto; }
            set { devuelto = value; }
        }
        public Publicacion Pub
        {
            get { return pub; }
            set { pub = value; }
        }


        public Prestamo() { }
        public Prestamo(int pNumero, DateTime pFecha, int pDias, string pNombreUsuario, bool pDevuelto, Publicacion pPub)
        {
            numero = pNumero;
            fecha = pFecha;
            dias = pDias;
            nombreUsuario = pNombreUsuario;
            devuelto = pDevuelto;
            pub = pPub;
        }


        public override string ToString()
        {
            return "PRESATMO: Número: " + numero + " Fecha: " + fecha.ToShortDateString() + " Dias: " + dias + " Usuario: " + nombreUsuario +
                " Devuelta?: " + devuelto + " Publicación: " + pub.Titulo;
        }
    }

}
