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
    [RoutePrefix("api/TipoServicios")]
    public class TipoServiciosController : ApiController
    {
        [HttpGet]
        [Route("TipoServicioCombo")]
        public IQueryable TipoServicioCombo()
        {
            clsTipoServicio tipoServicio = new clsTipoServicio();
            return tipoServicio.TipoServicioCombo();
        }
    }
}