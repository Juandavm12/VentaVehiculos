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
    
    public partial class Factura
    {
        public int id_factura { get; set; }
        public Nullable<int> id_venta { get; set; }
        public Nullable<System.DateTime> fecha_emision { get; set; }
        public Nullable<long> monto_total { get; set; }

        [JsonIgnore]
        public virtual Venta Venta { get; set; }
    }
}
