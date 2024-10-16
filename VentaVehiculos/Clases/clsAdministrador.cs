using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsAdministrador 
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla usuario
        public Administrador admin { get; set; }

        public string InsertarAdmin()
        {
            try
            {
                Administrador _admin = BuscarAdmin(admin.Documento);

                if (_admin == null)
                {
                    dbVentaVehiculos.Administradors.Add(admin);
                    dbVentaVehiculos.SaveChanges();
                    return "El Administrador " + admin.Nombre + " ha sido creado exitosamente";
                }
                else
                {
                    return "El documento " + admin.Documento + " ya esta asociado a un administrador";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string ActualizarAdmin()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                Administrador _admin = BuscarAdmin(admin.Documento);

                if (_admin != null)
                {
                    dbVentaVehiculos.Administradors.AddOrUpdate(admin);
                    dbVentaVehiculos.SaveChanges();
                    return "El Administrador " + admin.Nombre + " se ha actualizado exitosamente";
                }
                else
                {
                    return "El Administrador que intenta actualizar no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Administrador BuscarAdmin(string documento)
        {
            return dbVentaVehiculos.Administradors.FirstOrDefault(x => x.Documento == documento);
        }

        public string EliminarAdmin()
        {
            try
            {
                //We use Search method that we created to allow us searching for the user id we want to delete
                Administrador _admin = BuscarAdmin(admin.Documento);

                if (_admin != null)
                {
                    dbVentaVehiculos.Administradors.Remove(_admin);
                    dbVentaVehiculos.SaveChanges();
                    return "El Administrador " + admin.Nombre + " se ha eliminado exitosamente";
                }
                else
                {
                    return "El Administrador que intenta eliminar no existe";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}