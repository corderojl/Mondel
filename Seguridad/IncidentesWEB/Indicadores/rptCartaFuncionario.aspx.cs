using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Indicadores
{
    public partial class rptCartaFuncionario : System.Web.UI.Page
    {
        string _Lider_id;
        string _Anio, _Departamento; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                _Lider_id = (Request.QueryString["Lider_id"]).ToString();
                _Anio = (Request.QueryString["Anio"]).ToString();
                _Departamento = (Request.QueryString["Departamento"]).ToString();
            }
            else
            {
                _Lider_id = (Request.QueryString["Lider_id"]).ToString();
                _Anio = (Request.QueryString["Anio"]).ToString();
                _Departamento = (Request.QueryString["Departamento"]).ToString();
                mostrarReporte(_Anio,  _Lider_id, _Departamento);
            }


        }

        private void mostrarReporte(string _Anio, string _Lider_id, string _Departamento)
        {
            ReportViewer1.Reset();

            DataTable dt = GetData(_Anio,_Lider_id, _Departamento);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Indicadores\\Reportes\\rptCartaFuncionario.rdlc";

            //ReportParameter[] rptParam = new ReportParameter[] {
            //   new ReportParameter("Evaluacion_id", _Evaluacion_id.ToString()) 
            // };
            ReportViewer1.LocalReport.Refresh();

        }
        private DataTable GetData(string _Anio, string _Lider_id, string _Departamento)
        {
            DataTable dt = new DataTable();
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["DB_IndicadoresConnectionString"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarEVA_EvaluacionByCarta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Anio", SqlDbType.VarChar, 7).Value = _Anio;                
                cmd.Parameters.Add("@lider_id", SqlDbType.VarChar, 5).Value = _Lider_id;
                cmd.Parameters.Add("@Departamento_id", SqlDbType.VarChar, 10).Value = _Departamento;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            return dt;
        }
    }
}