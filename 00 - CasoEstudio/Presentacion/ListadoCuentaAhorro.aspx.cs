using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListadoCuentaAhorro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnbuscarahorrocliente_Click(object sender, EventArgs e)
    {
        try
        {

            EntidadesCompartidas.Cliente _unCliente = null;
            _unCliente = Logica.LogicaCliente.ClienteBuscar(Convert.ToInt32(txtcuentaahorro.Text));
            List<EntidadesCompartidas.CuentaCAhorro> _lista = Logica.LogicaCuenta.BuscarCuentaAhorroporcliente(_unCliente);
            //_lista.Sort();
           gdrcuentaahorrocliente.DataSource = _lista;
           gdrcuentaahorrocliente.DataBind();
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }
}