using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Liquidacion
    {
        public string CodigoProyecto { get; set; }
        public string CodigoCargo { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public Int64 HorasTrabajadas { get; set; }
        public Int64 ValorPagar { get; set; }

        public List<string> LeerDatos()
        {
            List<string> datos = new List<string>();
            datos.Add(CodigoProyecto);
            datos.Add(CodigoCargo);
            datos.Add(Identificacion);
            datos.Add(Nombre);
            datos.Add(HorasTrabajadas.ToString());
            datos.Add(ValorPagar.ToString());
            return datos;
        }
    }
}
