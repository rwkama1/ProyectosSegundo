using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
    }

    protected void Logueo_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            int _Ci = Convert.ToInt32(Logueo.UserName.Trim());
            string _Pass = Logueo.Password.Trim();
            EntidadesCompartidas.Empleado _unEmpleado = Logica.FabricaLogica.GetLogicaEmpleado().Logueo(_Ci, _Pass);

            if (_unEmpleado == null)
                LblError.Text = "CI o Pass Invalidos";
            else
            {
                Session["Usuario"] = _unEmpleado;
                Response.Redirect("~/PaginaInicialEmp.aspx");
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }

    }

}