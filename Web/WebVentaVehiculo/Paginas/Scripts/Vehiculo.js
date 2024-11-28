
jQuery(function () {
    $("#dvMenu").load("../Paginas/MenuSupervisor.html");
    LlenarComboxServiciosAuth("https://localhost:44337/api/TipoVehiculos/TipoVehiculoCombo", "#cboTipoVehiculo");
    LlenarComboxServiciosAuth("https://localhost:44337/api/EstadoVehiculos/EstadoVehiculoCombo", "#cboEstadoVehiculo");
    LlenarTablaVehiculo();
});

function LimpiarVehiculo() {
    LimpiarFormularios('frmVehiculos');
}

function LlenarTablaVehiculo() {

    LlenarTablaxServiciosAuth("https://localhost:44337/api/Vehiculos/LlenarTablaVehiculo", "#tblVehiculo");
}

class Vehiculo {

    constructor(Placa, Marca, Modelo, Precio, Kilometraje, CodEstadoVehiculo, CodTipoVehiculo) {

        this.Placa = Placa;
        this.Marca = Marca;
        this.Modelo = Modelo;
        this.Precio = Precio;
        this.Kilometraje = Kilometraje;
        this.CodEstadoVehiculo = CodEstadoVehiculo;
        this.CodTipoVehiculo = CodTipoVehiculo;

    }
}

async function Execute(Method, Function) {
    const vehiculo = new Vehiculo($("#txtPlaca").val(), $("#txtMarca").val(), $("#txtModelo").val(),
        $("#txtPrecio").val(), $("#txtKilometraje").val(), $("#cboEstadoVehiculo").val(), $("#cboTipoVehiculo").val());
    let URL = "https://localhost:44337/api/Vehiculos/" + Function;
    await ExecuteCommandServiceAuth(Method, URL, vehiculo);
    LlenarTablaVehiculo();
}

async function BuscarVehiculo() {
    let Placa = $("#txtPlaca").val();
    URL = "https://localhost:44337/api/Vehiculos/BuscarxPlaca?Placa=" + Placa;

    //invoco el servicio generico 
    const Vehiculo = await SearchServiceAuth(URL);

    if (Vehiculo != null) {

        $("#txtPlaca").val(Vehiculo.Placa);
        $("#txtMarca").val(Vehiculo.Marca);
        $("#txtModelo").val(Vehiculo.Modelo);
        $("#txtPrecio").val(Vehiculo.Precio);
        $("#txtKilometraje").val(Vehiculo.Kilometraje);
        $("#cboEstadoVehiculo").val(Vehiculo.CodEstadoVehiculo);
        $("#cboTipoVehiculo").val(Vehiculo.CodTipoVehiculo);
    }
    else {
        $("#dvMensaje").html("No se encontro el Vehiculo");
    }
}