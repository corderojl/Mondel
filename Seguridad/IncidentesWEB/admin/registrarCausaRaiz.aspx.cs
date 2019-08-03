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
    public partial class registrarCausaRaiz : System.Web.UI.Page
    {
        TB_CausaRaizBL _TB_CausaRaizBL = new TB_CausaRaizBL();
        TB_CausaRaizBE _TB_CausaRaizBE = new TB_CausaRaizBE();
        List<TB_CausaRaizBE> lTTB_CausaRaizBE;

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
        private void GenerarTabla(Int16 _CategoriaTB_CausaRaiz_id)
        {

            lTTB_CausaRaizBE = _TB_CausaRaizBL.ListarTB_CausaRaizO_Act();
            rpEmpleado.DataSource = lTTB_CausaRaizBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _CausaRaiz_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_CausaRaizBE;
            //_miempl.Emp_id = "";
            _miObj.CausaRaiz_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.CausaRaiz_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_CausaRaizBL.ActualizarTB_CausaRaiz(_TB_CausaRaizBE);
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
            Int16 _CausaRaiz_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_CausaRaizBL.EliminarTB_CausaRaiz(_CausaRaiz_id);
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
                var _miObj = _TB_CausaRaizBE;
                //_miempl.Emp_id = "";
                _miObj.CausaRaiz_desc = txtCausaRaiz.Text;
                int vexito = _TB_CausaRaizBL.InsertarTB_CausaRaiz(_TB_CausaRaizBE);
                if (vexito != 0)
                {
                    GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
                    txtCausaRaiz.Text = "";
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