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
    public partial class registrarCausaInmediata : System.Web.UI.Page
    {
        TB_CausaInmediataBL _TB_CausaInmediataBL = new TB_CausaInmediataBL();
        TB_CausaInmediataBE _TB_CausaInmediataBE = new TB_CausaInmediataBE();
        List<TB_CausaInmediataBE> lTTB_CausaInmediataBE;

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
        private void GenerarTabla(Int16 _CategoriaTB_CausaInmediata_id)
        {

            lTTB_CausaInmediataBE = _TB_CausaInmediataBL.ListarTB_CausaInmediataO_Act();
            rpEmpleado.DataSource = lTTB_CausaInmediataBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _CausaInmediata_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_CausaInmediataBE;
            //_miempl.Emp_id = "";
            _miObj.Causainmediata_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Causainmediata_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_CausaInmediataBL.ActualizarTB_CausaInmediata(_TB_CausaInmediataBE);
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
            Int16 _CausaInmediata_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_CausaInmediataBL.EliminarTB_CausaInmediata(_CausaInmediata_id);
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
                var _miObj = _TB_CausaInmediataBE;
                //_miempl.Emp_id = "";
                _miObj.Causainmediata_desc = txtCausaInmediata.Text;
                int vexito = _TB_CausaInmediataBL.InsertarTB_CausaInmediata(_TB_CausaInmediataBE);
                if (vexito != 0)
                {
                    GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
                    txtCausaInmediata.Text = "";
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