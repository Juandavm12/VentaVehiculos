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
    
    public partial class ServicioTaller
    {
        public int Id { get; set; }
        public string DocCliente { get; set; }
        public string PlacaVeh { get; set; }
        public int CodEstadoServicio { get; set; }
        public int CodTipoServicio { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Comentarios { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual EstadoServicio EstadoServicio { get; set; }
        public virtual TipoServicio TipoServicio { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
