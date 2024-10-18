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
    [RoutePrefix("api/Admins")]
    public class AdminsController : ApiController
    {
        [HttpPost]
        [Route("InsertarAdmin")]
        public string InsertarAdmin([FromBody] Administrador Admin)
        {
            clsAdministrador _admin = new clsAdministrador();
            _admin.admin = Admin;

            return _admin.InsertarAdmin();
        }

        [HttpPut]
        [Route("ActualizarAdmin")]
        public string ActualizarAdmin([FromBody] Administrador Admin)
        {
            clsAdministrador _admin = new clsAdministrador();
            _admin.admin = Admin;

            return _admin.ActualizarAdmin();

        }

        [HttpDelete]
        [Route("EliminarAdmin")]
        public string EliminarAdmin([FromBody] Administrador Admin)
        {
            clsAdministrador _admin = new clsAdministrador();
            _admin.admin = Admin;

            return _admin.EliminarAdmin();
        }

        [HttpGet]
        [Route("AdminxDocumento")]
        public Administrador AdminxDocumento(string Documento)
        {
            clsAdministrador _admin = new clsAdministrador();
            return _admin.BuscarAdmin(Documento);
        }

        [HttpGet]
        [Route("LlenarTablaAdmin")]
        public IQueryable LlenarTablaAdmin()
        {

            clsAdministrador _admin = new clsAdministrador();
            return _admin.LlenarTablaAdmin();
        }
    }
}