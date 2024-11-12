using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsEstadoServicio
    {
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        public EstadoServicio estadoServicio { get; set; }

        public IQueryable EstadoServicioCombo()
        {
            return dbVentaVehiculos.EstadoServicios
                .OrderBy(t => t.Estado)
                .Select(t => new
                {
                    Id = t.Codigo,
                    Nombre = t.Estado
                });
        }
    }
}