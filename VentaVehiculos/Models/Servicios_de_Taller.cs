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
    
    public partial class Servicios_de_Taller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicios_de_Taller()
        {
            this.Citas_Taller = new HashSet<Citas_Taller>();
        }
    
        public int id_servicio { get; set; }
        public string placa_vehiculo { get; set; }
        public Nullable<int> id_tipo_servicio { get; set; }
        public Nullable<System.DateTime> fecha_servicio { get; set; }
        public Nullable<int> id_estado_servicio { get; set; }
        public string comentarios { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas_Taller> Citas_Taller { get; set; }

        [JsonIgnore]
        public virtual Estado_Servicio Estado_Servicio { get; set; }

        [JsonIgnore]
        public virtual Tipo_Servicio Tipo_Servicio { get; set; }

        [JsonIgnore]
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
