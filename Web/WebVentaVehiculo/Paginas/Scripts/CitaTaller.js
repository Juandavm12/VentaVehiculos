jQuery(function () {

    LlenarComboxServicios("https://localhost:44337/api/TipoServicios/TipoServicioCombo", "#cboTipoServicio");
    LlenarTablaCita();
});
function LimpiarCita() {
    LimpiarFormularios('frmCita');
}

function LlenarTablaCita() {
    LlenarTablaxServicios("https://localhost:44337/api/Citas/LlenarTablaCita", "#tblCita");
}

async function Execute(Method, Function) {
    const cita = new Cita($("#txtCodigo").val(), $("#txtIdCliente").val(), $("#txtIdVeh").val(), $("#txtCodTipoServicio").val(),
        $("#txtFechaHora").val());
    let URL = "https://localhost:44337/api/Citas/" + Function;
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

async function BuscarCita() {
    let Codigo = $("#txtCodigo").val();
    URL = "https://localhost:44337/api/Citas/CitaxCodigo?Codigo=" + Codigo;

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
