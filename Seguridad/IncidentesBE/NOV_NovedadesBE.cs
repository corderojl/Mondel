using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class NOV_NovedadesBE
    {
        public int Novedades_id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }
        public int Originador { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha_Reg { get; set; }
    }
}
