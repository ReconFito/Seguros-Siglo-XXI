using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SegurosSigloXXI.Clases
{
    public class EnlaceData
    {
        public void EnlazarGridView(GridView elemento, object recurso)
        {
            elemento.DataSource = recurso;
            elemento.DataBind();
        }
        public void EnlazarDropDownList(DropDownList elemento, object recurso)
        {
            elemento.DataSource = recurso;
            elemento.DataBind();
        }
    }
}