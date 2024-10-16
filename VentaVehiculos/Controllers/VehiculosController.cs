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
    [RoutePrefix("api/Vehiculos")]
    public class VehiculosController : ApiController
    {
        [HttpPost]
        [Route("InsertarVehiculo")]
        public string InsertarVehiculo([FromBody] Vehiculo Vehiculo)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = Vehiculo;

            return _vehiculo.InsertarVehiculo();
        }

        [HttpPut]
        [Route("ActualizarVehiculo")]
        public string ActualizarVehiculo([FromBody] Vehiculo Vehiculo)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = Vehiculo;

            return _vehiculo.ActualizarVehiculo();

        }

        [HttpDelete]
        [Route("EliminarVehiculo")]
        public string EliminarVehiculo([FromBody] Vehiculo Vehiculo)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = Vehiculo;

            return _vehiculo.EliminarVehiculo();
        }

        [HttpGet]
        [Route("BuscarxPlaca")]
        public Vehiculo BuscarVehiculo(string Placa)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            return _vehiculo.BuscarVehiculo(Placa);
        }
    }
}