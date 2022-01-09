using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
namespace Controles
{
    public class Dropdownlistdiasmes:DropDownList
    {
        private List<int> _Dias;
        public Dropdownlistdiasmes():base()
        {
            _Dias = new List<int>();
            for (int i = 1; i < 32; i++)
            {
                _Dias.Add(i);
            }
           
            this.DataSource = _Dias;
            this.DataBind();
        }
      
    }
}
