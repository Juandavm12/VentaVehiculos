jQuery(function () {

    LlenarTablaTC();
});
function LimpiarTC() {
    LimpiarFormularios('frmTC');
}

function LlenarTablaTC() {
    /*LlenarTablaxServiciosAuth("link", "#tblTC");*/
}

async function Execute(Method, Function) {
    const tc = new TC($("#txtMembresia").val(), $("#txtDescuento").val());
    let URL = /*"link"*/ + Function;
    await ExecuteCommandServiceAuth(Method, URL, tc);
    LlenarTablaTC();
}

class TC {
    constructor(Membresia, Descuento) {

        this.Membresia = Membresia;
        this.Descuento = Descuento;
    }
}

async function BuscarTC() {
    let Membresia = $("#txtMembresia").val();
    URL = "link" + Membresia;

    //invoco el servicio generico 
    const TC = await SearchServiceAuth(URL);

    if (TC != null) {

        $("#txtMembresia").val(TC.Membresia);
        $("#txtDescuento").val(TC.Descuento);
    }
    else {

        $("#dvMensaje").html("No se encontro el Tipo del Cliente");
        $("#txtMembresia").val("");
        $("#txtDescuento").val("");
    }
}