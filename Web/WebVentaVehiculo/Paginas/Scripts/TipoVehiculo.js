jQuery(function () {
    LlenarTablaTV();
});
function LimpiarTV() {
    LimpiarFormularios('frmTV');
}

function LlenarTablaTV() {
    /*LlenarTablaxServiciosAuth("link", "#tblTV");*/
}

async function Execute(Method, Function) {
    const tv = new TV($("#txtCodigo").val(), $("#txtTipo").val());
    let URL = "/*link*/" + Function;
    await ExecuteCommandServiceAuth(Method, URL, tv);
    LlenarTablaTV();
}

class TV {
    constructor(Codigo, Tipo) {

        this.Codigo = Codigo;
        this.Tipo = Tipo;
    }
}

async function BuscarTV() {
    let Codigo = $("#txtCodigo").val();
    URL = "link" + Codigo;

    //invoco el servicio generico 
    const TV = await SearchServiceAuth(URL);

    if (TV != null) {

        $("#txtCodigo").val(TV.Codigo);
        $("#txtTipo").val(TV.Tipo);
    }
    else {

        $("#dvMensaje").html("No se encontro el Tipo de Vehiculo");
        $("#txtCodigo").val("");
        $("#txtTipo").val("");
    }
}