using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsTipoServicio
    {
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        public TipoServicio tipoServicio { get; set; }

        public IQueryable TipoServicioCombo()
        {
            return dbVentaVehiculos.TipoServicios
                .OrderBy(t => t.Tipo)
                .Select(t => new
                {
                    Id = t.Codigo,
                    Nombre = t.Tipo,
                    Costo = t.Costo
                });
        }
    }
}