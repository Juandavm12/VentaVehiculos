
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsTipoCliente
    {
        VentaVehiculosEntities2 dbVentaVehiculos = new VentaVehiculosEntities2();

        public Tipo_Cliente  tipo_Cliente { get; set; }

        public List<Tipo_Cliente> TipoClientCombo()
        {
            return dbVentaVehiculos.Tipo_Cliente
                .OrderBy(t => t.membresia)
                .ToList();
        }
    }
}