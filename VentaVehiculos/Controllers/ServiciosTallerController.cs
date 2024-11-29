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
    [RoutePrefix("api/Servicios")]
    public class ServiciosTallerController : ApiController
    {
        [HttpPost]
        [Route("InsertarServicio")]
        public string InsertarServicio([FromBody] ServicioTaller servicioTaller)
        {
            clsServicioTaller _servicio = new clsServicioTaller();
            _servicio.servicioTaller = servicioTaller;

            return _servicio.InsertarServicio();
        }

        [HttpPut]
        [Route("ActualizarServicio")]
        public string ActualizarServicio([FromBody] ServicioTaller servicioTaller)
        {
            clsServicioTaller _servicio = new clsServicioTaller();
            _servicio.servicioTaller = servicioTaller;

            return _servicio.ActualizarServicio();

        }

        [HttpDelete]
        [Route("EliminarServicio")]
        public string EliminarServicio([FromBody] ServicioTaller servicioTaller)
        {
            clsServicioTaller _servicio = new clsServicioTaller();
            _servicio.servicioTaller = servicioTaller;

            return _servicio.EliminarServicio();
        }

        [HttpGet]
        [Route("BuscarServicioxId")]
        public ServicioTaller BuscarServicio(int Id)
        {
            clsServicioTaller servicio = new clsServicioTaller();
            return servicio.BuscarServicio(Id);
        }

        [HttpGet]
        [Route("LlenarTablaServicio")]
        public IQueryable LlenarTablaServicio()
        {
            clsServicioTaller servicio = new clsServicioTaller();
            return servicio.LlenarTablaServicio();
        }
    }
}