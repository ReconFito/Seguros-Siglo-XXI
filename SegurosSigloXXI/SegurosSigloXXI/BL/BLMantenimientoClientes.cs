using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosSigloXXI.BL
{
    public class BLMantenimientoClientes
    {
        // Instancia modelo de bases de datos
        polizassigloxxiEntities mClientes = new polizassigloxxiEntities();

        #region Listar Clientes
        public List<paMantenimientoClienteSelect_Result> ListaClientes(Nullable<int> _cedula = null)
        {
            var listaClientes = mClientes.paMantenimientoClienteSelect(_cedula).ToList();
            return listaClientes;
        }
        #endregion

        #region Insertar Cliente
        public bool InsertaCliente(int cedula, string genero,
                                   DateTime fechaNaci, string nombre, string primerApellido,
                                   string direccion, int tel1,
                                   string correo, string segundoApellido = null,
                                   Nullable<int> tel2 = null)
        {
            int registro = mClientes.paMantenimientoClienteInsert(cedula, genero, fechaNaci,
                                                                nombre, primerApellido, segundoApellido,
                                                                direccion, tel1, tel2, correo);
            return registro > 0;
        }
        #endregion

        #region Modificar Cliente
        public bool ModificaCliente(int idCliente, int cedula, string genero,
                                   DateTime fechaNaci, string nombre, string primerApellido,
                                   string direccion, int tel1,
                                   string correo, string segundoApellido,
                                   Nullable<int> tel2 = null)
        {
            int estado = mClientes.paMantenimientoClienteUpdate(idCliente, cedula, genero, fechaNaci,
                                                                nombre, primerApellido, segundoApellido,
                                                                direccion, tel1, tel2.Value, correo);
            return estado > 0;
        }
        #endregion

        #region Elimina Cliente
        public bool EliminaCliente(int _cedula)
        {
            int estado = mClientes.paMantenimientoClienteDelete(_cedula);
            return estado > 0;
        }
        #endregion
    }
}