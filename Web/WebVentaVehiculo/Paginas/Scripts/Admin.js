class Admin {
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
    const admin = new Admin($("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtDireccion").val(),
        $("#txtCorreo").val(), $("#txtTelefono").val(), $("#txtFechaNacimiento").val(), $("#txtCargo").val());
    let URL = "https://localhost:44337/api/Admins/" + Function;
    ExecuteCommandService(Method, URL, admin);
}

async function BuscarAdmin() {
    let Documento = $("#txtDocumento").val();
    URL = "https://localhost:44337/api/Admins/AdminxDocumento?Documento=" + Documento;

    //invoco el servicio generico 
    const Admin = await SearchService(URL);

    if (Admin != null) {

        $("#txtNombre").val(Admin.Nombre);
        $("#txtApellido").val(Admin.Apellido);
        $("#txtDireccion").val(Admin.Direccion);
        $("#txtCorreo").val(Admin.Correo);
        $("#txtTelefono").val(Admin.Telefono);
        $("#txtFechaNacimiento").val(Admin.FechaNacimiento.split('T')[0]);
        $("#txtCargo").val(Admin.Cargo);
    }
    else {
        $("#dvMensaje").html("No se encontro el Administrador");
    }
}