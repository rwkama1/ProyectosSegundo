using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using EntidadesCompartidas;
using Logica;
using Persistencia;

public partial class AltaArticulo : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int codigo;
        decimal precio;
        string nombre;
        Articulo A;
        try
        {
            codigo = Convert.ToInt32(txtCodigo.Text);
            precio = Convert.ToInt32(txtPrecio.Text);
            nombre = txtNombre.Text;
            A = new Articulo(codigo, nombre, precio);
            FachadaLogica.AgregarArticulo(A);
            lblError.Text = "Alta con Exito";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCodigo.Text = "";

        }
        catch(Exception ex) 
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btneliminar_Click(object sender, EventArgs e)
    {
        //int codigo;
          
        //try
        //{

        //    Articulo Art =  FachadaLogica.EliminarArticulo(Art);
        //    lblError.Text = "Elimino con Exito";
            
           

        //}
        //catch (Exception ex)
        //{
        //    lblError.Text = ex.Message;
        //}
    }
}
