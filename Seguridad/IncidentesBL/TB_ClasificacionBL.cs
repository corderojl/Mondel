using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_ClasificacionBL
    {
        TB_ClasificacionADO _TB_ClasificacionADO = new TB_ClasificacionADO();

        public DataTable ListarTB_Clasificacion_All()
        {
            return _TB_ClasificacionADO.ListarTB_Clasificacion_All();
        }
        public DataTable ListarTB_Clasificacion_Act()
        {
            return _TB_ClasificacionADO.ListarTB_Clasificacion_Act();
        }
        public List<TB_ClasificacionBE> ListarTB_ClasificacionO_Act()
        {
            return _TB_ClasificacionADO.ListarTB_ClasificacionO_Act();
        }

        public bool ActualizarTB_Clasificacion(TB_ClasificacionBE _TB_ClasificacionBE)
        {
            return _TB_ClasificacionADO.ActualizarTB_Clasificacion(_TB_ClasificacionBE);     
        }

        public bool EliminarTB_Clasificacion(short _Clasificacion_id)
        {
            return _TB_ClasificacionADO.EliminarTB_Clasificacion(_Clasificacion_id);  
        }

        public int InsertarTB_Clasificacion(TB_ClasificacionBE _TB_ClasificacionBE)
        {
            return _TB_ClasificacionADO.InsertarTB_Clasificacion(_TB_ClasificacionBE);  
        }
    }
}
