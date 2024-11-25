﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVehiculos.Models
{
    public class Login
    {
        public string Usuario { get; set; }

        public string Clave { get; set; }
    }

    public class LoginRespuesta
    {
        public string Perfil { get; set; }  

        public string Token { get; set; }

        public bool Autenticado { get; set; }

        public string PaginaInicio { get; set; }

        public string Mensaje { get; set; }
    }

}
