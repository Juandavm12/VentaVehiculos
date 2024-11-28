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

        public string ActualizarUsuario(int idUsuario, int idUsuarioPerfil, int idPerfil)
        {
            try
            {
                Usuario _usuario = dbVentaVehiculos.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
                _usuario.NombreUsuario = usuario.NombreUsuario;
                dbVentaVehiculos.SaveChanges();

                UsuarioPerfil usuarioPerfil = dbVentaVehiculos.UsuarioPerfils.FirstOrDefault(up => up.Id == idUsuarioPerfil);
                usuarioPerfil.IdPerfil = idPerfil;
                dbVentaVehiculos.SaveChanges();
                return "Se actualizaron los datos del usuario: " + usuario.NombreUsuario;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActivarUsuario(int idUsuarioPerfil, bool Activo)
        {
            try
            {
                UsuarioPerfil usuarioPerfil = dbVentaVehiculos.UsuarioPerfils.FirstOrDefault(u => u.Id == idUsuarioPerfil);
                if (usuarioPerfil == null)
                {
                    return "El Usuario que intenta actualizar, no existe";
                }

                usuarioPerfil.Activo = Activo;
                dbVentaVehiculos.SaveChanges();
                return "Se activó el usuario";
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
                       Editar = "<img src=\"Images/editar-informacion.png\" onclick=\"EditarUsuario('" + U.Id + "', " +
                       "'" + E.Documento + "', '" + E.Nombre + " " + E.Apellido + "', '" + E.Cargo + "', '" + E.Id + "'," +
                       "'" + U.NombreUsuario + "', '" + P.Id + "', '" + UP.Id + "')" +
                       "\" style=\"width: 35px; height: 35px; cursor: pointer; margin-left: 5px;\" />" +
                       "&nbsp;&nbsp;&nbsp;&nbsp<img src =\"Images/encendido-apagado.png\" onclick=\"ActivarUsuario('" + UP.Id + "'," +
                       "" + (UP.Activo ? "false" : "true") + ", '" + U.NombreUsuario + "')" +
                       "\" style=\"width: 35px; height: 35px; cursor: pointer; margin-left: 5px;\" />",
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