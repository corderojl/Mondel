using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class NOV_NovedadesBL
    {
        NOV_NovedadesADO _NOV_NovedadesADO = new NOV_NovedadesADO();

        public DataTable ListarNOV_NovedadesAll()
        {
            return _NOV_NovedadesADO.ListarNOV_NovedadesAll();
        }
        public DataTable ListarNOV_NovedadesAct()
        {
            return _NOV_NovedadesADO.ListarNOV_NovedadesAct();
        }
        public int InsertarNOV_Novedades(NOV_NovedadesBE _inseBE)
        {
            return _NOV_NovedadesADO.InsertarNOV_Novedades(_inseBE);
        }

        public bool ActualizarNOV_Novedades(NOV_NovedadesBE _inseBE)
        {
            return _NOV_NovedadesADO.ActualizarNOV_Novedades(_inseBE);
        }

        public bool EliminarNOV_Novedades(int vcod)
        {
            return _NOV_NovedadesADO.EliminarNOV_Novedades(vcod);
        }

        public NOV_NovedadesBE TraerNOV_NovedadesById(int vcod)
        {
            return _NOV_NovedadesADO.TraerNOV_NovedadesById(vcod);
        }

        public DataTable ListarNOV_NovedadesFind(string _Titulo, string _Descripcion)
        {
            return _NOV_NovedadesADO.ListarNOV_NovedadesFind(_Titulo, _Descripcion);
        }

        public List<NOV_NovedadesBE> ListarNOV_NovedadesO_All()
        {
            return _NOV_NovedadesADO.ListarNOV_NovedadesO_All();
        }
    }
}
