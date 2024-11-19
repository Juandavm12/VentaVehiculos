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
    [RoutePrefix("api/Reservas")]
    public class ReservasController : ApiController
    {
        [HttpPost]
        [Route("InsertarReserva")]
        public string InsertarReserva([FromBody] Reserva Reserva)
        {
            clsReserva _reserva = new clsReserva();
            _reserva.reserva = Reserva;

            return _reserva.InsertarReserva();
        }

        [HttpPut]
        [Route("ActualizarReserva")]
        public string ActualizarReserva([FromBody] Reserva Reserva)
        {
            clsReserva _reserva = new clsReserva();
            _reserva.reserva = Reserva;

            return _reserva.ActualizarReserva();
        }

        [HttpDelete]
        [Route("EliminarReserva")]
        public string EliminarReserva([FromBody] Reserva Reserva)
        {
            clsReserva _reserva = new clsReserva();
            _reserva.reserva = Reserva;

            return _reserva.EliminarReserva();
        }

        [HttpGet]
        [Route("ReservaxCodigo")]
        public Reserva BuscarReserva(int Codigo)
        {
            clsReserva reserva = new clsReserva();
            return reserva.BuscarReserva(Codigo);
        }

        [HttpGet]
        [Route("LlenarTablaReserva")]
        public IQueryable LlenarTablaReserva()
        {
            clsReserva reserva = new clsReserva();
            return reserva.LlenarTablaReserva();
        }
    }
}