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
                Cliente _obj = SearchClient(obj.documento);

                if (_obj.documento == null)
                {
                    dbVentaVehiculos.Clientes.Add(_obj);
                    dbVentaVehiculos.SaveChanges();
                    return "El Cliente " + obj.nombre + " ha sido creado exitosamente";
                }
                else
                {
                    return "El documento " + obj.documento + " ya esta asociado a un cliente";
                }
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
                Cliente _obj = SearchClient(obj.documento);

                if (_obj.documento != null)
                {
                    dbVentaVehiculos.Clientes.AddOrUpdate(_obj);
                    dbVentaVehiculos.SaveChanges();
                    return "El Cliente " + obj.nombre + " se ha actualizado exitosamente";
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

        //Method IQuearyable
        public IQueryable FillClientTable()
        {
            return from C in dbVentaVehiculos.Set<Cliente>()
                   join TC in dbVentaVehiculos.Set<Tipo_Cliente>()
                   on C.id_tipo_cliente equals TC.id_tipo_cliente
                   orderby TC.membresia, C.nombre
                   select new
                   {
                       Documento = C.documento,
                       Nombre = C.nombre,
                       Apellido = C.apellido,
                       Edad = C.edad,
                       Correo = C.correo_electronico,
                       Telefono = C.telefono,
                       Membresia = TC.membresia,
                   };
        }
    }
}