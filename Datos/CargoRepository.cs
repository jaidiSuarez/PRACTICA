using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class CargoRepository
    {
        private readonly SqlConnection conexion;
        public CargoRepository (ConnectionManager connectionManager)
        {
            conexion = connectionManager.conexion;
        }

        public void GuardarBD(Cargo cargo)
        {
            using (var command = conexion.CreateCommand())
            {
                command.CommandText = @"Insert Into Cargo (Codigo, Nombre, ValorHora) Values" +
                                         "(@Codigo, @Nombre, @ValorHora)";
                command.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = cargo.Codigo;
                command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = cargo.Nombre;
                command.Parameters.Add("@ValorHora", SqlDbType.BigInt).Value = cargo.ValorHora;
                command.ExecuteNonQuery();
            }
        }
        public List<Cargo> Consultar()
        {
            List<Cargo> cargos = new List<Cargo>();

            using (var command = conexion.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Cargo ";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Cargo cargo = DataReaderMap(dataReader);
                        cargos.Add(cargo);
                    }
                }
            }
            return cargos;
        }

        public Cargo DataReaderMap(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Cargo cargo = new Cargo()
            {
                Codigo = (string)dataReader["Codigo"],
                Nombre = (string)dataReader["Nombre"],
                ValorHora = (Int64)dataReader["ValorHora"]
            };
            return cargo;
        }

        public Int64 BuscarValorHora (string codigo)
        {
            foreach (var item in Consultar())
            {
                if (item.Codigo.Equals(codigo))
                {
                    return item.ValorHora;
                }
            }
            return 0;
        }
    }
}
