jQuery(function () {

    //Al iniciar la pagina se llena el combo de TipoCliente
    LlenarComboxServicios("https://localhost:44337/api/TipoClientes/TipoClienteCombo", "#cboTipoCliente");
    LlenarTablaCliente();

});

function LimpiarCliente() {
    LimpiarFormularios('frmClientes');
}

function LlenarTablaCliente() {
    LlenarTablaxServicios("https://localhost:44337/api/Clientes/LlenarTablaCliente", "#tblCliente");
}

async function Execute(Method, Function) {
    const cliente = new Cliente($("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtDireccion").val(),
        $("#txtCorreo").val(), $("#txtTelefono").val(), $("#txtFechaNacimiento").val(), $("#cboTipoCliente").val());
    let URL = "https://localhost:44337/api/Clientes/" + Function; 
    await ExecuteCommandService(Method, URL, cliente);
    LlenarTablaCliente();
}

async function BuscarCliente() {
    let Documento = $("#txtDocumento").val();
    URL = "https://localhost:44337/api/Clientes/BuscarxDocumento?Documento=" + Documento;

    //invoco el servicio generico 
    const Cliente = await SearchService(URL);

    if (Cliente != null) { 

        $("#dvMensaje").html("");
        $("#txtNombre").val(Cliente.Nombre);
        $("#txtApellido").val(Cliente.Apellido);      
        $("#txtDireccion").val(Cliente.Direccion);
        $("#txtCorreo").val(Cliente.Correo);
        $("#txtTelefono").val(Cliente.Telefono);  
        $("#txtFechaNacimiento").val(Cliente.FechaNacimiento.split('T')[0]);
        $("#cboTipoCliente").val(Cliente.IdTipoCliente);
    }
    else {
        $("#dvMensaje").html("No existe el cliente que intenta buscar");
        $("#txtNombre").val("");
        $("#txtApellido").val("");
        $("#txtDireccion").val("");
        $("#txtCorreo").val("");
        $("#txtTelefono").val("");
        $("#txtFechaNacimiento").val("");
    }
}

class Cliente {
    constructor(Documento, Nombre, Apellido, Direccion, Correo, Telefono, FechaNacimiento, IdTipoCliente) {

        this.Documento = Documento;
        this.Nombre = Nombre;
        this.Apellido = Apellido;    
        this.Direccion = Direccion;       
        this.Correo = Correo;
        this.Telefono = Telefono;
        this.FechaNacimiento = FechaNacimiento;
        this.IdTipoCliente = IdTipoCliente;
    }
}