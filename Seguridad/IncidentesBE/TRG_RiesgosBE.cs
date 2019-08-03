using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class TRG_RiesgosBE
    {
        public int Riesgo_id { get; set; }
        public string Riesgo_desc { get; set; }
        public int Valor { get; set; }
        public Int16 Departamento_id { get; set; }
        public bool activo { get; set; }
    }
}
