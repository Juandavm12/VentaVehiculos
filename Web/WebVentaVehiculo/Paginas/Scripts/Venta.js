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
    let URL = "https://localhost:44337/api/Ventas/" + Function;
    ExecuteCommandService(Method, URL, venta);
}

async function BuscarVenta() {
    let Codigo = $("#txtCodigo").val();
    URL = "https://localhost:44337/api/Ventas/VentaxCodigo?Codigo=" + Codigo;

    //invoco el servicio generico 
    const Venta = await SearchService(URL);

    if (Venta != null) {

        $("#txtCodigo").val(Venta.Codigo);
        $("#txtDocCliente").val(Venta.DocCliente);
        $("#txtDocAdmin").val(Venta.DocAdmin);
        $("#txtFecha").val(Venta.Fecha.split('T')[0]);
    }
    else {

        $("#dvMensaje").html("No se encontro la venta");
    }
}