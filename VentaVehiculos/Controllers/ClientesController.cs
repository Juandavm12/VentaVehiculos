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
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        [HttpPost]
        [Route("AddClient")]
        public string AddClient([FromBody] Cliente Obj)
        {
            //To call AuthClient from Cliente class, we create a type clsCliente object
            clsCliente _obj = new clsCliente();
            _obj.obj = Obj;

            return _obj.AddClient();
        }

        [HttpPut]
        [Route("UpdateClient")]
        public string UpdateClient([FromBody] Cliente Obj)
        {
            //To call UpdateClient from CLiente class, we create a type clsCliente object
            clsCliente _obj = new clsCliente();
            _obj.obj = Obj;

            return _obj.UpdateClient();

        }

        [HttpDelete]
        [Route("DeleteClient")]
        public string DeleteClient([FromBody] Cliente Obj)
        {
            //To call DeleteClient from Cliente class, we create a type clsCliente object
            clsCliente _obj = new clsCliente();
            _obj.obj = Obj;

            return _obj.DeleteClient();
        }

        [HttpGet]
        [Route("SearchxDocument")]
        public Cliente SearchClientDocument(string Cliente)
        {
            //To call Search from Cliente class, we create a type clsCliente object
            clsCliente _obj = new clsCliente();
            return _obj.SearchClient(Cliente);
        }

        [HttpGet]
        [Route("FillClientTable")]
        public IQueryable FillClientTable()
        {
            clsCliente client = new clsCliente();
            return client.FillClientTable();
        }
    }
}