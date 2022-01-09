using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListadoCuentaCorrienteporcliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
            // int numerocliente=0;
            //   EntidadesCompartidas.Cliente _unCliente = null;
            //   _unCliente = Logica.LogicaCliente.ClienteBuscar(Convert.ToInt32());
            //   List<EntidadesCompartidas.CuentaCorriente> _lista = Logica.LogicaCuenta.BuscarCuentaCorrienteporcliente(_unCliente);
            //_lista.Sort();
            //gdrcuentacorrienteporcliente.DataSource = _lista;
            //gdrcuentacorrienteporcliente.DataBind();
        
    }
    protected void btnBuscarCorriente_Click(object sender, EventArgs e)
    {
        try
        {

            EntidadesCompartidas.Cliente _unCliente = null;
            _unCliente = Logica.LogicaCliente.ClienteBuscar(Convert.ToInt32(txtcorriente.Text));
            List<EntidadesCompartidas.CuentaCorriente> _lista = Logica.LogicaCuenta.BuscarCuentaCorrienteporcliente(_unCliente);
            //_lista.Sort();
            gdrcuentacorrienteporcliente.DataSource = _lista;
            gdrcuentacorrienteporcliente.DataBind();
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }

    }
}