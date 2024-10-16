
async function Execute(Method, Function) {
    const cliente = new Cliente($("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtDireccion").val(),
        $("#txtCorreo").val(), $("#txtTelefono").val(), $("txtFechaNacimiento").val(), $("#txtIdTipoCliente").val());
    let URl = "https://localhost:44337/api/Clientes/" + Function; 
    ExecuteCommandService(Method, URL, cliente);
}

async function BuscarCliente() {
    let Documento = $("#txtDocumento").val();
    URl = "https://localhost:44337/api/Clientes/BuscarxDocumento?Documento=" + Documento;

    //invoco el servicio generico 
    const cliente = await SearchService(URL);

    if (cliente != null) { 
     
        $("#txtDocumento").val(Cliente.Documento);
        $("#txtNombre").val(Cliente.Nombre);
        $("#txtApellido").val(Cliente.Apellido);      
        $("#txtDireccion").val(Cliente.Direccion);
        $("#txtCorreoElectronico").val(Cliente.Correo);
        $("#txtTelefono").val(Cliente.Telefono);      
        $("#txtFechaNacimiento").val(Cliente.FechaNacimiento);
        $("#txtIdTipoCliente").val(Cliente.IdTipoCliente);
    }
    else {
        $("#dvMensaje").html("No se encontro el cliente");
    }
}

class Cliente {
    constructor(Documento, Nombre, Apellido, Direccion, Correo, Telefono, FechaNacimiento, IdTipoCliente) {
        
        this.Documento = Documento;
        this.Nombre = Nombre;
        this.Apellido = Apellido;    
        this.Direccion = Direccion;       
        this.Correo = Correo;
        this.Telefono = Telefono;
        this.FechaNacimiento = FechaNacimiento;
        this.IdTipoCliente = IdTipoCliente;
    }
}


//async function ClientePrice() {
//    let days = $("#txtDiasComprados").val();

//    try {
//        const Response = await fetch("https://localhost:44319/api/Clientes/ClientePrice?days=" + days,
//            {
//                method: "GET",
//                mode: "cors",
//                headers: { "Content-Type": "application/json" }
//            });

//        const Cliente = await Response.json();

//        $("#txtDocumento").val(Cliente.Documento);
//        $("#txtNombre").val(Cliente.Nombre);
//        let PurchaseDate = Cliente.FechaCompra;
//        $("#txtFechaCompra").val(Cliente.FechaCompra.split('T')[0]);
//        $("#txtTipoLocal").val(Cliente.TipoLocal);
//        $("#txtDiasComprados").val(Cliente.DiasComprados);
//        $("#txtPorcentajeDescuento").val(Cliente.PorcentajeDescuento);
//        $("#txtValorDescuento").val(Cliente.ValorDescuento);
//        $("#txtValorTotal").val(Cliente.ValorTotal);
//    }
//    catch (error) {
//        $("#dvMensaje").html(error);
//    }

//}

//function AddCliente() {
//    ExecuteCommand("Post", "AddCliente");
//}

//function Update() {
//    ExecuteCommand("Put", "Update");
//}

//function Delete() {
//    ExecuteCommand("Delete", "Delete");
//}

//async function ExecuteCommand(Method, Function) {
//    const Cliente = new Cliente($("#txtidEntrada").val(), $("#txtDocumento").val(), $("#txtNombre").val(), $("#txtFechaCompra").val(),
//        $("#txtTipoLocal").val(), $("#txtDiasComprados").val(), $("#txtPorcentajeDescuento").val(), $("#txtValorDescuento").val(),
//        $("#txtValorTotal").val());

//    try {
//        const Response = await fetch("https://localhost:44319/api/Clientes/" + Function,
//            {
//                method: Method,
//                mode: "cors",
//                headers: { "Content-Type": "application/json" },
//                body: JSON.stringify(Cliente)
//            });

//        const Result = await Response.json();
//        $("#dvMensaje").html(Result);
//    }
//    catch (error) {
//        $("#dvMensaje").html(error);
//    }
//}

//class Cliente {
//    constructor(idEntrada, Documento, Nombre, FechaCompra, TipoLocal, DiasComprados, PorcentajeDescuento, ValorDescuento, ValorTotal) {
//        this.idEntrada = idEntrada;
//        this.Documento = Documento;
//        this.Nombre = Nombre;
//        this.FechaCompra = FechaCompra;
//        this.TipoLocal = TipoLocal;
//        this.DiasComprados = DiasComprados;
//        this.PorcentajeDescuento = PorcentajeDescuento;
//        this.ValorDescuento = ValorDescuento;
//        this.ValorTotal = ValorTotal;
//    }