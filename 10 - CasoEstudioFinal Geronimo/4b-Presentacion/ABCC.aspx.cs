using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABCC : System.Web.UI.Page
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
        TxtCliente.Text = "";
        TxtMinimo.Text = "";
        LblCliente.Text = "";
        LblError.Text = "";
        Session["UnCliente"] = null;
    }

    private void ActualizoGrilla()
    {
        GrVCuentas.DataSource = Logica.FabricaLogica.GetLogicaCuenta().ListarCuentaCorriente();
        GrVCuentas.DataBind();
    }
     
    protected void BtnBuscarCliente_Click(object sender, EventArgs e)
    {
        try
        {
            //busco al cliente
            EntidadesCompartidas.Cliente _unCliente = null;
            _unCliente = Logica.FabricaLogica.GetLogicaCliente().Buscar(Convert.ToInt32(TxtCliente.Text));
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

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            //verifico que tenga cliente
            if (Session["UnCliente"] == null)
                throw new Exception("No hay Cliente Asignado - No se crea la cuenta");

            //doy de alta a la cuenta
            EntidadesCompartidas.CuentaCorriente _cuenta = new EntidadesCompartidas.CuentaCorriente(0, (EntidadesCompartidas.Cliente)Session["UnCliente"] , 0, Convert.ToInt32(TxtMinimo.Text));
            Logica.FabricaLogica.GetLogicaCuenta().Alta(_cuenta);
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
            EntidadesCompartidas.Cuenta _unaCuenta = Logica.FabricaLogica.GetLogicaCuenta().Buscar(Convert.ToInt32(GrVCuentas.SelectedRow.Cells[3].Text));

            //trato de eliminar la cuenta
            if (_unaCuenta == null)
                throw new Exception("No se encontro la Cuenta para Eliminarla");
            else
                Logica.FabricaLogica.GetLogicaCuenta().Baja(_unaCuenta);

            //si llego aca, todo ok
            this.LimpioControles();
            this.ActualizoGrilla();
            LblError.Text = "Se elimino Exitosamente";


        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
        this.LimpioControles();
        this.ActualizoGrilla();
    }

}