using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class COM_ComportamientoBE
    {
        public int Comportamiento_id { get; set; }
        public Int16 Auditor { get; set; }
        public DateTime Fecha_Comportamiento { get; set; }
        public Int16 Guardia { get; set; }
        public Int16 Tipo_emp { get; set; }
        public Int16 SubCategoria_id { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public Int16 Turno { get; set; }
        public Int16 Departamento { get; set; }
        public Int16 Area_id { get; set; }
        public Int16 Estado { get; set; }
        public Int16 Originador { get; set; }
        public DateTime Fecha_registro { get; set; }
        public bool activo { get; set; }
        public string Motivo { get; set; }

        public object Sector_id { get; set; }
    }
}
