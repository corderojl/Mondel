using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IndicadoresForm
{
    public partial class FrmCargaRapida : Form
    {
        DataTable tabla1;
        Importar _Importar = new Importar();
        public FrmCargaRapida()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            tabla1 = _Importar.traerExcel("Carga");
            dgvExamen.DataSource = tabla1;
        }
    }
}
