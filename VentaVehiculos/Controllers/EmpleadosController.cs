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
    [RoutePrefix("api/Empleados")]
    [Authorize]
    public class EmpleadosController : ApiController
    {
        [HttpPost]
        [Route("InsertarEmpleado")]
        public string InsertarEmpleado([FromBody] Empleado Empleado)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = Empleado;

            return _empleado.InsertarEmpleado();
        }

        [HttpPut]
        [Route("ActualizarEmpleado")]
        public string ActualizarEmpleado([FromBody] Empleado Empleado)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = Empleado;

            return _empleado.ActualizarEmpleado();

        }

        [HttpDelete]
        [Route("EliminarEmpleado")]
        public string EliminarEmpleado([FromBody] Empleado Empleado)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = Empleado;

            return _empleado.EliminarEmpleado();
        }

        [HttpGet]
        [Route("EmpleadoxDocumento")]
        public Empleado EmpleadoxDocumento(string Documento)
        {
            clsEmpleado _empleado = new clsEmpleado();
            return _empleado.BuscarEmpleado(Documento);
        }

        [HttpGet]
        [Route("LlenarTablaEmpleado")]
        public IQueryable LlenarTablaEmpleado()
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.LlenarTablaEmpleado();
        }

        [HttpGet]
        [Route("EmpleadoCombo")]
        public IQueryable EmpleadoCombo()
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.EmpleadoCombo();
        }

        [HttpGet]
        [Route("EmpleadoxCargo")]
        public IQueryable EmpleadoxCargo(string Documento)
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.EmpleadoxCargo(Documento);
        }

        [HttpGet]
        [Route("EmpleadoxUsuario")]
        public IQueryable EmpleadoxUsuario(string Usuario)
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.EmpleadoxUsuario(Usuario);
        }
    }
}