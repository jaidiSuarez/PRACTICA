using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class LiquidacionRepository
    {
        private readonly SqlConnection conexion;
        public LiquidacionRepository (ConnectionManager connectionManager)
        {
            conexion = connectionManager.conexion;
        }

        public void GuardarBD(Liquidacion liquidacion)
        {
            using (var command = conexion.CreateCommand())
            {
                command.CommandText = @"Insert Into Liquidacion (CodigoProyecto, CodigoCargo, Identificacion, Nombre, HorasTrabajadas, ValorPagar) Values" +
                                         "(@CodigoProyecto, @CodigoCargo, @Identificacion, @Nombre, @HorasTrabajadas, @ValorPagar)";
                command.Parameters.Add("@CodigoProyecto", SqlDbType.VarChar).Value = liquidacion.CodigoProyecto;
                command.Parameters.Add("@CodigoCargo", SqlDbType.VarChar).Value = liquidacion.CodigoCargo;
                command.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = liquidacion.Identificacion;
                command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = liquidacion.Nombre;
                command.Parameters.Add("@HorasTrabajadas", SqlDbType.BigInt).Value = liquidacion.HorasTrabajadas;
                command.Parameters.Add("@ValorPagar", SqlDbType.BigInt).Value = liquidacion.ValorPagar;
                command.ExecuteNonQuery();
            }
        }

        public List<Liquidacion> ConsultarTabla()
        {
            List<Liquidacion> liquidaciones = new List<Liquidacion>();

            using (var command = conexion.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM  Liquidacion";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Liquidacion liquidacion = DataReaderMap(dataReader);
                        liquidaciones.Add(liquidacion);
                    }
                }
            }
            return liquidaciones;
        }

        public Liquidacion DataReaderMap(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Liquidacion liquidacion = new Liquidacion()
            {
                CodigoProyecto = (string)dataReader["CodigoProyecto"],
                CodigoCargo = (string)dataReader["CodigoCargo"],
                Identificacion = (string)dataReader["Identificacion"],
                Nombre = (string)dataReader["Nombre"],
                HorasTrabajadas = (Int64)dataReader["HorasTrabajadas"],
                ValorPagar = (Int64)dataReader["ValorPagar"]
            };
            return liquidacion;
        }

        public List<Liquidacion> ConsultarArchivo(string ruta)
        {
            List<Liquidacion> servicos = new List<Liquidacion>();
            FileStream file = new FileStream(ruta, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string linea;

            while ((linea = reader.ReadLine()) != null)
            {
                servicos.Add(Mapear(linea));
            }
            file.Close();
            reader.Close();
            return servicos;
        }

        public Liquidacion Mapear(string linea)
        {
            string[] datos = linea.Split(';');
            Liquidacion liquidacion = new Liquidacion()
            {
                CodigoProyecto = datos[0],
                CodigoCargo = datos[1],
                Identificacion = datos[2],
                Nombre = datos[3],
                HorasTrabajadas = Int64.Parse(datos[4]),
                ValorPagar = Int64.Parse(datos[5])
            };
            return liquidacion;
        }

        public bool ValidarCodigoProyecto(string ruta, string codigoProyecto)
        {
            foreach (var item in ConsultarArchivo(ruta))
            {
                if (!item.CodigoProyecto.Equals(codigoProyecto))
                {
                    return false;
                }
            }
            return true;
        }

        public void Validar(CargoRepository cargoRepository, string  ruta)
        {
            foreach (var item in ConsultarArchivo(ruta))
            {
                if (cargoRepository.BuscarValorHora(item.CodigoCargo) != 0)
                {
                    double valorHoraCargo = cargoRepository.BuscarValorHora(item.CodigoCargo);
                    double valorHoraRegistro = item.ValorPagar / item.HorasTrabajadas;
                    if (valorHoraCargo == valorHoraRegistro)
                    {
                        GuardarBD(item);
                    }
                }
                else
                {
                    Cargo cargo = new Cargo()
                    {
                        Codigo = item.CodigoCargo,
                        Nombre = "Nuevo Cargo",
                        ValorHora = item.ValorPagar / item.HorasTrabajadas
                    };
                    cargoRepository.GuardarBD(cargo);
                    GuardarBD(item);
                }      
            }
        }
       

    }
}
