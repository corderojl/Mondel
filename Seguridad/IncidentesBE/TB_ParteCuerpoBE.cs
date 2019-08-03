using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class TB_ParteCuerpoBE
    {
        public int ParteCuerpo_id { get; set; }
        public string ParteCuerpo_desc { get; set; }
        public string activo { get; set; }
        public int TipoDanio { get; set; }
    }
}
