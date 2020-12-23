using System;
using System.Data.SqlClient;
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
    public partial class frmRegistroPoliza : System.Web.UI.Page, EventosGridView
    {
        BLRegistroPoliza poliza = new BLRegistroPoliza();
        BLCoberturaPoliza coberturaPoliza = new BLCoberturaPoliza();
        BLMantenimientoClientes clientes = new BLMantenimientoClientes();
        EnlaceData enlace = new EnlaceData();

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
            enlace.EnlazarGridView(this.tablaRegistroPolizas, poliza.InnerSelectRegistroPolizas(-1, 0, 0, 0, 0));
        }

        public void CargaDatosLista()
        {
            clientes.ListaClientes().ForEach((cliente) =>
            {
                string nombre = cliente.Nombre + " " + cliente.Primer_Apellido + " " + cliente.Segundo_Apellido;
                this.slIdCliente.Items.Add(new ListItem(nombre, cliente.Id_Cliente.ToString()));
            });
            coberturaPoliza.ListaCoberturaPolizas().ForEach((cobertura) =>
            {
                this.slIdCoberturaPoliza.Items.Add(new ListItem(cobertura.Nombre,
                    cobertura.Id_Cobertura_Poliza.ToString()));
            });
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
            GridViewRow fila = this.tablaRegistroPolizas.Rows[e.RowIndex];
            int idRegistro = Convert.ToInt32(fila.Cells[0].Text);
            int idCobertura = Convert.ToInt32((fila.FindControl("sl_IdCobertura") as HtmlSelect).Value);
            decimal montoAsegurado = Convert.ToDecimal((fila.FindControl("txt_MontoAsegurado") as HtmlInputControl).Value);
            int numeroAdicciones = Convert.ToInt32(fila.Cells[5].Text);
            ValidaDatosUpdate(idRegistro, idCobertura, montoAsegurado, numeroAdicciones);
        }
        #endregion

        #region Paginación
        public void Paginacion(object sender, GridViewPageEventArgs e)
        {
            this.tablaRegistroPolizas.PageIndex = e.NewPageIndex;
            CargaDatos();
        }
        #endregion

        #region Evento click para insertar registro
        protected void InsertaRegistro_Click(object sender, EventArgs e)
        {
            InsertarRegistro();
        }
        public void InsertarRegistro()
        {
            int idCoberturaPoliza = Convert.ToInt32(this.slIdCoberturaPoliza.Value);
            int idCliente = Convert.ToInt32(this.slIdCliente.Value);
            int numeroAdicciones = Convert.ToInt32(this.txtNumeroAdicciones.Value);
            decimal montoAsegurado = Convert.ToDecimal(this.txtMontoAsegurado.Value);
            decimal porcentajeCobertura = Convert.ToDecimal(this.txtPorcentaje.Value);
            decimal montoAdicciones = Convert.ToDecimal(this.txtMontoAdicciones.Value);
            decimal primaAntesImpuestos = Convert.ToDecimal(this.txtPrimaAntesImpuesto.Value);
            decimal impuestos = Convert.ToDecimal(this.txtImpuesto.Value);
            decimal primaFinal = Convert.ToDecimal(this.txtPrimaFinal.Value);

            bool estadoInsert = poliza.InsertaRegistroPoliza(idCoberturaPoliza, idCliente, montoAsegurado,
                                                        porcentajeCobertura, numeroAdicciones,
                                                        montoAdicciones, primaAntesImpuestos,
                                                        impuestos, primaFinal);
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

        #region Generar poliza sin insertar
        protected void GeneraPoliza_Click(object sender, EventArgs e)
        {
            GeneraPoliza();
        }

        void GeneraPoliza()
        {
            int idCoberturaPoliza = Convert.ToInt32(this.slIdCoberturaPoliza.Value);
            int idCliente = Convert.ToInt32(this.slIdCliente.Value);
            int montoAsegurado = Convert.ToInt32(this.txtMontoAsegurado.Value);

            ValidaDatosInsert(montoAsegurado, idCliente, idCoberturaPoliza);
        }
        #endregion

        #region Validar e imprimir valores de registro
        /// <summary>
        /// Valida y calcular los datos ingresados por el usuario
        /// antes de insertar estos datos en la base de datos 
        /// </summary>
        /// <param name="montoAsegurado"></param>
        /// <param name="idCliente"></param>
        /// <param name="idCoberturaPoliza"></param>
        void ValidaDatosInsert(int montoAsegurado, int idCliente, int idCoberturaPoliza)
        {
            decimal montoAdicciones = 0;
            decimal primaAntesImpuestos;
            decimal impuestos;
            decimal primaFinal;
            int numeroAdicciones;
            decimal porcentaje = coberturaPoliza.ListaCoberturaPolizas(idCoberturaPoliza).FirstOrDefault().Porcentaje;

            // Obtener el total de adicciones de un cliente
            using (var db = new polizassigloxxiEntities())
            {
                numeroAdicciones = db.Mantenimiento_Adicciones_Cliente
                   .SqlQuery("SELECT * FROM Mantenimiento_Adicciones_Cliente WHERE Id_Cliente=@idCliente"
                   , new SqlParameter("@idCliente", idCliente)).Count();
            }

            if (montoAsegurado < 1000000 || montoAsegurado > 100000000)
            {
                this.Master.Alerta("Monto del asegurado debe ser mayor a\n1,000,000 y menor 100,000,000", "error");
            }
            else
            {
                // Validar que el monto del asegurado sea mayor a 1,000,000 y menor 100,000,000
                if (numeroAdicciones == 1)
                {
                    montoAdicciones = (decimal)(montoAsegurado + (montoAsegurado * 0.05));
                }
                else if (numeroAdicciones >= 2 || numeroAdicciones <= 3)
                {
                    montoAdicciones = (decimal)(montoAsegurado + (montoAsegurado * 0.1));
                }
                else if (numeroAdicciones > 3)
                {
                    montoAdicciones = (decimal)(montoAsegurado + (montoAsegurado * 0.15));
                }
                primaAntesImpuestos = montoAdicciones + (montoAdicciones * (porcentaje / 100));
                impuestos = decimal.Multiply(primaAntesImpuestos, 0.13m);
                primaFinal = primaAntesImpuestos + impuestos;

                this.txtNumeroAdicciones.Value = numeroAdicciones.ToString();
                this.txtMontoAdicciones.Value = montoAdicciones.ToString();
                this.txtPrimaAntesImpuesto.Value = primaAntesImpuestos.ToString();
                this.txtImpuesto.Value = impuestos.ToString();
                this.txtPrimaFinal.Value = primaFinal.ToString();
                this.txtPorcentaje.Value = porcentaje.ToString();

                this.btnGenerar.Visible = false;
                this.btnIngresar.Visible = true;
            }
        }

        /// <summary>
        /// Valida y calcula los ingresados por el usuario
        /// antes de modificarlo
        /// </summary>
        /// <param name="idRegistro"></param>
        /// <param name="idCoberturaPoliza"></param>
        /// <param name="montoAsegurado"></param>
        /// <param name="numeroAdicciones"></param>
        void ValidaDatosUpdate(int idRegistro, int idCoberturaPoliza, decimal montoAsegurado, int numeroAdicciones)
        {
            decimal montoAdicciones = 0;
            decimal primaAntesImpuestos;
            decimal impuestos;
            decimal primaFinal;
            decimal porcentaje = coberturaPoliza.ListaCoberturaPolizas(idCoberturaPoliza).FirstOrDefault().Porcentaje;

            if (montoAsegurado < 1000000 || montoAsegurado > 100000000)
            {
                this.Master.Alerta("Monto del asegurado debe ser mayor a\n1,000,000ymenor 100,000,000", "error");
            }
            else
            {
                // Validar que el monto del asegurado sea mayor a 1,000,000 y menor 100,000,000
                if (numeroAdicciones == 1)
                {
                    montoAdicciones = montoAsegurado + (montoAsegurado * 0.05m);
                }
                else if (numeroAdicciones >= 2 || numeroAdicciones <= 3)
                {
                    montoAdicciones = montoAsegurado + (montoAsegurado * 0.1m);
                }
                else if (numeroAdicciones > 3)
                {
                    montoAdicciones = montoAsegurado + (montoAsegurado * 0.15m);
                }
                primaAntesImpuestos = montoAdicciones + (montoAdicciones * (porcentaje / 100));
                impuestos = primaAntesImpuestos * 0.13m;
                primaFinal = primaAntesImpuestos + impuestos;

                bool estadoUpdate = poliza.ModificaRegistroPoliza(idRegistro, idCoberturaPoliza, montoAsegurado,
                                                porcentaje, montoAdicciones,
                                                primaAntesImpuestos, impuestos, primaFinal);
                if (estadoUpdate)
                {
                    this.tablaRegistroPolizas.EditIndex = -1;
                    CargaDatos();
                    this.Master.Alerta("Registro modificado correctamente");
                }
                else
                {
                    this.Master.Alerta("Error al modificar el registro", "error");
                }
            }
        }
        #endregion

        #region Enlazar datos al activar modo edición
        /// <summary>
        /// Enlazar datos en la lista desplebable si esta habilitado la edición
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaRegistroPolizas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    HtmlSelect listaCoberturas = (e.Row.FindControl("sl_IdCobertura") as HtmlSelect);
                    HtmlSelect listaPorcentajes = (e.Row.FindControl("sl_PorcentajeCobertura") as HtmlSelect);
                    coberturaPoliza.ListaCoberturaPolizas().ForEach((cobertura) =>
                    {
                        listaPorcentajes.Items.Add(
                            new ListItem(cobertura.Porcentaje.ToString(), cobertura.Id_Cobertura_Poliza.ToString()));

                        listaCoberturas.Items.Add(
                            new ListItem(cobertura.Nombre, cobertura.Id_Cobertura_Poliza.ToString()));
                    });

                }
            }
        }
        #endregion
    }
}
