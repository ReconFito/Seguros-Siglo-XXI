//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Registro_Polizas
    {
        public int Id { get; set; }
        public int Id_Cobertura_Poliza { get; set; }
        public int Id_Cliente { get; set; }
        public decimal Monto_Asegurado { get; set; }
        public decimal Porcentaje_Cobertura { get; set; }
        public int Numero_Adicciones { get; set; }
        public decimal Monto_Adicciones { get; set; }
        public decimal Prima_Antes_Impuestos { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Prima_Final { get; set; }
    
        public virtual Cobertura_Poliza Cobertura_Poliza { get; set; }
    }
}
