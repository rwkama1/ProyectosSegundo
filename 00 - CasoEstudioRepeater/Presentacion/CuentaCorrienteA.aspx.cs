using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CuentaCorrienteA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //primer acceso a la pagina - cargo grilla con las cuentas corrientes que hay para que se puedan eliminar
                this.LimpioControles();
                this.ActualizoGrilla();
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    private void LimpioControles()
    {
        TxtMinimo.Text = "";
        LblError.Text = "";
        Session["UnCliente"] = null;
    }

    private void ActualizoGrilla()
    {
        GrVCuentas.DataSource = Logica.LogicaCuenta.CuentaCorrienteListar();
        GrVCuentas.DataBind();
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            //busco al cliente
            if (Session["UnCliente"] == null)
                throw new Exception("No se selecciono al cliente");

            //doy de alta a la cuenta
            EntidadesCompartidas.CuentaCorriente _cuenta = new EntidadesCompartidas.CuentaCorriente(0,(EntidadesCompartidas.Cliente)Session["UnCliente"],0,Convert.ToInt32(TxtMinimo.Text));
            Logica.LogicaCuenta.CuentaAlta(_cuenta);
            this.LimpioControles();
            this.ActualizoGrilla();

            //si llego aca todo ok
            LblError.Text = "Alta con Exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void GrVCuentas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //determino la cuenta a eliminar
            EntidadesCompartidas.Cuenta _unaCuenta = Logica.LogicaCuenta.CuentaBuscar(Convert.ToInt32(GrVCuentas.SelectedRow.Cells[1].Text));

            //trato de eliminar la cuenta
            Logica.LogicaCuenta.CuentaBaja(_unaCuenta);
            this.LimpioControles();
            this.ActualizoGrilla();

            //si llego aca, todo ok
            LblError.Text = "Se elimino Exitosamente";

        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }

    protected void BtnBuscarCliente_Click(object sender, EventArgs e)
    {
        try
        {
            //busco al cliente
            EntidadesCompartidas.Cliente _unCliente = null;
            _unCliente = Logica.LogicaCliente.ClienteBuscar(Convert.ToInt32(TxtCliente.Text));
            if (_unCliente == null)
                throw new Exception("No se encontro al cliente");
            else
            {
                Session["UnCliente"] = _unCliente;
                LblCliente.Text = _unCliente.NomCli;
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
        this.LimpioControles();
    }
}