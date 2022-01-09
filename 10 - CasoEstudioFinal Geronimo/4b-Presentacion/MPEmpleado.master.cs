using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MPEmpleado : System.Web.UI.MasterPage
{//la idea de la master page es reutilizar codigo y si la uso con los logueos tengo que asegurarme de que el codigo de control este
    //en la master page y no en las paginas
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !(Session["Usuario"] is EntidadesCompartidas.Empleado))//no hay que verificar que en la session halla un objeto, sino q el objeto sea del tipo correspondiente
            Response.Redirect("~/Default.aspx");
    }

    protected void BtnSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
