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
    public partial class rptEvaluacionColegaAll : System.Web.UI.Page
    {
        string _Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                _Anio = (Request.QueryString["Anio"]).ToString();
            }
            else
            {
                _Empleado = (Request.QueryString["Empleado"]).ToString();
                _Categoria = (Request.QueryString["Categoria"]).ToString();
                _SubCategoria = (Request.QueryString["SubCategoria"]).ToString();
                _Lider = (Request.QueryString["Lider"]).ToString();
                _Departamento_id = (Request.QueryString["Departamento"]).ToString();
                _Tipo = (Request.QueryString["Tipo"]).ToString();
                _Anio = (Request.QueryString["Anio"]).ToString();
                _Clasificacion = (Request.QueryString["Clasificacion"]).ToString();
                _Estado = (Request.QueryString["Estado"]).ToString();
                _Arealaboral = (Request.QueryString["Arealaboral"]).ToString();
                mostrarReporte(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral);
            }
            

        }

        private void mostrarReporte(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            ReportViewer1.Reset();

            DataTable dt = GetData(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = "Indicadores\\Reportes\\rptReporteColegaAll.rdlc";

            //ReportParameter[] rptParam = new ReportParameter[] {
             //   new ReportParameter("Evaluacion_id", _Evaluacion_id.ToString()) 
           // };
            ReportViewer1.LocalReport.Refresh();

        }
        private DataTable GetData(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            DataTable dt = new DataTable();
            SqlParameter par1;
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["DB_IndicadoresConnectionString"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarEVA_EvaluacionDetalleByEvaluacionReportePrint", cn);
                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@Anio", SqlDbType.VarChar, 6).Value = _Anio;
                par1 = cmd.Parameters.Add(new SqlParameter("@Empleado_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Empleado_id"].Value = _Empleado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _Categoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _SubCategoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 2));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo"].Value = _Tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = _Anio;
                par1 = cmd.Parameters.Add(new SqlParameter("@Clasificacion", SqlDbType.VarChar, 20));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Clasificacion"].Value = _Clasificacion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider"].Value = _Lider;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 2));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Arealabor", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Arealabor"].Value = _Arealaboral;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            return dt;
        }

    }
}