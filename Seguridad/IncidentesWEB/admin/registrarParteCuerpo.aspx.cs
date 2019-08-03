using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.admin
{
    public partial class registrarParteCuerpo : System.Web.UI.Page
    {
        TB_ParteCuerpoBL _TB_ParteCuerpoBL = new TB_ParteCuerpoBL();
        TB_ParteCuerpoBE _TB_ParteCuerpoBE = new TB_ParteCuerpoBE();
        List<TB_ParteCuerpoBE> lTTB_ParteCuerpoBE;
        TB_TipoDanioBL _TB_TipoDanioBL = new TB_TipoDanioBL();
        List<TB_TipoDanioBE> lTTB_TipoDanioBE;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Text = "";
                ibnGuardar.Visible = false;
                txtParteCuerpo.Visible = false;
                LlenarCamboTipoDanio();
            }
        }

        private void GenerarTabla(Int16 _TipoIncidente_id)
        {
            if (_TipoIncidente_id != 0)
            {
                ibnGuardar.Visible = true;
                txtParteCuerpo.Visible = true;
            }
            else
            {
                ibnGuardar.Visible = false;
                txtParteCuerpo.Visible = false;
            }
            lTTB_ParteCuerpoBE = _TB_ParteCuerpoBL.ListarTB_ParteCuerpoByTipoIncidente(_TipoIncidente_id);
            rpParteCuerpo.DataSource = lTTB_ParteCuerpoBE;
            rpParteCuerpo.DataBind();
        }
        private void LlenarCamboTipoDanio()
        {
            lTTB_TipoDanioBE = _TB_TipoDanioBL.ListarTB_TipoDanioO_Act();
            ddlTipoIncidente.DataSource = lTTB_TipoDanioBE;
            ddlTipoIncidente.DataValueField = "TipoDanio_id";
            ddlTipoIncidente.DataTextField = "TipoDanio_Desc";
            ddlTipoIncidente.SelectedValue = "0";
            ddlTipoIncidente.DataBind();
        }
        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _ParteCuerpo_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_ParteCuerpoBE;
            //_miempl.Emp_id = "";
            _miObj.ParteCuerpo_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.TipoDanio = short.Parse(ddlTipoIncidente.SelectedValue);
            _miObj.ParteCuerpo_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_ParteCuerpoBL.ActualizarTB_ParteCuerpo(_TB_ParteCuerpoBE);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            Int16 _Departamento_id = Int16.Parse(ddlTipoIncidente.SelectedValue);
            GenerarTabla(_Departamento_id);
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _ParteCuerpo_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_ParteCuerpoBL.EliminarTB_ParteCuerpo(_ParteCuerpo_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            Int16 _Departamento_id = Int16.Parse(ddlTipoIncidente.SelectedValue);
            GenerarTabla(_Departamento_id);
        }

        protected void ibnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var _miObj = _TB_ParteCuerpoBE;
                Int16 _Departamento_id = Int16.Parse(ddlTipoIncidente.SelectedValue);
                _miObj.ParteCuerpo_desc = txtParteCuerpo.Text;
                _miObj.TipoDanio = short.Parse(ddlTipoIncidente.SelectedValue);
                _miObj.TipoDanio = _Departamento_id;
                int vexito = _TB_ParteCuerpoBL.InsertarTB_ParteCuerpo(_TB_ParteCuerpoBE);
                if (vexito != 0)
                {
                    GenerarTabla(_Departamento_id);
                    txtParteCuerpo.Text = "";
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

        protected void ddlTipoIncidente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 _TipoIncidente_id = Int16.Parse(ddlTipoIncidente.SelectedValue);
            GenerarTabla(_TipoIncidente_id);
        }
    }
}
