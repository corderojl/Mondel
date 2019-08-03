using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class ALR_SistemaqaBE
    {
        public Int16 SistemaQA_id { get; set; }
        public string SistemaQA_desc { get; set; }
        public int Departamento_id { get; set; }
        public bool activo { get; set; }
        public string SistemaQA_nom { get; set; }
    }
}
