//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentaVehiculos.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Garantia
    {
        public int Codigo { get; set; }
        public int NumFactura { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFinal { get; set; }
        public int CodTipoGarantia { get; set; }

        [JsonIgnore]
        public virtual Factura Factura { get; set; }
        [JsonIgnore]
        public virtual TipoGarantia TipoGarantia { get; set; }
    }
}
