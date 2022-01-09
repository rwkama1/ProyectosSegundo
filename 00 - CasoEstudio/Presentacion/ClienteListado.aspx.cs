using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClienteListado : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            List<EntidadesCompartidas.Cliente> _lista=  Logica.LogicaCliente.ClienteListar();
            _lista.Sort();
            DGVListado.DataSource = _lista;
            DGVListado.DataBind();
        //}
        //catch (Exception ex)
        //{ }
    }
 
}