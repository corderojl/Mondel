using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class REC_ReconocimientosBE
    {
        public Int64 Reconocimiento_Id { get; set; }
        public Int16 EmpleadoReconocido { get; set; }
        public Int16 Originador { get; set; }
        public Int16 Categoria_id { get; set; }
        public string Motivo { get; set; }
        public Int16 Lider { get; set; }
        public DateTime Fecha_Reconocimiento { get; set; }
        public DateTime Fecha_Reg { get; set; }
        public bool activo { get; set; }
    }
}
