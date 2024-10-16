class Venta {
    constructor(Codigo, DocCliente, DocAdmin, Fecha) {
        this.Codigo = Codigo;
        this.DocCliente = DocCliente;
        this.DocAdmin = DocAdmin;
        this.Fecha = Fecha;
    }
}

async function Execute(Method, Function) {
    const venta = new Venta($("#txtCodigo").val(), $("#txtDocCliente").val(), $("#txtDocAdmin").val(), $("#txtFecha").val());
    let URl = "https://localhost:44337/api/Ventas/" + Function;
    ExecuteCommandService(Method, URL, venta);
}

async function BuscarVenta() {
    let Codigo = $("#txtCodigo").val();
    URl = "https://localhost:44337/api/Ventas/VentaxCodigo?Codigo=" + Codigo;

    //invoco el servicio generico 
    const Codigo = await SearchService(URL);

    if (venta != null) {

        $("#txtCodigo").val(Venta.Codigo);
        $("#txtDocCliente").val(Venta.DocCliente);
        $("#txtDocAdmin").val(Venta.DocAdmin);
        $("#txtFecha").val(Venta.Fecha);
    }
    else {

        $("#dvMensaje").html("No se encontro la venta");
    }
}