using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
   public class EVA_IndicadorBE
    {
        public int Indicador_id { get; set; }
        public string Objetivo { get; set; }
        public string Scope { get; set; }
        public string Meta { get; set; }
        public int Puntos { get; set; }
        public string Comentarios { get; set; }
        public int Area_id { get; set; }
        public bool activo { get; set; }
    }
}
