using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsUsuario
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities2 dbVentaVehiculos = new VentaVehiculosEntities2();
        
        //Objeto de la tabla usuario
        public Usuario obj { get; set; }

        public string AddUser()
        {
            try
            {
                //Add method and Usuario data call
                dbVentaVehiculos.Usuarios.Add(obj);

                //SaveChanges method call to save the client in the database
                dbVentaVehiculos.SaveChanges();
                return "El Usuario " + obj.nombre + " con documento " + obj.documento + " ha sido creado exitosamente";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UpdateUser()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                dbVentaVehiculos.Usuarios.AddOrUpdate(obj);

                dbVentaVehiculos.SaveChanges();
                return "Usuario ha sido actualizado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Usuario SearchUser(string documento)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.Usuarios.FirstOrDefault(x => x.documento == documento);
        }

        public string DeleteUser()
        {
            try
            {
                //We use Search method that we created to allow us searching for the user id we want to delete
                Usuario _obj = SearchUser(obj.documento);

                if (_obj.documento != null)
                {
                    dbVentaVehiculos.Usuarios.Remove(_obj);
                    dbVentaVehiculos.SaveChanges();
                    return "El Usuario " + obj.nombre + " con documento " + obj.documento + " ha sido eliminado exitosamente";
                }
                else 
                {
                    return "El Usuario que intenta eliminar no existe";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Method to search for a user
        public string AuthUser(Usuario newuser)
        {
            try
            {
                SearchUser(obj.documento);
                if (newuser.documento.Equals(obj.documento))
                {
                    return "El usuario con el documento " + obj.documento + " ya existe";
                }
                else
                {
                    return AddUser();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}