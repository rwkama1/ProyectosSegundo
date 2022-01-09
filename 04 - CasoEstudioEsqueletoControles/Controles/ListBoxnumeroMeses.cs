using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
namespace Controles
{
   public  class ListBoxnumeroMeses:ListBox
    {
       
        private List<int> _NumeroMeses;
       //contructor
       public ListBoxnumeroMeses()
           : base()
       {
           //cargo los Meses
           _NumeroMeses = new List<int>();
            for (int i = 1; i < 13; i++)
            {
                
                _NumeroMeses.Add(i);
            }
           //_Meses.Add("Febrero");
           //_Meses.Add("Marzo");
           //_Meses.Add("Abril");
           //_Meses.Add("Mayo");
           //_Meses.Add("Junio");
           //_Meses.Add("Julio");
           //_Meses.Add("Agosto");
           //_Meses.Add("Setiembre");
           //_Meses.Add("Octubre");
           //_Meses.Add("Noviembre");
           //_Meses.Add("Diciembre");
           //asigno la lista al list
           this.DataSource = _NumeroMeses;
           this.DataBind();
       }
       public int SelectedMesNumero
       {
           get { return (_NumeroMeses[this.SelectedIndex]); }
           set
           {
               switch(value)
               {
                   case 1:
                       {
                           this.SelectedValue = "enero";
                           break;
                       }
                   case 2:
                       {
                           this.SelectedValue = "febrero";
                           break;
                       }
                   case 3:
                       {
                           this.SelectedValue = "marzo";
                           break;
                       }
                   case 4:
                       {
                           this.SelectedValue = "abril";
                           break;
                       }
                   case 5:
                       {
                           this.SelectedValue = "mayo";
                           break;
                       }

                   case 6:
                       {
                           this.SelectedValue = "junio";
                           break;
                       }
                   case 7:
                       {
                           this.SelectedValue = "julio";
                           break;
                       }
                   case 8:
                       {
                           this.SelectedValue = "agosto";
                           break;
                       }
                   case 9:
                       {
                           this.SelectedValue = "setiembre";
                           break;
                       }
                   case 10:
                       {
                           this.SelectedValue = "octubre";
                           break;
                       }
                   case 11:
                       {
                           this.SelectedValue = "noviembre";
                           break;
                       }
                   case 12:
                       {
                           this.SelectedValue = "diciembre";
                           break;
                       }

                   default:
                       {
                           throw new InvalidCastException("El texto asignado no se corresponde con ningun mes");
                       }
               }//final switch
           }//final set
       }//final propiedad

    }
}
