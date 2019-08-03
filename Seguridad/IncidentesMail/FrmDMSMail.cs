using IncidentesBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IncidentesMail
{
    public partial class FrmDMSMail : Form
    {
        SOP_SopBL _SOP_SopBL = new SOP_SopBL();
        MailBL _MailBL = new MailBL();
        DataTable _resultado;
        public FrmDMSMail()
        {
            InitializeComponent();
        }

        private void FrmDMSMail_Load(object sender, EventArgs e)
        {
            _resultado = _SOP_SopBL.ListarSOP_SopDuenoCaducado();
            int TotalRegistros = _resultado.Rows.Count;
            bool vexito;
            for (int i = 0; i < 1; i++)
            {
                vexito = enviarEmail(_resultado.Rows[i]["FUNCIONARIO_NOME"].ToString(), _resultado.Rows[i]["FUNCIONARIO_EMAIL"].ToString(), _resultado.Rows[i]["AREA_ID"].ToString(), _resultado.Rows[i]["AREA_NOME"].ToString(), _resultado.Rows[i]["CODIGO_SOP"].ToString()
                    , _resultado.Rows[i]["PROCEDIMIENTO_SOP"].ToString(), _resultado.Rows[i]["FECHA_CADU_SOP"].ToString(), Convert.ToString(_resultado.Rows[i]["CADUCA"]));

            }
            Application.Exit();
        }
        private bool enviarEmail(string _dueno, string _mailDueno, string _areaID, string _area, string _codigoSop, string _procedimientoSop, string _fechaCadu, string _caduca)
        {

            string _BodyHTML = _MailBL.doBodySOP(_areaID, _area, _codigoSop, _procedimientoSop, _fechaCadu, _caduca);
            return _MailBL.sndMailHeader(_mailDueno, _BodyHTML, "SOP caducado Codigo: " + _codigoSop);
        }
    }
}
