using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SegurosSigloXXI.Clases;
using SegurosSigloXXI.BL;

namespace SegurosSigloXXI.Formularios
{
    public partial class frmAdiccion : System.Web.UI.Page, EventosGridView
    {
        BLAdicciones adiccion = new BLAdicciones();
        EnlaceData enlace = new EnlaceData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatos();
            }
        }


        #region Cancelar modo edición
        public void onCancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            this.tablaAdiccion.EditIndex = -1;
            CargaDatos();
        }
        #endregion

        #region Eliminar Registro
        public void onRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Activar modo edición
        public void onRowEditing(object sender, GridViewEditEventArgs e)
        {
            this.tablaAdiccion.EditIndex = e.NewEditIndex;
            CargaDatos();
        }
        #endregion


        #region Modificar Registro
        public void onRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = this.tablaAdiccion.Rows[e.RowIndex];
            int idAdiccion = Convert.ToInt32(fila.Cells[0].Text);
            string nombre = (fila.FindControl("txt_Nombre") as HtmlInputControl).Value;
            string codigo = (fila.FindControl("txt_Codigo") as HtmlInputControl).Value;
            bool estadoUpdate = adiccion.ModificaAdiccion(idAdiccion, nombre, codigo);
            if (estadoUpdate)
            {
                this.Master.Alerta("Registro modificado correctamente");
                this.tablaAdiccion.EditIndex = -1;
                CargaDatos();
            }
            else
            {
                this.Master.Alerta("Error al modificar el registro", "error");
            }

        }
        #endregion

        public void Paginacion(object sender, GridViewPageEventArgs e)
        {
            this.tablaAdiccion.PageIndex = e.NewPageIndex;
            CargaDatos();
        }

        #region Carga de datos
        void CargaDatos()
        {
            var adicciones = adiccion.ListaAdicciones();
            enlace.EnlazarGridView(this.tablaAdiccion, adicciones);
        }
        #endregion

        #region Insertar Registro
        protected void InsertaRegistro_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Value;
            string codigo = this.txtCodigo.Value;

            bool estadoInsert = adiccion.InsertaAdiccion(nombre, codigo);
            if (estadoInsert)
            {
                this.Master.Alerta("Registro insertado correctamente");
            }
            else
            {
                this.Master.Alerta("Error al insertar el registro", "error");
            }
        }
        #endregion

    }
}