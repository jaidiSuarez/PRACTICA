using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class ProyectoRepository
    {
        private readonly SqlConnection conexion;
        public ProyectoRepository (ConnectionManager connectionManager)
        {
            conexion = connectionManager.conexion;
        }

        public List<Proyecto> Consultar()
        {
            List<Proyecto> proyectos = new List<Proyecto>();

            using (var command = conexion.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Proyecto ";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Proyecto proyecto = DataReaderMap(dataReader);
                        proyectos.Add(proyecto);
                    }
                }
            }
            return proyectos;
        }

        public Proyecto DataReaderMap(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Proyecto proyecto = new Proyecto()
            {
                Codigo = (string)dataReader["Codigo"],
                Nombre = (string)dataReader["Nombre"]
            };
            return proyecto;
        }

        public string BuscarCodigo(string nombre)
        {
            foreach (var item in Consultar())
            {
                if (item.Nombre.Equals(nombre))
                {
                    return item.Codigo;
                }
            }
            return "";
        }
    }
}
