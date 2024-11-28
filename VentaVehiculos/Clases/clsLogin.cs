using Servicios_PD.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        private VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        private bool ValidarUsuario()
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                Usuario usuario = dbVentaVehiculos.Usuarios.FirstOrDefault(u => u.NombreUsuario == login.Usuario);
                if (usuario == null)
                {
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                byte[] arrBytesSalt = Convert.FromBase64String(usuario.Salt);
                string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
                login.Clave = ClaveCifrada;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in dbVentaVehiculos.Set<Usuario>()
                       join UP in dbVentaVehiculos.Set<UsuarioPerfil>()
                       on U.Id equals UP.IdUsuario
                       join P in dbVentaVehiculos.Set<Perfil>()
                       on UP.IdPerfil equals P.Id
                       where U.NombreUsuario == login.Usuario && U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.NombreUsuario,
                           Perfil = P.Nombre,
                           Token = token,
                           Autenticado = true,
                           PaginaInicio = P.PaginaNavegar,
                           Mensaje = "Usuario Autenticado",
                       };
            }
            else
            {
                return null;
            }
        }

    }
}