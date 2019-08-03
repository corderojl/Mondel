using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.admin
{
    public partial class TrianguloSeguridad : System.Web.UI.Page
    {
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;

        DateTime Hoy, fecha1;
        string fecha_actual;
        DateTime _Fecha_incidente, _Fecha_incidente1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Hoy = DateTime.Today;
            if (this.IsPostBack)
            {

            }
            else
            {
                Hoy = DateTime.Today;
                fecha1 = new DateTime(Hoy.Year, Hoy.Month, 1);
                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                txtFecha.Text = fecha1.ToString("dd/MM/yyyy");
                txtFecha0.Text = fecha_actual;
                LlenarComboDepartamento();
                _Fecha_incidente = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _Fecha_incidente1 = DateTime.ParseExact(txtFecha0.Text, "dd/MM/yyyy", null);
                GenerarTriangulo(ddlDepartamento.SelectedValue, _Fecha_incidente, _Fecha_incidente1);
                
            }
        }

        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string _Departamento_id, _Responsable, _tipoPlan, _Estado;
            
            _Departamento_id = ddlDepartamento.SelectedValue;
                _Fecha_incidente = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _Fecha_incidente1 = DateTime.ParseExact(txtFecha0.Text, "dd/MM/yyyy", null);
            GenerarTriangulo(_Departamento_id, _Fecha_incidente, _Fecha_incidente1);
        }

        private void GenerarTriangulo(string _Departamento_id, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            COM_ComportamientoBL _COM_ComportamientoBL = new COM_ComportamientoBL();
            DataTable Resultados=_TB_IncidentesBL.ContarIncidentesByClasificacion(_Departamento_id,_Fecha_incidente, _Fecha_incidente1);
            int NumComp = _COM_ComportamientoBL.ContarCOM_Comportamiento(_Departamento_id, _Fecha_incidente, _Fecha_incidente1);
            StringBuilder Tabla = new StringBuilder();
            string colorSup, colorMedio, colorBajo, colorBase;
            int clase1, clase2, clase3;

            clase1 = (Convert.ToInt32(Resultados.Rows[0]["numero"]) + Convert.ToInt32(Resultados.Rows[1]["numero"]) + Convert.ToInt32(Resultados.Rows[2]["numero"]));
            clase2= Convert.ToInt32(Resultados.Rows[3]["numero"]);
            clase3=Convert.ToInt32(Resultados.Rows[4]["numero"]);



            if (clase1 > 0)
            {
                colorMedio = "red";
                colorBajo = "red";
                colorBase = "red";
            }
            if (clase2 > 0)
            {
                colorMedio = "red";
                colorBajo = "red";
                colorBase = "red";
            }
            if (clase3 > 0)
            {
                colorSup = "red";
                colorMedio = "red";
                colorBajo = "red";
                colorBase = "red";
            }

            colorSup = "#f0ad4e";
            colorMedio = "#428bca";
            colorBajo = "#91c11b";
            colorBase = "#de4514";



            Tabla.AppendLine("<div class=\"triangulo_sup\" style=\"border-bottom: 100px solid " + colorSup + ";\">");
            Tabla.AppendLine(" Clase III:" + clase3 + "</div>");
            Tabla.AppendLine("<div class=\"trapecio-medio\" style=\"border-bottom: 100px solid " + colorMedio + ";\">Clase II:" + clase2 + "</div>");
            Tabla.AppendLine("<div class=\"trapecio-bajo\" style=\"border-bottom: 100px solid " + colorBajo + ";\">Clase I:" + clase1 + "</div>");
            Tabla.AppendLine("<div class=\"trapecio-base\" style=\"border-bottom: 100px solid " + colorBase + ";\">Comportamientos:" + NumComp.ToString() + "</div>");
            Tabla.AppendLine("</table>");
            Tabla.AppendLine("</table>");

            ltlTriangulo.Text = Tabla.ToString();

        }
    }
}