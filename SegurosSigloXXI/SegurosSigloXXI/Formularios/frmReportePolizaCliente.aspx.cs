using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SegurosSigloXXI.BL;
using SegurosSigloXXI.Clases;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace SegurosSigloXXI.Formularios
{
    public partial class frmReportePolizaCliente : System.Web.UI.Page
    {
        BLMantenimientoClientes clientes = new BLMantenimientoClientes();
        BLRegistroPoliza polizas = new BLRegistroPoliza();
        BLCoberturaPoliza cobertura = new BLCoberturaPoliza();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatos();
                CrearReporte();
            }
        }

        void CargaDatos()
        {
            clientes.ListaClientes().ForEach((cliente) =>
            {
                string nombre = cliente.Nombre + " " + cliente.Primer_Apellido + " " + cliente.Segundo_Apellido;
                this.sl_ListaClientes.Items.Add(new ListItem(nombre, cliente.Id_Cliente.ToString()));
            });

            cobertura.ListaCoberturaPolizas().ForEach((cobertura) =>
            {
                this.sl_ListaCoberturas.Items.Add(new ListItem(cobertura.Nombre,
                    cobertura.Id_Cobertura_Poliza.ToString()));
            });
        }
        /// Evento para generar reporte filtrado
        protected void GenerarReporteFiltrado_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(string.IsNullOrEmpty(
                this.sl_ListaClientes.Value) ? "0" : this.sl_ListaClientes.Value);
            int idCobertura = Convert.ToInt32(string.IsNullOrEmpty(
                this.sl_ListaCoberturas.Value) ? "0" : this.sl_ListaCoberturas.Value);

            decimal montoAsegurado = Convert.ToDecimal(string.IsNullOrEmpty(
                this.txtMontoAsegurado.Value) ? "0" : this.txtMontoAsegurado.Value);
            int numeroAdiccion = Convert.ToInt32(string.IsNullOrEmpty(
                this.txtNumeroAdicciones.Value) ? "0" : this.txtNumeroAdicciones.Value);
            CrearReporte(0, idCliente, idCobertura, montoAsegurado, numeroAdiccion);
        }

        /// <summary>
        /// Code made by Cristopher Castillo
        /// </summary>
        void CrearReporte(int id = -1, int idCliente = 0, int idCobertura = 0,
                            decimal montoAsegurado = 0, int numeroAdiccion = 0)
        {
            ///indicar la ruta del reporte
            string rutaReporte = "~/Reportes/ReportePolizaCliente.rdlc";
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
                this.rpvRegistroPolizas.LocalReport.ReportPath = rutaFisica;
                var infoFuenteDatos = this.rpvRegistroPolizas.LocalReport.GetDataSourceNames();
                ///limpiar los datos de la fuente de datos
                this.rpvRegistroPolizas.LocalReport.DataSources.Clear();

                var reportData = polizas.InnerSelectRegistroPolizas(id, idCliente, idCobertura, montoAsegurado, numeroAdiccion);

                ///crear la fuente de datos
                ReportDataSource fuenteDatos = new ReportDataSource();
                fuenteDatos.Name = infoFuenteDatos[0];
                fuenteDatos.Value = reportData;

                // agregar la fuente de datos al reporte
                this.rpvRegistroPolizas.LocalReport.DataSources.Add(fuenteDatos);

                /// mostrar los datos en el reporte
                this.rpvRegistroPolizas.LocalReport.SetParameters(parametroReporte);
                this.rpvRegistroPolizas.LocalReport.Refresh();
            }
        }
    }
}