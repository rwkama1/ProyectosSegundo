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

public partial class EjemploHostControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnCarga_Click(object sender, EventArgs e)
    {
        try
        {
            GrillasArticulos1.CargoArticulo();
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
 
    }

    protected void BtnMuestra_Click(object sender, EventArgs e)
    {
        try
        {
            DataRow _dr = GrillasArticulos1.ArticuloSeleccionado;
            txtCodigo.Text = _dr[0].ToString();
            txtnombre.Text = _dr[1].ToString();
            txtprecio.Text = _dr[2].ToString();

        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }

}
