using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Logica;
using EntidadesCOmpartidas;

public partial class IngresarPrestamo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Publicacion> oPublicaciones = LogicaPublicaciones.ListarPublicaciones();
     
        //Muestro en un ComboBox todos los ISBN de las publicaciones
        if (oPublicaciones.Count > 0)
        {
            cboPublicaciones.DataSource = oPublicaciones;
            cboPublicaciones.DataTextField = "Titulo";
            cboPublicaciones.DataValueField = "ISBN";
            cboPublicaciones.DataBind();
        }
        else
        {
            lblError.Text = "Error: no existe ninguna publicación. Debe ingresar una primero.";
            txtDias.Enabled = false;
            txtUsuario.Enabled = false;
            btnAgregar.Enabled = false;
            cboPublicaciones.Enabled = false;
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string oMensaje = "";
        int isbn=0;
        int dias=0;
        string usuario = txtUsuario.Text;
        try
        {
            isbn = Convert.ToInt32(cboPublicaciones.SelectedValue);
            dias = Convert.ToInt32(txtDias.Text);
        }
        catch
        {
            oMensaje = "El isbn no es un numeros";
        }
        if (oMensaje != "")
        {
            lblError.Text = oMensaje;
            lblError.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            try
            {
                Publicacion pub = LogicaPublicaciones.Buscar(isbn);
                Prestamo pre = new Prestamo(0, clnFechaPrestado.SelectedDate, dias, usuario, false, pub);
                if (LogicaPrestamos.Agregar(pre))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblError.Text = "El numero de prestamo esta repetido,";
                    lblError.BackColor = System.Drawing.Color.Red;
                }
            }
            catch (ApplicationException ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}