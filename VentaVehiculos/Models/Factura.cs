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
    using System;
    using System.Collections.Generic;
    
    public partial class Factura
    {
        public int Numero { get; set; }
        public int CodVenta { get; set; }
        public string PlacaVeh { get; set; }
        public double Cantidad { get; set; }
        public double VUnidad { get; set; }
        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double VTotal { get; set; }
    
        public virtual Venta Venta { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
