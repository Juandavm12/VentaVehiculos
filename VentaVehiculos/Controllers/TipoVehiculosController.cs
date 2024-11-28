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
    [RoutePrefix("api/TipoVehiculos")]
    [Authorize]
    public class TipoVehiculosController : ApiController
    {
        [HttpGet]
        [Route("TipoVehiculoCombo")]
        public IQueryable TipoVehiculoCombo()
        {
            clsTipoVehiculo tipoVehiculo = new clsTipoVehiculo();
            return tipoVehiculo.TipoVehiculoCombo();
        }
    }
}