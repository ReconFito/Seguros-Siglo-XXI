using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SegurosSigloXXI.BL;
using SegurosSigloXXI.Clases;
using System.Data.SqlClient;

namespace SegurosSigloXXI.Formularios
{
    public partial class frmAdiccionCliente : System.Web.UI.Page, EventosGridView
    {
        BLAdiccionCliente adiccionCLiente = new BLAdiccionCliente();
        BLMantenimientoClientes cliente = new BLMantenimientoClientes();
        BLAdicciones adiccion = new BLAdicciones();
        EnlaceData enlace = new EnlaceData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatosGridView();
                CargaDatos();
            }
        }

        #region Carga de datos
        /// <summary>
        /// Precargar datos usando los parámetros en la url
        /// </summary>
        public void CargaDatos()
        {
            int idCliente = Convert.ToInt32(Request.QueryString["id"]);
            int cedula = Convert.ToInt32(Request.QueryString["cedula"]);

            var registroCliente = cliente.ListaClientes(cedula).FirstOrDefault();
            this.txtNombre.Value = registroCliente.Nombre + " " +
                                    registroCliente.Primer_Apellido + " " +
                                    registroCliente.Segundo_Apellido;

            adiccion.ListaAdicciones().ForEach((adiccion) =>
            {
                this.slNombreAdiccion.Items.Add(new ListItem(adiccion.Nombre, adiccion.ID_ADICCION.ToString()));
            });
        }
        #endregion

        #region Evento para insertar nueva adicción a cliente
        protected void InsertarNuevaAdiccion_Click(object sender, EventArgs e)
        {
            RegistraDatos();
        }
        #endregion

        #region Carga Datos en gridView
        void CargaDatosGridView()
        {
            int cedula = Convert.ToInt32(Request.QueryString["cedula"]);
            using (var db = new polizassigloxxiEntities())
            {
                var registro = db.vw_infoCliente.SqlQuery("SELECT * FROM vw_infoCliente WHERE Cedula=@cedula",
                    new SqlParameter("@cedula", cedula)).ToList();
                enlace.EnlazarGridView(this.tablaAdiccionCliente, registro);
            }
        }
        #endregion

        #region Insertar nueva registro para la tabla adicciones por cliente
        /// <summary>
        /// Buscar las adicciones registradas al cliente y registrar
        /// una nueva si esta no está presente en los registros.
        /// </summary>
        void RegistraDatos()
        {
            int idCliente = Convert.ToInt32(Request.QueryString["id"]);
            int idAdiccion = Convert.ToInt32(this.slNombreAdiccion.Value);

            using (var db = new polizassigloxxiEntities())
            {

                if (ValidarRegistro(idAdiccion))
                {
                    this.Master.Alerta("Este usuario ya tiene registrado esta adicción", "error");
                }
                else
                {
                    bool estadoInsert = adiccionCLiente.InsertaAdiccionCliente(idAdiccion, idCliente);
                    if (estadoInsert)
                    {
                        this.Master.Alerta("Adicción registrada correctamente");
                    }
                    else
                    {
                        this.Master.Alerta("Error al insertar la adicción");
                    }
                }
            }

        }
        #endregion

        #region Activar modo edición
        public void onRowEditing(object sender, GridViewEditEventArgs e)
        {
            this.tablaAdiccionCliente.EditIndex = e.NewEditIndex;
            CargaDatosGridView();
        }
        #endregion

        #region Eliminar registro
        public void onRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Modificar registro
        public void onRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = this.tablaAdiccionCliente.Rows[e.RowIndex];
            int idCliente = Convert.ToInt32(Request.QueryString["id"]);
            int idAdiccionCliente = Convert.ToInt32(fila.Cells[0].Text);
            int idAdiccion = Convert.ToInt32((fila.FindControl("sl_NombreAdiccion") as HtmlSelect).Value);
            if (ValidarRegistro(idAdiccion))
            {
                this.Master.Alerta("Este usuario ya tiene registrada esta adicción", "error");
            }
            else
            {
                bool estadoUpdate = adiccionCLiente.ModificaAdiccionCliente(idAdiccionCliente, idAdiccion, idCliente);
                if (estadoUpdate)
                {
                    this.Master.Alerta("Registro modificado correctamente");
                }
                else
                {
                    this.Master.Alerta("Error al modificar el registro", "error");
                }
            }
        }
        #endregion

        #region Cancelar modo edición
        public void onCancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            this.tablaAdiccionCliente.EditIndex = -1;
            CargaDatosGridView();
        }
        #endregion

        #region Paginación
        public void Paginacion(object sender, GridViewPageEventArgs e)
        {
            this.tablaAdiccionCliente.PageIndex = e.NewPageIndex;
            CargaDatosGridView();
        }
        #endregion

        #region Validar registro insertado o modificado
        /// <summary>
        /// Validar si el cliente ya posee la adicción registrada o modificada.
        /// </summary>
        /// <returns></returns>
        bool ValidarRegistro(int idAdiccion)
        {
            int idCliente = Convert.ToInt32(Request.QueryString["id"]);
            using (var db = new polizassigloxxiEntities())
            {
                var registro = db.Mantenimiento_Adicciones_Cliente
                    .SqlQuery("SELECT * FROM Mantenimiento_Adicciones_Cliente " +
                    "WHERE Id_Cliente=@idCliente AND Id_Adiccion=@idAdiccion",
                    new SqlParameter("@idCliente", idCliente),
                    new SqlParameter("@idAdiccion", idAdiccion)).Count();
                return registro > 0;
            }
        }
        #endregion

        #region Enlazar datos al activar modo edición
        /// <summary>
        /// Enlazar datos en la lista desplebable si esta habilitado la edición
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaAdiccionCliente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    HtmlSelect listaAdicciones = (e.Row.FindControl("sl_NombreAdiccion") as HtmlSelect);
                    adiccion.ListaAdicciones().ForEach((adiccion) =>
                    {
                        listaAdicciones.Items.Add(new ListItem(adiccion.Nombre, adiccion.ID_ADICCION.ToString()));
                    });
                }
            }
        }
        #endregion
    }
}