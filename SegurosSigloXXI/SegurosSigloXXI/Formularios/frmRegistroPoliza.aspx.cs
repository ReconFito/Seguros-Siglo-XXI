using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SegurosSigloXXI.Clases;
using SegurosSigloXXI.BL;

namespace SegurosSigloXXI.Formularios
{
    public partial class frmRegistroPoliza : System.Web.UI.Page, EventosGridView
    {
        BLRegistroPoliza poliza = new BLRegistroPoliza();
        EnlaceData enlace = new EnlaceData();

        #region Variables globales
        int idCliente
        {
            get { return this.idCliente; }
            set { this.idCliente = Convert.ToInt32(Request.QueryString["id"].ToString()); }
        }
        int idCoberturaPoliza
        {
            get { return this.idCoberturaPoliza; }
            set { this.idCoberturaPoliza = Convert.ToInt32(this.slIdCoberturaPoliza.Value); }
        }
        decimal montoAsegurado
        {
            get { return this.montoAsegurado; }
            set { this.montoAsegurado = Convert.ToDecimal(this.txtMontoAsegurado.Value); }
        }
        decimal porcentajeCobertura
        {
            get { return this.porcentajeCobertura; }
            set { this.porcentajeCobertura = Convert.ToDecimal(this.txtPorcentajeCobertura.Value); }
        }
        int numeroAdicciones
        {
            get { return this.numeroAdicciones; }
            set { this.numeroAdicciones = Convert.ToInt32(this.txtNumeroAdicciones.Value); }
        }
        decimal montoAdicciones
        {
            get { return this.montoAdicciones; }
            set { this.montoAdicciones = Convert.ToDecimal(this.txtMontoAdicciones.Value); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatos();
                CargaDatosLista();
            }
        }

        #region Cancelar modo edición
        public void onCancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            this.tablaRegistroPolizas.EditIndex = -1;
            CargaDatos();
        }
        #endregion

        #region Carga datos
        public void CargaDatos()
        {
            enlace.EnlazarGridView(this.tablaRegistroPolizas, poliza.ListaRegistroPoliza());
        }

        public void CargaDatosLista()
        {

        }
        #endregion

        #region Eliminar registro
        public void onRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow fila = this.tablaRegistroPolizas.Rows[e.RowIndex];
            int idRegistro = Convert.ToInt32(fila.Cells[0].Text);
            bool estadoDelete = poliza.EliminaRegistroPoliza(idRegistro);
            if (estadoDelete)
            {
                this.Master.Alerta("Registo eliminado correctamente");
            }
            else
            {
                this.Master.Alerta("Error al eliminar el registro", "error");
            }
        }

        #endregion

        #region Activar modo edición
        public void onRowEditing(object sender, GridViewEditEventArgs e)
        {
            this.tablaRegistroPolizas.EditIndex = e.NewEditIndex;
            CargaDatos();
        }
        #endregion

        #region Modificar registro
        public void onRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Paginación
        public void Paginacion(object sender, GridViewPageEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Evento click para insertar registro
        protected void InsertaRegistro_Click(object sender, EventArgs e)
        {
            InsertarRegistro();
        }
        #endregion

        #region Método para insertar registro
        public void InsertarRegistro()
        {
            //bool estadoInsert = poliza.InsertaRegistroPoliza(idCoberturaPoliza, idCliente, montoAsegurado, 
            //                                                    porcentajeCobertura, numeroAdicciones, 
            //                                                    montoAdicciones, 0, 0, 0);

        }
        #endregion


        bool ValidarDatosRegistro()
        {
            if (this.montoAsegurado >= 1000000 || this.montoAsegurado <= 100000000)
                return true;
            return false;
        }
    }
}