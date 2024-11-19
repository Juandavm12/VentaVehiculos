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
    [RoutePrefix("api/Citas")]
    public class CitasTallerController : ApiController
    {
        [HttpPost]
        [Route("InsertarCita")]
        public string InsertarCita([FromBody] CitaTaller CitaTaller)
        {
            clsCitaTaller _cita = new clsCitaTaller();
            _cita.cita = CitaTaller;

            return _cita.InsertarCita();
        }

        [HttpPut]
        [Route("ActualizarCita")]
        public string ActualizarCita([FromBody] CitaTaller CitaTaller)
        {
            clsCitaTaller _cita = new clsCitaTaller();
            _cita.cita = CitaTaller;

            return _cita.ActualizarCita();
        }

        [HttpDelete]
        [Route("EliminarCita")]
        public string EliminarCita([FromBody] CitaTaller CitaTaller)
        {
            clsCitaTaller _cita = new clsCitaTaller();
            _cita.cita = CitaTaller;

            return _cita.EliminarCita();
        }

        [HttpGet]
        [Route("CitaxCodigo")]
        public CitaTaller BuscarCita(int Codigo)
        {
            clsCitaTaller cita = new clsCitaTaller();
            return cita.BuscarCita(Codigo);
        }

        [HttpGet]
        [Route("LlenarTablaCita")]
        public IQueryable LlenarTablaCita()
        {
            clsCitaTaller cita = new clsCitaTaller();
            return cita.LlenarTablaCita();
        }
    }
}