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


using Logica;
using EntidadesCOmpartidas;

public partial class EjemploCompletoGrilla : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cargo dos listas en la session para trabajar
            Session["_listaC"] = LogicaPublicaciones.ListarPublicaciones();
            Session["_listaS"] = new List<Publicacion>();
            //cargo las dos grillas
            GVCompleto.DataSource = (List<Publicacion>)Session["_listaC"];
            GVCompleto.DataBind();
            GVSeleccion.DataSource = (List<Publicacion>)Session["_listaS"];
            GVSeleccion.DataBind();
        }
    }
    protected void btnVer_Click(object sender, EventArgs e)
    {
        try
        {
            // primero verifico que haya una linea seleccionada
            if (GVCompleto.SelectedRow != null)
            {
                //saco el identificador de publicacion y lo busco 
                int isbn = Convert.ToInt32(GVCompleto.SelectedRow.Cells[2].Text);
                Publicacion pub = LogicaPublicaciones.Buscar(isbn);
                lblerror.Text = "Ud. Selecciono la Publicacion " + pub.ToString();
            }
        }
        catch
        {
        }
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
       List<Publicacion> _listaC = (List<Publicacion>)Session["_listaC"];
       try
       {
           // primero verifico que haya una linea seleccionada
           if (GVCompleto.SelectedRow != null)
           {
               //saco el identificador de publicacion y lo borro de la lista completa
               _listaC.RemoveAt(GVCompleto.SelectedRow.RowIndex);
               GVCompleto.DataSource = _listaC;
               GVCompleto.DataBind();
           }
       }
       catch
       {
       }
    }

    protected void btnCopiar_Click(object sender, EventArgs e)
    {
        Publicacion pub = null;
        List<Publicacion> _listaS = (List<Publicacion>)Session["_listaS"];

        // primero verifico que haya una linea seleccionada
        if (GVCompleto.SelectedRow != null)
        {
            try
            {
                //saco el identificador de publicacion y lo borro de la lista completa
                int isbn = Convert.ToInt32(GVCompleto.SelectedRow.Cells[2].Text);
                pub = LogicaPublicaciones.Buscar(isbn);
                _listaS.Add(pub);
                GVSeleccion.DataSource = _listaS;
                GVSeleccion.DataBind();
            }
            catch
            {
            }
        }
    }
    protected void GVCompleto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
