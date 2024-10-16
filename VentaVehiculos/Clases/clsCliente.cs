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
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla usuario
        public Cliente cliente { get; set; }

        public string InsertarCliente()
        {
            try
            {
                Cliente _cliente = BuscarCliente(cliente.Documento);

                if (_cliente == null)
                {
                    dbVentaVehiculos.Clientes.Add(cliente);
                    dbVentaVehiculos.SaveChanges();
                    return "El Cliente " + cliente.Nombre + " ha sido creado exitosamente";
                     
                }
                else
                {
                    return "El documento " + cliente.Documento + " ya esta asociado a un cliente";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string ActualizarCliente()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                Cliente _cliente = BuscarCliente(cliente.Documento);

                if (_cliente != null)
                {
                    dbVentaVehiculos.Clientes.AddOrUpdate(cliente);
                    dbVentaVehiculos.SaveChanges();
                    return "El Cliente " + cliente.Nombre + " se ha actualizado exitosamente";
                }
                else
                {
                    return "El Cliente que intenta actualizar no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Cliente BuscarCliente(string documento)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.Clientes.FirstOrDefault(x => x.Documento == documento);
        }

        public string EliminarCliente()
        {
            try
            {
                //We use Search method that we created to allow us searching for the user id we want to delete
                Cliente _cliente = BuscarCliente(cliente.Documento);

                if (_cliente != null)
                {
                    dbVentaVehiculos.Clientes.Remove(_cliente);
                    dbVentaVehiculos.SaveChanges();
                    return "El Cliente " + cliente.Nombre + " con documento " + cliente.Documento + " ha sido eliminado exitosamente";
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

        //Method IQuearyable
        public IQueryable LlenarTablaCliente()
        {
            return from C in dbVentaVehiculos.Set<Cliente>()
                   join TC in dbVentaVehiculos.Set<TipoCliente>()
                   on C.IdTipoCliente equals TC.Id
                   orderby TC.Membresia, C.Nombre
                   select new
                   {
                       Documento = C.Documento,
                       Nombre = C.Nombre,
                       Apellido = C.Apellido,
                       Direccion = C.Direccion,
                       Email = C.Correo,
                       Telefono = C.Telefono,
                       Membresia = TC.Membresia,
                       Descuento = TC.Descuento,
                   };
        }
    }
}