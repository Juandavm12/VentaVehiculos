using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsReserva
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla usuario
        public Reserva reserva { get; set; }

        public string InsertarReserva()
        {
            try
            {
                dbVentaVehiculos.Reservas.Add(reserva);
                dbVentaVehiculos.SaveChanges();
                return "Se ha registrado una reserva el dia " + reserva.Fecha;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarReserva()
        {
            try
            {
                Reserva _reserva = BuscarReserva(reserva.Codigo);

                if (_reserva == null)
                {
                    return "La reserva que intenta actualizar no existe";
                }
                else
                {
                    dbVentaVehiculos.Reservas.AddOrUpdate(reserva);
                    dbVentaVehiculos.SaveChanges();
                    return "La Reserva " + reserva.Codigo + " ha sido actualizada exitosamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Reserva BuscarReserva(int codigo)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.Reservas.FirstOrDefault(x => x.Codigo == codigo);
        }

        public string EliminarReserva()
        {
            try
            {
                Reserva _reserva = BuscarReserva(reserva.Codigo);

                if (_reserva == null)
                {
                    return "La Reserva que intenta eliminar no existe";
                }
                else
                {        
                    dbVentaVehiculos.Reservas.Remove(_reserva);
                    dbVentaVehiculos.SaveChanges();
                    return "La Reserva " + reserva.Codigo + " ha sido eliminada exitosamente";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}