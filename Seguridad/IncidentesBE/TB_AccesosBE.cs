using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class TB_AccesosBE
    {
        public Int16 Usuario_id { get; set; }
        public Int16 Permiso { get; set; }
        public Int16 Departamento_id { get; set; }
        public bool Activo { get; set; }
    }
}
