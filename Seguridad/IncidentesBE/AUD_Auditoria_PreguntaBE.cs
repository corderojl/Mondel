using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class AUD_Auditoria_PreguntaBE
    {
        public int Registro_id { get; set; }
        public int Auditoria_id { get; set; }
        public int Pregunta_id { get; set; }
        public short Valor { get; set; }
        public bool Activo { get; set; }
    }
}
