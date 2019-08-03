using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.RRHH
{
    public partial class func_grupo : System.Web.UI.Page
    {
        //Fnc_Func_GruposBL _func_gruposBL = new Fnc_Func_GruposBL();

        Fnc_FuncionariosBL _funcioBL = new Fnc_FuncionariosBL();
        string Texto = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            int _func_id = Convert.ToInt32(Request.QueryString["func_id"]);
            int _act = Convert.ToInt32(Request.QueryString["act"]);
            string _texto = Request.QueryString["texto"];
            if (_texto != null)
            {
                if (_act == 1)
                {
                    txtTag.Text = _texto;
                    _funcioBL.DeshabilitarFuncionario(_func_id);
                }
                else
                {
                    txtTag.Text = _texto;
                    _funcioBL.HabilitarFuncionario(_func_id);
                }
                //txtTag.Text = _texto;
                // generarTabla(_texto);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            generarTabla(txtTag.Text);
        }
        private void generarTabla(string text)
        {
            DataTable _dt_func_grupos = new DataTable();
            StringBuilder Tabla = new StringBuilder();

            _dt_func_grupos = _funcioBL.BuscarFuncionario_Nombre(text);
            if (_dt_func_grupos.Rows.Count > 0)
            {
                int TotalRegistros = _dt_func_grupos.Rows.Count;
                Tabla.Append("<table class=\"search_table\">");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("<thead>");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("<th> Legajo </th><th> Apellidos y Nombres </th><th> Grupo </th><th> Estado </th>");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("</thead>");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("<tbody>");
                Tabla.Append(Environment.NewLine);
                for (int i = 0; i < TotalRegistros; i++)
                {
                    int Nro = i + 1;
                    Tabla.Append("<tr>");
                    Tabla.Append(Environment.NewLine);
                    Tabla.Append("<td><a href=\"ActualizarDepartamento.aspx?Guardia_id=" + _dt_func_grupos.Rows[i]["Guardia_id"] + "&area=" + _dt_func_grupos.Rows[i]["Departamento_id"] + "&grupo=" + _dt_func_grupos.Rows[i]["Guardia_id"] + "\">" + _dt_func_grupos.Rows[i]["FUNCIONARIO_DRT"] + "</a></td>");
                    Tabla.Append("<td>" + _dt_func_grupos.Rows[i]["funcionario_nome"] + "</td>");
                    Tabla.Append("<td>" + _dt_func_grupos.Rows[i]["Guardia_desc"] + "</td>");
                    Tabla.Append("<td> <a href=\"func_grupo.aspx?func_id=" + _dt_func_grupos.Rows[i]["funcionario_id"] +
                        "&act=" + _dt_func_grupos.Rows[i]["funcionario_status"] + "&texto=" + txtTag.Text + "\"> <img src=\"../images/status" +
                        _dt_func_grupos.Rows[i]["funcionario_status"] + ".png\" border=\"0\"></a></td>");
                    Tabla.Append(Environment.NewLine);
                    Tabla.Append("</tr>");
                }
                Tabla.Append(Environment.NewLine);
                Tabla.Append("</tbody>");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("</table>");
                ltlResults.Text = Tabla.ToString();
            }
            else
            {
                ltlResults.Text = "No hay resultados para : <em>" + Texto + "</em>";
            }
        }
    }
}