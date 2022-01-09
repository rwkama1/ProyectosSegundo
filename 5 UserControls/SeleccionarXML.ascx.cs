using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Xml;


public partial class SeleccionarXML : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {   
    }

    protected void btnSeleccionarTodos_Click(object sender, EventArgs e)
    {
        if (lstOrigen.Items.Count > 0)
        {
            //copio todos los registros a la segunda lista
            Session["Seleccion"] = ((DataTable)Session["Original"]).Copy();

            //limpio la primer lista
            ((DataTable)Session["Original"]).Rows.Clear();
            lstOrigen.Items.Clear();
            lstOrigen.DataSource = (DataTable)Session["Original"];
            lstOrigen.DataBind();

            //Actualizo la segunda Lista
            lstDestino.Items.Clear();
            lstDestino.DataSource = (DataTable)Session["Seleccion"];
            lstDestino.DataBind();
        }
    }

    protected void btnDesSeleccionarTodos_Click(object sender, EventArgs e)
    {
        if (lstDestino.Items.Count > 0)
        {
            //copio todos los registros a la primer lista
            Session["Original"] = ((DataTable)Session["Seleccion"]).Copy();

            //limpio la primer lista
            lstOrigen.Items.Clear();
            lstOrigen.DataSource = (DataTable)Session["Original"];
            lstOrigen.DataBind();

            //Actualizo la segunda Lista
            ((DataTable)Session["Seleccion"]).Rows.Clear();
            lstDestino.Items.Clear();
            lstDestino.DataSource = (DataTable)Session["Seleccion"];
            lstDestino.DataBind();
        }
    }

    protected void btnSelecionarUno_Click(object sender, EventArgs e)
    {
        if (lstOrigen.SelectedIndex > -1)
        {
            DataTable _Original = (DataTable)Session["Original"];
            DataTable _Seleccion = (DataTable)Session["Seleccion"];

            //cambio la linea de tabla
            DataRow _DRCopiar = _Original.Rows[lstOrigen.SelectedIndex];
            _Seleccion.Rows.Add(_DRCopiar.ItemArray);
            _Original.Rows.RemoveAt(lstOrigen.SelectedIndex);
           
            //Actualizo la primer lista
            lstOrigen.Items.Clear();
            lstOrigen.DataSource = _Original;
            lstOrigen.DataBind();

            //Actualizo la segunda Lista
            lstDestino.Items.Clear();
            lstDestino.DataSource = _Seleccion;
            lstDestino.DataBind();

            //determino q no hay seleccion
            lstOrigen.SelectedIndex = -1;
        }
    }

    protected void btnDesSeleccionarUno_Click(object sender, EventArgs e)
    {
        if (lstDestino.SelectedIndex > -1)
        {
            DataTable _Original = (DataTable)Session["Original"];
            DataTable _Seleccion = (DataTable)Session["Seleccion"];

            //cambio la linea de tabla
            DataRow _DRCopiar = _Seleccion.Rows[lstDestino.SelectedIndex];
            _Original.Rows.Add(_DRCopiar.ItemArray);
            _Seleccion.Rows.RemoveAt(lstDestino.SelectedIndex);

            //Actualizo la primer lista
            lstOrigen.Items.Clear();
            lstOrigen.DataSource = _Original;
            lstOrigen.DataBind();

            //Actualizo la segunda Lista
            lstDestino.Items.Clear();
            lstDestino.DataSource = _Seleccion;
            lstDestino.DataBind();

            //determino q no hay seleccion
            lstDestino.SelectedIndex = -1;
        }
    }

    

    //Propiedades
    public string TituloGeneral
    {
        set { lblTituloGeneral.Text = value; }
        get { return lblTituloGeneral.Text; }
    }

    public string TituloOrigen
    {
        set { lblTituloOrigen.Text = value; }
        get { return lblTituloOrigen.Text; }
    }

    public string TituloDestino
    {
        set { lblTituloDestino.Text = value; }
        get { return lblTituloDestino.Text; }
    }



    //Operaciones del control  
    public void CargarOrigen(DataTable unaTabla, string texto, string valor)
    {
        //muestro datos
        lstOrigen.DataSource = unaTabla;
        lstOrigen.DataTextField = texto;
        lstOrigen.DataValueField = valor;
        lstOrigen.DataBind();

        //guardo en la session los datos
        Session["Original"] = unaTabla;

        //crea una nueva tabla con la misma estructura que la original, pero sin registros - para los seleccionados
        Session["Seleccion"] = unaTabla.Clone();
        lstDestino.DataSource = (DataTable)Session["Seleccion"];
        lstDestino.DataTextField = texto;
        lstDestino.DataValueField = valor;
        lstDestino.DataBind();

    }

    public DataTable DevolverSeleccionados()
    {
        return (DataTable)Session["Seleccion"];
    }

   
}
