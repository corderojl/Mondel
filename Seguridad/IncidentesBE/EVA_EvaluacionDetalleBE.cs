using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class EVA_EvaluacionDetalleBE
    {
        public int EvaluacionDetalle_id { get; set; }
        public int Evaluacion_id { get; set; }
        public int Indicador_id { get; set; }
        public int Puntos { get; set; }
        public int PuntosOpt { get; set; }
        public string Observacion { get; set; }
        public bool activo { get; set; }


    }
}
