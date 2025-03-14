﻿using System;
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
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        [HttpPost]
        [Route("InsertarCliente")]
        public string InsertarCliente([FromBody] Cliente Cliente)
        {
            //To call AuthClient from Cliente class, we create a type clsCliente object
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = Cliente;

            return _cliente.InsertarCliente();
        }

        [HttpPut]
        [Route("ActualizarCliente")]
        public string ActualizarCliente([FromBody] Cliente Cliente)
        {
            //To call UpdateClient from CLiente class, we create a type clsCliente object
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = Cliente;

            return _cliente.ActualizarCliente();

        }

        [HttpDelete]
        [Route("EliminarCliente")]
        public string EliminarCliente([FromBody] Cliente Cliente)
        {
            //To call DeleteClient from Cliente class, we create a type clsCliente object
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = Cliente;

            return _cliente.EliminarCliente();
        }

        [HttpGet]
        [Route("BuscarxDocumento")]
        public Cliente BuscarCliente(string Documento)
        {
            //To call Search from Cliente class, we create a type clsCliente object
            clsCliente cliente = new clsCliente();
            return cliente.BuscarCliente(Documento);
        }

        [HttpGet]
        [Route("LlenarTablaCliente")]
        public IQueryable LlenarTablaCliente()
        {
            clsCliente cliente = new clsCliente();
            return cliente.LlenarTablaCliente();
        }

        [HttpGet]
        [Route("ClienteCombo")]
        public IQueryable ClienteCombo()
        {
            clsCliente cliente = new clsCliente();
            return cliente.ClienteCombo();
        }

        [HttpGet]
        [Route("ClientexTipo")]
        public IQueryable ClientexTipo(string Documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.ClientexTipo(Documento);
        }
    }
}