using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsServicioTaller
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla ServicioTaller
        public ServicioTaller servicioTaller { get; set; }

        public string InsertarServicio()
        {
            try
            {
                ServicioTaller _servicio = BuscarServicio(servicioTaller.Id);

                if (_servicio == null)
                {
                    dbVentaVehiculos.ServicioTallers.Add(servicioTaller);
                    dbVentaVehiculos.SaveChanges();
                    return "El Servicio numero " + servicioTaller.Id + " ha sido creado exitosamente";

                }
                else
                {
                    return "El numero de servicio " + servicioTaller.Id + " ya esta asociado a un cliente";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string ActualizarServicio()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                ServicioTaller _servicio = BuscarServicio(servicioTaller.Id);

                if (_servicio != null)
                {
                    dbVentaVehiculos.ServicioTallers.AddOrUpdate(servicioTaller);
                    dbVentaVehiculos.SaveChanges();
                    return "El Servicio numero" + servicioTaller.Id + " se ha actualizado exitosamente";
                }
                else
                {
                    return "El Servicio que intenta actualizar no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ServicioTaller BuscarServicio(int id)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.ServicioTallers.FirstOrDefault(x => x.Id == id);
        }

        public string EliminarServicio()
        {
            try
            {
                //We use Search method that we created to allow us searching for the user id we want to delete
                ServicioTaller _servicio = BuscarServicio(servicioTaller.Id);

                if (_servicio != null)
                {
                    dbVentaVehiculos.ServicioTallers.Remove(_servicio);
                    dbVentaVehiculos.SaveChanges();
                    return "El Servicio numero " + servicioTaller.Id + " ha sido eliminado exitosamente";
                }
                else
                {
                    return "El Servicio que intenta eliminar no existe";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Method IQuearyable
        public IQueryable LlenarTablaServicio()
        {
            return from S in dbVentaVehiculos.Set<ServicioTaller>()
                   join TS in dbVentaVehiculos.Set<TipoServicio>()
                   on S.CodTipoServicio equals TS.Codigo
                   join ES in dbVentaVehiculos.Set<EstadoServicio>()
                   on S.CodEstadoServicio equals ES.Codigo
                   orderby TS.Tipo, S.IdCliente
                   select new
                   {
                       Cliente = S.IdCliente,
                       Vehiculo = S.IdVeh,
                       Estado = ES.Estado,
                       Tipo = TS.Tipo,
                       Fecha = S.Fecha,
                       Comentarios = S.Comentarios
                   };
        }

    }
}