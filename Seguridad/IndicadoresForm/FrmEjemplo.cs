using IncidentesBE;
using IncidentesBL;
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
    public partial class FrmEjemplo : Form
    {
        public FrmEjemplo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
            DataTable dt = null;
            dt=_Fnc_FuncionariosBL.BuscarFuncionario_Nombre(txtNombre.Text);
            dwvEjemplo.AutoGenerateColumns = false;
            dwvEjemplo.DataSource = dt;

        }
    }
}
