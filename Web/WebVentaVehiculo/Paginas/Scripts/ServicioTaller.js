jQuery(function () {

    //LlenarComboxServicios("link", "#cboEstadoServicio");
    //LlenarComboxServicios("link", "#cboTipoServicio");
    LlenarTablaServicio();
});

function LimpiarServicio() {
    LimpiarFormularios('frmServicio');
}

function LlenarTablaServicio() {
    /*LlenarTablaxServicios("link", "#tblServicio");*/
}

async function Execute(Method, Function) {
    const servicio = new Servicio($("#txtCodigo").val(), $("#txtIdCliente").val(), $("#txtIdVeh").val(), $("#txtCodEstadoServicio").val(), $("#txtCodTipoServicio").val(),
        $("#txtFecha").val(), $("#txtComentarios").val());
    let URL = "/*link*/" + Function;
    await ExecuteCommandService(Method, URL, servicio);
    LlenarTablaServicio();
}


async function BuscarServicio() {
    let Codigo = $("#txtCodigo").val();
    URL = "link" + Codigo;

    //invoco el servicio generico 
    const Servicio = await SearchService(URL);

    if (Servicio != null) {

        $("#txtCodigo").val(Servicio.Codigo);
        $("#txtIdCliente").val(Servicio.IdCliente);
        $("#txtIdVeh").val(Servicio.IdVeh);
        $("#txtCodEstadoServicio").val(Servicio.CodEstadoServicio);
        $("#txtCodTipoServicio").val(Servicio.CodTipoServicio); 
        $("#txtFecha").val(Servicio.Fecha.split('T')[0]);
        $("#txtComentarios").val(Servicio.Comentarios); 
    }
    else {

        $("#dvMensaje").html("No se encontro el Servicio");
        $("#txtCodigo").val("");
        $("#txtIdCliente").val("");
        $("#txtIdVeh").val("");
        $("#txtCodEstadoServicio").val("");
        $("#txtCodTipoServicio").val("");
        $("#txtFecha").val("");
        $("#txtComentarios").val("");
    }
}

class Servicio {
    constructor(Codigo, IdCliente, IdVeh, CodEstadoServicio, CodTipoServicio, Fecha, Comentarios) {

        this.Codigo = Codigo;
        this.IdCliente = IdCliente;
        this.IdVeh = IdVeh;
        this.CodEstadoServicio = CodEstadoServicio;
        this.CodTipoServicio = CodTipoServicio;
        this.Fecha = Fecha;
        this.Comentarios = Comentarios;
    }
}