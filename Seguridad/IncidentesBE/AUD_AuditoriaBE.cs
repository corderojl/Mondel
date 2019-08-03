using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class AUD_AuditoriaBE
    {
        public int Auditoria_id { get; set; }
        public DateTime Fecha_Auditoria { get; set; }
        public Int16 Departamento_id { get; set; }
        public Int16 Guardia_id { get; set; }
        public Int16 Area_id { get; set; }
        public Int16 Operador { get; set; }
        public Int16 Originador { get; set; }
        public DateTime Fecha_firmaOpe { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public Int16 AuditoriaTipo_id { get; set; }
        public bool Activo { get; set; }

        
    }
}
