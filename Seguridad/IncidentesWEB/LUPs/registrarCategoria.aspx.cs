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
    public partial class registrarCategoria : System.Web.UI.Page
    {
        LUP_CategoriaBL _LUP_CategoriaBL = new LUP_CategoriaBL();
        LUP_CategoriaBE _LUP_CategoriaBE = new LUP_CategoriaBE();
        TB_PilarBL _TB_PilarBL = new TB_PilarBL();
        List<LUP_CategoriaBE> lTLUP_CategoriaBE;
        List<TB_PilarBE> lTTB_PilarBE;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                lblMensaje.Text = "";
            }
            else
            {
                LlenarComboPilar();
                lblMensaje.Text = "";
                ibnGuardar.Visible = false;
                txtCategoria.Visible = false;
            }
        }
        private void LlenarComboPilar()
        {
            lTTB_PilarBE = _TB_PilarBL.ListarTB_Pilar_Act();
            ddlPilar.DataSource = lTTB_PilarBE;
            ddlPilar.DataValueField = "Pilar_id";
            ddlPilar.DataTextField = "Pilar_desc";
            ddlPilar.DataBind();
            ddlPilar.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void GenerarTabla(Int16 _Pilar_id)
        {
            if (_Pilar_id != 0)
            {
                ibnGuardar.Visible = true;
                txtCategoria.Visible = true;
            }
            else
            {
                ibnGuardar.Visible = false;
                txtCategoria.Visible = false;
            }
            lTLUP_CategoriaBE = _LUP_CategoriaBL.ListarLUP_CategoriaByPilar(_Pilar_id);
            rpCategoria.DataSource = lTLUP_CategoriaBE;
            rpCategoria.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Categoria_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _LUP_CategoriaBE;
            //_miempl.Emp_id = "";
            _miObj.Categoria_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Pilar_id = short.Parse(ddlPilar.SelectedValue);
            _miObj.Categoria_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _LUP_CategoriaBL.ActualizarLUP_Categoria(_LUP_CategoriaBE);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            Int16 _Pilar_id = Int16.Parse(ddlPilar.SelectedValue);
            GenerarTabla(_Pilar_id);
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Categoria_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _LUP_CategoriaBL.EliminarLUP_Categoria(_Categoria_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            Int16 _Pilar_id = Int16.Parse(ddlPilar.SelectedValue);
            GenerarTabla(_Pilar_id);
        }

        protected void ibnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var _miObj = _LUP_CategoriaBE;
                Int16 _Pilar_id = Int16.Parse(ddlPilar.SelectedValue);
                _miObj.Categoria_desc = txtCategoria.Text;
                _miObj.Pilar_id = _Pilar_id;
                int vexito = _LUP_CategoriaBL.InsertarLUP_Categoria(_LUP_CategoriaBE);
                if (vexito != 0)
                {
                    GenerarTabla(_Pilar_id);
                    txtCategoria.Text = "";
                }
                else
                {
                    lblMensaje.Text = "error, no se pudo registrar contacte con el administrador";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "error,  no se pudo registrar contacte con el administrador" + ex.Message;
            }
        }

        protected void ddlPilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 _Pilar_id = Int16.Parse(ddlPilar.SelectedValue);
            GenerarTabla(_Pilar_id);
        }
    }
}
