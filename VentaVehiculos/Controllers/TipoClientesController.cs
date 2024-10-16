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
    [RoutePrefix("api/TipoClientes")]
    public class TipoClientesController : ApiController
    {
        [HttpGet]
        [Route("TipoClienteCombo")]
        public List<TipoCliente> TipoClienteCombo()
        {
            clsTipoCliente tipoCliente = new clsTipoCliente();
            return tipoCliente.TipoClienteCombo();
        }
    }
}
