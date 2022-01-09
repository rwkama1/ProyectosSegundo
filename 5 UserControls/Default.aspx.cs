using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //seteos para el User Control de Calendario
            Calendario.Fecha = DateTime.Now;

            //Seteos para el user control de SeleccionarXML
            SeleccionarXML1.TituloGeneral = "Generar un Nuevo Archivo XML";
            SeleccionarXML1.TituloOrigen = "Datos en el archivo XML Original";
            SeleccionarXML1.TituloDestino = "Datos para el nuevo archivo  de XML";
            DataSet _ds = new DataSet();
            _ds.ReadXml(Server.MapPath("Libros.xml"));
            SeleccionarXML1.CargarOrigen(_ds.Tables[0], "Titulo", "ISBN");
        }
    }


    protected void btnVer_Click(object sender, EventArgs e)
    {
        txtFecha.Text = Calendario.Fecha.ToShortDateString();
    }


    protected void BtnCrearXML_Click(object sender, EventArgs e)
    {
        //obtengo los nuevos datos
        DataSet _ds = new DataSet("Libros");
        DataTable _dt = SeleccionarXML1.DevolverSeleccionados();
        _ds.Tables.Add(_dt);

        //creo el archivo con los nuevos datos
        _ds.WriteXml(Server.MapPath("Libros.xml"));

        //refresco el user control
        SeleccionarXML1.CargarOrigen(_ds.Tables[0], "Titulo", "ISBN");

    }
}
