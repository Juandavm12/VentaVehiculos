using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsEstadoVehiculo
    {
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        public EstadoVehiculo estadoVehiculo { get; set; }

        public IQueryable EstadoVehiculoCombo()
        {
            return dbVentaVehiculos.EstadoVehiculoes
                .OrderBy(t => t.Codigo)
                .Select(t => new
                {
                    Id = t.Codigo,
                    Nombre = t.Estado,
                    Comentarios = t.Comentarios
                });
        }
    }
}