using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsPerfil
    {
        private VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        public Perfil perfil {  get; set; }

        public IQueryable PerfilCombo()
        {
            return dbVentaVehiculos.Perfils                
                .Select(t => new
                {
                    Id = t.Id,
                    Nombre = t.Nombre
                });
        }
    }
}