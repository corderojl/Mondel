using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class EVA_SubCategoriaBE
    {
        public int SubCategoria_id { get; set; }
        public string SubCategoria_desc { get; set; }
        public int Categoria_id { get; set; }
        public bool activo { get; set; }
    }
}
