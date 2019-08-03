using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class TRG_TriggerBE
    {
        public int Trigger_id { get; set; }
        public DateTime Trigger_fecha { get; set; }
        public Int16 Departamento_id { get; set; }
        public Int16 Guardia_id { get; set; }
        public string Comp_crit_dia { get; set; }
        public string Comp_crit_sem { get; set; }
        public string Accidente_donde { get; set; }
        public Int16 Completar { get; set; }
        public Int16 Originador { get; set; }
        public int Incidente_reg { get; set; }
        public int Incidente_cls { get; set; }
        public bool Activo { get; set; }
    }
}
