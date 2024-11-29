using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VentaVehiculos.Clases;
using VentaVehiculos.Models;

namespace VentaVehiculos.Controllers
{
    [EnableCors(origins: "https://localhost:44330", headers: "*", methods: "*")]
    [RoutePrefix("api/Facturas")]
    public class FacturasController : ApiController
    {
        [HttpGet]
        [Route("DescuentoTipoCliente")]
        public Factura DescuentoTipoCliente(int id)
        {
            clsFactura _factura = new clsFactura();
            return _factura.DescuentoTipoCliente(id);
        }

        [HttpGet]
        [Route("LlenarTablaFactura")]
        public IQueryable LlenarTablaFactura()
        {
            clsFactura factura = new clsFactura();
            return factura.LlenarTablaFactura();
        }
    }
}