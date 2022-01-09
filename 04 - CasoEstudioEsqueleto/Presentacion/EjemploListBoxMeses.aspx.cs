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

public partial class EjemploListBoxMeses : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSeleccionString_Click(object sender, EventArgs e)
    {
        try
        {
            LbMeses.SelectedMes = TxtMesString.Text.Trim();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnRevisar_Click(object sender, EventArgs e)
    {
        TxtMesRev.Text = LbMeses.SelectedMes;
    }

    protected void BtnSeleccionInt_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnSeleccionarnumero_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    LBlistboxnumeromeses.SelectedMesNumero = txtmes.Text.ToString();

        //}
    }
}
