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

namespace IncidentesWEB.Comportamiento
{
    public partial class registrarFormato : System.Web.UI.Page
    {
        string fecha_actual;
        protected DataView dvLocaliza;
        protected DataView dvComponentes;
        protected DataView dvTipos;
        protected DataView dvEncontrado;
        protected DataView dvResuelto;
        protected DataView dvCategoria;
        protected DataView dvDispositivos;
        protected DataView dvPartes;
        protected DataView dvGrupos;
        //datatable
        protected DataTable dtFuncionario;
        protected DataTable dtComponente;
        protected DataTable dtPartes;
        protected DataTable dtDueno;

        TB_AreaLaborBL _TB_AreaLaborBL = new TB_AreaLaborBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_SectorBL _TB_SectorBL = new TB_SectorBL();
        COM_CategoriasBL _COM_CategoriasBL = new COM_CategoriasBL();
        COM_CategoriasBE _COM_CategoriasBE = new COM_CategoriasBE();


        protected DataView dvEstatusOperacional;
        List<TB_AreaLaborBE> lTTB_AreaLaborBE;

        List<TB_SectorBE> lTTB_SectorBE;
        List<COM_CategoriasBE> lTCOM_CategoriasBE;
        private List<TB_SectorBE> lbeFiltroSector;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsPostBack)
                {

                }
                else
                {

                    //Session["FUNCIONARIO_ID"] = "71046";
                    DateTime Hoy = DateTime.Today;
                    fecha_actual = Hoy.ToString("dd/MM/yyyy");



                    lTTB_SectorBE = _TB_SectorBL.ListarTB_SectorO_Act();

                    //LlenarComboAreaLabor();
                    Session["Sector"] = lTTB_SectorBE;
                    LlenarComboSector();
                }

            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }

        private void LlenarComboSector()
        {
            ddlSector.DataSource = _TB_SectorBL.ListarTB_SectorO_Act();
            ddlSector.DataValueField = "Sector_id";
            ddlSector.DataTextField = "Sector_desc";
            ddlSector.DataBind();
            ddlSector.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            //LlenarComboCategoria();
        }


        private void GenerarTabla(Int16 _Sector_id)
        {

            lTCOM_CategoriasBE = _COM_CategoriasBL.ListarCOM_CategoriasBySector(_Sector_id);
            rpEmpleado.DataSource = lTCOM_CategoriasBE;
            rpEmpleado.DataBind();
        }

        protected void ddlAreaLabor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboSector();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Categoria_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _COM_CategoriasBE;
            //_miempl.Emp_id = "";
            _miObj.Categoria_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Categoria_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _COM_CategoriasBL.ActualizarCOM_Categoria(_COM_CategoriasBE);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
           // GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarTabla(Int16.Parse(ddlSector.SelectedValue));
        }
    }
}