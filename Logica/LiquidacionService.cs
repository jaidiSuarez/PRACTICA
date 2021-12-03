using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Logica
{
    public class LiquidacionService
    {
        private readonly ConnectionManager conexion;
        private readonly ProyectoRepository proyectoRepository;
        private readonly LiquidacionRepository repository;
        private readonly CargoRepository cargoRepository;

        public LiquidacionService (string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repository = new LiquidacionRepository(conexion);
            proyectoRepository = new ProyectoRepository(conexion);
            cargoRepository = new CargoRepository(conexion);

        }

        public LiquidacionConsultaResponse ConsultarArchivo(string ruta, string nombreProyecto )
        {
            try
            {
                conexion.Open();
                if (repository.ValidarCodigoProyecto(ruta, proyectoRepository.BuscarCodigo(nombreProyecto)))
                {
                    repository.Validar(cargoRepository, ruta);
                    return new LiquidacionConsultaResponse(repository.ConsultarArchivo(ruta)) ;
                }
                else
                {
                    return new LiquidacionConsultaResponse("El Código de proyecto encontrada en el archivo que se reporta no coincide con el seleccionado en el combo");
                }

            }
            catch (Exception e)
            {
                return new LiquidacionConsultaResponse("Se presento el siguiente Error " + e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public LiquidacionConsultaResponse ConsultarTabla()
        {
            try
            {
                conexion.Open();
                return new LiquidacionConsultaResponse(repository.ConsultarTabla());
            }
            catch (Exception e)
            {
                return new LiquidacionConsultaResponse("Se presento el siguiente Error " + e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }


    }

    public class LiquidacionConsultaResponse
    {
        public List<Liquidacion> Liquidaciones { get; set; }
        public String Mensaje { get; set; }
        public bool Error { get; set; }

        public LiquidacionConsultaResponse (List<Liquidacion> liquidaciones)
        {
            Liquidaciones = liquidaciones;
            Error = false;
        }
        public LiquidacionConsultaResponse (string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
