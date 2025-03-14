﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VentaVehiculos.Models;

namespace VentaVehiculos.Clases
{
    public class clsVehiculo
    {
        //Atributo DbVentaVehiculos
        VentaVehiculosEntities dbVentaVehiculos = new VentaVehiculosEntities();

        //Objeto de la tabla usuario
        public Vehiculo vehiculo { get; set; }

        public string InsertarVehiculo()
        {
            try
            {
                Vehiculo _vehiculo = BuscarVehiculo(vehiculo.Placa);

                if (_vehiculo == null)
                {
                    dbVentaVehiculos.Vehiculoes.Add(vehiculo);
                    dbVentaVehiculos.SaveChanges();
                    return "El Vehiculo con Placas " + vehiculo.Placa + " ha sido creado exitosamente";
                }
                else
                {
                    return "La Placa " + vehiculo.Placa + " ya esta asociada a un Vehiculo";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string ActualizarVehiculo()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                Vehiculo _vehiculo = BuscarVehiculo(vehiculo.Placa);

                if (_vehiculo != null)
                {
                    dbVentaVehiculos.Vehiculoes.AddOrUpdate(vehiculo);
                    dbVentaVehiculos.SaveChanges();
                    return "El Vehiculo con placas " + vehiculo.Placa + " se ha actualizado exitosamente";
                }
                else
                {
                    return "El Vehiculo que intenta actualizar no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Vehiculo BuscarVehiculo(string placa)
        {
            //We use lambda to take the object type we are using
            return dbVentaVehiculos.Vehiculoes.FirstOrDefault(x => x.Placa == placa);
        }

        public string EliminarVehiculo()
        {
            try
            {
                //We use AddorUpdate method that allows us to update the user information
                Vehiculo _vehiculo = BuscarVehiculo(vehiculo.Placa);

                if (_vehiculo.Placa != null)
                {
                    dbVentaVehiculos.Vehiculoes.Remove(_vehiculo);
                    dbVentaVehiculos.SaveChanges();
                    return "El Vehiculo con placas " + vehiculo.Placa + " se ha eliminado exitosamente";
                }
                else
                {
                    return "El Vehiculo que intenta eliminar no existe";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Method IQuearyable
        public IQueryable LlenarTablaVehiculo()
        {
            return from V in dbVentaVehiculos.Set<Vehiculo>()
                       join EV in dbVentaVehiculos.Set<EstadoVehiculo>()
                       on V.CodEstadoVehiculo equals EV.Codigo
                       join TV in dbVentaVehiculos.Set<TipoVehiculo>()
                       on V.CodTipoVehiculo equals TV.Codigo
                   orderby TV.Tipo, V.Marca
                   select new
                   {
                       Tipo = TV.Tipo,
                       Placa = V.Placa,
                       Marca = V.Marca,
                       Modelo = V.Modelo,
                       Precio = V.Precio,
                       Kilometraje = V.Kilometraje,
                       Estado = EV.Estado,
                   };
        }

        public IQueryable VehiculoCombo()
        {
            return dbVentaVehiculos.Vehiculoes
                .OrderBy(t => t.Placa)
                .Select(t => new
                {
                    Id = t.Id,
                    Nombre = t.Placa
                });
        }

        public IQueryable VehiculoxTipo(int TipoVehiculo)
        {
            return from V in dbVentaVehiculos.Set<Vehiculo>()
                   join TV in dbVentaVehiculos.Set<TipoVehiculo>() on V.CodTipoVehiculo equals TV.Codigo
                   where TV.Codigo == TipoVehiculo
                   orderby TV.Tipo, V.Placa
                   select new //Finalmente, se presentan los campos que se van a mostrar
                   {
                       Codigo = V.Id + "|" + V.Precio,
                       Nombre = V.Placa
                   };
        }
    }
}