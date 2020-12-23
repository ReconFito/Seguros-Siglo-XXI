using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SegurosSigloXXI.Clases
{
    interface EventosGridView
    {
        void onRowEditing(object sender, GridViewEditEventArgs e);
        void onRowDeleting(object sender, GridViewDeleteEventArgs e);
        void onRowUpdating(object sender, GridViewUpdateEventArgs e);
        void onCancelEditing(object sender, GridViewCancelEditEventArgs e);
        void Paginacion(object sender, GridViewPageEventArgs e);
    }
}
