jQuery(function () {

    LlenarComboxServiciosAuth("https://localhost:44337/api/Clientes/ClienteCombo", "#cboCliente");
    LlenarComboxServiciosAuth("https://localhost:44337/api/Empleados/EmpleadoCombo", "#cboEmpleado");
    LlenarComboxServiciosAuth("https://localhost:44337/api/Vehiculos/VehiculoCombo", "#cboVehiculo");
    LlenarTablaReserva();

});
function LimpiarReserva() {
    LimpiarFormularios('frmReserva');
}

function LlenarTablaReserva() {
    LlenarTablaxServiciosAuth("https://localhost:44337/api/Reservas/LlenarTablaReserva", "#tblReserva");
}

class Reserva {
    constructor(Codigo, IdCliente, IdEmpleado, IdVeh, Fecha, FechaVen) {
        this.Codigo = Codigo;
        this.IdCliente = IdCliente;
        this.IdEmpleado = IdEmpleado;
        this.IdVeh = IdVeh;
        this.Fecha = Fecha;
        this.FechaVen = FechaVen;
    }
}

async function Execute(Method, Function) {
    const reserva = new Reserva($("#txtCodigo").val(), $("#cboCliente").val(), $("#cboEmpleado").val(),
        $("#cboVehiculo").val(), $("#txtFecha").val(), $("#txtFechaVen").val());
    let URL = "https://localhost:44337/api/Reservas/" + Function;
    await ExecuteCommandServiceAuth(Method, URL, reserva);
    LlenarTablaReserva();
}

async function BuscarReserva() {
    let Codigo = $("#txtCodigo").val();
    URL = "https://localhost:44337/api/Reservas/ReservaxCodigo?Codigo=" + Codigo;

    //invoco el servicio generico 
    const Reserva = await SearchServiceAuth(URL);

    if (Reserva != null) {

        $("#txtCodigo").val(Reserva.Codigo);
        $("#cboCliente").val(Reserva.IdCliente);
        $("#cboEmpleado").val(Reserva.IdEmpleado);
        $("#cboVehiculo").val(Reserva.IdVeh);
        $("#txtFecha").val(Reserva.Fecha.split('T')[0])
        $("#txtFechaVen").val(Reserva.FechaVen.split('T')[0]);
    }
    else {

        $("#dvMensaje").html("No se encontro la Reserva");
    }
}