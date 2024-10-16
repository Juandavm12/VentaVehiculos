jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html")
});

async function ExecuteCommandService(Method, URlService, Object) {
    const cliente = new Cliente($("#txtTipoCliente").val(), $("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("txtFechaNacimiento").val(),
        $("#txtDireccion").val(), $("#txtTelefono").val(), $("#txtCorreoElectronico").val());

    try {
        const Response = await fetch(URlService,
            {
                method: Method,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(Object)
            });

        const Result = await Response.json();
        $("#dvMensaje").html(Result);
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function SearchService(URLService) {
    let Documento = $("#txtDocumento").val();

    try {
        const Response = await fetch(URLService,
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });

        const Result = await Response.json();

        return Result; 
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}
