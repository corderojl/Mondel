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
    public partial class FrmCartaPremio : Form
    {
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        protected DataView dvCar;
        public FrmCartaPremio()
        {
            InitializeComponent();
        }

        private void FrmCartaPremio_Load(object sender, EventArgs e)
        {
            cargarComboLider();
            cmbAnio.SelectedItem = "2017-2";
            ddlLider.SelectedItem = "Todos";
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            try
            {
                EVA_EvaluacionBL _EVA_EvaluacionBL = new EVA_EvaluacionBL();
                string lider = "%%";
                if (Convert.ToInt32(ddlLider.SelectedValue) != 0)
                    lider = ddlLider.SelectedValue.ToString();

                dgvCarta.DataSource = _EVA_EvaluacionBL.ListarEVA_EvaluacionByCarta(txtColaborador.Text, lider, cmbAnio.SelectedItem.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cargarComboLider()
        {
           // dvCar = new DataView(_Fnc_FuncionariosBL.ListarFNC_FuncionariosLideres_Act());
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFNC_FuncionariosLideresO_Act();
            lTFnc_FuncionariosBE.Add(new Fnc_FuncionariosBE() { Funcionario_Id = 0, Funcionario_Nome = "-Todos-" });
            ddlLider.DataSource = lTFnc_FuncionariosBE;
            ddlLider.DisplayMember = "Funcionario_Nome";
            ddlLider.ValueMember = "Funcionario_Id";
            ddlLider.SelectedValue = 63;
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            FrmReporteCarta FormCarta = new FrmReporteCarta();
            FormCarta._Anio = cmbAnio.SelectedItem.ToString();
            FormCarta._Funcionario = txtColaborador.Text;
            FormCarta._Lider = ddlLider.SelectedValue.ToString();
            FormCarta.ShowDialog();
            //FormCarta.MdiParent = EvaluacionIndicadoresMDI.ActiveForm;
            //FormCarta.Show();
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void txtColaborador_TextChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void ddlLider_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }
    }
}
