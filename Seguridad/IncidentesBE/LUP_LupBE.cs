using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class LUP_LupBE
    {
        public int Lup_id { get; set; }
        public string Lup_Titulo { get; set; }
        public string Lup_desc { get; set; }
        public Int16 Pilar_id { get; set; }
        public Int16 Departamento_id { get; set; }
        public Int16 Guardia_id { get; set; }
        public Int16 Categoria_id { get; set; }
        public Int16 Encargado { get; set; }
        public string adjunto_lup { get; set; }
        public DateTime fecha_reg { get; set; }
        public DateTime fecha_ven { get; set; }
        public Int16 Registrador { get; set; }
        public Int16 Estado { get; set; }
        public bool activo { get; set; }
        public string adjunto_aprob { get; set; }
    }
}
