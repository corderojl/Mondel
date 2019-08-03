using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class COM_FormatosBE
    {
        public Int16 Formato_id { get; set; }
        public string Formato_desc { get; set; }
        public Int16 Formato_tipo { get; set; }
        public Int16 AreaLabor_id { get; set; }
        public bool activo { get; set; }
    }
}
