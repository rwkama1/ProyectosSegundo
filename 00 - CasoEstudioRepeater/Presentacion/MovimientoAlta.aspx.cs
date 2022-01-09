using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovimientoAlta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //primer acceso a la pagina
                this.LimpioControles();
                DDLCuenta.DataSource = Logica.LogicaCuenta.CuentaListarTodas();
                DDLCuenta.DataTextField = "NumCta";
                DDLCuenta.DataValueField = "NumCta";
                DDLCuenta.DataBind();
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    private void LimpioControles()
    {
        TxtMonto.Text = "";
        RbtnRetiro.Checked = true;
        LblError.Text = "";
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            //busco a la cuenta
            EntidadesCompartidas.Cuenta _unaCuenta = null;
            _unaCuenta = Logica.LogicaCuenta.CuentaBuscar(Convert.ToInt32(DDLCuenta.SelectedValue));
            if (_unaCuenta == null)
                throw new Exception("No se encontro a la cuenta");

            //doy de alta el movimiento
            if (RBTNDeposito.Checked)
            {
                _unaCuenta.Deposito(Convert.ToDouble(TxtMonto.Text));
                Logica.LogicaMovimiento.MovimientoAlta(new EntidadesCompartidas.Movimiento(0, DateTime.Now, Convert.ToDouble(TxtMonto.Text), "D", _unaCuenta));
            }
            else
            {
                _unaCuenta.Retiro(Convert.ToDouble(TxtMonto.Text));
                Logica.LogicaMovimiento.MovimientoAlta(new EntidadesCompartidas.Movimiento(0, DateTime.Now, Convert.ToDouble(TxtMonto.Text), "R", _unaCuenta));
            }
            this.LimpioControles();
            LblError.Text = "Alta con Exito";
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