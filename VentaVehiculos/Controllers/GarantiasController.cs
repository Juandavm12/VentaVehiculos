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
    [RoutePrefix("api/Garantias")]
    [Authorize]
    public class GarantiasController : ApiController
    {
        [HttpPost]
        [Route("InsertarGarantia")]
        public string InsertarGarantia([FromBody] Garantia Garantia)
        {
            clsGarantia _garantia = new clsGarantia();
            _garantia.garantia = Garantia;

            return _garantia.InsertarGarantia();
        }

        [HttpPut]
        [Route("ActualizarGarantia")]
        public string ActualizarGarantia([FromBody] Garantia Garantia)
        {
            clsGarantia _garantia = new clsGarantia();
            _garantia.garantia = Garantia;

            return _garantia.ActualizarGarantia();

        }

        [HttpDelete]
        [Route("EliminarGarantia")]
        public string EliminarGarantia([FromBody] Garantia Garantia)
        {
            clsGarantia _garantia = new clsGarantia();
            _garantia.garantia = Garantia;

            return _garantia.EliminarGarantia();
        }

        [HttpGet]
        [Route("BuscarxCodigo")]
        public Garantia BuscarGarantia(int Codigo)
        {
            //To call Search from Cliente class, we create a type clsCliente object
            clsGarantia garantia = new clsGarantia();
            return garantia.BuscarGarantia(Codigo);
        }

        [HttpGet]
        [Route("LlenarTablaGarantia")]
        public IQueryable LlenarTablaGarantia()
        {
            clsGarantia garantia = new clsGarantia();
            return garantia.LlenarTablaGarantia();
        }
    }
}