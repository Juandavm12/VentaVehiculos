jQuery(function () {

    LlenarTablaVendedor();

});

function LimpiarVendedor() {
    LimpiarFormularios('frmVendedor');
}

function LlenarTablaVendedor() {
    LlenarTablaxServicios("https://localhost:44337/api/Vendedores/LlenarTablaVendedor", "#tblVendedor");
}
class Vendedor {
    constructor(Documento, Nombre, Apellido, Direccion, Correo, Telefono, FechaNacimiento, Cargo) {

        this.Documento = Documento;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Direccion = Direccion;
        this.Correo = Correo;
        this.Telefono = Telefono;
        this.FechaNacimiento = FechaNacimiento;
        this.Cargo = Cargo;
    }
}

async function Execute(Method, Function) {
    const vendedor = new Vendedor($("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtDireccion").val(),
        $("#txtCorreo").val(), $("#txtTelefono").val(), $("#txtFechaNacimiento").val(), $("#txtCargo").val());
    let URL = "https://localhost:44337/api/Vendedores/" + Function;
    ExecuteCommandService(Method, URL, vendedor);
    LlenarTablaVendedor();
}

async function BuscarVendedor() {
    let Documento = $("#txtDocumento").val();
    URL = "https://localhost:44337/api/Vendedores/VendedorxDocumento?Documento=" + Documento;

    //invoco el servicio generico 
    const Vendedor = await SearchService(URL);

    if (Vendedor != null) {

        $("#txtNombre").val(Vendedor.Nombre);
        $("#txtApellido").val(Vendedor.Apellido);
        $("#txtDireccion").val(Vendedor.Direccion);
        $("#txtCorreo").val(Vendedor.Correo);
        $("#txtTelefono").val(Vendedor.Telefono);
        $("#txtFechaNacimiento").val(Vendedor.FechaNacimiento.split('T')[0]);
        $("#txtCargo").val(Vendedor.Cargo);
    }
    else {
        $("#dvMensaje").html("No se encontro el Vendedor");
        $("#txtNombre").val("");
        $("#txtApellido").val("");
        $("#txtDireccion").val("");
        $("#txtCorreo").val("");
        $("#txtTelefono").val("");
        $("#txtFechaNacimiento").val("");
        $("#txtCargo").val("");
    }
}

