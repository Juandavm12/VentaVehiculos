using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsVenta
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla usuario
        public Venta venta { get; set; }

        public string InsertarVenta()
        {
            try
            {
                dbVentaVehiculos.Ventas.Add(venta);
                dbVentaVehiculos.SaveChanges();
                return "Se ha registrado una venta el dia " + venta.Fecha;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarVenta()
        {
            try
            {
                Venta _venta = BuscarVenta(venta.Codigo);

                if (_venta == null)
                {
                    return "La Venta que intenta actualizar no existe";
                }
                else
                {
                    dbVentaVehiculos.Ventas.AddOrUpdate(venta);
                    dbVentaVehiculos.SaveChanges();
                    return "La Venta " + venta.Codigo + " ha sido actualizada exitosamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Venta BuscarVenta(int codigo)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.Ventas.FirstOrDefault(x => x.Codigo == codigo);
        }

        public string EliminarVenta()
        {
            try
            {
                Venta _venta = BuscarVenta(venta.Codigo);

                if (_venta == null)
                {
                    return "La Venta que intenta eliminar no existe";
                }
                else
                {        
                    dbVentaVehiculos.Ventas.Remove(_venta);
                    dbVentaVehiculos.SaveChanges();
                    return "La Venta " + venta.Codigo + " ha sido eliminada exitosamente";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}