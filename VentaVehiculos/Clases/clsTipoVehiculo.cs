using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsTipoVehiculo
    {
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        public TipoVehiculo tipoVehiculo { get; set; }

        public IQueryable TipoVehiculoCombo()
        {
            return dbVentaVehiculos.TipoVehiculoes
                .OrderBy(t => t.Tipo)
                .Select(t => new
                {
                    Id = t.Codigo,
                    Nombre = t.Tipo
                });
        }
    }
}