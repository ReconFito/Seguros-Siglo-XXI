using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosSigloXXI.BL
{
    public class BLAdiccionCliente
    {
        polizassigloxxiEntities adiccionCliente = new polizassigloxxiEntities();
        #region Lista Adicciones por cliente
        public List<paMantenimientoAdiccionesClienteSelect_Result> ListaAdiccionCliente(int idAdiccion = -1)
        {
            var registro = adiccionCliente.paMantenimientoAdiccionesClienteSelect(idAdiccion).ToList();
            return registro;
        }
        #endregion

        #region Inserta Adiccion Cliente
        public bool InsertaAdiccionCliente(int idAdiccion, int idCliente)
        {
            int estadoInsert = adiccionCliente.paMantenimientoAdiccionesClienteInsert(idAdiccion, idCliente);
            return estadoInsert > 0;
        }
        #endregion

        #region Modifica Adiccion Cliente
        public bool ModificaAdiccionCliente(int id, int idAdiccion, int idCliente)
        {
            int estadoUpdate = adiccionCliente.paMantenimientoAdiccionesClienteUpdate(id, idAdiccion, idCliente);
            return estadoUpdate > 0;
        }
        #endregion

        #region Elimina Adiccion Cliente
        public bool EliminaAdiccionCliente(int id)
        {
            int estadoDelete = adiccionCliente.paMantenimientoAdiccionesClienteDelete(id);
            return estadoDelete > 0;
        }
        #endregion
    }
}