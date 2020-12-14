﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SegurosSigloXXI
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class polizassigloxxiEntities : DbContext
    {
        public polizassigloxxiEntities()
            : base("name=polizassigloxxiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Adicciones> Adicciones { get; set; }
        public DbSet<Cobertura_Poliza> Cobertura_Poliza { get; set; }
        public DbSet<Mantenimiento_Adicciones_Cliente> Mantenimiento_Adicciones_Cliente { get; set; }
        public DbSet<Mantenimiento_Cliente> Mantenimiento_Cliente { get; set; }
        public DbSet<Registro_Polizas> Registro_Polizas { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
    
        public virtual int paAdiccionesDelete(Nullable<int> pId_Adiccion)
        {
            var pId_AdiccionParameter = pId_Adiccion.HasValue ?
                new ObjectParameter("pId_Adiccion", pId_Adiccion) :
                new ObjectParameter("pId_Adiccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paAdiccionesDelete", pId_AdiccionParameter);
        }
    
        public virtual int paAdiccionesInsert(string pNombre, string pCodigo)
        {
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pCodigoParameter = pCodigo != null ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paAdiccionesInsert", pNombreParameter, pCodigoParameter);
        }
    
        public virtual ObjectResult<paAdiccionesSelect_Result> paAdiccionesSelect(Nullable<int> id_adiccion)
        {
            var id_adiccionParameter = id_adiccion.HasValue ?
                new ObjectParameter("id_adiccion", id_adiccion) :
                new ObjectParameter("id_adiccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paAdiccionesSelect_Result>("paAdiccionesSelect", id_adiccionParameter);
        }
    
        public virtual int paAdiccionesUpdate(Nullable<int> pID_ADICCION, string pNOMBRE, string codigo)
        {
            var pID_ADICCIONParameter = pID_ADICCION.HasValue ?
                new ObjectParameter("PID_ADICCION", pID_ADICCION) :
                new ObjectParameter("PID_ADICCION", typeof(int));
    
            var pNOMBREParameter = pNOMBRE != null ?
                new ObjectParameter("PNOMBRE", pNOMBRE) :
                new ObjectParameter("PNOMBRE", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paAdiccionesUpdate", pID_ADICCIONParameter, pNOMBREParameter, codigoParameter);
        }
    
        public virtual int paCoberturaPolizaDelete(Nullable<int> pId_Cobertura_Poliza)
        {
            var pId_Cobertura_PolizaParameter = pId_Cobertura_Poliza.HasValue ?
                new ObjectParameter("pId_Cobertura_Poliza", pId_Cobertura_Poliza) :
                new ObjectParameter("pId_Cobertura_Poliza", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paCoberturaPolizaDelete", pId_Cobertura_PolizaParameter);
        }
    
        public virtual int paCoberturaPolizaInsert(string pNombre, string pDescripcion, Nullable<decimal> pPorcentaje)
        {
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pDescripcionParameter = pDescripcion != null ?
                new ObjectParameter("pDescripcion", pDescripcion) :
                new ObjectParameter("pDescripcion", typeof(string));
    
            var pPorcentajeParameter = pPorcentaje.HasValue ?
                new ObjectParameter("pPorcentaje", pPorcentaje) :
                new ObjectParameter("pPorcentaje", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paCoberturaPolizaInsert", pNombreParameter, pDescripcionParameter, pPorcentajeParameter);
        }
    
        public virtual ObjectResult<paCoberturaPolizaSelect_Result> paCoberturaPolizaSelect(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paCoberturaPolizaSelect_Result>("paCoberturaPolizaSelect", idParameter);
        }
    
        public virtual int paCoberturaPolizaUpdate(Nullable<int> pId_Cobertura_Poliza, string pNombre, string pDescripcion, Nullable<decimal> pPorcentaje)
        {
            var pId_Cobertura_PolizaParameter = pId_Cobertura_Poliza.HasValue ?
                new ObjectParameter("pId_Cobertura_Poliza", pId_Cobertura_Poliza) :
                new ObjectParameter("pId_Cobertura_Poliza", typeof(int));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pDescripcionParameter = pDescripcion != null ?
                new ObjectParameter("pDescripcion", pDescripcion) :
                new ObjectParameter("pDescripcion", typeof(string));
    
            var pPorcentajeParameter = pPorcentaje.HasValue ?
                new ObjectParameter("pPorcentaje", pPorcentaje) :
                new ObjectParameter("pPorcentaje", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paCoberturaPolizaUpdate", pId_Cobertura_PolizaParameter, pNombreParameter, pDescripcionParameter, pPorcentajeParameter);
        }
    
        public virtual int paMantenimientoAdiccionesClienteDelete(Nullable<int> pId)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paMantenimientoAdiccionesClienteDelete", pIdParameter);
        }
    
        public virtual ObjectResult<paMantenimientoAdiccionesClienteInnerSelect_Result> paMantenimientoAdiccionesClienteInnerSelect(Nullable<int> iD_CLIENTE)
        {
            var iD_CLIENTEParameter = iD_CLIENTE.HasValue ?
                new ObjectParameter("ID_CLIENTE", iD_CLIENTE) :
                new ObjectParameter("ID_CLIENTE", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paMantenimientoAdiccionesClienteInnerSelect_Result>("paMantenimientoAdiccionesClienteInnerSelect", iD_CLIENTEParameter);
        }
    
        public virtual int paMantenimientoAdiccionesClienteInsert(Nullable<int> iD_ADICCION, Nullable<int> iD_CLIENTE)
        {
            var iD_ADICCIONParameter = iD_ADICCION.HasValue ?
                new ObjectParameter("ID_ADICCION", iD_ADICCION) :
                new ObjectParameter("ID_ADICCION", typeof(int));
    
            var iD_CLIENTEParameter = iD_CLIENTE.HasValue ?
                new ObjectParameter("ID_CLIENTE", iD_CLIENTE) :
                new ObjectParameter("ID_CLIENTE", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paMantenimientoAdiccionesClienteInsert", iD_ADICCIONParameter, iD_CLIENTEParameter);
        }
    
        public virtual ObjectResult<paMantenimientoAdiccionesClienteSelect_Result> paMantenimientoAdiccionesClienteSelect(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paMantenimientoAdiccionesClienteSelect_Result>("paMantenimientoAdiccionesClienteSelect", iDParameter);
        }
    
        public virtual int paMantenimientoAdiccionesClienteUpdate(Nullable<int> iD, Nullable<int> iD_ADICCION, Nullable<int> iD_CLIENTE)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var iD_ADICCIONParameter = iD_ADICCION.HasValue ?
                new ObjectParameter("ID_ADICCION", iD_ADICCION) :
                new ObjectParameter("ID_ADICCION", typeof(int));
    
            var iD_CLIENTEParameter = iD_CLIENTE.HasValue ?
                new ObjectParameter("ID_CLIENTE", iD_CLIENTE) :
                new ObjectParameter("ID_CLIENTE", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paMantenimientoAdiccionesClienteUpdate", iDParameter, iD_ADICCIONParameter, iD_CLIENTEParameter);
        }
    
        public virtual int paMantenimientoClienteDelete(Nullable<int> cedula)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paMantenimientoClienteDelete", cedulaParameter);
        }
    
        public virtual int paMantenimientoClienteInsert(Nullable<int> pCedula, string pGenero, Nullable<System.DateTime> pFecha_Nacimiento, string pNombre, string pPrimer_Apellido, string pSegundo_Apellido, string pDireccion_Fisica, Nullable<int> pTelefono_Principal, Nullable<int> pTelefono_Secundario, string pCorreo_Electronico)
        {
            var pCedulaParameter = pCedula.HasValue ?
                new ObjectParameter("pCedula", pCedula) :
                new ObjectParameter("pCedula", typeof(int));
    
            var pGeneroParameter = pGenero != null ?
                new ObjectParameter("pGenero", pGenero) :
                new ObjectParameter("pGenero", typeof(string));
    
            var pFecha_NacimientoParameter = pFecha_Nacimiento.HasValue ?
                new ObjectParameter("pFecha_Nacimiento", pFecha_Nacimiento) :
                new ObjectParameter("pFecha_Nacimiento", typeof(System.DateTime));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pPrimer_ApellidoParameter = pPrimer_Apellido != null ?
                new ObjectParameter("pPrimer_Apellido", pPrimer_Apellido) :
                new ObjectParameter("pPrimer_Apellido", typeof(string));
    
            var pSegundo_ApellidoParameter = pSegundo_Apellido != null ?
                new ObjectParameter("pSegundo_Apellido", pSegundo_Apellido) :
                new ObjectParameter("pSegundo_Apellido", typeof(string));
    
            var pDireccion_FisicaParameter = pDireccion_Fisica != null ?
                new ObjectParameter("pDireccion_Fisica", pDireccion_Fisica) :
                new ObjectParameter("pDireccion_Fisica", typeof(string));
    
            var pTelefono_PrincipalParameter = pTelefono_Principal.HasValue ?
                new ObjectParameter("pTelefono_Principal", pTelefono_Principal) :
                new ObjectParameter("pTelefono_Principal", typeof(int));
    
            var pTelefono_SecundarioParameter = pTelefono_Secundario.HasValue ?
                new ObjectParameter("pTelefono_Secundario", pTelefono_Secundario) :
                new ObjectParameter("pTelefono_Secundario", typeof(int));
    
            var pCorreo_ElectronicoParameter = pCorreo_Electronico != null ?
                new ObjectParameter("pCorreo_Electronico", pCorreo_Electronico) :
                new ObjectParameter("pCorreo_Electronico", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paMantenimientoClienteInsert", pCedulaParameter, pGeneroParameter, pFecha_NacimientoParameter, pNombreParameter, pPrimer_ApellidoParameter, pSegundo_ApellidoParameter, pDireccion_FisicaParameter, pTelefono_PrincipalParameter, pTelefono_SecundarioParameter, pCorreo_ElectronicoParameter);
        }
    
        public virtual ObjectResult<paMantenimientoClienteSelect_Result> paMantenimientoClienteSelect(Nullable<int> cedula)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paMantenimientoClienteSelect_Result>("paMantenimientoClienteSelect", cedulaParameter);
        }
    
        public virtual int paMantenimientoClienteUpdate(Nullable<int> pId_Cliente, Nullable<int> pCedula, string pGenero, Nullable<System.DateTime> pFecha_Nacimiento, string pNombre, string pPrimer_Apellido, string pSegundo_Apellido, string pDireccion_Fisica, Nullable<int> pTelefono_Principal, Nullable<int> pTelefono_Secundario, string pCorreo_Electronico)
        {
            var pId_ClienteParameter = pId_Cliente.HasValue ?
                new ObjectParameter("pId_Cliente", pId_Cliente) :
                new ObjectParameter("pId_Cliente", typeof(int));
    
            var pCedulaParameter = pCedula.HasValue ?
                new ObjectParameter("pCedula", pCedula) :
                new ObjectParameter("pCedula", typeof(int));
    
            var pGeneroParameter = pGenero != null ?
                new ObjectParameter("pGenero", pGenero) :
                new ObjectParameter("pGenero", typeof(string));
    
            var pFecha_NacimientoParameter = pFecha_Nacimiento.HasValue ?
                new ObjectParameter("pFecha_Nacimiento", pFecha_Nacimiento) :
                new ObjectParameter("pFecha_Nacimiento", typeof(System.DateTime));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pPrimer_ApellidoParameter = pPrimer_Apellido != null ?
                new ObjectParameter("pPrimer_Apellido", pPrimer_Apellido) :
                new ObjectParameter("pPrimer_Apellido", typeof(string));
    
            var pSegundo_ApellidoParameter = pSegundo_Apellido != null ?
                new ObjectParameter("pSegundo_Apellido", pSegundo_Apellido) :
                new ObjectParameter("pSegundo_Apellido", typeof(string));
    
            var pDireccion_FisicaParameter = pDireccion_Fisica != null ?
                new ObjectParameter("pDireccion_Fisica", pDireccion_Fisica) :
                new ObjectParameter("pDireccion_Fisica", typeof(string));
    
            var pTelefono_PrincipalParameter = pTelefono_Principal.HasValue ?
                new ObjectParameter("pTelefono_Principal", pTelefono_Principal) :
                new ObjectParameter("pTelefono_Principal", typeof(int));
    
            var pTelefono_SecundarioParameter = pTelefono_Secundario.HasValue ?
                new ObjectParameter("pTelefono_Secundario", pTelefono_Secundario) :
                new ObjectParameter("pTelefono_Secundario", typeof(int));
    
            var pCorreo_ElectronicoParameter = pCorreo_Electronico != null ?
                new ObjectParameter("pCorreo_Electronico", pCorreo_Electronico) :
                new ObjectParameter("pCorreo_Electronico", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paMantenimientoClienteUpdate", pId_ClienteParameter, pCedulaParameter, pGeneroParameter, pFecha_NacimientoParameter, pNombreParameter, pPrimer_ApellidoParameter, pSegundo_ApellidoParameter, pDireccion_FisicaParameter, pTelefono_PrincipalParameter, pTelefono_SecundarioParameter, pCorreo_ElectronicoParameter);
        }
    
        public virtual int paRegistroClienteDelete(Nullable<int> pId)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paRegistroClienteDelete", pIdParameter);
        }
    
        public virtual ObjectResult<paRegistroPolizasInnerSelect_Result> paRegistroPolizasInnerSelect()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paRegistroPolizasInnerSelect_Result>("paRegistroPolizasInnerSelect");
        }
    
        public virtual int paRegistroPolizasInsert(Nullable<int> iD_COBERTURA_POLIZA, Nullable<int> iD_CLIENTE, Nullable<decimal> pMONTO_ASEGURADO, Nullable<decimal> pPORCENTAJE_COBERTURA, Nullable<int> pNUMERO_ADICCIONES, Nullable<decimal> pMONTOADICCIONES, Nullable<decimal> pPRIMA_ANTES_IMPUESTOS, Nullable<decimal> pIMPUESTOS, Nullable<decimal> pPRIMA_FINAL)
        {
            var iD_COBERTURA_POLIZAParameter = iD_COBERTURA_POLIZA.HasValue ?
                new ObjectParameter("ID_COBERTURA_POLIZA", iD_COBERTURA_POLIZA) :
                new ObjectParameter("ID_COBERTURA_POLIZA", typeof(int));
    
            var iD_CLIENTEParameter = iD_CLIENTE.HasValue ?
                new ObjectParameter("ID_CLIENTE", iD_CLIENTE) :
                new ObjectParameter("ID_CLIENTE", typeof(int));
    
            var pMONTO_ASEGURADOParameter = pMONTO_ASEGURADO.HasValue ?
                new ObjectParameter("PMONTO_ASEGURADO", pMONTO_ASEGURADO) :
                new ObjectParameter("PMONTO_ASEGURADO", typeof(decimal));
    
            var pPORCENTAJE_COBERTURAParameter = pPORCENTAJE_COBERTURA.HasValue ?
                new ObjectParameter("PPORCENTAJE_COBERTURA", pPORCENTAJE_COBERTURA) :
                new ObjectParameter("PPORCENTAJE_COBERTURA", typeof(decimal));
    
            var pNUMERO_ADICCIONESParameter = pNUMERO_ADICCIONES.HasValue ?
                new ObjectParameter("PNUMERO_ADICCIONES", pNUMERO_ADICCIONES) :
                new ObjectParameter("PNUMERO_ADICCIONES", typeof(int));
    
            var pMONTOADICCIONESParameter = pMONTOADICCIONES.HasValue ?
                new ObjectParameter("PMONTOADICCIONES", pMONTOADICCIONES) :
                new ObjectParameter("PMONTOADICCIONES", typeof(decimal));
    
            var pPRIMA_ANTES_IMPUESTOSParameter = pPRIMA_ANTES_IMPUESTOS.HasValue ?
                new ObjectParameter("PPRIMA_ANTES_IMPUESTOS", pPRIMA_ANTES_IMPUESTOS) :
                new ObjectParameter("PPRIMA_ANTES_IMPUESTOS", typeof(decimal));
    
            var pIMPUESTOSParameter = pIMPUESTOS.HasValue ?
                new ObjectParameter("PIMPUESTOS", pIMPUESTOS) :
                new ObjectParameter("PIMPUESTOS", typeof(decimal));
    
            var pPRIMA_FINALParameter = pPRIMA_FINAL.HasValue ?
                new ObjectParameter("PPRIMA_FINAL", pPRIMA_FINAL) :
                new ObjectParameter("PPRIMA_FINAL", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paRegistroPolizasInsert", iD_COBERTURA_POLIZAParameter, iD_CLIENTEParameter, pMONTO_ASEGURADOParameter, pPORCENTAJE_COBERTURAParameter, pNUMERO_ADICCIONESParameter, pMONTOADICCIONESParameter, pPRIMA_ANTES_IMPUESTOSParameter, pIMPUESTOSParameter, pPRIMA_FINALParameter);
        }
    
        public virtual ObjectResult<paRegistroPolizasSelect_Result> paRegistroPolizasSelect(Nullable<int> iD_REGISTRO)
        {
            var iD_REGISTROParameter = iD_REGISTRO.HasValue ?
                new ObjectParameter("ID_REGISTRO", iD_REGISTRO) :
                new ObjectParameter("ID_REGISTRO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paRegistroPolizasSelect_Result>("paRegistroPolizasSelect", iD_REGISTROParameter);
        }
    
        public virtual int paRegistroPolizaUpdate(Nullable<int> pID, Nullable<int> pID_COBERTURA_POLIZA, Nullable<int> pID_CLIENTE, Nullable<decimal> pMONTO_ASEGURADO, Nullable<decimal> pPORCENTAJE_COBERTURA, Nullable<int> pNUMERO_ADICCIONES, Nullable<decimal> monto_adicciones, Nullable<decimal> pPRIMA_ANTES_IMPUESTOS, Nullable<decimal> pIMPUESTOS, Nullable<decimal> pPRIMA_FINAL)
        {
            var pIDParameter = pID.HasValue ?
                new ObjectParameter("PID", pID) :
                new ObjectParameter("PID", typeof(int));
    
            var pID_COBERTURA_POLIZAParameter = pID_COBERTURA_POLIZA.HasValue ?
                new ObjectParameter("PID_COBERTURA_POLIZA", pID_COBERTURA_POLIZA) :
                new ObjectParameter("PID_COBERTURA_POLIZA", typeof(int));
    
            var pID_CLIENTEParameter = pID_CLIENTE.HasValue ?
                new ObjectParameter("PID_CLIENTE", pID_CLIENTE) :
                new ObjectParameter("PID_CLIENTE", typeof(int));
    
            var pMONTO_ASEGURADOParameter = pMONTO_ASEGURADO.HasValue ?
                new ObjectParameter("PMONTO_ASEGURADO", pMONTO_ASEGURADO) :
                new ObjectParameter("PMONTO_ASEGURADO", typeof(decimal));
    
            var pPORCENTAJE_COBERTURAParameter = pPORCENTAJE_COBERTURA.HasValue ?
                new ObjectParameter("PPORCENTAJE_COBERTURA", pPORCENTAJE_COBERTURA) :
                new ObjectParameter("PPORCENTAJE_COBERTURA", typeof(decimal));
    
            var pNUMERO_ADICCIONESParameter = pNUMERO_ADICCIONES.HasValue ?
                new ObjectParameter("PNUMERO_ADICCIONES", pNUMERO_ADICCIONES) :
                new ObjectParameter("PNUMERO_ADICCIONES", typeof(int));
    
            var monto_adiccionesParameter = monto_adicciones.HasValue ?
                new ObjectParameter("monto_adicciones", monto_adicciones) :
                new ObjectParameter("monto_adicciones", typeof(decimal));
    
            var pPRIMA_ANTES_IMPUESTOSParameter = pPRIMA_ANTES_IMPUESTOS.HasValue ?
                new ObjectParameter("PPRIMA_ANTES_IMPUESTOS", pPRIMA_ANTES_IMPUESTOS) :
                new ObjectParameter("PPRIMA_ANTES_IMPUESTOS", typeof(decimal));
    
            var pIMPUESTOSParameter = pIMPUESTOS.HasValue ?
                new ObjectParameter("PIMPUESTOS", pIMPUESTOS) :
                new ObjectParameter("PIMPUESTOS", typeof(decimal));
    
            var pPRIMA_FINALParameter = pPRIMA_FINAL.HasValue ?
                new ObjectParameter("PPRIMA_FINAL", pPRIMA_FINAL) :
                new ObjectParameter("PPRIMA_FINAL", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paRegistroPolizaUpdate", pIDParameter, pID_COBERTURA_POLIZAParameter, pID_CLIENTEParameter, pMONTO_ASEGURADOParameter, pPORCENTAJE_COBERTURAParameter, pNUMERO_ADICCIONESParameter, monto_adiccionesParameter, pPRIMA_ANTES_IMPUESTOSParameter, pIMPUESTOSParameter, pPRIMA_FINALParameter);
        }
    
        public virtual int paRegistroPolizaDelete(Nullable<int> pId)
        {
            var pIdParameter = pId.HasValue ?
                new ObjectParameter("pId", pId) :
                new ObjectParameter("pId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paRegistroPolizaDelete", pIdParameter);
        }
    }
}
