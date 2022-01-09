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


public partial class AgregarPublicacionPapel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string oMensaje = "";
        int isbn = 0;
        int peso = 0;
        string titulo = txtTitulo.Text;
        try
        {
            isbn = Convert.ToInt32(txtISBN.Text);
            peso = Convert.ToInt32(txtPeso.Text);
        }
        catch
        {
            oMensaje = "El isbn y el peso deben ser numeros";
        }
        if (oMensaje != "")
        {
            lblError.Text = oMensaje;
            txtISBN.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            Papel p = new Papel(isbn, titulo, peso);
            try
            {
                if (!LogicaPublicaciones.Agregar(p))
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
