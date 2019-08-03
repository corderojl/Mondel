using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Comportamiento
{
    public partial class registrarSubCategorias : System.Web.UI.Page
    {
        COM_SubCategoriasBL _COM_SubCategoriasBL = new COM_SubCategoriasBL();
        COM_SubCategoriasBE _COM_SubCategoriasBE = new COM_SubCategoriasBE();
        TB_SectorBL _TB_SectorBL = new TB_SectorBL();
        List<COM_SubCategoriasBE> lTCOM_SubCategoriasBE;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                lblMensaje.Text = "";
            }
            else
            {
                llenarComboSector();
                short _Categoria_id = short.Parse(ddlSector.SelectedValue);
                GenerarTabla(_Categoria_id);
                lblMensaje.Text = "";
            }
        }

        private void llenarComboSector()
        {
            ddlSector.DataSource = _TB_SectorBL.ListarTB_SectorO_Act();
            ddlSector.DataValueField = "Sector_id";
            ddlSector.DataTextField = "Sector_desc";
            ddlSector.DataBind();
            ddlSector.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void GenerarTabla(Int16 _Categoria_id)
        {

            lTCOM_SubCategoriasBE = _COM_SubCategoriasBL.ListarCOM_SubCategoriasBySector(_Categoria_id);
            rpEmpleado.DataSource = lTCOM_SubCategoriasBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _SubCategoria_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _COM_SubCategoriasBE;
            //_miempl.Emp_id = "";
            _miObj.SubCategoria_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.SubCategoria_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            short _idSector = short.Parse(ddlSector.SelectedValue);
            bool obeRespuesta = _COM_SubCategoriasBL.ActualizarCOM_SubCategoria(_COM_SubCategoriasBE);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }

            GenerarTabla(_idSector);
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _SubCategoria_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _COM_SubCategoriasBL.EliminarCOM_SubCategoria(_SubCategoria_id);
            short _idSector = short.Parse(ddlSector.SelectedValue);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla(_idSector);
        }

        protected void ibnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            string msj1, msj2;
            msj1 = subirArchivo1();
            msj2 = subirArchivo2();
            switch (msj1)
            {
                case "":
                    guardarSubCategoria(msj1);
                    break;
                case "Error":
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al subir archivo')", true);
                    break;
                case "Formato":
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tipo de archivo no valido')", true);
                    break;
                default:
                    guardarSubCategoria(msj1);
                    break;
            }
           
        }
        private string subirArchivo1()
        {
            Boolean fileOK = false;
            String path = Server.MapPath("fotos/");
            string mensaje;
            try
            {
                if (fulPositivo.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(fulPositivo.FileName).ToLower();
                    String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
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
                            fulPositivo.PostedFile.SaveAs(path
                                + fulPositivo.FileName);
                            return mensaje = fulPositivo.FileName;

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
            catch (Exception ex)
            {
                return mensaje = "Error";
            }
        }
        private string subirArchivo2()
        {
            Boolean fileOK = false;
            String path = Server.MapPath("fotos/");
            string mensaje;
            try
            {
                if (fulNegativo.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(fulNegativo.FileName).ToLower();
                    String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
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
                            fulNegativo.PostedFile.SaveAs(path
                                + fulNegativo.FileName);
                            return mensaje = fulNegativo.FileName;

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
            catch (Exception ex)
            {
                return mensaje = "Error";
            }
        }
        private void guardarSubCategoria(string msj)
        {
            try
            {
                var _miObj = _COM_SubCategoriasBE;
                short _idSector = short.Parse(ddlSector.SelectedValue);
                _miObj.SubCategoria_desc = txtSubCategoria.Text;
                _miObj.AreaLabor_id = _idSector;
                _miObj.FSeguro = fulPositivo.FileName;
                _miObj.FInseguro = fulNegativo.FileName;
                _miObj.SubCategoria_codigo = (((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id).ToString();

                int vexito = _COM_SubCategoriasBL.InsertarCOM_SubCategoria(_COM_SubCategoriasBE);
                if (vexito != 0)
                {
                    GenerarTabla(_idSector);
                    txtSubCategoria.Text = "";
                }
                else
                {
                    lblMensaje.Text = "error, no se pudo registrar la Categoria";
                }


            }
            catch (Exception ex)
            {
                lblMensaje.Text = "error, no se pudo registrar la Categoria" + ex.Message;
            }
        }

        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            short _idSector = short.Parse(ddlSector.SelectedValue);
            GenerarTabla(_idSector);
        }
    }
}