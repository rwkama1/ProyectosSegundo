using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente : IComparable
    {

        //atributos
        private int _NumCli;
        private string _NomCli;
        private string _DirCli;


        //Propiedades
        public int NumCli
        {
            get { return _NumCli; }
            set { _NumCli = value; }
        }

        public string NomCli
        {
            get { return _NomCli; }
            set
            {
                if ((value.Trim().Length > 30) || (value.Trim().Length <= 0))
                    throw new Exception("Error en Nombre cliente");
                else
                    _NomCli = value;
            }
        }

        public string DirCli
        {
            get { return _DirCli; }
            set
            {
                if ((value.Trim().Length > 30) || (value.Trim().Length <= 0))
                    throw new Exception("Error en Direccion cliente");
                else
                    _DirCli = value;
            }
        }


        //Constructor Completo
        public Cliente(int pNumCli, string pNomCli, string pDirCli)
        {
            _NumCli = pNumCli;
            NomCli = pNomCli;
            DirCli = pDirCli;
        }


        //operaciones
        public int CompareTo(Object obj)
        {
            Cliente _parametro = (Cliente)obj;
            if (this == null)
                return 1;
            else if (_parametro == null)
                return -1;
            else 
                return (this.NomCli.CompareTo(_parametro.NomCli));
        }

    }
}
