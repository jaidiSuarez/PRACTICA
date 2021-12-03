using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void BttCargar_Click(object sender, EventArgs e)
        {
            FrmCargar frmCargar = new FrmCargar();
            frmCargar.Show();
        }

        private void BttConsultar_Click(object sender, EventArgs e)
        {
            FrmCosultar frmCosultar = new FrmCosultar();
            frmCosultar.Show();
        }
    }
}
