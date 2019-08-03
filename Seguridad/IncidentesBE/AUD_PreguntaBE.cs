using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class AUD_PreguntaBE
    {
        public int Pregunta_id { get; set; }
        public string Pregunta_desc { get; set; }
        public short QuienAuditar_id { get; set; }
        public string Pregunta_donde { get; set; }
        public int Valor { get; set; }
        public Int16 Departamento_id { get; set; }
        public bool activo { get; set; }
        public short AuditoriaTipo_id { get; set; }
    }
}
