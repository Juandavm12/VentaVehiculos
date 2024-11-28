jQuery(function () {

    //Al iniciar la pagina se llena el combo
    LlenarTablaTG();

});

function LimpiarTG() {
    LimpiarFormularios('frmTG');
}

//function LlenarTablaTG() {
//    LlenarTablaxServiciosAuth(/*"link"*/, "#tblTG");
//}

async function Execute(Method, Function) {
    const tg = new TG($("#txtCodigo").val(), $("#txtNombre").val(), $("#txtDescripcion").val());
    let URL = "link" + Function;
    await ExecuteCommandServiceAuth(Method, URL, tg);
    LlenarTablaTG();
}

async function BuscarTG() {
    let Codigo = $("#txtCodigo").val();
    URL = "link" + Codigo;

    //invoco el servicio generico 
    const TG = await SearchServiceAuth(URL);

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