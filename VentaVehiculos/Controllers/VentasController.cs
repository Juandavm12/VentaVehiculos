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
    [RoutePrefix("api/Ventas")]
    public class VentasController : ApiController
    {
        [HttpPost]
        [Route("InsertarVenta")]
        public string InsertarVenta([FromBody] Venta Venta)
        {
            clsVenta _venta = new clsVenta();
            _venta.venta = Venta;

            return _venta.InsertarVenta();
        }

        [HttpPut]
        [Route("ActualizarVenta")]
        public string ActualizarVenta([FromBody] Venta Venta)
        {
            clsVenta _venta = new clsVenta();
            _venta.venta = Venta;

            return _venta.ActualizarVenta();
        }

        [HttpDelete]
        [Route("EliminarVenta")]
        public string EliminarVenta([FromBody] Venta Venta)
        {
            clsVenta _venta = new clsVenta();
            _venta.venta = Venta;

            return _venta.EliminarVenta();
        }

        [HttpGet]
        [Route("VentaxCodigo")]
        public Venta BuscarVenta(int Codigo)
        {
            clsVenta _venta = new clsVenta();
            return _venta.BuscarVenta(Codigo);
        }
    }
}