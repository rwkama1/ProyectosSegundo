using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCOmpartidas
{
    public class Papel : Publicacion
    {
        private int peso;


        public int Peso
        {
            get { return peso; }
            set { peso = value; }
        }


        public Papel() { }
        public Papel(int pISBN, string pTitulo, int pPeso)
            : base(pISBN, pTitulo)
        {
            peso = pPeso;
        }


        public override string ToString()
        {
            return "PUBLICACION EN PAPEL: " + base.ToString() + " Peso: " + peso;

        }

    }

}
