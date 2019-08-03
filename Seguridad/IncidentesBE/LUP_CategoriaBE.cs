using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class LUP_CategoriaBE
    {
        public int Categoria_id { get; set; }
        
        public string Categoria_desc { get; set; }
        public short Pilar_id { get; set; }
        public bool Activo { get; set; }
    }
}
