using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsCitaTaller
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla CitaTaller
        public CitaTaller cita { get; set; }

        public string InsertarCita()
        {
            try
            {
                CitaTaller _cita = BuscarCita(cita.Codigo);

                if (_cita == null)
                {
                    dbVentaVehiculos.CitaTallers.Add(cita);
                    dbVentaVehiculos.SaveChanges();
                    return "La Cita numero " + cita.Codigo + " ha sido creada exitosamente";
                }
                else
                {
                    return "El numero " + cita.Codigo + " ya esta asociada a una cita";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string ActualizarCita()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                CitaTaller _cita = BuscarCita(cita.Codigo);

                if (_cita != null)
                {
                    dbVentaVehiculos.CitaTallers.AddOrUpdate(cita);
                    dbVentaVehiculos.SaveChanges();
                    return "La cita con numero " + cita.Codigo + " se ha actualizado exitosamente";
                }
                else
                {
                    return "La cita que intenta actualizar no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public CitaTaller BuscarCita(int codigo)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.CitaTallers.FirstOrDefault(x => x.Codigo == codigo);
        }

        public string EliminarCita()
        {
            try
            {
                CitaTaller _cita = BuscarCita(cita.Codigo);

                if (_cita == null)
                {
                    return "La Cita que intenta eliminar no existe";
                }
                else
                {
                    dbVentaVehiculos.CitaTallers.Remove(_cita);
                    dbVentaVehiculos.SaveChanges();
                    return "La Cita " + cita.Codigo + " ha sido eliminada exitosamente";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Method IQuearyable
        public IQueryable LlenarTablaCita()
        {
            return from C in dbVentaVehiculos.Set<CitaTaller>()
                   join TS in dbVentaVehiculos.Set<TipoServicio>()
                   on C.CodTipoServicio equals TS.Codigo
                   orderby TS.Tipo
                   select new
                   {
                       Tipo = TS.Tipo,
                       Cliente = C.IdCliente,
                       Vehiculo = C.IdVeh,
                       Fecha = C.FechaHora
                   };
        }
    }
}