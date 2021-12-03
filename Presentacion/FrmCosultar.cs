using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Presentacion
{
    public partial class FrmCosultar : Form
    {
        public FrmCosultar()
        {
            InitializeComponent();
            CargarConsulta();
        }

        private void CargarConsulta()
        {
            LiquidacionService service = new LiquidacionService(ConfigConnection.connectionString);
            LiquidacionConsultaResponse response = service.ConsultarTabla();

            if (response.Error)
            {
                MessageBox.Show(response.Mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (var item in response.Liquidaciones)
                {
                    List<string> filaDatos = item.LeerDatos();
                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(DtgDatos);
                    int i = 0;
                    foreach (var x in filaDatos)
                    {
                        fila.Cells[i].Value = x.ToString();
                        i++;
                    }
                    DtgDatos.Rows.Add(fila);
                }
            }

        }
    }
}
