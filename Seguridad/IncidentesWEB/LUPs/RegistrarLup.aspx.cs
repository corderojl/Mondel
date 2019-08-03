using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.LUPs
{
    public partial class RegistrarLup : System.Web.UI.Page
    {
        LUP_LupBL _LUP_LupBL = new LUP_LupBL();
        TB_PilarBL _TB_PilarBL = new TB_PilarBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        LUP_CategoriaBL _LUP_CategoriaBL = new LUP_CategoriaBL();
        private List<TB_GuardiaBE> lbeFiltroGuardia;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        private List<LUP_CategoriaBE> lbeFiltroCategoria;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        TB_ResponsableBL _TB_ResponsableBL = null;
        List<LUP_CategoriaBE> lTLUP_CategoriaBE;
        string fecha_actual;


        DateTime Hoy;
        protected void Page_Load(object sender, EventArgs e)
        {
            Hoy = DateTime.Today;
            if (!this.IsPostBack)
            {
                Hoy = DateTime.Today;
                fecha_actual = Hoy.AddYears(1).ToString("dd/MM/yyyy");
                txtFecha.Text = fecha_actual;
                LlenarComboDepartamento();
                lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                Session["Guardias"] = lTTB_GuardiaBE;
                LlenarComboGuardia();
                lTLUP_CategoriaBE = _LUP_CategoriaBL.ListarLUP_CategoriaO_Act();
                Session["Categoria"] = lTLUP_CategoriaBE;
                LlenarComboCategoria();
                LlenarComboPilar();
                LlenarComboOriginador();
            }

        }
        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }
        private void LlenarComboGuardia()
        {
            lTTB_GuardiaBE = (List<TB_GuardiaBE>)Session["Guardias"];
            Predicate<TB_GuardiaBE> pred = new Predicate<TB_GuardiaBE>(buscarGuardias);
            lbeFiltroGuardia = lTTB_GuardiaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltroGuardia;

            ddlGuardia.DataSource = lbeFiltroGuardia;
            ddlGuardia.DataValueField = "Guardia_id";
            ddlGuardia.DataTextField = "Guardia_desc";
            ddlGuardia.DataBind();
            ddlGuardia.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboOriginador()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlDuenio.DataSource = lTFnc_FuncionariosBE;
            ddlDuenio.DataValueField = "Funcionario_id";
            ddlDuenio.DataTextField = "Funcionario_nome";
            ddlDuenio.DataBind();
            ddlDuenio.Items.Insert(0, new ListItem("(Todos)", "0"));
        }

        private void LlenarComboPilar()
        {
            ddlPilar.DataSource = _TB_PilarBL.ListarTB_Pilar_Act();
            ddlPilar.DataValueField = "Pilar_id";
            ddlPilar.DataTextField = "Pilar_desc";
            ddlPilar.DataBind();
            ddlPilar.Items.Insert(0, new ListItem("(Todos)", "0"));
        }

        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("(Todos)", "0"));
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string msj;
            msj = subirArchivo();
            switch (msj)
            {
                case "":
                    guardarLup(msj);
                    break;
                case "Error":
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al subir archivo')", true);
                    break;
                case "Formato":
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tipo de archivo no valido')", true);
                    break;
                default:
                    guardarLup(msj);
                    break;
            }
        }

        private void guardarLup(string msj)
        {
            LUP_LupBE _LUP_LupBE = new LUP_LupBE();
            _LUP_LupBE.Departamento_id = short.Parse(ddlDepartamento.SelectedValue);
            _LUP_LupBE.Guardia_id = short.Parse(ddlGuardia.SelectedValue);
            _LUP_LupBE.Categoria_id = short.Parse(ddlCategoria.SelectedValue);
            _LUP_LupBE.Pilar_id = short.Parse(ddlPilar.SelectedValue);
            _LUP_LupBE.Categoria_id = short.Parse(ddlCategoria.SelectedValue);
            _LUP_LupBE.Encargado = short.Parse(ddlDuenio.SelectedValue);
            _LUP_LupBE.fecha_ven = Convert.ToDateTime(txtFecha.Text);
            _LUP_LupBE.Lup_Titulo = txtTitulo.Text;
            _LUP_LupBE.Lup_desc = txtDescripcion.Text;
            _LUP_LupBE.adjunto_lup = msj;
            _LUP_LupBE.Estado = 1;
            _LUP_LupBE.adjunto_aprob = "";
            _LUP_LupBE.Registrador = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
            int vexito = -1;
            vexito = _LUP_LupBL.InsertarLUP_Lup(_LUP_LupBE);
            if (vexito > 0)
                Response.Redirect("ActualizarLup.aspx?Lup_id=" + vexito + "&reggistro=exito");
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ocurrió un error al registrar')", true);
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
            TraerResponsable(Convert.ToInt16(ddlDepartamento.SelectedValue));
        }
        private void TraerResponsable(Int16 _Departamento_id)
        {
            _TB_ResponsableBL = new TB_ResponsableBL();
            lblResponsable.Text = _TB_ResponsableBL.TraerTB_ResponsableByDepartamento(_Departamento_id).Funcionario_nome;
        }
        private string subirArchivo()
        {
            Boolean fileOK = false;
            String path = Server.MapPath("Archivos/");
            string mensaje;
            try
            { 
            if (fupLup.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(fupLup.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf", ".doc", ".docx", ".docm", ".xls", ".xlsx", ".ppt", ".pptx" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
                if (fileOK)
                {
                    try
                    {
                        fupLup.PostedFile.SaveAs(path
                            + fupLup.FileName);
                        return mensaje = fupLup.FileName;

                    }
                    catch (Exception ex)
                    {
                        return mensaje = "Error";
                    }
                }
                else
                {
                    return mensaje = "Formato";
                }
            }
            else
                return "";
                }
            catch(Exception e)
            {
                return mensaje = "Error";
            }
        }

        protected void ddlPilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboCategoria();
        }

        private void LlenarComboCategoria()
        {
            lTLUP_CategoriaBE = (List<LUP_CategoriaBE>)Session["Categoria"];
            Predicate<LUP_CategoriaBE> pred = new Predicate<LUP_CategoriaBE>(buscarCategorias);
            lbeFiltroCategoria = lTLUP_CategoriaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltroCategoria;

            ddlCategoria.DataSource = lbeFiltroCategoria;
            ddlCategoria.DataValueField = "Categoria_id";
            ddlCategoria.DataTextField = "Categoria_desc";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private bool buscarCategorias(LUP_CategoriaBE obeCategoria)
        {
            bool exitoIdCategoria = true;
            if (!ddlPilar.SelectedValue.Equals("0")) exitoIdCategoria = (obeCategoria.Pilar_id.ToString().Equals(ddlPilar.SelectedValue));
            return (exitoIdCategoria);
        }
    }
}