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
    [RoutePrefix("api/Vendedores")]
    public class VendedoresController : ApiController
    {
        [HttpPost]
        [Route("InsertarVendedor")]
        public string InsertarVendedor([FromBody] Vendedor Vendedor)
        {
            clsVendedor _vendedor = new clsVendedor();
            _vendedor.vendedor = Vendedor;

            return _vendedor.InsertarVendedor();
        }

        [HttpPut]
        [Route("ActualizarVendedor")]
        public string ActualizarVendedor([FromBody] Vendedor Vendedor)
        {
            clsVendedor _vendedor = new clsVendedor();
            _vendedor.vendedor = Vendedor;

            return _vendedor.ActualizarVendedor();

        }

        [HttpDelete]
        [Route("EliminarVendedor")]
        public string EliminarVendedor([FromBody] Vendedor Vendedor)
        {
            clsVendedor _vendedor = new clsVendedor();
            _vendedor.vendedor = Vendedor;

            return _vendedor.EliminarVendedor();
        }

        [HttpGet]
        [Route("VendedorxDocumento")]
        public Vendedor VendedorxDocumento(string Documento)
        {
            clsVendedor _vendedor = new clsVendedor();
            return _vendedor.BuscarVendedor(Documento);
        }

        [HttpGet]
        [Route("LlenarTablaVendedor")]
        public IQueryable LlenarTablaVendedor()
        {

            clsVendedor vendedor = new clsVendedor();
            return vendedor.LlenarTablaVendedor();
        }
    }
}