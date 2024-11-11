class Reserva {
    constructor(Codigo, IdCliente, IdVendedor, IdVeh, Fecha, FechaVen) {
        this.Codigo = Codigo;
        this.IdCliente = IdCliente;
        this.IdVendedor = IdVendedor;
        this.IdVeh = IdVeh;
        this.Fecha = Fecha;
        this.FechaVen = FechaVen;
    }
}

async function Execute(Method, Function) {
    const venta = new Venta($("#txtCodigo").val(), $("#txtIdCliente").val(), $("#txtIdVendedor").val(),
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
        $("#txtIdVendedor").val(Reserva.IdVendedor);
        $("#txtIdVeh").val(Reserva.IdVeh);
        $("#txtFecha").val(Reserva.Fecha.split('T')[0])
        $("#txtFechaVen").val(Reserva.FechaVen.split('T')[0]);
    }
    else {

        $("#dvMensaje").html("No se encontro la Reserva");
    }
}