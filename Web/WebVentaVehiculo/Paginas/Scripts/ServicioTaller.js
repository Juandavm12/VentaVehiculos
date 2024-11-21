jQuery(function () {

    LlenarComboxServicios("https://localhost:44337/api/EstadoServicios/EstadoServicioCombo", "#cboEstadoServicio");
    LlenarComboxServicios("https://localhost:44337/api/TipoServicios/TipoServicioCombo", "#cboTipoServicio");
    LlenarTablaServicio();
});

function LimpiarServicio() {
    LimpiarFormularios('frmServicio');
}

function LlenarTablaServicio() {
    LlenarTablaxServicios("https://localhost:44337/api/Servicios/LlenarTablaServicio", "#tblServicio");
}

async function Execute(Method, Function) {
    const servicio = new Servicio($("#txtId").val(), $("#txtIdCliente").val(), $("#txtIdVeh").val(),
        $("#cboEstadoServicio").val(), $("#cboTipoServicio").val(),
        $("#txtFecha").val(), $("#txtComentarios").val());
    let URL = "https://localhost:44337/api/Servicios/" + Function;
    await ExecuteCommandService(Method, URL, servicio);
    LlenarTablaServicio();
}


async function BuscarServicio() {
    let Id = $("#txtId").val();
    URL = "https://localhost:44337/api/Servicios/BuscarServicioxId?Id=" + Id;

    //invoco el servicio generico 
    const Servicio = await SearchService(URL);

    if (Servicio != null) {

        $("#txtId").val(Servicio.Id);
        $("#txtIdCliente").val(Servicio.IdCliente);
        $("#txtIdVeh").val(Servicio.IdVeh);
        $("#cboEstadoServicio").val(Servicio.CodEstadoServicio);
        $("#cboTipoServicio").val(Servicio.CodTipoServicio); 
        $("#txtFecha").val(Servicio.Fecha.split('T')[0]);
        $("#txtComentarios").val(Servicio.Comentarios); 
    }
    else {

        $("#dvMensaje").html("No se encontro el Servicio");
        $("#txtId").val("");
        $("#txtIdCliente").val("");
        $("#txtIdVeh").val("");
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