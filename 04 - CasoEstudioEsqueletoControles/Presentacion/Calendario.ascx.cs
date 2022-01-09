using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Calendario : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //determino mismo controlador para los controles de los meses
        lbtnenero.Click += new EventHandler(DeterminoMeses);
       lbtnfebrero.Click += new EventHandler(DeterminoMeses);
       lbtnmarzo.Click += new EventHandler(DeterminoMeses);
       lbtnabril.Click += new EventHandler(DeterminoMeses);
        lbtnmayo.Click += new EventHandler(DeterminoMeses);
       lbtnjunio.Click += new EventHandler(DeterminoMeses);
       lbtnjulio.Click += new EventHandler(DeterminoMeses);
        lbtnagosto.Click += new EventHandler(DeterminoMeses);
        lbtnsetiembre.Click += new EventHandler(DeterminoMeses);
       lbtnoctubre.Click += new EventHandler(DeterminoMeses);
        lbtnnoviembre.Click += new EventHandler(DeterminoMeses);
        lbtndiciembre.Click += new EventHandler(DeterminoMeses);


    }
    protected void DeterminoMeses(object sender, EventArgs e)//el primer parametros de los controladores segun todos los delegados de net framework,presenta el objeto que provoco el evento
        //(en nuestro caso linkbutton)
    {
        //obtengo datos de la fecha seleccionada
        int anio = cfecha.SelectedDate.Year;
        int mes = cfecha.SelectedDate.Month;
        int dia = cfecha.SelectedDate.Day;
        //determino la cantidad de dias del mes que se selecciono
        //(me baso en el numero que muestra el control
        int cantidad=DateTime.DaysInMonth(anio,Convert.ToInt32(((LinkButton)sender).Text));
        //verifico para cambio de mes en el control calendar
        if(dia<=cantidad)
        {
            //esta bien el dia
            cfecha.SelectedDate=new DateTime(anio,Convert.ToInt32(((LinkButton)sender).Text),dia);
            cfecha.VisibleDate=new DateTime(anio,Convert.ToInt32(((LinkButton)sender).Text),dia);

        }
        else
        {
            //el dia no corresponde, pongo el ultimo del mes
            cfecha.SelectedDate=new DateTime(anio,Convert.ToInt32(((LinkButton)sender).Text),cantidad);
            cfecha.VisibleDate=new DateTime(anio,Convert.ToInt32(((LinkButton)sender).Text),cantidad);
        }
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnenero_Click(object sender, EventArgs e)
    {

    }
    protected void btnañoatras_Click(object sender, EventArgs e)
    {
        //le saco un año a la fecha seleccionada en el calendario
        DateTime unaFecha = cfecha.SelectedDate.AddYears(-1);
        cfecha.SelectedDate = unaFecha;
        cfecha.VisibleDate = unaFecha;
    }
    protected void btnañoadelante_Click(object sender, EventArgs e)
    {
        //le saco un año a la fecha seleccionada en el calendario
        DateTime unaFecha = cfecha.SelectedDate.AddYears(+1);
        cfecha.SelectedDate = unaFecha;
        cfecha.VisibleDate = unaFecha;

    }
    public DateTime Fecha
    {
        //propiedad que permite manejar
        get { return cfecha.SelectedDate; }
        set
        {
            cfecha.SelectedDate = value;
            cfecha.VisibleDate=value;
        }
    }
}