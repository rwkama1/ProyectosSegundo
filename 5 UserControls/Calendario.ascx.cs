using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Calendario : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
   
    protected void BtnAnioAtras_Click(object sender, EventArgs e)
    {
        //le saco un año a la fecha seleccionada en el calendario
        DateTime unaFecha = CFecha.SelectedDate;
        unaFecha = unaFecha.AddYears(-1);
        CFecha.SelectedDate = unaFecha;
        CFecha.VisibleDate = unaFecha;
        //cargo el combo con el mes
        ddlMeses.SelectedIndex = unaFecha.Month - 1;
    }
   
    protected void btnAñoAdelante_Click(object sender, EventArgs e)
    {
        //le agrego un año a la fecha seleccionada en el calendario
        DateTime unaFecha = CFecha.SelectedDate;
        unaFecha = unaFecha.AddYears(1);
        CFecha.SelectedDate = unaFecha;
        CFecha.VisibleDate = unaFecha;
        //cargo el combo con el mes
        ddlMeses.SelectedIndex = unaFecha.Month - 1;
    }
   
    public DateTime Fecha
    {
        get { return CFecha.SelectedDate; }
        set 
        { 
            CFecha.SelectedDate = value;
            CFecha.VisibleDate = value;
            //cargo el combo con el mes
            ddlMeses.SelectedIndex = value.Month - 1;

        }
    }

    protected void ddlMeses_SelectedIndexChanged(object sender, EventArgs e)
    {
        //obtengo datos
        int anio = CFecha.SelectedDate.Year;
        int mes = CFecha.SelectedDate.Month;
        int dia = CFecha.SelectedDate.Day;
        //determino la cantidad de dias del mes que se selecciono
        int cantidad = DateTime.DaysInMonth(anio, Convert.ToInt32(ddlMeses.SelectedValue));
        if (dia <= cantidad)
        {
            //esta bien el dia
            CFecha.SelectedDate = new DateTime(anio, Convert.ToInt32(ddlMeses.SelectedValue), dia);
            CFecha.VisibleDate = new DateTime(anio, Convert.ToInt32(ddlMeses.SelectedValue), dia);
        }
        else
        {
            //el dia no corresponde, pongo el ultimo del mes
            CFecha.SelectedDate = new DateTime(anio, Convert.ToInt32(ddlMeses.SelectedValue), cantidad);
            CFecha.VisibleDate = new DateTime(anio, Convert.ToInt32(ddlMeses.SelectedValue), cantidad);
        }
    }
    
    protected void CFecha_SelectionChanged(object sender, EventArgs e)
    {
        //cargo el combo con el mes
        ddlMeses.SelectedIndex = CFecha.SelectedDate.Month - 1;


    }
}
