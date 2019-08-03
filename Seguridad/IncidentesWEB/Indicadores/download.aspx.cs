using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Indicadores
{
    public partial class download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
            if(!this.IsPostBack)
            {
                string _Anio = Request.QueryString["_Anio"].ToString();
                string _Superior = Request.QueryString["_Superior"].ToString();
                string _Departamento_id = Request.QueryString["_Departamento_id"].ToString();
                string _Estado = Request.QueryString["_Estado"].ToString();
                DataView dvDefectos = new DataView(_Fnc_FuncionariosBL.ListarEVA_FuncionariosBySuperiorXML(_Anio, _Superior, _Departamento_id, _Estado));
                if (dvDefectos.Table.Rows.Count > 0)
                {
                    try
                    {
                        string filename = "Reporte de Evaluación.xls";
                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                        GridView dgGrid = new GridView();
                        dgGrid.DataSource = dvDefectos;
                        dgGrid.DataBind();
                        dgGrid.RenderControl(hw);
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                        this.EnableViewState = false;
                        Response.Write(tw.ToString());
                        Response.End();
                    }
                    catch (Exception x)
                    {

                    }
                }
            }
        }
    }
}