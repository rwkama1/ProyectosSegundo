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


public partial class ListarTodosLosPrestamos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<Prestamo> prestamos = LogicaPrestamos.ListarPrestamos();
            for (int i = 0; i < prestamos.Count; i++)
            {
                lstPrestamos.Items.Add(((Prestamo)prestamos[i]).ToString());
            }
        }
        catch (ApplicationException ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
