using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCOmpartidas
{
    public class Publicacion
    {
        private int isbn;
        private string titulo;


        public int ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }


        public Publicacion() { }
        public Publicacion(int pISBN, string pTitulo)
        {
            isbn = pISBN;
            titulo = pTitulo;
        }


        public override string ToString()
        {
            return "Título: " + titulo + " ISBN: " + isbn;
        }

    }
}
