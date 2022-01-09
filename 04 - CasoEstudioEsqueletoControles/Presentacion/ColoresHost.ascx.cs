using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class ColoresHost : System.Web.UI.UserControl
{
    //atributos
    protected int _indiceActualColor;
    protected string[] _colores = { "Red", "Blue", "Green", "Yellow" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            _indiceActualColor = Convert.ToInt16(ViewState["_indiceActualColor"].ToString());
        }
        else
        {
            _indiceActualColor = 0;
            DesplegarColor();
        }


    }
    protected void DesplegarColor()
    {
        txtcolor.Text = _colores[_indiceActualColor];
        ViewState["_indiceActualColor"] = _indiceActualColor.ToString();
    }
    protected void btnatras_Click(object sender, EventArgs e)
    {
        if (_indiceActualColor == 0)
            _indiceActualColor = _colores.Length - 1;
        else
            _indiceActualColor -= 1;
        DesplegarColor();
    }
    protected void btnadelante_Click(object sender, EventArgs e)
    {
        if (_indiceActualColor == (_colores.Length - 1))
            _indiceActualColor = 0;
        else
            _indiceActualColor += 1;
        DesplegarColor();

    }
    protected void btnaplicar_Click(object sender, EventArgs e)
    {
        btnaplicar.BackColor = System.Drawing.Color.FromName(_colores[_indiceActualColor]);//system.drawing es un espacio de
        //nombres a partir del cual tenemos la definiciones de todos los elementos necesarios,
        //para manejar formas letras y colores, en la interfaz grafica,de ahi provienen los tipos de datos, Font y Color que nos permiten cambiar en los controles
        //todo lo que tenga que ver con la fuentes y los colores
        //La clase Color tiene una operacion de clase llamada FromName, que dado el nombre de una constante de color, me devuelve un objeto,
        //de tipo color, que lo representa
        
    }
    protected void btnaplicarhost_Click(object sender, EventArgs e)
    {
        try
        {
            //obtengo referencia a mi pagina host
            //(donde se coloco el control)
            HtmlForm _paginaHost = (HtmlForm)this.Parent;
            //busco los tres controles que voy a modificar
            Label _lblPrueba = (Label)_paginaHost.FindControl("lblPrueba");
            TextBox _txtPrueba = (TextBox)_paginaHost.FindControl("txtPrueba");
            Button _btnPrueba = (Button)_paginaHost.FindControl("btnPrueba");
          
            //modifico color de despliegue de dichos controles
            _lblPrueba.ForeColor = System.Drawing.Color.FromName(_colores[_indiceActualColor]);
            _btnPrueba.BackColor = System.Drawing.Color.FromName(_colores[_indiceActualColor]);
            _txtPrueba.ForeColor = System.Drawing.Color.FromName(_colores[_indiceActualColor]);
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
    }
}