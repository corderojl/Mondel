using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace IncidentesWEB.Indicadores
{
    public partial class rptEvaluacionColega : System.Web.UI.Page
    {
        int _Evaluacion_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                _Evaluacion_id = Convert.ToInt32(Request.QueryString["Evaluacion_id"]);
            }
            else
            {
                _Evaluacion_id = Convert.ToInt32(Request.QueryString["Evaluacion_id"]);
                mostrarReporte(_Evaluacion_id);
            }
            

        }

        private void mostrarReporte(int _Evaluacion_id)
        {
            ReportViewer1.Reset();

            DataTable dt = GetData(_Evaluacion_id);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Indicadores\\Reportes\\rptEvaColega.rdlc";

            //ReportParameter[] rptParam = new ReportParameter[] {
             //   new ReportParameter("Evaluacion_id", _Evaluacion_id.ToString()) 
           // };
            ReportViewer1.LocalReport.Refresh();

        }
        private DataTable GetData(int _Evaluacion_id)
        {
            DataTable dt = new DataTable();
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["DB_IndicadoresConnectionString"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarEVA_EvaluacionDetalleByEvaluacionReporte1", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Evaluacion_id", SqlDbType.Int).Value = _Evaluacion_id;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            return dt;
        }

    }
}