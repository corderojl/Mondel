using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class TRG_Trigger_RiesgosBE
    {
        public int Registro_id { get; set; }
        public int Trigger_id { get; set; }
        public int Riesgo_id { get; set; }
        public bool Activo { get; set; }
        public short Usuario_update { get; set; }
        public bool Estado { get; set; }
        public bool Estado_ini { get; set; }
    }
}
