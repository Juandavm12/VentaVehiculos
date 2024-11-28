jQuery(function () {
    $("#txtTotalCompra").val(0);
    $("#txtNumeroFactura").val(0);
    $("#txtFechaCompra").val(FechaHoy());
    ConsultarDatosUsuario();
    ListarTipoProductos();
    //LlenarTabla();
});
async function TipoVehiculoCombo() {
    await LlenarComboxServiciosAuth("http://localhost:44330/api/TipoVehiculos/TipoVehiculoCombo", "#cboTipoProducto");
    ListarProductos($("#cboTipoVehiculo").val())
}
async function ListarProductos(TipoProducto) {
    let idTipoProducto = TipoProducto == 0 ? $("#cboTipoProducto").val() : TipoProducto;
    await LlenarComboXServiciosAuth("http://localhost:54671/api/Productos/ListarProductosXTipo?TipoProducto=" + idTipoProducto, "#cboProducto");
    CalcularSubtotal();
}
function CalcularSubtotal() {
    let DatosCombo = $("#cboProducto").val();
    $("#txtCodigoProducto").val(DatosCombo.split('|')[0]);
    let ValorUnitario = DatosCombo.split('|')[1];
    $("#txtValorUnitario").val(ValorUnitario);
    $("#txtValorUnitarioTexto").val(FormatoMiles(ValorUnitario));
    let Cantidad = $("#txtCantidad").val();
    if (Cantidad <= 0) {
        $("#txtCantidad").val(1);
        Cantidad = 1;
    }
    $("#txtSubtotal").val(FormatoMiles(Cantidad * ValorUnitario));
}
async function ConsultarDatosUsuario() {
    let Usuario = getCookie("Usuario");
    const DatosEmpleado = await ConsultarServicioAuth("http://localhost:54671/api/Empleados/ConsultarXUsuario?Usuario=" + Usuario);
    $("#txtidEmpleado").val(DatosEmpleado[0].idEmpleado);
    $("#idTitulo").html("FACTURA DE COMPRA - EMPLEADO: " + DatosEmpleado[0].Empleado + " - CARGO: " + DatosEmpleado[0].Cargo + " - USUARIO: " + Usuario);
}
async function Consultar() {
    let Documento = $("#txtDocumento").val();
    const Cliente = await ConsultarServicioAuth("http://localhost:54671/api/Clientes/ConsultarXDocumento?Documento=" + Documento);
    $("#txtNombreCliente").val(Cliente.Nombre + " " + Cliente.PrimerApellido + " " + Cliente.SegundoApellido);
}