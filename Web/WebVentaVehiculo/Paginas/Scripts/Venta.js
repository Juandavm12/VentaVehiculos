class Venta {
    constructor(DocCliente, DocAdmin, Fecha) {
        this.DocCliente = DocCliente;
        this.DocAdmin = DocAdmin;
        this.Fecha = Fecha;
    }
}

async function Execute(Method, Function) {
    const venta = new Venta($("#txtDocCliente").val(), $("#txtDocAdmin").val(), $("#txtFecha").val());
    let URl = "https://localhost:44337/api/Ventas/" + Function;
    ExecuteCommandService(Method, URL, venta);
}

async function Search() {
    let Codigo = $("#txtDocumento").val();
    URl = "https://localhost:44337/api/Ventas/VentaxCodigo?Codigo=" + Documento;

    //invoco el servicio generico 
    const cliente = await SearchService(URL);

    if (cliente != null) {

        $("#txtIdTipoCliente").val(Cliente.IdTipoCliente);
        $("#txtDocumento").val(Cliente.Documento);
        $("#txtNombre").val(Cliente.Nombre);
        $("#txtApellido").val(Cliente.Apellido);
        $("#txtFechaNacimiento").val(Cliente.FechaNacimiento);
        $("#txtDireccion").val(Cliente.Direccion);
        $("#txtTelefono").val(Cliente.Telefono);
        $("#txtCorreoElectronico").val(Cliente.CorreoElectronico);
    }
    else {
        $("#dvMensaje").html("No se encontro el cliente");
    }
}
