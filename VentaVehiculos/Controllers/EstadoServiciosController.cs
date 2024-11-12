using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VentaVehiculos.Clases;

namespace VentaVehiculos.Controllers
{
    [EnableCors(origins: "https://localhost:44330", headers: "*", methods: "*")]
    [RoutePrefix("api/EstadoServicios")]
    public class EstadoServiciosController : ApiController
    {
        [HttpGet]
        [Route("EstadoServicioCombo")]
        public IQueryable EstadoServicioCombo()
        {
            clsEstadoServicio estadoServicio = new clsEstadoServicio();
            return estadoServicio.EstadoServicioCombo();
        }
    }
}