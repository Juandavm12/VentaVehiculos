jQuery(function () {

    LlenarComboxServiciosAuth("https://localhost:44337/api/Perfiles/PerfilCombo", "#cboPerfil");
    LlenarTablaUsuario();
});

async function LlenarTablaUsuario() {
    LlenarTablaxServiciosAuth("https://localhost:44337/api/Usuarios/LlenarTablaUsuario", "#tblUsuarios");
}

async function ActivarUsuario(idUsuarioPerfil, Activo, Usuario) {
    let Mensaje = Activo ? "Esta seguro de activar el usuario: " + Usuario + "?" : "Esta seguro de desactivar el usuario: " + Usuario + "?";

    if (window.confirm(Mensaje)) {
        let URL = "https://localhost:44337/api/Usuarios/ActivarUsuario?idUsuarioPerfil=" + idUsuarioPerfil + "&Activo=" + Activo;
        await ExecuteCommandServiceAuth("PUT", URL, null);
        LlenarTablaUsuario();
    }
    else {
        alert("Ha cancelado el proceso");
    }
}

function LimpiarUsuario() {
    LimpiarFormularios('frmUsuario');
}

function EditarUsuario(IdUsuario, DocumentoEmpleado, Empleado, Cargo, IdEmpleado, Usuario, Perfil, IdUsuarioPerfil) {
    $("#txtDocumento").val(DocumentoEmpleado);
    $("#txtNombre").val(Empleado);
    $("#txtCargo").val(Cargo);
    $("#txtIdEmpleado").val(IdEmpleado);
    $("#txtUsuario").val(Usuario);
    $("#cboPerfil").val(Perfil);
    $("#txtIdUsuario").val(IdUsuario);
    $("#txtIdUsuarioPerfil").val(IdUsuarioPerfil);
}

async function Execute(Method, Function) {
    let Clave = $("#txtClave").val();
    let RepitaClave = $("#txtConfirmaClave").val();
    let idPerfil = $("#cboPerfil").val();

    if (Clave != RepitaClave) {
        $("#dvMensaje").html("Las claves no son iguales");
        return;
    }

    let idUsuario = Method == "PUT" ? $("#txtIdUsuario").val() : 0;
    let idUsuarioPerfil = Method == "PUT" ? $("#txtIdUsuarioPerfil").val() : 0;
    const usuario = new Usuario(idUsuario, $("#txtIdEmpleado").val(), $("#txtUsuario").val(), Clave);
    let URL = "https://localhost:44337/api/Usuarios/" + Function + "?Perfil=" + idPerfil + "&idUsuarioPerfil=" + idUsuarioPerfil;
    await ExecuteCommandServiceAuth(Method, URL, usuario);
    LlenarTablaUsuario();
}

async function EmpleadoxCargo() {
    let Documento = $("#txtDocumento").val();
    URL = "https://localhost:44337/api/Empleados/EmpleadoxCargo?Documento=" + Documento;

    const empleado = await SearchServiceAuth(URL);

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
