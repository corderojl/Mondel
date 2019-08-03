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
namespace IncidentesWEB.Comportamiento
{
    public partial class prueba : System.Web.UI.Page
    {
        string fecha_actual;
        protected DataView dvLocaliza;
        protected DataView dvComponentes;
        protected DataView dvTipos;
        protected DataView dvEncontrado;
        protected DataView dvResuelto;
        protected DataView dvCategoria;
        protected DataView dvDispositivos;
        protected DataView dvPartes;
        protected DataView dvGrupos;
        //datatable
        protected DataTable dtFuncionario;
        protected DataTable dtComponente;
        protected DataTable dtPartes;
        protected DataTable dtDueno;

        COM_ComportamientoBE _COM_ComportamientoBE = new COM_ComportamientoBE();

        COM_ComportamientoBL _COM_ComportamientoBL = new COM_ComportamientoBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        COM_FormatosBL _COM_FormatosBL = new COM_FormatosBL();
        COM_CategoriasBL _COM_CategoriasBL = new COM_CategoriasBL();
        COM_SubCategoriasBL _COM_SubCategoriasBL = new COM_SubCategoriasBL();


        protected DataView dvEstatusOperacional;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<Fnc_FuncionariosBE> lTTB_Fnc_FuncionariosBE;
        List<COM_FormatosBE> lTCOM_FormatosBE;
        List<COM_CategoriasBE> lTCOM_CategoriasBE;
        List<COM_SubCategoriasBE> lTCOM_SubCategoriasBE;
        private List<TB_GuardiaBE> lbeFiltro;
        private List<COM_CategoriasBE> lbeFiltroCa;
        private List<COM_SubCategoriasBE> lbeFiltroSu;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsPostBack)
                {

                }
                else
                {

                    //Session["FUNCIONARIO_ID"] = "71046";
                    DateTime Hoy = DateTime.Today;
                    fecha_actual = Hoy.ToString("dd/MM/yyyy");
                    txtFecha.Text = fecha_actual;


                    lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                    lTCOM_CategoriasBE = _COM_CategoriasBL.ListarCOM_CategoriasO_Act();
                    lTCOM_SubCategoriasBE = _COM_SubCategoriasBL.ListarCOM_SubCategoriasO_Act();

                    LlenarComboDepartamento();
                    LlenarComboAuditor();
                    Session["Guardias"] = lTTB_GuardiaBE;
                    LlenarComboGuardia();


                    Session["Categoria"] = lTCOM_CategoriasBE;
                    Session["SubCategoria"] = lTCOM_SubCategoriasBE;
                    LlenarComboFormato();
                    ddlCategoria.Visible = false;
                    //LlenarComboCategoria();
                    //LlenarComboSubCategoria();

                }
                GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }

        private void GenerarTabla(Int16 _Originador)
        {
            DataTable Resultados = _COM_ComportamientoBL.BuscarCOM_ComportamientoByOriginador(_Originador);
            rpComportamiento.DataSource = Resultados;
            rpComportamiento.DataBind();
            //StringBuilder Tabla = new StringBuilder();
            //Tabla.AppendLine("<table class='CSSTableGenerator'>");
            //Tabla.AppendLine("<tr>");
            //Tabla.AppendLine("<td width='60px'>Id</td>");
            //Tabla.AppendLine("<td width='100px'>Sistema</td>");
            //Tabla.AppendLine("<td width='200px'>Categoria</td>");
            //Tabla.AppendLine("<td width='100px'>Valor</td>");
            //Tabla.AppendLine("<td width='200px'>Descripción</td>");
            //Tabla.AppendLine("<td width='100px'>Emp.</td>");
            //Tabla.AppendLine("<td width='100px'></td>");
            //Tabla.AppendLine("</tr>");

            //int TotalRegistros = Resultados.Rows.Count;
            //for (int i = 0; i < TotalRegistros; i++)
            //{
            //    Tabla.AppendLine("<tr>");
            //    //Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('ActualizarPlanAccion.aspx?PlanAccion_id=" + _PlanAccion_id + "&Incidente_id=" + _Incidente_id + "&Titulo=" + _Titulo + "',20,20,800,400); return false;\"> Editar </a></td>");
            //    Tabla.Append("<td>" + Resultados.Rows[i]["Comportamiento_id"].ToString() + "</td>");
            //    Tabla.Append("<td>" + Resultados.Rows[i]["Formato_desc"].ToString() + "</td>");
            //    Tabla.Append("<td>" + Resultados.Rows[i]["SubCategoria_desc"].ToString() + "</td>");
            //    Tabla.Append("<td>" + Resultados.Rows[i]["Valor"].ToString() + "</td>");
            //    Tabla.Append("<td>" + Resultados.Rows[i]["Descripcion"].ToString() + "</td>");
            //    Tabla.Append("<td>" + Resultados.Rows[i]["Tipo_EMP"].ToString() + "</td>");
            //    Tabla.Append("<td><asp:ImageButton ID='ibnEliminar' ImageUrl='Images/btnEliminar.png' Width='30' Height='30' ToolTip='Eliminar Empleado' OnClick='ibnEliminar_Click' runat='server'/></td>");
            //    //Tabla.Append("<td> <a href='RegistrarComportamiento.aspx?Comportamiento_id=" + Resultados.Rows[i]["Comportamiento_id"].ToString() + "'><img src='Images/btnEliminar.png'></a></td>");

            //    //Tabla.Append("<td>" + Resultados.Rows[i]["fecha"] + "</td>");
            //    Tabla.Append(Environment.NewLine);
            //    Tabla.AppendLine("</tr>");
            //}
            ////lblTitulo.Text = "Comentarios: " + Resultados.Rows[0]["Titulo"];
            //ltlTabla.Text = Tabla.ToString();
        }
        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }
        private bool buscarCategorias(COM_CategoriasBE obeCategoria)
        {
            bool exitoIdCategoria = true;
            if (!ddlFormato.SelectedValue.Equals("0")) exitoIdCategoria = (obeCategoria.Formato_id.ToString().Equals(ddlFormato.SelectedValue));
            return (exitoIdCategoria);
        }
        private bool buscarSubCategorias(COM_SubCategoriasBE obeSubCategoria)
        {
            bool exitoIdSubCategoria = true;
            if (!ddlCategoria.SelectedValue.Equals("0")) exitoIdSubCategoria = (obeSubCategoria.AreaLabor_id.ToString().Equals(ddlCategoria.SelectedValue));
            return (exitoIdSubCategoria);
        }
        private void LlenarComboAuditor()
        {
            lTTB_Fnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlAuditor.DataSource = lTTB_Fnc_FuncionariosBE;
            ddlAuditor.DataValueField = "Funcionario_id";
            ddlAuditor.DataTextField = "Funcionario_Nome";
            ddlAuditor.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id.ToString();
            ddlAuditor.DataBind();

        }
        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboGuardia()
        {
            lTTB_GuardiaBE = (List<TB_GuardiaBE>)Session["Guardias"];
            Predicate<TB_GuardiaBE> pred = new Predicate<TB_GuardiaBE>(buscarGuardias);
            lbeFiltro = lTTB_GuardiaBE.FindAll(pred);
            // Session["Filtro"] = lbeFiltro;

            ddlGuardia.DataSource = lbeFiltro;
            ddlGuardia.DataValueField = "Guardia_id";
            ddlGuardia.DataTextField = "Guardia_desc";
            ddlGuardia.DataBind();
            ddlGuardia.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboFormato()
        {
            lTCOM_FormatosBE = _COM_FormatosBL.ListarCOM_FormatosO_Act();
            ddlFormato.DataSource = lTCOM_FormatosBE;
            ddlFormato.DataValueField = "Formato_id";
            ddlFormato.DataTextField = "Formato_desc";
            ddlFormato.DataBind();
            ddlFormato.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            LlenarComboCategoria();
        }
        private void LlenarComboCategoria()
        {
            lTCOM_CategoriasBE = (List<COM_CategoriasBE>)Session["Categoria"];
            Predicate<COM_CategoriasBE> pred = new Predicate<COM_CategoriasBE>(buscarCategorias);
            lbeFiltroCa = lTCOM_CategoriasBE.FindAll(pred);
            //Session["FiltroCa"] = lbeFiltroCa;

            ddlCategoria.DataSource = lbeFiltroCa;
            ddlCategoria.DataValueField = "Categoria_id";
            ddlCategoria.DataTextField = "Categoria_desc";
            ddlCategoria.DataBind();
            LlenarComboSubCategoria();
        }
        private void LlenarComboSubCategoria()
        {
            lTCOM_SubCategoriasBE = (List<COM_SubCategoriasBE>)Session["SubCategoria"];
            Predicate<COM_SubCategoriasBE> pred = new Predicate<COM_SubCategoriasBE>(buscarSubCategorias);
            lbeFiltroSu = lTCOM_SubCategoriasBE.FindAll(pred);
            Session["FiltroSu"] = lbeFiltroSu;

            ddlSubCategoria.DataSource = lbeFiltroSu;
            ddlSubCategoria.DataValueField = "SubCategoria_id";
            ddlSubCategoria.DataTextField = "SubCategoria_desc";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            if (ddlCategoria.SelectedValue == "1")
                ddlCategoria.Visible = false;
            else
                ddlCategoria.Visible = true;

        }
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
        }

        protected void ddlFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboCategoria();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboSubCategoria();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int status;
                var _mietq_etiqueta = _COM_ComportamientoBE;
                //_miempl.Emp_id = "";
                _mietq_etiqueta.Auditor = Convert.ToInt16(ddlAuditor.SelectedValue);
                _mietq_etiqueta.Fecha_Comportamiento = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _mietq_etiqueta.Guardia = Convert.ToInt16(ddlGuardia.SelectedValue);
                _mietq_etiqueta.Tipo_emp = Convert.ToInt16(ddlTipoEmpleado.SelectedValue);
                _mietq_etiqueta.Sector_id = Convert.ToInt16(ddlFormato.SelectedValue);
                _mietq_etiqueta.SubCategoria_id = Convert.ToInt16(ddlSubCategoria.SelectedValue);
                _mietq_etiqueta.Valor = ddlValor.SelectedValue;
                _mietq_etiqueta.Descripcion = txtDescripcion.Text;
                _mietq_etiqueta.Departamento = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Turno = 1;
                _mietq_etiqueta.Originador = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
                _mietq_etiqueta.Estado = 1;
                int vexito = _COM_ComportamientoBL.InsertarCOM_Comportamiento(_COM_ComportamientoBE);
                if (vexito != 0)
                {
                    ltlTabla.Text = "";
                    GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
                }
                else
                {
                    String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo registrar el comportamiento')";
                    mensaje += Environment.NewLine;
                    this.Page.Response.Write(mensaje);
                }


            }
            catch (Exception ex)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo registrar el comportamiento " + ex.Message + "')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;

            int _Comportamiento_id = int.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _COM_ComportamientoBL.EliminarCOM_Comportamiento(_Comportamiento_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
                String mensaje = "<script language='JavaScript'>window.alert('Registro eliminado')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
        }
    }
}