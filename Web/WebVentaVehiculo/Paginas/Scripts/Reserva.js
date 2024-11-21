function LimpiarReserva() {
    LimpiarFormularios('frmReserva');
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
    const venta = new Venta($("#txtCodigo").val(), $("#txtIdCliente").val(), $("#txtIdEmpleado").val(),
        $("#txtIdVeh").val(), $("#txtFecha").val(), $("#txtFechaVen").val());
    let URL = "https://localhost:44337/api/Reservas/" + Function;
    ExecuteCommandService(Method, URL, reserva);
}

async function BuscarReserva() {
    let Codigo = $("#txtCodigo").val();
    URL = "https://localhost:44337/api/Reservas/VentaxCodigo?Codigo=" + Codigo;

    //invoco el servicio generico 
    const Reserva = await SearchService(URL);

    if (Reserva != null) {

        $("#txtCodigo").val(Reserva.Codigo);
        $("#txtIdCliente").val(Reserva.IdCliente);
        $("#txtIdEmpleado").val(Reserva.IdEmpleado);
        $("#txtIdVeh").val(Reserva.IdVeh);
        $("#txtFecha").val(Reserva.Fecha.split('T')[0])
        $("#txtFechaVen").val(Reserva.FechaVen.split('T')[0]);
    }
    else {

        $("#dvMensaje").html("No se encontro la Reserva");
    }
}