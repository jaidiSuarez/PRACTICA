using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Logica
{
    public class ProyectoService
    {
        private readonly ConnectionManager conexion;
        private readonly ProyectoRepository repository;

        public ProyectoService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repository = new ProyectoRepository(conexion);
        }

        public ProyectoConsultaResponse Consultar()
        {
            try
            {
                conexion.Open();
                return new ProyectoConsultaResponse(repository.Consultar());
            }
            catch (Exception e)
            {
                return new ProyectoConsultaResponse("Se presento el siguiente Error " + e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

    }

    public class ProyectoConsultaResponse
    {
        public List<Proyecto> Proyectos { get; set; }
        public String Mensaje { get; set; }
        public bool Error { get; set; }

        public ProyectoConsultaResponse (List<Proyecto> proyectos)
        {
            Proyectos = proyectos;
            Error = false;
        }
        public ProyectoConsultaResponse (string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
