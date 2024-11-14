jQuery(function () {

    //LlenarComboxServicios("link", "#cboTipoServicio");
    LlenarTablaCita();
});
function LimpiarCita() {
    LimpiarFormularios('frmCita');
}

function LlenarTablaCita() {
    /*LlenarTablaxServicios("link", "#tblCita");*/
}

async function Execute(Method, Function) {
    const cita = new Cita($("#txtCodigo").val(), $("#txtIdCliente").val(), $("#txtIdVeh").val(), $("#txtCodTipoServicio").val(),
        $("#txtFechaHora").val());
    let URL = "/*link*/" + Function;
    await ExecuteCommandService(Method, URL, cita);
    LlenarTablaCita();
}

class Cita {
    constructor(Codigo, IdCliente, IdVeh, CodTipoServicio, FechaHora) {

        this.Codigo = Codigo;
        this.IdCliente = IdCliente;
        this.IdVeh = IdVeh;
        this.CodTipoServicio = CodTipoServicio;
        this.FechaHora = FechaHora;
    }
}

async function BuscarServicio() {
    let Codigo = $("#txtCodigo").val();
    URL = "link" + Codigo;

    //invoco el servicio generico 
    const Cita = await SearchService(URL);

    if (Cita != null) {

        $("#txtCodigo").val(Cita.Codigo);
        $("#txtIdCliente").val(Cita.IdCliente);
        $("#txtIdVeh").val(Cita.IdVeh);
        $("#txtCodTipoServicio").val(Cita.CodTipoServicio);
        $("#txtFechaHora").val(Cita.FechaHora.split('T')[0]);
    }
    else {

        $("#dvMensaje").html("No se encontro la Cita");
        $("#txtCodigo").val("");
        $("#txtIdCliente").val("");
        $("#txtIdVeh").val("");
        $("#txtCodTipoServicio").val("");
        $("#txtFechaHora").val("");
    }
}
