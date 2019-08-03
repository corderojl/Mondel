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

namespace IncidentesWEB.Novedades
{
    public partial class Default : System.Web.UI.Page
    {
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
        ALR_AlertasBL _ALR_AlertasBL = new ALR_AlertasBL();
        StringBuilder Tabla = new StringBuilder();
        NOV_NovedadesBL _NOV_NovedadesBL = new NOV_NovedadesBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["Fnc_Funcionarios"] == null)
                {
                    Response.Redirect("login_Novedades.aspx");
                }
                _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
                TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id, 6);
                if (_TB_AccesosBE.Permiso != 1)
                {
                    Response.Redirect("login_Novedades.aspx");
                }
                GenerarTabla();     
            }

        }

        private void registrarNovedad(NOV_NovedadesBE _NOV_NovedadesBE)
        {

            try
            {
                string _Foto = "";
                if (_NOV_NovedadesBE.Foto != "")
                {
                    string[] validFileTypes = { "png", "jpg", "jpeg"};
                    string ext = System.IO.Path.GetExtension(FlpArchivo.PostedFile.FileName);
                    bool isValidFile = false;
                    
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isValidFile = true;
                            break;
                        }
                    }
                    if (!isValidFile)
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "Archivo invalido, por favor seleccionar una imagen con extensión jpg, jpeg o png" +
                                       string.Join(",", validFileTypes);
                    }
                    else
                    {
                        _NOV_NovedadesBE.Foto = FlpArchivo.FileName;
                        FlpArchivo.SaveAs(Server.MapPath("~/Novedades/Archivos/") + FlpArchivo.FileName);
                        // lblinformacion.Text = "El archivo " + FlpArchivo.FileName + " ha sido subido correctamente";
                       
                    }

                }
                else
                {
                    _NOV_NovedadesBE.Foto = "";
                }

                int vexito = _NOV_NovedadesBL.InsertarNOV_Novedades(_NOV_NovedadesBE);
                if (vexito != 0)
                {
                    //Response.Redirect("actualizarNovedades.aspx?ID_Novedades=" + vexito);
                    GenerarTabla(); 
                }
                else
                {
                    lblMensaje.Text = "Se produjo un error al guardar los datos, comuniquese con el administrador";
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.ToString();
            }
        }

        private void GenerarTabla()
        {
            List<NOV_NovedadesBE> lTNOV_NovedadesBE;
            lTNOV_NovedadesBE = _NOV_NovedadesBL.ListarNOV_NovedadesO_All();
            rpNovedades.DataSource = lTNOV_NovedadesBE;
            rpNovedades.DataBind();
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string _desc = txtDescripcion.Text;
            if (_desc.Length < 8000)
            {
                NOV_NovedadesBE _NOV_NovedadesBE = new NOV_NovedadesBE();
                _NOV_NovedadesBE.Titulo = txtTitulo.Text;
                _NOV_NovedadesBE.Descripcion = txtDescripcion.Text;
                _NOV_NovedadesBE.Originador = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
                _NOV_NovedadesBE.Foto = FlpArchivo.FileName;
                registrarNovedad(_NOV_NovedadesBE);
            }
            else
            {
                String mensaje = "<script language='JavaScript'>window.alert('El número de caracteres a superado , no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Novedades_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _NOV_NovedadesBL.EliminarNOV_Novedades(_Novedades_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla();
        }
    }
}