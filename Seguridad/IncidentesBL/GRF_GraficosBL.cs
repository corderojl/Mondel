using IncidentesADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class GRF_GraficosBL
    {
        GRF_GraficosADO _GRF_GraficosBL = new GRF_GraficosADO();

        public DataTable GraficoParetoComportamientos(short _Departamento_id)
        {
            return _GRF_GraficosBL.GraficoPareto_Comportamientos(_Departamento_id);
        }
        public DataTable GraficoParetoIncidentes_Clasificación(short _Departamento_id)
        {
            return _GRF_GraficosBL.GraficoParetoIncidentes_Clasificación(_Departamento_id);
        }
    }
}
