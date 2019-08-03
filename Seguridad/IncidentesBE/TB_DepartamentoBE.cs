using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class TB_DepartamentoBE
    {
        public int Departamento_id { get; set; }
        public string Departamento_desc { get; set; }
        public string activo { get; set; }
        public string Sigla { get; set; }
        public short Sector_id { get; set; }

        public int Zona { get; set; }
    }
}
