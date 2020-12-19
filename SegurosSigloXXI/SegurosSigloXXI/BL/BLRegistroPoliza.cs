using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosSigloXXI.BL
{
    public class BLRegistroPoliza
    {
        polizassigloxxiEntities registroPoliza = new polizassigloxxiEntities();
        #region Lista Registro de pólizas
        public List<paRegistroPolizasSelect_Result> ListaRegistroPoliza(int idRegistro = -1)
        {
            var registro = registroPoliza.paRegistroPolizasSelect(idRegistro).ToList();
            return registro;
        }
        #endregion

        #region Inserta Registro póliza
        public bool InsertaRegistroPoliza(int idCoberturaPoliza, int idCliente, decimal montoAsegurado,
                                            decimal porcentajeCobertura, int numeroAdicciones,
                                            decimal montoAdicciones, decimal primaAntesImpuesto,
                                            decimal impuesto, decimal primaFinal)
        {
            int estadoInsert = registroPoliza
                .paRegistroPolizasInsert(idCoberturaPoliza, idCliente, montoAsegurado,
                                        porcentajeCobertura, numeroAdicciones, montoAdicciones,
                                        primaAntesImpuesto, impuesto, primaFinal);
            return estadoInsert > 0;
        }
        #endregion

        #region Modifica Registro póliza
        public bool ModificaRegistroPoliza(int id, int idCoberturaPoliza, int idCliente, decimal montoAsegurado,
                                            decimal porcentajeCobertura, int numeroAdicciones,
                                            decimal montoAdicciones, decimal primaAntesImpuesto,
                                            decimal impuesto, decimal primaFinal)
        {
            int estadoUpdate = registroPoliza
                .paRegistroPolizaUpdate(id, idCoberturaPoliza, idCliente, montoAsegurado,
                                        porcentajeCobertura, numeroAdicciones, montoAdicciones,
                                        primaAntesImpuesto, impuesto, primaFinal);
            return estadoUpdate > 0;

        }
        #endregion

        #region Elimina Registro póliza
        public bool EliminaRegistroPoliza(int idRegistro)
        {
            int estadoDelete = registroPoliza.paRegistroPolizaDelete(idRegistro);
            return estadoDelete > 0;
        }
        #endregion
    }
}