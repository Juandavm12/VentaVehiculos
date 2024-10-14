using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsCliente
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities2 dbVentaVehiculos = new VentaVehiculosEntities2();

        //Objeto de la tabla usuario
        public Cliente obj { get; set; }

        public string AddClient()
        {
            try
            {
                //Add method and Usuario data call
                dbVentaVehiculos.Clientes.Add(obj);

                //SaveChanges method call to save the client in the database
                dbVentaVehiculos.SaveChanges();
                return "El Cliente " + obj.nombre + " con documento " + obj.documento + " ha sido creado exitosamente";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UpdateClient()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                dbVentaVehiculos.Clientes.AddOrUpdate(obj);

                dbVentaVehiculos.SaveChanges();
                return "El Cliente ha sido actualizado exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Cliente SearchClient(string documento)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.Clientes.FirstOrDefault(x => x.documento == documento);
        }

        public string DeleteClient()
        {
            try
            {
                //We use Search method that we created to allow us searching for the user id we want to delete
                Cliente _obj = SearchClient(obj.documento);

                if (_obj.documento != null)
                {
                    dbVentaVehiculos.Clientes.Remove(_obj);
                    dbVentaVehiculos.SaveChanges();
                    return "El Cliente " + obj.nombre + " con documento " + obj.documento + " ha sido eliminado exitosamente";
                }
                else
                {
                    return "El Cliente que intenta eliminar no existe";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Method to search for a user
        public string AuthClient(Cliente newclient)
        {
            try
            {
                SearchClient(obj.documento);
                if (newclient.documento.Equals(obj.documento))
                {
                    return "El cliente con el documento " + obj.documento + " ya existe";
                }
                else
                {
                    return AddClient();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}