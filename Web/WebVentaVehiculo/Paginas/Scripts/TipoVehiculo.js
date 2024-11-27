jQuery(function () {

    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/MenuCliente.html")
    LlenarTablaTV();
});
function LimpiarTV() {
    LimpiarFormularios('frmTV');
}

function LlenarTablaTV() {
    /*LlenarTablaxServicios("link", "#tblTV");*/
}

async function Execute(Method, Function) {
    const tv = new TV($("#txtCodigo").val(), $("#txtTipo").val());
    let URL = "/*link*/" + Function;
    await ExecuteCommandService(Method, URL, tv);
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
    const TV = await SearchService(URL);

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