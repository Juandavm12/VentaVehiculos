using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsFactura
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla Reserva
        public Factura factura { get; set; }

        //Objeto de la tabla Cliente 
        public Cliente cliente { get; set; }

        public Factura BuscarFactura(int numero)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.Facturas.FirstOrDefault(x => x.Numero == numero);
        }

        public Factura DescuentoTipoCliente(int id)
        {
            factura = new Factura();
            cliente.IdTipoCliente = id;
            CalculoFactura();
            return factura;
        }

        public void CalculoFactura()
        {
            switch (cliente.IdTipoCliente)
            {
                case 1:
                    factura.Subtotal = factura.Cantidad + factura.VUnidad;
                    factura.Descuento = Convert.ToInt32(factura.Subtotal * 0.05);
                    factura.VTotal = factura.Subtotal - factura.Descuento;
                    break;

                case 2:
                    factura.Subtotal = factura.Cantidad + factura.VUnidad;
                    factura.Descuento = Convert.ToInt32(factura.Subtotal * 0.1);
                    factura.VTotal = factura.Subtotal - factura.Descuento;
                    break;

                case 3:
                    factura.Subtotal = factura.Cantidad + factura.VUnidad;
                    factura.Descuento = Convert.ToInt32(factura.Subtotal * 0.15);
                    factura.VTotal = factura.Subtotal - factura.Descuento;
                    break;
            }
        }

        public string InsertarFactura()
        {
            try
            {
                Factura _factura = BuscarFactura(factura.Numero);

                if (_factura == null)
                {
                    dbVentaVehiculos.Facturas.Add(factura);
                    dbVentaVehiculos.SaveChanges();
                    return "La Factura numero " + factura.Numero + " ha sido creadoa exitosamente a nombre de " + cliente.Nombre;
                }
                else
                {
                    return "La Factura numero " + factura.Numero + " ya esta creada";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string ActualizarFactura()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                Factura _factura = BuscarFactura(factura.Numero);

                if (_factura != null)
                {
                    dbVentaVehiculos.Facturas.AddOrUpdate(factura);
                    dbVentaVehiculos.SaveChanges();
                    return "La Factura numero " + factura.Numero + " se ha actualizado exitosamente";
                }
                else
                {
                    return "La Factura que intenta actualizar no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarFactura()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                Factura _factura = BuscarFactura(factura.Numero);

                if (_factura == null)
                {
                    return "La Factura que intenta eliminar no existe";
                }
                else
                {
                    dbVentaVehiculos.Facturas.Remove(factura);
                    dbVentaVehiculos.SaveChanges();
                    return "La Factura numero " + factura.Numero + " ha sido eliminada exitosamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Method IQuearyable
        public IQueryable LlenarTablaFactura()
        {
            return from F in dbVentaVehiculos.Set<Factura>()
                   join C in dbVentaVehiculos.Set<Cliente>() on F.IdCliente equals C.Id
                   join V in dbVentaVehiculos.Set<Vehiculo>() on F.IdVeh equals V.Id
                   join Ven in dbVentaVehiculos.Set<Vendedor>() on F.IdVendedor equals Ven.Id
                   orderby F.Numero ascending
                   select new
                   {
                       Numero = F.Numero,
                       Cliente = C.Nombre,
                       Placas = V.Placa,
                       Vehiculo = V.Marca,
                       Vendedor = Ven.Nombre,
                       Cantidad = F.Cantidad,
                       ValorUnidad = F.VUnidad,
                       Subtotal = F.Subtotal,
                       Descuento = F.Descuento,
                       Total = F.VTotal
                   };
        }
    }
}