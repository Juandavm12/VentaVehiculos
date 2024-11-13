jQuery(function () {

    /*LlenarComboxServicios("", "#cboTipoVehiculo");*/
    /*LlenarComboxServicios("", "#cboEstadoVehiculo");*/
    LlenarTablaVehiculo();
});

function LimpiarVehiculo() {
    LimpiarFormularios('frmVehiculo');
}

function LlenarTablaVehiculo() {

    LlenarTablaxServicios("https://localhost:44337/api/Vehiculos/LlenarTablaVehiculo", "#tblVehiculo");
}

class Vehiculo {

    constructor(CodTipoVehiculo, Placa, Marca, Modelo, Precio, Kilometraje, CodEstadoVehiculo) {

        this.CodTipoVehiculo = CodTipoVehiculo;
        this.Placa = Placa;
        this.Marca = Marca;
        this.Modelo = Modelo;
        this.Precio = Precio;
        this.Kilometraje = Kilometraje;
        this.CodEstadoVehiculo = CodEstadoVehiculo; 

    }
}

async function Execute(Method, Function) {
    const vehiculo = new Vehiculo($("#txtCodTipoVehiculo").val(), $("#txtPlaca").val(), $("#txtMarca").val(), $("#txtModelo").val(),
        $("#txtPrecio").val(), $("#txtKilometraje").val(), $("#txtCodEstadoVehiculo").val());
    let URL = "https://localhost:44337/api/Vehiculos/" + Function;
    ExecuteCommandService(Method, URL, vehiculo);
    LlenarTablaVehiculo();
}

async function BuscarVehiculo() {
    let Placa = $("#txtPlaca").val();
    URL = "https://localhost:44337/api/Vehiculos/BuscarxPlaca?Placa=" + Placa;

    //invoco el servicio generico 
    const Vehiculo = await SearchService(URL);

    if (Vehiculo != null) {

        $("#txtCodTipoVehiculo").val(Vehiculo.CodTipoVehiculo);
        $("#txtPlaca").val(Vehiculo.Placa);
        $("#txtMarca").val(Vehiculo.Marca);
        $("#txtModelo").val(Vehiculo.Modelo);
        $("#txtPrecio").val(Vehiculo.Precio);
        $("#txtKilometraje").val(Vehiculo.Kilometraje);
        $("#txtCodEstadoVehiculo").val(Vehiculo.CodEstadoVehiculo);
    }
    else {
        $("#dvMensaje").html("No se encontro el Vehiculo");
    }
}