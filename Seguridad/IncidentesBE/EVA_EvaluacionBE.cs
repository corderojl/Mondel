using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class EVA_EvaluacionBE
    {
        public int Evaluacion_id { get; set; }
        public int Empleado_id { get; set; }
        public int SubCategoria_id { get; set; }
        public int Lider_id { get; set; }
        public int Departamento_id { get; set; }
        public DateTime Fecha_registro { get; set; }
        public int Tipo { get; set; }
        public string Anio { get; set; }
        public bool activo { get; set; }
    }
}
