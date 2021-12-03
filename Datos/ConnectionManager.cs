using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConnectionManager
    {
        internal SqlConnection conexion;

        public ConnectionManager(string connectionString)
        {
            conexion = new SqlConnection(connectionString);
        }

        public void Open()
        {
            conexion.Open();
        }

        public void Close()
        {
            conexion.Close();
        }
    }
}
