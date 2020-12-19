using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosSigloXXI.BL
{
    public class BLAdicciones
    {
        polizassigloxxiEntities adicciones = new polizassigloxxiEntities();
        #region Lista Adicciones
        public List<paAdiccionesSelect_Result> ListaAdicciones(int idAdiccion = -1)
        {
            var registro = adicciones.paAdiccionesSelect(idAdiccion).ToList();
            return registro;
        }
        #endregion

        #region Inserta Adicción
        public bool InsertaAdiccion(string nombre, string codigo)
        {
            int estadoInsert = adicciones.paAdiccionesInsert(nombre, codigo);
            return estadoInsert > 0;
        }
        #endregion

        #region Modifica Adicción
        public bool ModificaAdiccion(int idAdiccion, string nombre, string codigo)
        {
            int estadoUpdate = adicciones.paAdiccionesUpdate(idAdiccion, nombre, codigo);
            return estadoUpdate > 0;
        }
        #endregion

        #region Elimina Adicción
        public bool EliminaAdiccion(int idAdiccion)
        {
            int estadoDelete = adicciones.paAdiccionesDelete(idAdiccion);
            return estadoDelete > 0;
        }
        #endregion
    }
}