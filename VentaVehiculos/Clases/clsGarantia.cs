using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsGarantia
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla Reserva
        public Garantia garantia { get; set; }

        //Objeto de la tabla Factura
        public Factura factura { get; set; }

        public string InsertarGarantia()
        {
            try
            {
                Garantia _garantia = BuscarGarantia(garantia.Codigo);

                if (_garantia == null)
                {
                    dbVentaVehiculos.Garantias.Add(garantia);
                    dbVentaVehiculos.SaveChanges();
                    return "La Garantia con el codigo " + garantia.Codigo + " ha sido creada exitosamente para la factura " + factura.Numero;
                }
                else
                {
                    return "La Garantia con el codigo " + garantia.Codigo + " ya esta creada";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string ActualizarGarantia()
        {
            try
            {
                Garantia _garantia = BuscarGarantia(garantia.Codigo);

                if (_garantia == null)
                {
                    return "La garantia que intenta actualizar no existe";
                }
                else
                {
                    dbVentaVehiculos.Garantias.AddOrUpdate(garantia);
                    dbVentaVehiculos.SaveChanges();
                    return "La Garantia " + garantia.Codigo + " ha sido actualizada exitosamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Garantia BuscarGarantia(int codigo)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.Garantias.FirstOrDefault(x => x.Codigo == codigo);
        }

        public string EliminarGarantia()
        {
            try
            {
                Garantia _garantia = BuscarGarantia(garantia.Codigo);

                if (_garantia == null)
                {
                    return "La Garantia que intenta eliminar no existe";
                }
                else
                {
                    dbVentaVehiculos.Garantias.Remove(_garantia);
                    dbVentaVehiculos.SaveChanges();
                    return "La Garantia " + garantia.Codigo + " ha sido eliminada exitosamente";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarTablaGarantia()
        {
            return from G in dbVentaVehiculos.Set<Garantia>()
                   join TG in dbVentaVehiculos.Set<TipoGarantia>() on G.CodTipoGarantia equals TG.Codigo
                   orderby G.FechaFinal, TG.Nombre
                   select new
                   {
                       Codigo = G.Codigo,
                       Nombre = TG.Nombre,
                       Factura = G.NumFactura,
                       Inicio = G.FechaInicio,
                       Finaliza = G.FechaFinal,
                       Descripcion = TG.Descripcion
                   };
        }
    }
}