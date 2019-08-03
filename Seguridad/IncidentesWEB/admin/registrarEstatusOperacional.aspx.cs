using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Alerta
{
    public partial class registrarEstatusOperacional : System.Web.UI.Page
    {
        TB_EstatusOperacionalBL _TB_EstatusOperacionalBL = new TB_EstatusOperacionalBL();
        TB_EstatusOperacionalBE _TB_EstatusOperacionalBE = new TB_EstatusOperacionalBE();
        List<TB_EstatusOperacionalBE> lTTB_EstatusOperacionalBE;

        protected void Page_Load(object sender, EventArgs e)
        {
            Int16 _Categoria_id = Convert.ToInt16(Request.QueryString["Categoria_id"]);
            if (this.IsPostBack)
            {
                lblMensaje.Text = "";
            }
            else
            {
                GenerarTabla(_Categoria_id);
                lblMensaje.Text = "";
            }
        }
        private void GenerarTabla(Int16 _CategoriaTB_EstatusOperacional_id)
        {

            lTTB_EstatusOperacionalBE = _TB_EstatusOperacionalBL.ListarTB_EstatusOperacionalO_Act();
            rpEmpleado.DataSource = lTTB_EstatusOperacionalBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _EstatusOperacional_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_EstatusOperacionalBE;
            //_miempl.Emp_id = "";
            _miObj.EstatusOperacional_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.EstatusOperacional_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_EstatusOperacionalBL.ActualizarTB_EstatusOperacional(_TB_EstatusOperacionalBE);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _EstatusOperacional_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_EstatusOperacionalBL.EliminarTB_EstatusOperacional(_EstatusOperacional_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
        }

        protected void ibnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int status;
                var _miObj = _TB_EstatusOperacionalBE;
                //_miempl.Emp_id = "";
                _miObj.EstatusOperacional_desc = txtEstatusOperacional.Text;
                int vexito = _TB_EstatusOperacionalBL.InsertarTB_EstatusOperacional(_TB_EstatusOperacionalBE);
                if (vexito != 0)
                {
                    GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
                    txtEstatusOperacional.Text = "";
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
    }
}