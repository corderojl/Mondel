using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class COM_CategoriasBE
    {
        public Int16 Categoria_id { get; set; }
        public string Categoria_desc { get; set; }
        public Int16 Categoria_tipo { get; set; }
        public Int16 Formato_id { get; set; }
        public bool activo { get; set; }
        public short Grado { get; set; }

        public short AreaLabor_id { get; set; }
    }
}
