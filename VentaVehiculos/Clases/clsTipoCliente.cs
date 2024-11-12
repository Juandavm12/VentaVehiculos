
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsTipoCliente
    {
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        public TipoCliente  tipoCliente { get; set; }

        public IQueryable TipoClienteCombo()
        {
            return dbVentaVehiculos.TipoClientes
                .OrderBy(t => t.Membresia)
                .Select(t => new
                {
                    Id = t.Id,
                    Nombre = t.Membresia,
                    Descuento = t.Descuento
                });
        }
    }
}