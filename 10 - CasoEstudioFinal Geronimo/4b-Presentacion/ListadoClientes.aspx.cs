using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListadoClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                RpClientes.DataSource = Logica.FabricaLogica.GetLogicaCliente().Listar();
                RpClientes.DataBind();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

    }

    protected void RpClientes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Listar")
        {
            try
            {
                EntidadesCompartidas.Cliente _unCliente = Logica.FabricaLogica.GetLogicaCliente().Buscar(Convert.ToInt32(((TextBox)(e.Item.Controls[1])).Text));
                List<EntidadesCompartidas.Cuenta> _miLista = Logica.FabricaLogica.GetLogicaCliente().ListaCuentasDeCliente(_unCliente);
                GVCuentas.DataSource = _miLista;
                GVCuentas.DataBind();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }
}