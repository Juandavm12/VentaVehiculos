jQuery(function () {
    $("#txtTotalCompra").val(0);
    $("#txtNumeroFactura").val(0);
    $("#txtFechaCompra").val(FechaHoy());
    ConsultarDatosUsuario();
    TipoVehiculoCombo();
    //LlenarTabla();
});
async function TipoVehiculoCombo() {
    await LlenarComboxServiciosAuth("http://localhost:44337/api/TipoVehiculos/TipoVehiculoCombo", "#cboTipoVehiculo");
    VehiculoxTipo($("#cboTipoVehiculo").val())
}
async function VehiculoxTipo(TipoVehiculo) {
    let CodTipoVehiculo = TipoVehiculo == 0 ? $("#cboTipoVehiculo").val() : CodTipoVehiculo;
    await LlenarComboVehiculoFacturaAuth("https://localhost:44337/api/Vehiculos/VehiculoxTipo?TipoProducto=" + CodTipoVehiculo, "#cboMarcaVehiculo", "cboPlacaVehiculo");
    /*CalcularSubtotal();*/
}
//function CalcularSubtotal() {
//    let DatosCombo = $("#cboProducto").val();
//    $("#txtCodigoProducto").val(DatosCombo.split('|')[0]);
//    let ValorUnitario = DatosCombo.split('|')[1];
//    $("#txtValorUnitario").val(ValorUnitario);
//    $("#txtValorUnitarioTexto").val(FormatoMiles(ValorUnitario));
//    let Cantidad = $("#txtCantidad").val();
//    if (Cantidad <= 0) {
//        $("#txtCantidad").val(1);
//        Cantidad = 1;
//    }
//    $("#txtSubtotal").val(FormatoMiles(Cantidad * ValorUnitario));
//}
async function ConsultarDatosUsuario() {
    let Usuario = getCookie("Usuario");
    const DatosEmpleado = await SearchServiceAuth("https://localhost:44337/api/Empleados/EmpleadoxUsuario?Usuario=" + Usuario);
    $("#txtIdEmpleado").val(DatosEmpleado[0].IdEmpleado);
    $("#IdTitulo").html("FACTURA DE COMPRA - EMPLEADO: " + DatosEmpleado[0].Empleado + " - CARGO: " + DatosEmpleado[0].Cargo + " - USUARIO: " + Usuario);
}

async function ClientexTipo() {
    let Documento = $("#txtDocumento").val();
    URL = "https://localhost:44337/api/Clientes/ClientexTipo?Documento=" + Documento;

    const cliente = await SearchServiceAuth(URL);

    if (cliente != null && cliente.length > 0) {
        $("#txtNombreCliente").val(cliente[0].Cliente);
        $("#txtDescuento").val(cliente[0].Descuento);
        $("#txtIdCliente").val(cliente[0].Id);
        $("#dvMensaje").html("");
    }
    else {
        $("#txtNombre").val("");
        $("#txtCargo").val("");
        $("#dvMensaje").html("No se encontro el Cliente, por favor valide la informacion");
    }
}