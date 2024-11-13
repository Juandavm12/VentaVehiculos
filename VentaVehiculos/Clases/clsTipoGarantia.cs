using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsTipoGarantia
    {
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        public TipoGarantia tipoGarantia { get; set; }

        public IQueryable TipoGarantiaCombo()
        {
            return dbVentaVehiculos.TipoGarantias
                .OrderBy(t => t.Nombre)
                .Select(t => new
                {
                    Id = t.Codigo,
                    Nombre = t.Nombre,
                    Descripcion = t.Descripcion
                });
        }
    }
}