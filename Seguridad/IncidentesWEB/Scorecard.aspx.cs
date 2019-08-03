using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB
{
    public partial class Scorecard : System.Web.UI.Page
    {
        
        GRF_GraficosBL _GRF_GraficosBL = new GRF_GraficosBL();
        DataTable _comportamiento, _incidentes_clas;
        DataView dv;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                generarGrafico();
               

            }

        }

        private void generarGrafico()
        {
            double yValue2 = 100;
            double yValue = 100.0;
            string xValue = "0";

            

            _comportamiento = _GRF_GraficosBL.GraficoParetoComportamientos(4);
            _incidentes_clas = _GRF_GraficosBL.GraficoParetoIncidentes_Clasificación(4);
            dv = _comportamiento.DefaultView;

            chrComportamiento.Series[0].Points.DataBindXY(dv, "valor", dv, "numero");
            //  chrComportamiento.Series[1].Points.DataBindXY(dv, "valor", dv, "numero");

            dv = _incidentes_clas.DefaultView;
            chrIncidentesClasificacion.Series[0].Points.DataBindXY(dv, "Clasificacion_desc", dv, "numero");
           // chrIncidentesClasificacion.Series[0].Points.DataBindXY(dv, "Clasificacion_desc", dv, "numero");

            int TotalRegistros = _incidentes_clas.Rows.Count;

            chrIncidentesClasificacion.Series["Series2"].Points.AddXY(xValue, yValue);
           // chrIncidentesClasificacion.Series["Series1"].Points.AddXY(xValue, yValue2);
            for (int i = 0; i < TotalRegistros; i++)
            {
                xValue = _incidentes_clas.Rows[i]["Clasificacion_desc"].ToString();
                yValue = yValue + Convert.ToDouble(_incidentes_clas.Rows[i]["numero"]);
              //  yValue2 = yValue2 + Convert.ToDouble(_incidentes_clas.Rows[i]["Encontrados"]);
                chrIncidentesClasificacion.Series["Series2"].Points.AddXY(xValue, yValue);
                //chrIncidentesClasificacion.Series["Series1"].Points.AddXY(xValue, yValue2);
            }
        }
       

    }
}