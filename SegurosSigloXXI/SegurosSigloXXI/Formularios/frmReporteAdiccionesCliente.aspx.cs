using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SegurosSigloXXI.Clases;
using SegurosSigloXXI.BL;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace SegurosSigloXXI.Formularios
{
    public partial class frmReporteAdiccionesCliente : System.Web.UI.Page
    {

        BLAdiccionCliente adiccionCliente = new BLAdiccionCliente();
        BLMantenimientoClientes clientes = new BLMantenimientoClientes();
        BLAdicciones adiccion = new BLAdicciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatos();
                CrearReporte();
            }
        }

        #region Carga datos para filtrado
        void CargaDatos()
        {
            clientes.ListaClientes().ForEach((cliente) =>
            {
                string nombre = cliente.Nombre + " " + cliente.Primer_Apellido + " " + cliente.Segundo_Apellido;
                this.sl_ListaClientes.Items.Add(new ListItem(nombre, cliente.Id_Cliente.ToString()));
            });

            adiccion.ListaAdicciones().ForEach((adiccion) =>
            {
                this.sl_ListaAdicciones.Items.Add(new ListItem(adiccion.Nombre,
                    adiccion.ID_ADICCION.ToString()));
            });

        }
        #endregion

        #region Evento para generar reporte filtrado
        protected void GenerarReporteFiltrado_Click(object sender, EventArgs e)
        {
            int idCliente = int.Parse(string.IsNullOrEmpty(
                this.sl_ListaClientes.Value) ? "-1" : this.sl_ListaClientes.Value);
            int idAdiccion = int.Parse(string.IsNullOrEmpty(
                this.sl_ListaAdicciones.Value) ? "-1" : this.sl_ListaAdicciones.Value);
            CrearReporte(idAdiccion, idCliente);
        }
        #endregion

        /// <summary>
        /// Code made by Cristopher Castillo
        /// </summary>
        void CrearReporte(int idAdiccion = -1, int idCliente = -1)
        {
            ///indicar la ruta del reporte
            string rutaReporte = "~/Reportes/ReporteAdiccionesCliente.rdlc";
            ///construir la ruta física
            string rutaFisica = Server.MapPath(rutaReporte);

            if (!File.Exists(rutaFisica))
            {
                this.Master.Alerta("No se encontro el informe seleccionado", "info");
                return;
            }
            else
            {
                /// Obtener el nombre completo en la sesión actual
                string nombreUsuario = Session["clienteNombre"] + " " +
                                        Session["clientePrimerApellido"] + " " +
                                        Session["clienteSegundoApellido"];

                /// Parámetro para utilizarse en el reporte
                ReportParameter parametroReporte = new ReportParameter("generaReporte", nombreUsuario);
                this.rpvAdiccionesCliente.LocalReport.ReportPath = rutaFisica;
                var infoFuenteDatos = this.rpvAdiccionesCliente.LocalReport.GetDataSourceNames();
                ///limpiar los datos de la fuente de datos
                this.rpvAdiccionesCliente.LocalReport.DataSources.Clear();

                var reportData = adiccionCliente.InnerSelectAdiccionesCliente(idCliente, idAdiccion);



                ///crear la fuente de datos
                ReportDataSource fuenteDatos = new ReportDataSource();
                fuenteDatos.Name = infoFuenteDatos[0];
                fuenteDatos.Value = reportData;

                // agregar la fuente de datos al reporte
                this.rpvAdiccionesCliente.LocalReport.DataSources.Add(fuenteDatos);

                /// mostrar los datos en el reporte
                this.rpvAdiccionesCliente.LocalReport.SetParameters(parametroReporte);
                this.rpvAdiccionesCliente.LocalReport.Refresh();
            }
        }
    }
}