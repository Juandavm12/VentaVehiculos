using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsVendedor 
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla usuario
        public Vendedor vendedor { get; set; }

        public string InsertarVendedor()
        {
            try
            {
                Vendedor _admin = BuscarVendedor(vendedor.Documento);

                if (_admin == null)
                {
                    dbVentaVehiculos.Vendedors.Add(vendedor);
                    dbVentaVehiculos.SaveChanges();
                    return "El Vendedor " + vendedor.Nombre + " ha sido creado exitosamente";
                }
                else
                {
                    return "El documento " + vendedor.Documento + " ya esta asociado a un vendedor";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string ActualizarVendedor()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                Vendedor _admin = BuscarVendedor(vendedor.Documento);

                if (_admin != null)
                {
                    dbVentaVehiculos.Vendedors.AddOrUpdate(vendedor);
                    dbVentaVehiculos.SaveChanges();
                    return "El Vendedor " + vendedor.Nombre + " se ha actualizado exitosamente";
                }
                else
                {
                    return "El Vendedor que intenta actualizar no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Vendedor BuscarVendedor(string documento)
        {
            return dbVentaVehiculos.Vendedors.FirstOrDefault(x => x.Documento == documento);
        }

        public string EliminarVendedor()
        {
            try
            {
                //We use Search method that we created to allow us searching for the user id we want to delete
                Vendedor _admin = BuscarVendedor(vendedor.Documento);

                if (_admin != null)
                {
                    dbVentaVehiculos.Vendedors.Remove(vendedor);
                    dbVentaVehiculos.SaveChanges();
                    return "El Vendedor " + vendedor.Nombre + " se ha eliminado exitosamente";
                }
                else
                {
                    return "El Vendedor que intenta eliminar no existe";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarTablaVendedor()
        {
            return from A in dbVentaVehiculos.Set<Vendedor>()
                   //join  in dbVentaVehiculos.Set<>()
                   //on A.Cargo equals 
                   //orderby 
                   select new
                   {
                       Documento = A.Documento,
                       Nombre = A.Nombre,
                       Apellido = A.Apellido,
                       Direccion = A.Direccion,
                       Email = A.Correo,
                       Telefono = A.Telefono,
                       Cargo = A.Cargo,
                   };
        }
    }
}
