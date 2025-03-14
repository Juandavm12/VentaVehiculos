﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsEmpleado 
    {
        //Atributo VentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla usuario
        public Empleado empleado { get; set; }

        public string InsertarEmpleado()
        {
            try
            {
                Empleado _empleado = BuscarEmpleado(empleado.Documento);

                if (_empleado == null)
                {
                    dbVentaVehiculos.Empleadoes.Add(empleado);
                    dbVentaVehiculos.SaveChanges();
                    return "El Empleado " + empleado.Nombre + " ha sido creado exitosamente";
                }
                else
                {
                    return "El Documento " + empleado.Documento + " ya esta asociado a un empleado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ActualizarEmpleado()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                Empleado _empleado = BuscarEmpleado(empleado.Documento);

                if (_empleado != null)
                {
                    dbVentaVehiculos.Empleadoes.AddOrUpdate(empleado);
                    dbVentaVehiculos.SaveChanges();
                    return "El Empleado " + empleado.Nombre + " se ha actualizado exitosamente";
                }
                else
                {
                    return "El Empleado que intenta actualizar no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Empleado BuscarEmpleado(string documento)
        {
            return dbVentaVehiculos.Empleadoes.FirstOrDefault(x => x.Documento == documento);
        }

        public string EliminarEmpleado()
        {
            try
            {
                //We use Search method that we created to allow us searching for the user id we want to delete
                Empleado _empleado = BuscarEmpleado(empleado.Documento);

                if (_empleado != null)
                {
                    dbVentaVehiculos.Empleadoes.Remove(_empleado);
                    dbVentaVehiculos.SaveChanges();
                    return "El Empleado " + empleado.Nombre + " se ha eliminado exitosamente";
                }
                else
                {
                    return "El Empleado que intenta eliminar no existe";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarTablaEmpleado()
        {
            return from E in dbVentaVehiculos.Set<Empleado>()
                   orderby E.Nombre, E.Cargo
                   select new
                   {
                       Documento = E.Documento,
                       Nombre = E.Nombre,
                       Apellido = E.Apellido,
                       Direccion = E.Direccion,
                       Email = E.Correo,
                       Telefono = E.Telefono,
                       FechaNacimiento = E.FechaNacimiento,
                       Cargo = E.Cargo
                   };
        }

        public IQueryable EmpleadoCombo()
        {
            return dbVentaVehiculos.Empleadoes
                .OrderBy(t => t.Nombre)
                .Select(t => new
                {
                    Id = t.Id,
                    Nombre = t.Nombre + " " + t.Apellido
                });
        }

        public IQueryable EmpleadoxCargo(string Documento)
        {
            return from E in dbVentaVehiculos.Set<Empleado>()
                   where E.Documento == Documento
                   select new
                   {
                       Empleado = E.Nombre + " " + E.Apellido,
                       Cargo = E.Cargo,
                       Id = E.Id
                   };
        }

        public IQueryable EmpleadoxUsuario(string Usuario)
        {
            return from E in dbVentaVehiculos.Set<Empleado>()
                   join U in dbVentaVehiculos.Set<Usuario>() on E.Id equals U.IdEmpleado
                   where U.NombreUsuario == Usuario
                   select new
                   {
                       IdEmpleado = E.Id,
                       Empleado = E.Nombre + " " + E.Apellido,
                       Cargo = E.Cargo            
                   };
        }
    }
}
