jQuery(function () {

    LlenarComboxServicios("https://localhost:44337/api/Perfiles/PerfilCombo", "#cboPerfil");
});

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