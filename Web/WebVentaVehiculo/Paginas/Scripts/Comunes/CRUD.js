
function LimpiarFormularios(frmid) {
    try {
        const form = document.getElementById(frmid);
        if (form) {
            form.reset();
        }
        else {
            console.warn(`No se encontró el formulario con el ID: ${formularioId}`);
        }

    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

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

async function ExecuteCommandServiceRpta(Method, URLService, Object) {
    try {
        const Response = await fetch(URLService,
            {
                method: Method,
                mode: "cors",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(Object)
            });

        const Result = await Response.json();
        return Result; 
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function ExecuteCommandServiceAuth(Metodo, URLServicio, Objeto) {
    //Se crea un objeto de la clase cliente con los datos de la interfaz
    try {
        let Token = getCookie("token");
        const Respuesta = await fetch(URLServicio,
            {
                method: Metodo,
                mode: "cors",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": 'Bearer ' + Token
                },
                body: JSON.stringify(Objeto)
            });
        //Leer la respuesta
        const Resultado = await Respuesta.json();
        $("#dvMensaje").html(Resultado);
    }
    catch (error) {
        //Se presenta el error en un div de Mensaje
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

async function SearchServiceAuth(URLServicio) {
    
    try {
        let Token = getCookie("token");
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": 'Bearer ' + Token
                }
            });
        //Se traduce la respuesta a un objeto
        const Resultado = await Respuesta.json();

        return Resultado;
    }
    catch (error) {
        //Se presenta el error en un div de Mensaje
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
            $(ComboLlenar).append('<option value=' + Rpta[i].Id + '>' + Rpta[i].Nombre + '</option>');
        }
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function LlenarComboxServiciosAuth(URLServicio, ComboLlenar) {
    try {
        Token = getCookie("token");
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": 'Bearer ' + Token
                }
            });
        const Rpta = await Respuesta.json();
        //Se debe limpiar el combo
        $(ComboLlenar).empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $(ComboLlenar).append('<option value=' + Rpta[i].Codigo + '>' + Rpta[i].Nombre + '</option>');
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

async function LlenarComboVehiculoFacturaAuth(URLServicio, ComboLlenar) {
    try {
        Token = getCookie("token");
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": 'Bearer ' + Token
                }
            });
        const Rpta = await Respuesta.json();
        //Se debe limpiar el combo
        $(ComboLlenar).empty();
        //Se recorre en un ciclo para llenar el select con la información
        for (i = 0; i < Rpta.length; i++) {
            $(ComboLlenar).append('<option value=' + Rpta[i].Id + '>' + Rpta[i].Marca + '>' + Rpta[i].Placa + '</option>');
        }
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

async function LlenarTablaxServicios(URLServicio, TablaLlenar) {
    try {
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: { "Content-Type": "application/json" }
            });
        const Rpta = await Respuesta.json();

        //Llenar el encabezado
        var Columnas = [];
        NombreColumnas = Object.keys(Rpta[0]);
        for (var i in NombreColumnas) {
            Columnas.push({
                data: NombreColumnas[i],
                title: NombreColumnas[i]
            });
        }

        //Llenar los datos
        $(TablaLlenar).DataTable({
            data: Rpta,
            columns: Columnas,
            destroy: true
        });
    }
    catch (error) {
        $("#dvMensaje").html(error);
    }
}

async function LlenarTablaxServiciosAuth(URLServicio, TablaLlenar) {
    try {
        Token = getCookie("token");
        const Respuesta = await fetch(URLServicio,
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": 'Bearer ' + Token
                }
            });
        const Rpta = await Respuesta.json();
        var Columnas = [];
        NombreColumnas = Object.keys(Rpta[0]);
        for (var i in NombreColumnas) {
            Columnas.push({
                data: NombreColumnas[i],
                title: NombreColumnas[i]
            });
        }
        //Llena los datos
        $(TablaLlenar).DataTable({
            data: Rpta,
            columns: Columnas,
            destroy: true
        });
    }
    catch (error) {
        //Se presenta la respuesta en el div mensaje
        $("#dvMensaje").html(error);
    }
}

function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
