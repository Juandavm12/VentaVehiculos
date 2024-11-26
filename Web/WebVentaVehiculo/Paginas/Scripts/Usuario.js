jQuery(function () {

    LlenarComboxServicios("https://localhost:44337/api/Perfiles/PerfilCombo", "#cboPerfil");
    /*LlenarTablaUsuario();*/
});

//function LlenarTabla() {
//    LlenarTablaXServicios("https://localhost:44337/api/Usuarios/ListarUsuarios", "#tblUsuarios");
//}


async function Execute(Method, Function) {

    let idPerfil = $("#cboPerfil").val();
    let Clave = $("#txtClave").val();
    let RepitaClave = $("#txtConfirmaClave").val();

    if (Clave != RepitaClave) {
        $("#dvMensaje").html("Las claves no son iguales");
        return;
    }
    const usuario = new Usuario(0, $("#txtDocumento").val(), $("#txtNombre").val(), $("#txtCargo").val(), $("#txtUsuario").val(), Clave);
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