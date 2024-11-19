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

        //Objeto de la tabla Reserva
        public Reserva reserva { get; set; }

        //Objeto de la tabla Cliente 
        public Cliente cliente { get; set; }

        public string InsertarReserva()
        {
            try
            {
                Reserva _reserva = BuscarReserva(reserva.Codigo);

                if (_reserva == null)
                {
                    dbVentaVehiculos.Reservas.Add(reserva);
                    dbVentaVehiculos.SaveChanges();
                    return "La Reserva con codigo " + reserva.Codigo + " ha sido creada exitosamente a nombre de " + cliente.Nombre;
                }
                else
                {
                    return "La Reserva con codigo " + reserva.Codigo + " ya esta creada";
                }
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
                    return "La Reserva que intenta actualizar no existe";
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

        public IQueryable LlenarTablaReserva()
        {
            return from R in dbVentaVehiculos.Set<Reserva>()
                   join C in dbVentaVehiculos.Set<Cliente>() on R.IdCliente equals C.Id
                   join V in dbVentaVehiculos.Set<Vehiculo>() on R.IdVeh equals V.Id
                   join E in dbVentaVehiculos.Set<Empleado>() on R.IdEmpleado equals E.Id
                   orderby R.Fecha, C.Nombre
                   select new
                   {
                       Codigo = R.Codigo,
                       Cliente = C.Nombre,
                       Vendedor = E.Nombre,
                       PlacaVehiculo = V.Placa,
                       MarcaVehiculo = V.Marca,
                       FechaReserva = R.Fecha,
                       FechaVencimiento = R.FechaVen
                   };
        }
    }
}