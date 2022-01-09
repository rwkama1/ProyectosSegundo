using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
namespace Controles
{
    public class DropDownListaños:DropDownList
    {
          private List<int> _Años;
        public DropDownListaños():base()
        {
            _Años = new List<int>();
            for (int i = 100; i < 2100; i++)
            {
                _Años.Add(i);

            }
           
            this.DataSource = _Años;
            this.DataBind();
        }
        //public int Selectedaño
        //{
        //    get { return (_Años[this.SelectedIndex]); }
        //    set
        //    {
        //        switch (value)
        //        {
        //            case 1:
        //                {
        //                    this.SelectedIndex = 1;
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    this.SelectedIndex = 2;
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    this.SelectedIndex = 2;
        //                    break;
        //                }
        //            case 4:
        //                {
        //                    this.SelectedIndex = 3;
        //                    break;
        //                }
        //            case 5:
        //                {
        //                    this.SelectedIndex = 4;
        //                    break;
        //                }
        //            case 6:
        //                {
        //                    this.SelectedIndex = 5;
        //                    break;
        //                }
        //            case 7:
        //                {
        //                    this.SelectedIndex = 6;
        //                    break;
        //                }
        //            case 8:
        //                {
        //                    this.SelectedIndex = 7;
        //                    break;
        //                }
        //            case 9:
        //                {
        //                    this.SelectedIndex = 8;
        //                    break;
        //                }
        //            case 10:
        //                {
        //                    this.SelectedIndex = 9;
        //                    break;
        //                }
        //            case "noviembre":
        //                {
        //                    this.SelectedIndex = 10;
        //                    break;
        //                }
        //            case "diciembre":
        //                {
        //                    this.SelectedIndex = 11;
        //                    break;
        //                }
        //            default:
        //                {
        //                    throw new InvalidCastException("El texto asignado no se corresponde con ningun mes");
        //                }
        //        }//final switch
        //    }//final set
        //}//final propiedad
    }
}
