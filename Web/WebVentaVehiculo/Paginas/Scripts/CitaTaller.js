jQuery(function () {
    LlenarComboxServicios("https://localhost:44337/api/Clientes/ClienteCombo", "#cboCliente");
    LlenarComboxServicios("https://localhost:44337/api/Vehiculos/VehiculoCombo", "#cboVehiculo");
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
    const cita = new Cita($("#txtCodigo").val(), $("#cboCliente").val(), $("#cboVehiculo").val(), $("#cboTipoServicio").val(),
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
        $("#cboCliente").val(Cita.IdCliente);
        $("#cboVehiculo").val(Cita.IdVeh);
        $("#cboTipoServicio").val(Cita.CodTipoServicio);
        $("#txtFechaHora").val(Cita.FechaHora);
    }
    else {

        $("#dvMensaje").html("No se encontro la Cita");
        $("#txtCodigo").val("");
        $("#cboCliente").val("");
        $("#cboVehiculo").val("");
        $("#cboTipoServicio").val("");
        $("#txtFechaHora").val("");
    }
}
