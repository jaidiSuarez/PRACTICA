using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;


namespace Logica
{
    public class CargoService
    {
        private readonly ConnectionManager conexion;
        private readonly CargoRepository repository;

        public CargoService (string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repository = new CargoRepository(conexion);
        }
    }
}
