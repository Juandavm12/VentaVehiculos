jQuery(function () {

    LlenarComboxServicios("https://localhost:44337/api/Perfiles/PerfilCombo", "#cboPerfil");
    LlenarTablaUsuario();
});

async function LlenarTablaUsuario() {
    LlenarTablaxServicios("https://localhost:44337/api/Usuarios/LlenarTablaUsuario", "#tblUsuarios");
}

function LimpiarUsuario() {
    LimpiarFormularios('frmUsuario');
}

function EditarUsuario(idUsuario, DocumentoEmpleado, Empleado, Cargo, IdEmpleado, Usuario, Perfil) {
    $("#txtDocumento").val(DocumentoEmpleado);
    $("#txtNombre").val(Empleado);
    $("#txtCargo").val(Cargo);
    $("#txtIdEmpleado").val(IdEmpleado);
    $("#txtUsuario").val(Usuario);
    $("#cboPerfil").val(Perfil);
}

async function Execute(Method, Function) {
    let Clave = $("#txtClave").val();
    let RepitaClave = $("#txtConfirmaClave").val();
    let idPerfil = $("#cboPerfil").val();

    if (Clave != RepitaClave) {
        $("#dvMensaje").html("Las claves no son iguales");
        return;
    }

    const usuario = new Usuario(0, $("#txtIdEmpleado").val(), $("#txtUsuario").val(), Clave);
    let URL = "https://localhost:44337/api/Usuarios/" + Function + "?Perfil=" + idPerfil;
    await  ExecuteCommandService(Method, URL, usuario);
    LlenarTablaUsuario();
}

async function EmpleadoxCargo() {
    let Documento = $("#txtDocumento").val();
    URL = "https://localhost:44337/api/Empleados/EmpleadoxCargo?Documento=" + Documento;

    const empleado = await SearchService(URL);

    if (empleado != null && empleado.length > 0) {
        $("#txtNombre").val(empleado[0].Empleado);
        $("#txtCargo").val(empleado[0].Cargo);
        $("#txtIdEmpleado").val(empleado[0].Id);
        $("#dvMensaje").html("");
    }
    else {
        $("#txtNombre").val("");
        $("#txtCargo").val("");
        $("#dvMensaje").html("No se encontro el Empleado, por favor valide la informacion");
    }
}
class Usuario {
    constructor(Id, IdEmpleado, NombreUsuario, Clave) {
        this.Id = Id;
        this.IdEmpleado = IdEmpleado;
        this.NombreUsuario = NombreUsuario;
        this.Clave = Clave;
    }
}