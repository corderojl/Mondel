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
    public partial class RegistrarComportamiento : System.Web.UI.Page
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

        TB_SectorBL _TB_SectorBL = new TB_SectorBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        COM_FormatosBL _COM_FormatosBL = new COM_FormatosBL();
        COM_CategoriasBL _COM_CategoriasBL = new COM_CategoriasBL();
        COM_SubCategoriasBL _COM_SubCategoriasBL = new COM_SubCategoriasBL();
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();


        protected DataView dvEstatusOperacional;
        List<TB_SectorBE> lTTB_SectorBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<Fnc_FuncionariosBE> lTTB_Fnc_FuncionariosBE;
        List<COM_SubCategoriasBE> lTCOM_SubCategoriasBE;
        private List<TB_AreaBE> lbeFiltroArea;
        private List<TB_DepartamentoBE> lbeFiltroDepartamento;
        private List<COM_SubCategoriasBE> lbeFiltroSu;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (this.IsPostBack)
                {
                    GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
                }
                else
                {

                    //Session["FUNCIONARIO_ID"] = "71046";
                    DateTime Hoy = DateTime.Today;
                    fecha_actual = Hoy.ToString("dd/MM/yyyy");
                    txtFecha.Text = fecha_actual;

                    lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                    Session["Guardias"] = lTTB_GuardiaBE;
                    lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
                    Session["Areas"] = lTTB_AreaBE;
                    lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("3");
                    Session["Departamento"] = lTTB_DepartamentoBE;  
                    lTCOM_SubCategoriasBE = _COM_SubCategoriasBL.ListarCOM_SubCategoriasO_Act();
                    Session["SubCategoria"] = lTCOM_SubCategoriasBE;
                    LlenarComboSector();
                    ddlSector.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Area_Id.ToString();
                    LlenarComboAuditor();
                    LlenarComboArea();
                    //LlenarComboFormato();
                    //Session["Guardias"] = lTTB_GuardiaBE;
                    // LlenarComboGuardia();
                    LlenarComboDepartamento();
                    LlenarComboDepartamento2();
                    LlenarComboSubCategoria();
                    
                    //LlenarComboCategoria();
                    //LlenarComboSubCategoria();
                    GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);


                }

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

        }
        private bool buscarDepartamento(TB_DepartamentoBE obeDepartamento)
        {
            bool exitoIdDepartamento = true;
            if (!ddlSector.SelectedValue.Equals("0")) exitoIdDepartamento = (obeDepartamento.Sector_id.ToString().Equals(ddlSector.SelectedValue));
            return (exitoIdDepartamento);
        }

        private bool buscarArea(TB_AreaBE obeArea)
        {
            bool exitoIdArea = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdArea = (obeArea.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdArea);
        }

        private bool buscarSubCategorias(COM_SubCategoriasBE obeSubCategoria)
        {
            bool exitoIdSubCategoria = true;
            if (!ddlSector.SelectedValue.Equals("0")) exitoIdSubCategoria = (obeSubCategoria.AreaLabor_id.ToString().Equals(ddlSector.SelectedValue));
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
        private void LlenarComboSector()
        {
            lTTB_SectorBE = _TB_SectorBL.ListarTB_SectorO_Act();
            ddlSector.DataSource = lTTB_SectorBE;
            ddlSector.DataValueField = "Sector_id";
            ddlSector.DataTextField = "Sector_desc";
            //ddlSector.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Area_Id.ToString();
            ddlSector.DataBind();
            ddlSector.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboArea()
        {
            lTTB_AreaBE = (List<TB_AreaBE>)Session["Areas"];
            Predicate<TB_AreaBE> pred = new Predicate<TB_AreaBE>(buscarArea);
            lbeFiltroArea = lTTB_AreaBE.FindAll(pred);
            ddlArea.DataSource = lbeFiltroArea;
            ddlArea.DataValueField = "Area_id";
            ddlArea.DataTextField = "Area_desc";            
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = (List<TB_DepartamentoBE>)Session["Departamento"];
            Predicate<TB_DepartamentoBE> pred = new Predicate<TB_DepartamentoBE>(buscarDepartamento);
            lbeFiltroDepartamento = lTTB_DepartamentoBE.FindAll(pred);
            ddlDepartamento.DataSource = lbeFiltroDepartamento;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboDepartamento2()
        {
            TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();

            ddlDepartamento2.DataSource = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento2.DataValueField = "Departamento_id";
            ddlDepartamento2.DataTextField = "Departamento_desc";
            ddlDepartamento2.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Area_Id.ToString();
            ddlDepartamento2.DataBind();
        }
        private void LlenarComboSubCategoria()
        {
            //EVA_SectorBE _EVA_SectorBE = new EVA_SectorBE();
            lTCOM_SubCategoriasBE = (List<COM_SubCategoriasBE>)Session["SubCategoria"];
            Predicate<COM_SubCategoriasBE> pred = new Predicate<COM_SubCategoriasBE>(buscarSubCategorias);
            lbeFiltroSu = lTCOM_SubCategoriasBE.FindAll(pred);
            Session["FiltroSu"] = lbeFiltroSu;

            ddlSubCategoria.DataSource = lbeFiltroSu;
            ddlSubCategoria.DataValueField = "SubCategoria_id";
            ddlSubCategoria.DataTextField = "SubCategoria_desc";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            //_EVA_SectorBE = _TB_SectorBL.ListarTB_SectorO_Act(int.Parse(ddlSector.SelectedValue));
            //if (_COM_CategoriasBE.Grado == 1)
            //    ddlCategoria.Visible = false;
            //else
            //    ddlCategoria.Visible = true;

        }
        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LlenarComboGuardia();
            LlenarComboDepartamento();
            //LlenarComboFormato();
            LlenarComboSubCategoria();
            ltlImagen.Text = "";
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
                _mietq_etiqueta.Guardia = Convert.ToInt16(ddlTurno.SelectedValue);
                _mietq_etiqueta.Tipo_emp = Convert.ToInt16(ddlTipoEmpleado.SelectedValue);
                _mietq_etiqueta.Sector_id = Convert.ToInt16(ddlSector.SelectedValue);
                _mietq_etiqueta.SubCategoria_id = Convert.ToInt16(ddlSubCategoria.SelectedValue);
                _mietq_etiqueta.Valor = ddlValor.SelectedValue;
                _mietq_etiqueta.Descripcion = txtDescripcion.Text;
                _mietq_etiqueta.Departamento = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Area_id = Convert.ToInt16(ddlArea.SelectedValue);
                _mietq_etiqueta.Turno = Convert.ToInt16(ddlTurno.SelectedValue); 
                _mietq_etiqueta.Originador = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
                _mietq_etiqueta.Estado = 1;
                _mietq_etiqueta.Motivo = txtMotivo.Text;
                int vexito = _COM_ComportamientoBL.InsertarCOM_Comportamiento(_COM_ComportamientoBE);
                if (vexito != 0)
                {
                    ltlTabla.Text = "";
                    GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
                    //String mensaje = "<script language='JavaScript'>window.alert('Comportamiento guardado con exito')";
                    //mensaje += Environment.NewLine;
                    //this.Page.Response.Write(mensaje);                    
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
            }
            GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
        }

        protected void ddlSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            COM_SubCategoriasBE _COM_SubCategoriasBE = new COM_SubCategoriasBE();
            short subcat = 0;
            subcat = short.Parse(ddlSubCategoria.SelectedValue);
            if (subcat != 0)
            {
                _COM_SubCategoriasBE = _COM_SubCategoriasBL.TraerCOM_SubCategoriaByID(subcat);
                StringBuilder Tabla = new StringBuilder();
                Tabla.AppendLine("<p class='imglist'>");
                Tabla.AppendLine("<a href='fotos/" + _COM_SubCategoriasBE.FSeguro + "' data-fancybox data-caption='Comportamiento Seguro'><img src='fotos/" + _COM_SubCategoriasBE.FSeguro + "' width='50px'/></a>");
                Tabla.AppendLine("<a href='fotos/" + _COM_SubCategoriasBE.FInseguro + "' data-fancybox data-caption='Comportamiento Inseguro'><img src='fotos/" + _COM_SubCategoriasBE.FInseguro + "' width='50px'/></a>");
                Tabla.AppendLine("</p>");
                ltlImagen.Text = Tabla.ToString();
            }
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboArea();
        }

        protected void ddlValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlValor.SelectedValue == "2")
                txtMotivo.Visible = true;
            else
                txtMotivo.Visible = false;

        }



    }
}