jQuery(function () {

    //Al iniciar la pagina se llena el combo de TipoGarantia
    LlenarComboxServiciosAuth("https://localhost:44337/api/TipoGarantias/TipoGarantiaCombo", "#cboTipoGarantia");
    LlenarTablaGarantia();

});

function LimpiarGarantia() {
    LimpiarFormularios('frmGarantia');
}

function LlenarTablaGarantia() {
    LlenarTablaxServiciosAuth("https://localhost:44337/api/Garantias/LlenarTablaGarantia", "#tblGarantia");
}

async function Execute(Method, Function) {
    const garantia = new Garantia($("#txtCodigo").val(), $("#txtNumFactura").val(), $("#txtFechaInicio").val(), $("#txtFechaFinal").val(),
        $("#cboTipoGarantia").val());
    let URL = "https://localhost:44337/api/Garantias/" + Function;
    await ExecuteCommandServiceAuth(Method, URL, garantia);
    LlenarTablaGarantia();
}

async function BuscarGarantia() {
    let Codigo = $("#txtCodigo").val();
    URL = "https://localhost:44337/api/Garantias/BuscarxCodigo?Codigo=" + Codigo;

    //invoco el servicio generico 
    const Garantia = await SearchServiceAuth(URL);

    if (Garantia != null) {

        $("#dvMensaje").html("");
        $("#txtCodigo").val(Garantia.Codigo);
        $("#txtNumFactura").val(Garantia.NumFactura);
        $("#txtFechaInicio").val(Garantia.FechaInicio.split('T')[0]);
        $("#txtFechaFinal").val(Garantia.FechaFinal.split('T')[0]);
        $("#cboTipoGarantia").val(Garantia.codTipoGarantia);
    }
    else {
        $("#dvMensaje").html("No existe la Garantia que intenta buscar");
        $("#txtCodigo").val("");
        $("#txtNumFactura").val("");
        $("#txtFechaInicio").val("");
        $("#txtFechaFinal").val("");
        $("#cboTipoGarantia").val("");
    }
}

class Garantia {
    constructor(Codigo, NumFactura, FechaInicio, FechaFinal, codTipoGarantia) {

        this.Codigo = Codigo;
        this.NumFactura = NumFactura;
        this.FechaInicio = FechaInicio;
        this.FechaFinal = FechaFinal;
        this.codTipoGarantia = codTipoGarantia;
    }
}