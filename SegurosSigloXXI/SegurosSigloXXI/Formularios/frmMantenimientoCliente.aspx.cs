using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SegurosSigloXXI.BL;
using SegurosSigloXXI.Clases;


namespace SegurosSigloXXI.Formularios
{
    public partial class MantenimientoCliente : Page, EventosGridView
    {
        EnlaceData enlace = new EnlaceData();
        Email enviar;
        BLMantenimientoClientes cliente = new BLMantenimientoClientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatos();
            }
        }

        #region Evento de comando por fila
        protected void ComandoAdiccion(object sender, GridViewCommandEventArgs e) 
        {
            if(e.CommandName == "nuevaAdiccion")
            {
                int indiceFila = Convert.ToInt32(e.CommandArgument);
                GridViewRow fila = this.tablaMantenimientoCliente.Rows[indiceFila];
                string idCliente = fila.Cells[0].Text;
                string cedula = fila.Cells[1].Text;
                string url = $"~/Formularios/frmAdiccionCliente.aspx?id={idCliente}&cedula={cedula}";
                Response.Redirect(url);
            }

        }
        #endregion


        #region Evento para elminar registro
        public void onRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Evento para cancelar edición
        public void onCancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            this.tablaMantenimientoCliente.EditIndex = -1;
            CargaDatos();
        }
        #endregion

        #region Evento click para insertar dato
        protected void InsertaCliente_Click(object s, EventArgs e)
        {
            InsertarCliente();
        }
        #endregion

        #region Evento para activar modo edición
        public void onRowEditing(object sender, GridViewEditEventArgs e)
        {
            this.tablaMantenimientoCliente.EditIndex = e.NewEditIndex;
            CargaDatos();
        }
        #endregion

        #region Evento para modificar registro
        public void onRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Controles de la fila seleccionda
            GridViewRow fila = this.tablaMantenimientoCliente.Rows[e.RowIndex];
            int idCliente = Convert.ToInt32(fila.Cells[0].Text);
            int cedulaCliente = Convert.ToInt32(fila.Cells[1].Text);
            string nombre = (fila.FindControl("txt_Nombre") as HtmlInputText).Value;
            string primerApellido = (fila.FindControl("txt_Apellido1") as HtmlInputText).Value;
            string segundoApellido = (fila.FindControl("txt_Apellido2") as HtmlInputText).Value;
            string genero = (fila.FindControl("slGenero") as HtmlSelect).Value;
            DateTime fechaNacimiento = Convert.ToDateTime((fila.FindControl("txt_Nacimiento") as HtmlInputGenericControl).Value);
            int telefonoPrincipal = Convert.ToInt32((fila.FindControl("txt_Telefono1") as HtmlInputText).Value);
            int telefonoSecundario = (string.IsNullOrEmpty(this.txtTelefonoSecundario.Value))
                ? 0 :
                Convert.ToInt32((fila.FindControl("txt_Telefono2") as HtmlInputText).Value);
            string direccion = (fila.FindControl("txt_Direccion") as HtmlInputText).Value;
            string email = (fila.FindControl("txt_Email") as HtmlInputText).Value;

            bool estadoUpdate = cliente.ModificaCliente(idCliente, cedulaCliente, genero,
                                                        fechaNacimiento, nombre, primerApellido,
                                                        direccion, telefonoPrincipal, email,
                                                        segundoApellido, telefonoSecundario);
            if (estadoUpdate)
            {
                Response.Write(
                    "<script>window.onload=()=>{actionMessage('success', 'Registro modificado correctamente');}</script>");
                this.tablaMantenimientoCliente.EditIndex = -1;
                CargaDatos();
            }
            else
            {
                Response.Write(
                 "<script>window.onload=()=>{actionMessage('error', 'Error al modificar el registro');}</script>");
            }
        }
        #endregion

        #region Evento de paginación de tabla
        public void Paginacion(object sender, GridViewPageEventArgs e)
        {
            this.tablaMantenimientoCliente.PageIndex = e.NewPageIndex;
            CargaDatos();
        }
        #endregion

        #region Carga de Datos
        /// <summary>
        /// Carga los datos en base al tipo de usuario que a iniciado una nueva sesión
        /// </summary>
        public void CargaDatos()
        {
            if (Convert.ToBoolean(Session["estadoSesion"]))
            {
                if (Session["tipo"].ToString() == "g")
                {
                    enlace.EnlazarGridView(this.tablaMantenimientoCliente,
                        cliente.ListaClientes(Convert.ToInt32(Session["clienteCedula"])));
                }
                else
                {
                    enlace.EnlazarGridView(this.tablaMantenimientoCliente, cliente.ListaClientes(null));
                }
            }
            else
            {
                Response.Redirect("~/Formularios/frmRegistroPrincipal.aspx");
            }
        }
        #endregion

        #region Insertar Cliente
        /// <summary>
        /// Método para invocar con el evento InsertaCliente_Click
        /// </summary>
        public void InsertarCliente()
        {
            int cedula = Convert.ToInt32(this.txtCedula.Value);
            string genero = this.txtGenero.Value.ToUpper();
            DateTime fechaNacimiento = Convert.ToDateTime(this.txtFechaNacimiento.Value);
            string nombre = this.txtNombre.Value;
            string primerApellido = this.txtPrimerApellido.Value;
            string segundoApellido = this.txtSegundoApellido.Value;
            string direccion = this.txtDireccion.Value;
            int tel1 = Convert.ToInt32(this.txtTelefonoPrincipal.Value);
            int tel2 = (string.IsNullOrEmpty(this.txtTelefonoSecundario.Value)) ? 0 :
                                    Convert.ToInt32(this.txtTelefonoSecundario.Value);
            string email = this.txtEmail.Value;

            bool estadoInsert = cliente.InsertaCliente(cedula, genero, fechaNacimiento,
                                                        nombre, primerApellido, direccion,
                                                        tel1, email, segundoApellido, tel2);
            if (estadoInsert)
            {
                enviar = new Email(email);
                enviar.EnviaCorreo(nombre, primerApellido, segundoApellido);
                Response.Write("<script>window.onload=()=>{actionMessage('success', 'Registro Insertado');}</script>");
            }
            else
            {
                Response.Write("<script>window.onload=()=>{actionMessage('error', 'Error al insertar el registro');}</script>");
            }
        }
        #endregion
    }

}