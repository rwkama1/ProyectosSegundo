using System;
using System.Collections;
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

using System.Data.SqlClient;

public partial class _08_ControlSqlDataSource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void BtnConsulta_Click(object sender, EventArgs e)
    {
 
    }
    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        //verifico que se haya ingresado un numero en el codigo
        try
        {
            //el dato de conversion numero lo hacemos para evitar que no se parta la informacion cuando se comunica con la base de datos
            //En el caso del delete escpescificamente, me va a devolver la cantidad de reigstros afectados,es exactamente lo que hace
            //el ExecuteNonQuery del SqlCommand, no podemos capturar return value de un procedimiento almacenado,pero si saber la cantidad
            //de regitros que se afectaron con la accion
            
            int unCodigo = Convert.ToInt32(txtCodigo.Text);
            //si tengo numero,borro
            //if (unCodigo == SdsArticulos.Delete())
            //{
                SdsArticulos.Delete();
               
                LblError.Text = "Eliminacion Exitosa";
            //}
            //else
            //{
            //    LblError.Text = "Ese numero no existe";
            //}
        }
        catch(Exception ex)
        {
            LblError.Text = "Error tratando de borrar" + ex.Message;
        }
    }
}
