using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class TB_PlanAccionBE
    {
        public int PlanAccion_id { get; set; }
        public string PlanAccion_desc { get; set; }
        public DateTime Fecha { get; set; }
        public int Responsable { get; set; }
        public Int16 tipoPlan { get; set; }
        public bool Estado { get; set; }
        public Int16 Sistema_id { get; set; }
        public bool activo { get; set; }
        public int Registro_id { get; set; }
        public DateTime Fecha_Cier { get; set; }
    }
}
