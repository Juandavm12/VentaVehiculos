
jQuery(function () {

    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/MenuGerente.html");

});
jQuery(function () {

    LlenarTablaEmpleado();
});

function LimpiarEmpleado() {
    LimpiarFormularios('frmEmpleado');
}

function LlenarTablaEmpleado() {
    LlenarTablaxServiciosAuth("https://localhost:44337/api/Empleados/LlenarTablaEmpleado", "#tblEmpleado");
}

class Empleado {
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
    const empleado = new Empleado($("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtDireccion").val(),
        $("#txtCorreo").val(), $("#txtTelefono").val(), $("#txtFechaNacimiento").val(), $("#txtCargo").val());
    let URL = "https://localhost:44337/api/Empleados/" + Function;
    await ExecuteCommandServiceAuth(Method, URL, empleado);
    LlenarTablaEmpleado();
}

async function BuscarEmpleado() {
    let Documento = $("#txtDocumento").val();
    URL = "https://localhost:44337/api/Empleados/EmpleadoxDocumento?Documento=" + Documento;

    //invoco el servicio generico 
    const Empleado = await SearchServiceAuth(URL);

    if (Empleado != null) {

        $("#txtNombre").val(Empleado.Nombre);
        $("#txtApellido").val(Empleado.Apellido);
        $("#txtDireccion").val(Empleado.Direccion);
        $("#txtCorreo").val(Empleado.Correo);
        $("#txtTelefono").val(Empleado.Telefono);
        $("#txtFechaNacimiento").val(Empleado.FechaNacimiento.split('T')[0]);
        $("#txtCargo").val(Empleado.Cargo);
    }
    else {
        $("#dvMensaje").html("No se encontro el Empleado");
        $("#txtNombre").val("");
        $("#txtApellido").val("");
        $("#txtDireccion").val("");
        $("#txtCorreo").val("");
        $("#txtTelefono").val("");
        $("#txtFechaNacimiento").val("");
        $("#txtCargo").val("");
    }
}

