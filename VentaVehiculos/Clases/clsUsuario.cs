using Servicios_PD.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsUsuario
    {
        private VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        public Usuario usuario { get; set; }

        public string InsertarUsuario(int idPerfil)
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                cifrar.Password = usuario.Clave;

                if (cifrar.CifrarClave())
                {
                    //Graba el usuario
                    usuario.Clave = cifrar.PasswordCifrado;
                    usuario.Salt = cifrar.Salt;
                    dbVentaVehiculos.Usuarios.Add(usuario);
                    dbVentaVehiculos.SaveChanges();

                    //Graba en la tabla Usuario_Perfil
                    UsuarioPerfil usuarioPerfil = new UsuarioPerfil();
                    usuarioPerfil.IdPerfil = idPerfil;
                    usuarioPerfil.IdUsuario = usuario.Id;
                    usuarioPerfil.Activo = true;
                    dbVentaVehiculos.UsuarioPerfils.Add(usuarioPerfil);
                    dbVentaVehiculos.SaveChanges();

                    return "Se creo el usuario: " + usuario.NombreUsuario;

                }
                else
                {
                    return "No pudo generar la clave cifrada, no se creo el usuario";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarTablaUsuario()
        {
            return from U in dbVentaVehiculos.Set<Usuario>()
                   join E in dbVentaVehiculos.Set<Empleado>() on U.IdEmpleado equals E.Id
                   join UP in dbVentaVehiculos.Set<UsuarioPerfil>() on U.Id equals UP.IdUsuario
                   join P in dbVentaVehiculos.Set<Perfil>() on UP.IdPerfil equals P.Id
                   orderby E.Id
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-lg\" style=\"color: #000000;\"" +
                       "onclick=\"EditarUsuario('" + U.Id + "', '" + E.Documento + "', '" + E.Nombre + " " + E.Apellido + "'," +
                       "'" + E.Cargo + "', '" + E.Id + "', '" + U.NombreUsuario + "', '" + P.Id + "')\">Editar</button>",
                       Documento = E.Documento,
                       Empleado = E.Nombre + " " + E.Apellido,
                       Cargo = E.Cargo,
                       Usuario = U.NombreUsuario,
                       Perfil = P.Nombre,
                       Activo = UP.Activo ? "SI" : "NO"
                   };
        }
    }
}