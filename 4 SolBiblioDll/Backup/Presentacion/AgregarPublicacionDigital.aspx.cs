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

using Logica;
using EntidadesCOmpartidas;


public partial class AgregarPublicacionDigital : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string oMensaje="";
        int isbn = 0;
        try
        {
            isbn = Convert.ToInt32(txtISBN.Text);
        }
        catch
        {
            oMensaje="El isbn debe ser un numero";
        }
        string titulo = txtTitulo.Text;
        string formato = txtFormato.Text;
        bool protegida = chkProtegida.Checked;
        if(oMensaje!="")
        {
            lblError.Text = oMensaje;
            txtISBN.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            Digital d = new Digital(isbn, titulo, formato, protegida);
            try
            {
                if (!LogicaPublicaciones.Agregar(d))
                {
                    lblError.Text = "Error: el ISBN ya existe, ingrese otro.";
                    txtISBN.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (ApplicationException ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}
