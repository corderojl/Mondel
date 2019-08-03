using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class TB_IncidentesBE
    {
        public int Incidente_id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion  { get; set; }
        public DateTime Fecha_incidente { get; set; }
        public DateTime Fecha_registro { get; set; }
        public DateTime Fecha_estimada { get; set; }
        public Int16 Turno { get; set; }
        public Int16 Tiempo_ext { get; set; }
        public Int16 Estatus_ope { get; set; }
        public Int16 Departamento { get; set; }
        public Int16 Guardia { get; set; }
        public Int16 Area_id { get; set; }
        public Int16 Tipo_emp { get; set; }
        public Int16 Contratista_id { get; set; }
        public Int16 Rol_id{ get; set; }
        public Int16 Rol_tiempo { get; set; }
        public Int16 Compania_tiempo { get; set; }
        public Int16 ParteCuerpo_id { get; set; }
        public Int16 EquipoAfectado_id { get; set; }
        public Int16 Clasificacion_id { get; set; }
        public Int16 Daño_tipo { get; set; }
        public Int16 Causainmediata_id { get; set; }
        public Int16 CausaRaiz_id { get; set; }
        public Int16 Tecnologia_id { get; set; }
        public Int16 ElementoClave_id { get; set; }
        public string Riesgo_inv_desc { get; set; }
        public string Condicion_inv_desc { get; set; }
        public Int16 Riesgo_inv_id { get; set; }
        public Int16 Condicion_inv_id { get; set; }
        public int Originador { get; set; }
        public string Registro { get; set; }
        public int Estado { get; set; }
        public bool activo { get; set; }

        public short EmpleadoAfectado { get; set; }
    }
}
