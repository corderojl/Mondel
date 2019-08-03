using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mime;

namespace IncidentesWEB.Reconocimiento
{
    public partial class Reconocimiento : System.Web.UI.Page
    {
        REC_ReconocimientosBL _REC_ReconocimientosBL = new REC_ReconocimientosBL();
        REC_ReconocimientosBE _REC_ReconocimientosBE = new REC_ReconocimientosBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();

        REC_CategoriasBL _REC_CategoriasBL = new REC_CategoriasBL();
        List<Fnc_FuncionariosBE> lTTB_Fnc_FuncionariosBE;
        List<REC_CategoriasBE> lTREC_CategoriasBE;
        string fecha_actual;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    DateTime Hoy = DateTime.Today;
                    fecha_actual = Hoy.ToString("dd/MM/yyyy");
                    //txtFecha.Text = fecha_actual;

                    lTTB_Fnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
                    lTREC_CategoriasBE = _REC_CategoriasBL.ListarREC_CategoriasO_Act();

                    LlenarComboPremiado();
                    LlenarComboOriginador();
                    LlenarComboLider();
                    LlenarComboCategoria();
                }
                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void LlenarComboLider()
        {
            ddlLider.DataSource = lTTB_Fnc_FuncionariosBE;
            ddlLider.DataValueField = "Funcionario_id";
            ddlLider.DataTextField = "Funcionario_Nome";
            //ddlEmpleado.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id.ToString();
            ddlLider.DataBind();
            ddlLider.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboPremiado()
        {
            ddlEmpleado.DataSource = lTTB_Fnc_FuncionariosBE;
            ddlEmpleado.DataValueField = "Funcionario_id";
            ddlEmpleado.DataTextField = "Funcionario_Nome";
            //ddlEmpleado.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id.ToString();
            ddlEmpleado.DataBind();
            ddlEmpleado.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboOriginador()
        {
            ddlOriginador.DataSource = lTTB_Fnc_FuncionariosBE;
            ddlOriginador.DataValueField = "Funcionario_id";
            ddlOriginador.DataTextField = "Funcionario_Nome";
            //ddlOriginador.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id.ToString();
            ddlOriginador.DataBind();
            
        }
        private void LlenarComboCategoria()
        {
            ddlCategoriaPremiacion.DataSource = lTREC_CategoriasBE;
            ddlCategoriaPremiacion.DataValueField = "Categoria_id";
            ddlCategoriaPremiacion.DataTextField = "Categoria_desc";
            //ddlOriginador.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id.ToString();
            ddlCategoriaPremiacion.DataBind();
            ddlCategoriaPremiacion.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            _REC_ReconocimientosBE.EmpleadoReconocido=Convert.ToInt16(ddlEmpleado.SelectedValue);
            _REC_ReconocimientosBL.InsertarREC_Reconocimientos(_REC_ReconocimientosBE);

            try
            {
                var _mietq_etiqueta = _REC_ReconocimientosBE;
                _mietq_etiqueta.EmpleadoReconocido = Convert.ToInt16(ddlEmpleado.SelectedValue);
                _mietq_etiqueta.Originador = Convert.ToInt16(ddlOriginador.SelectedValue);
                _mietq_etiqueta.Categoria_id = Convert.ToInt16(ddlCategoriaPremiacion.SelectedValue);
                _mietq_etiqueta.Motivo = txtMotivo.Text;
                _mietq_etiqueta.Lider = Convert.ToInt16(ddlLider.SelectedValue);
                _mietq_etiqueta.Fecha_Reconocimiento = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);

                int vexito = _REC_ReconocimientosBL.InsertarREC_Reconocimientos(_REC_ReconocimientosBE);
                if (vexito != 0)
                {
                    if (enviarEmailReconocimiento(vexito, _mietq_etiqueta.Originador + "," + _mietq_etiqueta.EmpleadoReconocido + "," + _mietq_etiqueta.Lider, "", "Reconocimiento a " + ddlEmpleado.Text))

                    Response.Redirect("ReporteReconocimiento.aspx?Alerta_id=" + vexito + "&reggistro=exito");
                    //else
                      //  Response.Redirect("ReporteReconocimiento.aspx?Alerta_id=" + vexito + "&reggistro=exito&email=false");
                }
                else
                {
                   // Response.Redirect("error.aspx?error=" + vexito);
                }

            }
            catch (Exception ex)
            {
                // lblMensaje.Text = ex.ToString();
            }
        }

        private bool enviarEmailReconocimiento(int Reconocimiento_id, string strTo, string strHTMLBody, string strSubject)
        {
    

            MailMessage objMail = new MailMessage();
            SmtpClient objsmtp = new SmtpClient();
            bool isSent;

            try
            {
                //string pathImg = HttpContext.Current.Server.MapPath("~/images/cabecera.gif");
                string server = ConfigurationSettings.AppSettings["mailServer"].ToString();
                string mailAccount = ConfigurationSettings.AppSettings["mailAccount"].ToString();
                objMail.From = new MailAddress(mailAccount);
                objsmtp.Host = server;
                objMail.Subject = strSubject;
                if (strTo.Contains("@mdlz.com"))
                    objMail.To.Add(strTo);
                else
                    objMail.To.Add(strTo + "@mdlz.com");
                //objMail.To.Add(strTo);
                //if (this.strCc != string.Empty)
                objMail.CC.Add("urco.jl@mdlz.com");
                //if (this.strBcc != string.Empty)
                //    msgMail.Bcc.Add(this.strBcc);
                LinkedResource img = new LinkedResource(@"D:\SisContratos\app\images\cabecera.jpg", MediaTypeNames.Image.Jpeg);
                AlternateView av1 = AlternateView.CreateAlternateViewFromString(strHTMLBody, null, MediaTypeNames.Text.Html);
                av1.LinkedResources.Add(img);
                img.ContentId = "imagen";
                objMail.AlternateViews.Add(av1);
                objMail.IsBodyHtml = true;
                objMail.Body = strHTMLBody;
                objsmtp.Send(objMail);
                isSent = true;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Response.Write(err);
                isSent = false;
            }
            finally
            {
                objMail.Dispose();
            }

            return (isSent);
        }
    }
}