using System;
using System.Collections.Generic;
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

        public Cliente DescuentoTipoCliente(int id)
        {
            factura = new Factura();
            cliente = new Cliente();
            cliente.IdTipoCliente = id;
            CalculoFactura();
            return cliente;
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


    }
}