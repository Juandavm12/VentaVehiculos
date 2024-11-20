jQuery(function () {

    //Al iniciar la pagina se llena el combo
    LlenarTablaTG();

});

function LimpiarTG() {
    LimpiarFormularios('frmTG');
}

function LlenarTablaTG() {
    LlenarTablaxServicios("link", "#tblTG");
}

async function Execute(Method, Function) {
    const tg = new TG($("#txtCodigo").val(), $("#txtNombre").val(), $("#txtDescripcion").val());
    let URL = "link" + Function;
    await ExecuteCommandService(Method, URL, tg);
    LlenarTablaTG();
}

async function BuscarTG() {
    let Codigo = $("#txtCodigo").val();
    URL = "link" + Codigo;

    //invoco el servicio generico 
    const TG = await SearchService(URL);

    if (TG != null) {

        $("#dvMensaje").html("");
        $("#txtCodigo").val(TG.Codigo);
        $("#txtNombre").val(TG.Nombre);
        $("#txtDescripcion").val(TG.Descripcion); 
    }
    else {
        $("#dvMensaje").html("No existe el Tipo de Garantia que intenta buscar");
        $("#txtCodigo").val("");
        $("#txtNombre").val("");
        $("#txtDescripcion").val("");
    }
}

class TG {
    constructor(Codigo, Nombre, Descripcion) {

        this.Codigo = Codigo;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
    }
}