using System;
using System.Collections.Generic;
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

public partial class ListarArticulos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Articulo> _lista = FabricaLogica.getLogicaArticulos().ListarArticulo();
        //_lista.Sort();
        gvListado.DataSource = _lista;
        gvListado.DataBind();
 
    }

}
