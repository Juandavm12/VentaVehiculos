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
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("InsertarUsuario")]
        public string InsertarUsuario([FromBody] Usuario usuario, int Perfil)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;

            return _usuario.InsertarUsuario(Perfil);
        }

        [HttpGet]
        [Route("LlenarTablaUsuario")]
        public IQueryable LlenarTablaUsuario()
        {
            clsUsuario usuario = new clsUsuario();
            return usuario.LlenarTablaUsuario();
        }
    }
}