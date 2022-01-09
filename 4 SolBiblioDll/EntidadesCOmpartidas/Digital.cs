using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCOmpartidas
{
    public class Digital : Publicacion
    {
        private string formato;
        private bool protegida;


        public string Formato
        {
            get { return formato; }
            set { formato = value; }
        }
        public bool Protegida
        {
            get { return protegida; }
            set { protegida = value; }
        }


        public Digital() { }
        public Digital(int pISBN, string pTitulo, string pFormato, bool pProtegida)
            : base(pISBN, pTitulo)
        {
            formato = pFormato;
            protegida = pProtegida;
        }


        public override string ToString()
        {
            return "PUBLICACION DIGITAL: " + base.ToString() + " Formato: " + formato + " Protegida?: " + protegida;
        }


    }

}
