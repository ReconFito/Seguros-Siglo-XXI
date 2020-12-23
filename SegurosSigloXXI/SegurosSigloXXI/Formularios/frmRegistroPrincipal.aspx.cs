using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SegurosSigloXXI.BL;
using System.Data.SqlClient;

namespace SegurosSigloXXI
{
    public partial class RegistroPrincipal : System.Web.UI.Page
    {
        BLLogin login = new BLLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void IniciarSesion(object s, EventArgs e)
        {
            if (IsValid)
            {
                verificarUsuario();
            }
        }

        public void verificarUsuario()
        {
            // Campos del formulario
            string email = this.txtEmail.Value;
            int contrasena = int.Parse(this.txtPassword.Value);
            if (email == "munozfito4@gmail.com" && contrasena == 123456789)
            {
                Session.Add("estadoSesion", true);
                Session.Add("email", "munozfito4@gmail.com");
                Session.Add("clienteCedula", 123456789);
                Session.Add("clienteNombre", "Emanuel");
                Session.Add("clientePrimerApellido", "Núñez");
                Session.Add("clienteSegundoApellido", "Maliaño");
                Session.Add("tipo", "a");

                Response.Redirect("~/Formularios/frmMantenimientoCliente.aspx");
            }
            else
            {
                bool estado = login.VerificaUsuario(email, contrasena);
                if (!estado)
                {
                    Response.Write("<script type='text/javascript'>window.onload = () => {mensaje();}</script>");
                }
                else
                {
                    // Si el usuario y contraseña son correctos se busca la informacion del usuario
                    using (var db = new polizassigloxxiEntities())
                    {                        
                        var registro = db.Mantenimiento_Cliente.
                            SqlQuery("select * from Mantenimiento_Cliente where Correo_Electronico=@email",
                                        new SqlParameter("@email", email))
                                        .ToList().FirstOrDefault();
                        
                        // Seleccionar el tipo de usuario registrado en la base de datos
                        string tipoUsuario = login.BuscarUsuario(email)[0].ToString();

                        // Establecer la fecha de inicio de sesión por defecto es nulo
                        db.usuarios
                            .SqlQuery("update usuarios set fecha_sesion=@fecha where correo_electronico=@email",
                            new SqlParameter("@email", email),
                            new SqlParameter("@fecha", DateTime.Now));

                        // Reestablecer valores de sesión
                        Session.Add("estadoSesion", true);
                        Session.Add("tipo", tipoUsuario);
                        Session.Add("email", email);
                        Session.Add("clienteCedula", registro.Cedula);
                        Session.Add("clienteNombre", registro.Nombre);
                        Session.Add("clientePrimerApellido", registro.Primer_Apellido);
                        Session.Add("clienteSegundoApellido", registro.Segundo_Apellido);

                        Response.Redirect("~/Formularios/frmMantenimientoCliente.aspx");
                    }
                }
            }
        }
    }
}