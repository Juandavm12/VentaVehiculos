jQuery(function () {
    LlenarComboxServiciosAuth("https://localhost:44337/api/Clientes/ClienteCombo", "#cboCliente");
    LlenarComboxServiciosAuth("https://localhost:44337/api/Vehiculos/VehiculoCombo", "#cboVehiculo");
    LlenarComboxServiciosAuth("https://localhost:44337/api/EstadoServicios/EstadoServicioCombo", "#cboEstadoServicio");
    LlenarComboxServiciosAuth("https://localhost:44337/api/TipoServicios/TipoServicioCombo", "#cboTipoServicio");
    LlenarTablaServicio();
});

function LimpiarServicio() {
    LimpiarFormularios('frmServicio');
}

function LlenarTablaServicio() {
    LlenarTablaxServiciosAuth("https://localhost:44337/api/Servicios/LlenarTablaServicio", "#tblServicio");
}

async function Execute(Method, Function) {
    const servicio = new Servicio($("#txtId").val(), $("#cboCliente").val(), $("#cboVehiculo").val(),
        $("#cboEstadoServicio").val(), $("#cboTipoServicio").val(),
        $("#txtFecha").val(), $("#txtComentarios").val());
    let URL = "https://localhost:44337/api/Servicios/" + Function;
    await ExecuteCommandServiceAuth(Method, URL, servicio);
    LlenarTablaServicio();
}


async function BuscarServicio() {
    let Id = $("#txtId").val();
    URL = "https://localhost:44337/api/Servicios/BuscarServicioxId?Id=" + Id;

    //invoco el servicio generico 
    const Servicio = await SearchServiceAuth(URL);

    if (Servicio != null) {

        $("#txtId").val(Servicio.Id);
        $("#cboCliente").val(Servicio.IdCliente);
        $("#cboVehiculo").val(Servicio.IdVeh);
        $("#cboEstadoServicio").val(Servicio.CodEstadoServicio);
        $("#cboTipoServicio").val(Servicio.CodTipoServicio); 
        $("#txtFecha").val(Servicio.Fecha.split('T')[0]);
        $("#txtComentarios").val(Servicio.Comentarios); 
    }
    else {

        $("#dvMensaje").html("No se encontro el Servicio");
        $("#txtId").val("");
        $("#cboCliente").val("");
        $("#cboVehiculo").val("");
        $("#cboEstadoServicio").val("");
        $("#cboTipoServicio").val("");
        $("#txtFecha").val("");
        $("#txtComentarios").val("");
    }
}

class Servicio {
    constructor(Id, IdCliente, IdVeh, CodEstadoServicio, CodTipoServicio, Fecha, Comentarios) {

        this.Id = Id;
        this.IdCliente = IdCliente;
        this.IdVeh = IdVeh;
        this.CodEstadoServicio = CodEstadoServicio;
        this.CodTipoServicio = CodTipoServicio;
        this.Fecha = Fecha;
        this.Comentarios = Comentarios;
    }
}