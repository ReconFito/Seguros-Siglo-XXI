using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using SegurosSigloXXI.BL;

namespace SegurosSigloXXI
{
    public partial class Plantilla : System.Web.UI.MasterPage
    {
        public string correoAdmin = "munozfito4@gmail.com";
        public int contrasenaAdmin = 123456789;

        BLLogin usuario = new BLLogin();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cerrarSesion.CausesValidation = false;
            if (!IsPostBack)
            {
                Opciones();
                CargaBienvenida();
            }
        }

        #region Cargar Bienvenida
        public void CargaBienvenida()
        {
            var fecha = Convert.ToDateTime(
                usuario.BuscarUsuario(
                    Session["email"].ToString())[1])
                .ToString("MM/dd/yyyy");
            string nombreCliente = Session["clienteNombre"].ToString();
            this.txtNombreSesion.InnerText = $"{nombreCliente} {Session["clienteSegundoApellido"]}";
            this.ultimaSesion.InnerText = $"{nombreCliente}, usted ingresó por última vez: {fecha}";
        }
        #endregion

        #region Evento cerrar sesión y actualización
        protected void CerrarSesion(object s, EventArgs e)
        {
            using (var db = new polizassigloxxiEntities())
            {
                db.usuarios
                          .SqlQuery("update usuarios set fecha_sesion=@nuevaFecha where correo_electronico=@email"
                          , new SqlParameter("@nuevaFecha", DateTime.Now.ToString("MM/dd/yyyy"))
                          , new SqlParameter("@email", Session["email"].ToString()));
            }
            Session.Add("estadoSesion", null);
            Session.Add("tipo", null);
            Session.Add("email", null);
            Session.Add("clienteCedula", null);
            Session.Add("clienteNombre", null);
            Session.Add("clientePrimerApellido", null);
            Session.Add("clienteSegundoApellido", null);
            Response.Redirect("~/Formularios/frmRegistroPrincipal.aspx");
        }
        #endregion

        #region Opciones
        /// <summary>
        /// Ocultar o mostrar opciones según la sesión iniciada
        /// Si la sesión iniciada es de administrador no se ocultará
        /// ninguna acción.
        /// </summary>
        public void Opciones()
        {
            if (Session["estadoSesion"] != null)
            {
                if (Session["tipo"].ToString() == "g")
                {
                    var btnRegistar = this.contentBody
                        .FindControl("btnRegistrar") as HtmlGenericControl;
                    btnRegistar.Visible = false;
                    this.op2.Visible = false;
                    this.op3.Visible = false;
                    this.op4.Visible = false;
                    this.op5.Visible = false;
                }
            }
        }
        #endregion

        #region Estado de acción
        public void Alerta(string mensaje, string tipo = "success", string nombreFunc = "actionMessage")
        {
            string alerta = "<script type='text/javascript'>" +
                "window.onload=()=>{" +
                nombreFunc + "('" + tipo + "'" + "," + "'" + mensaje + "')" +
                "}" +
                "</script>";

            Response.Write(alerta);
        }
        #endregion
    }
}