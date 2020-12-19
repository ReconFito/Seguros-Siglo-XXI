using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace SegurosSigloXXI.BL
{
    public class BLLogin
    {
        polizassigloxxiEntities usuario = new polizassigloxxiEntities();
        #region Verifica Usuario
        public bool VerificaUsuario(string _email, int _contrasena)
        {
            int estado;
            using (var db = new polizassigloxxiEntities())
            {
                estado = db.usuarios
                    .SqlQuery("select * from usuarios where " +
                                "correo_electronico=@email and " +
                                "contrasena_cedula=@contrasena",
                    new SqlParameter("@email", _email),
                    new SqlParameter("@contrasena", _contrasena)).ToList().Count();
            }
            return estado > 0;
        }
        #endregion

        #region Buscar Usuario
        public object[] BuscarUsuario(string email)
        {
            var informacionUsuario = from item in usuario.usuarios
                                     where (item.correo_electronico == email)
                                     select new
                                     {
                                         tipoUsuario = item.tipo,
                                         fechaSesion = item.fecha_sesion
                                     };
            object[] datos = new object[] { informacionUsuario.FirstOrDefault().tipoUsuario,
                                            informacionUsuario.FirstOrDefault().fechaSesion};
            return datos;
        }
        #endregion
    }
}