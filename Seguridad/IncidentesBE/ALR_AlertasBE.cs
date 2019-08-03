using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class ALR_AlertasBE
    {
        public int Alerta_id { get; set; }
        public string Alerta_desc { get; set; }
        public Int16 Clasificacion { get; set; }
        public Int16 Departamento_id { get; set; }
        public Int16 Area_id { get; set; }
        public Int16 Guardia_id { get; set; }
        public Int16 SistemaQA_id { get; set; }
        public Int16 ElementoClave_id { get; set; }
        public Int16 Originador { get; set; }
        public Int16 Estado { get; set; }
        public DateTime Fecha_alerta { get; set; }
        public DateTime Fecha_registro { get; set; }
        public Int16 Registrador { get; set; }
        public bool activo { get; set; }
    }
}
