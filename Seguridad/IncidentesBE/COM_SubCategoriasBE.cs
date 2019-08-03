using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class COM_SubCategoriasBE
    {
        public Int16 SubCategoria_id { get; set; }
        public string SubCategoria_desc { get; set; }
        public string SubCategoria_codigo { get; set; }
        public Int16 AreaLabor_id{ get; set; }
        public DateTime fecha_reg { get; set; }
        public bool activo { get; set; }
        public string FSeguro { get; set; }
        public string FInseguro { get; set; }
    }
}
