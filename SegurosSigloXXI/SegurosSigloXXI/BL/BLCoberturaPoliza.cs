using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosSigloXXI.BL
{
    public class BLCoberturaPoliza
    {
        polizassigloxxiEntities coberturaPoliza = new polizassigloxxiEntities();
        #region Lista Coberturas de pólizas
        public List<paCoberturaPolizaSelect_Result> ListaCoberturaPolizas(int idCobertura = -1)
        {
            var registros = coberturaPoliza.paCoberturaPolizaSelect(idCobertura).ToList();
            return registros;
        }
        #endregion

        #region Inserta Cobertura póliza
        public bool InsertaCoberturaPoliza(string nombre, string descripcion, decimal porcentaje)
        {
            int estadoInsert = coberturaPoliza.paCoberturaPolizaInsert(nombre, descripcion, porcentaje);
            return estadoInsert > 0;
        }
        #endregion

        #region Modifica Cobertura póliza
        public bool ModificaCoberturaPoliza(int idCobertura, string nombre, string descripcion, decimal porcentaje)
        {
            int estadoUpdate = coberturaPoliza.paCoberturaPolizaUpdate(idCobertura, nombre, descripcion, porcentaje);
            return estadoUpdate > 0;
        }
        #endregion

        #region Elimina Cobertura póliza
        public bool EliminaCoberturaPoliza(int idCobertura)
        {
            int estadoDelete = coberturaPoliza.paCoberturaPolizaDelete(idCobertura);
            return estadoDelete > 0;
        }
        #endregion
    }
}