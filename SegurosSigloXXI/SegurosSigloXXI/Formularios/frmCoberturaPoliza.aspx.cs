using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SegurosSigloXXI.Clases;
using SegurosSigloXXI.BL;

namespace SegurosSigloXXI.Formularios
{
    public partial class frmCoberturaPolzia : System.Web.UI.Page, EventosGridView
    {

        BLCoberturaPoliza coberturaPoliza = new BLCoberturaPoliza();
        EnlaceData enlace = new EnlaceData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatos();
            }

        }

        #region Insertar Registro
        protected void InsertaRegistro_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Value;
            string descripcion = this.txtDescripcion.Value;
            decimal porcentaje = Convert.ToDecimal(this.txtPorcentaje.Value);
            int registros;
            using (var db = new polizassigloxxiEntities())
            {
                registros = db.Cobertura_Poliza.SqlQuery("SELECT * FROM Cobertura_Poliza WHERE Nombre=@nombre",
                    new SqlParameter("@nombre", nombre)).Count();
            }

            if (registros > 0)
            {
                this.Master.Alerta("Ya existe un registro con el mismo nombre!!", "error");
            }

            else if (porcentaje < 0 || porcentaje > 100)
            {
                this.Master.Alerta("Porcentaje debe de ser mayor a cero y menor o igual a 100", "error");
            }
            else
            {
            bool estadoInsert = coberturaPoliza.InsertaCoberturaPoliza(nombre, descripcion, porcentaje);
            if (estadoInsert)
            {
                this.Master.Alerta("Registro insertado correctamente");
            }
            else
            {
                this.Master.Alerta("Error al insertar el registro", "error");
            }
        }
        }
        #endregion

        #region Carga de datos
        void CargaDatos()
        {
            var cobertura = coberturaPoliza.ListaCoberturaPolizas();
            enlace.EnlazarGridView(this.tablaCoberturaPoliza, cobertura);
        }
        #endregion

        #region Cancelar modo edición
        public void onCancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            this.tablaCoberturaPoliza.EditIndex = -1;
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
            this.tablaCoberturaPoliza.EditIndex = e.NewEditIndex;
            CargaDatos();
        }
        #endregion

        #region Modificar registro
        public void onRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = this.tablaCoberturaPoliza.Rows[e.RowIndex];
            int id = Convert.ToInt32(fila.Cells[0].Text);
            string nombre = (fila.FindControl("txt_Nombre") as HtmlInputControl).Value;
            string descripcion = (fila.FindControl("txt_Descripcion") as HtmlInputControl).Value;
            decimal porcentaje = Convert.ToDecimal((fila.FindControl("txt_Porcentaje") as HtmlInputControl).Value);

            bool estadoUpdate = coberturaPoliza.ModificaCoberturaPoliza(id, nombre, descripcion, porcentaje);
            if (estadoUpdate)
            {
                this.Master.Alerta("Registro modificado correctamente");
                this.tablaCoberturaPoliza.EditIndex = -1;
                CargaDatos();
            }
            else
            {
                this.Master.Alerta("Error al modificar el registro", "error");
            }
        }
        #endregion

        #region Paginación
        public void Paginacion(object sender, GridViewPageEventArgs e)
        {
            this.tablaCoberturaPoliza.PageIndex = e.NewPageIndex;
            CargaDatos();
        }
        #endregion
    }
}