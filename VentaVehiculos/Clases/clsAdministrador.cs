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
        VentaVehiculosEntities2 dbVentaVehiculos = new VentaVehiculosEntities2();

        //Objeto de la tabla usuario
        public Administradore obj { get; set; }

        public string AddAdmin()
        {
            try
            {
                //Add method and Usuario data call
                dbVentaVehiculos.Administradores.Add(obj);

                //SaveChanges method call to save the client in the database
                dbVentaVehiculos.SaveChanges();
                return "El Admin " + obj.nombre + " con documento " + obj.documento + " ha sido creado exitosamente";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UpdateAdmin()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                dbVentaVehiculos.Administradores.AddOrUpdate(obj);

                dbVentaVehiculos.SaveChanges();
                return "El Admin ha sido actualizado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Administradore SearchAdmin(string documento)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.Administradores.FirstOrDefault(x => x.documento == documento);
        }

        public string DeleteAdmin()
        {
            try
            {
                //We use Search method that we created to allow us searching for the user id we want to delete
                Administradore _obj = SearchAdmin(obj.documento);

                if (_obj.documento != null)
                {
                    dbVentaVehiculos.Administradores.Remove(_obj);
                    dbVentaVehiculos.SaveChanges();
                    return "El Admin " + obj.nombre + " con documento " + obj.documento + " ha sido eliminado exitosamente";
                }
                else
                {
                    return "El Admin que intenta eliminar no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AuthAdmin(Administradore newadmin)
        {
            try
            {
                SearchAdmin(obj.documento);
                if (newadmin.documento.Equals(obj.documento))
                {
                    return "El admin con el documento " + obj.documento + " ya existe";
                }
                else
                {
                    return AddAdmin();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}