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
    public partial class FrmReporteCarta : Form
    {
        public FrmReporteCarta()
        {
            InitializeComponent();
        }
        public string _Anio;
        public string _Funcionario;
        public string _Lider;
        private void FrmReporteCarta_Load(object sender, EventArgs e)
        {
            try
            { 
            rptCartaPremio rptObj = new rptCartaPremio();
            rptObj.SetParameterValue("@Anio", _Anio);
            rptObj.SetParameterValue("@FUNCIONARIO_NOME", _Funcionario);
            rptObj.SetParameterValue("@lider_id", _Lider);
            crystalReportViewer1.ReportSource = rptObj;
                }
            catch(Exception x)
            {
                MessageBox.Show("Error" + x.Message);
            }
        }
    }
}
