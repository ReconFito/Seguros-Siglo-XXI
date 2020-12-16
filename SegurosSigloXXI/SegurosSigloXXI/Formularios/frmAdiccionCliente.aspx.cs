using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SegurosSigloXXI.BL;
using SegurosSigloXXI.Clases;

namespace SegurosSigloXXI.Formularios
{
    public partial class frmAdiccionCliente : System.Web.UI.Page
    {
        BLAdiccionCliente adiccionCLiente = new BLAdiccionCliente();
        BLMantenimientoClientes cliente = new BLMantenimientoClientes();
        BLAdicciones adiccion = new BLAdicciones();
        EnlaceData enlace = new EnlaceData();
        protected void Page_Load(object sender, EventArgs e)
        { }

        #region Carga de datos
        public void CargaDatos()
        {
            cliente.ListaClientes().ForEach((cliente) =>
            {
                string nombreCompleto = cliente.Nombre + cliente.Primer_Apellido + cliente.Segundo_Apellido;
                this.slNombreAdiccion.Items.Add(new ListItem(nombreCompleto, cliente.Id_Cliente.ToString()));
            });

            adiccion.ListaAdicciones().ForEach((adiccion) =>
            {
                this.slNombreAdiccion.Items.Add(new ListItem(adiccion.Nombre, adiccion.ID_ADICCION.ToString()));
            });
        }
        #endregion

        #region Cargar las adicciones para el cliente seleccionado
        public void CargaAdiccionCliente()
        {
            int idCliente = Convert.ToInt32(this.slNombreCliente.Value);
            int idAdiccion = Convert.ToInt32(this.slNombreAdiccion.Value);

            ListItem elementoCliente = this.slNombreCliente.Items.FindByValue(idCliente.ToString());
            ListItem elementoAdiccion = this.slNombreAdiccion.Items.FindByValue(idAdiccion.ToString());
        }

        #endregion
    }
}