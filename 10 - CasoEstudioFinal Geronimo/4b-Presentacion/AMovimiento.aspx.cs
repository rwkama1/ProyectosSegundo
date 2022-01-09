using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AMovimiento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioControles();
    }

    protected void LimpioControles() 
    {
        TxtCuentaN.Text = "";
        LblCuenta.Text = "";
        TxtMonto.Text = "";
        RbtnRetiro.Checked = true;
        LblError.Text = "";
        Session["Cuenta"] = null;
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            //busco a la cuenta
            if ( Session["Cuenta"] == null)
                throw new Exception("No se Asigno Cuenta Valida");

            //doy de alta el movimiento
            if (RBTNDeposito.Checked)
            {
                Logica.FabricaLogica.GetLogicaMovimiento().MovimientoAlta(new EntidadesCompartidas.Movimiento(0, DateTime.Now, Convert.ToDouble(TxtMonto.Text), "D", (EntidadesCompartidas.Cuenta) Session["Cuenta"]));
            }
            else
            {
                Logica.FabricaLogica.GetLogicaMovimiento().MovimientoAlta(new EntidadesCompartidas.Movimiento(0, DateTime.Now, Convert.ToDouble(TxtMonto.Text), "R", (EntidadesCompartidas.Cuenta)Session["Cuenta"]));
            }

            //Si llego aca, salio todo OK
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

    protected void BtnBuscarCuenta_Click(object sender, EventArgs e)
    {
        try
        {
            //busco la cuenta
            EntidadesCompartidas.Cuenta _unaCuenta = Logica.FabricaLogica.GetLogicaCuenta().Buscar(Convert.ToInt32(TxtCuentaN.Text));

            //Verifico q exista
            if (_unaCuenta == null)
                throw new Exception("La cuenta no existe");
            else
            {
                Session["Cuenta"] = _unaCuenta;
                LblCuenta.Text = _unaCuenta.ToString();
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

}