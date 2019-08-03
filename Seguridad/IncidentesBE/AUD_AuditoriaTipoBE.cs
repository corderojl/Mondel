using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class AUD_AuditoriaTipoBE
    {
        public short AuditoriaTipo_id { get; set; }
        public string Auditoria_Desc { get; set; }
        public short Departamento_id { get; set; }
        public bool activo { get; set; }
    }
}
