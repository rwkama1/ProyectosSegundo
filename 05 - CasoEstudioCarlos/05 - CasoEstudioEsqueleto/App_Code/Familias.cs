using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public class Familia
{
    //atributos
    private int _Codigo;
    private string _Nombre;

    //propiedades
    public int Codigo
    {
        get { return _Codigo; }
        set { _Codigo = value; }
    }
    public string Nombre
    {
        get { return _Nombre; }
        set { _Nombre = value; }
    }

    //contructor 
	public Familia(int pCodigo, string pNombre)
	{
        _Codigo = pCodigo;
        _Nombre = pNombre;
    }

}
