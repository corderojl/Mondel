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
    public partial class registrarCondicionInvolucrada : System.Web.UI.Page
    {
        TB_CondicionInvolucradaBL _TB_CondicionInvolucradaBL = new TB_CondicionInvolucradaBL();
        TB_CondicionInvolucradaBE _TB_CondicionInvolucradaBE = new TB_CondicionInvolucradaBE();
        List<TB_CondicionInvolucradaBE> lTTB_CondicionInvolucradaBE;

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
        private void GenerarTabla(Int16 _CategoriaTB_CondicionInvolucrada_id)
        {

            lTTB_CondicionInvolucradaBE = _TB_CondicionInvolucradaBL.ListarTB_CondicionInvolucradaO_Act();
            rpEmpleado.DataSource = lTTB_CondicionInvolucradaBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _CondicionInvolucrada_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_CondicionInvolucradaBE;
            //_miempl.Emp_id = "";
            _miObj.Condicion_inv_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Condicion_inv_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_CondicionInvolucradaBL.ActualizarTB_CondicionInvolucrada(_TB_CondicionInvolucradaBE);
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
            Int16 _CondicionInvolucrada_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_CondicionInvolucradaBL.EliminarTB_CondicionInvolucrada(_CondicionInvolucrada_id);
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
                var _miObj = _TB_CondicionInvolucradaBE;
                //_miempl.Emp_id = "";
                _miObj.Condicion_inv_desc = txtCondicionInvolucrada.Text;
                int vexito = _TB_CondicionInvolucradaBL.InsertarTB_CondicionInvolucrada(_TB_CondicionInvolucradaBE);
                if (vexito != 0)
                {
                    GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
                    txtCondicionInvolucrada.Text = "";
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