using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegurosSigloXXI.BL
{
    public class BLRegistroPoliza
    {
        polizassigloxxiEntities registroPoliza = new polizassigloxxiEntities();
        #region Registros de poliza innerSelect
        /// <summary>
        /// Método encargado de filtar registros usando los parámetros opcionales enviados
        /// por el usuario, sobre la tabla registro de polizas.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idCliente"></param>
        /// <param name="idCobertura"></param>
        /// <param name="montoAsegurado"></param>
        /// <param name="numeroAdicciones"></param>
        /// <returns></returns>
        public List<pa_RegistroPolizasInnerSelect1_Result> InnerSelectRegistroPolizas(int id, int idCliente,
                                                                        int idCobertura, decimal montoAsegurado,
                                                                        int numeroAdicciones)
        {
            var registros = registroPoliza.pa_RegistroPolizasInnerSelect1(id, idCliente, idCobertura,
                                                                         montoAsegurado, numeroAdicciones).ToList();
            return registros;
        }
        #endregion

        #region Lista Registro de pólizas
        public List<paRegistroPolizasSelect_Result> ListaRegistroPoliza(int idRegistro = -1, int idCliente = -1)
        {
            var registro = registroPoliza.paRegistroPolizasSelect(idRegistro, idCliente).ToList();
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
        public bool ModificaRegistroPoliza(int id, int idCoberturaPoliza, decimal montoAsegurado,
                                            decimal porcentajeCobertura, decimal montoAdicciones, 
                                            decimal primaAntesImpuesto,decimal impuesto, decimal primaFinal)
        {
            int estadoUpdate = registroPoliza
                .paRegistroPolizaUpdate(id, idCoberturaPoliza, montoAsegurado,
                                        porcentajeCobertura, montoAdicciones,
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