using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Logica;

namespace Presentacion
{
    public partial class FrmCargar : Form
    {
        public FrmCargar()
        {
            InitializeComponent();
            CargarCmbProyectos();
        }

        private void BttCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == DialogResult.OK && openFile.FileName != null)
            {
                LiquidacionService service = new LiquidacionService(ConfigConnection.connectionString);
                string file = openFile.FileName;

                LiquidacionConsultaResponse response = service.ConsultarArchivo(file, CmbProyectos.Text);
                if (response.Error)
                {
                    MessageBox.Show(response.Mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }             
            }
        }

        private void CargarCmbProyectos()
        {
            ProyectoService proyectoService = new ProyectoService(ConfigConnection.connectionString);
            ProyectoConsultaResponse response = proyectoService.Consultar();

            if (response.Error)
            {
                MessageBox.Show(response.Mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (var item in response.Proyectos)
                {
                    CmbProyectos.Items.Add(item.Nombre);
                }
            }

        }

        private void CmbProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
