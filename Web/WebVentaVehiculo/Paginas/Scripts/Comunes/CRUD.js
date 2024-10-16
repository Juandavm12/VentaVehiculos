jQuery(function () {
    //Registrar los botones para responder al evento click
    $("#dvMenu").load("../Paginas/Menu.html")
});

async function ExecuteCommandService(Method, URLService, Object) {
    try {
        const Response = await fetch(URLService,
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

//Llenar Combo desde un servicio
async function LlenarComboxServicios(URLServicio, ComboLlenar) {
    try {
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                }
            });
        const Rpta = await Respuesta.json();

        //Se limpia el combo
        $(ComboLlenar).empty();

        //Se recorre un ciclo para llenar el select con la informacion
        for (i = 0; i < Rpta.length; i++) {
            $(ComboLlenar).append('<option value=' + Rpta[i].Documento + '>' + Rpta[i].Nombre + '</option>');
        }
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}
