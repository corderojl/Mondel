using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class LUP_LupBL
    {
        LUP_LupADO _LUP_LupADO = new LUP_LupADO();

        public DataTable ListarLUP_LupAll()
        {
            return _LUP_LupADO.ListarLUP_LupAll();
        }
        public DataTable ListarLUP_LupAct()
        {
            return _LUP_LupADO.ListarLUP_LupAct();
        }
        public int InsertarLUP_Lup(LUP_LupBE _inseBE)
        {
            return _LUP_LupADO.InsertarLUP_Lup(_inseBE);
        }

        public bool ActualizarLUP_Lup(LUP_LupBE _inseBE)
        {
            return _LUP_LupADO.ActualizarLUP_Lup(_inseBE);
        }

        public bool EliminarLUP_Lup(int vcod)
        {
            return _LUP_LupADO.EliminarLUP_Lup(vcod);
        }

        public LUP_LupBE TraerLUP_LupById(int vcod)
        {
            return _LUP_LupADO.TraerLUP_LupById(vcod);
        }

        public DataTable BuscarLUP_LupByUsuario(int _Usuario_id, Int16 _Permiso)
        {
            return _LUP_LupADO.BuscarLUP_LupByUsuario(_Usuario_id, _Permiso);
        }

        public DataTable ListarLUP_Lup_Estadistica(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador, string _Estado, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            return _LUP_LupADO.ListarLUP_Lup_Estadistica(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _SistemaQA_id, _ElementoClave_id, _Originador, _Estado, _Fecha_Alerta, _Fecha_Alerta1);
        }

        public DataTable ListarLUP_LupFind(string dep, string pil, string gua, string cat, string due, string estado, DateTime fecha, DateTime fecha1, string palabra)
        {
            return _LUP_LupADO.ListarLUP_LupFind(dep, pil, gua, cat, due, estado, fecha, fecha1, palabra);
        }

        public short ContarLUP_LupAprobacion(short Lup_id)
        {
            return _LUP_LupADO.ContarLUP_LupAprobacion(Lup_id);
        }

        public DataTable ListarLUP_LupFindXLS(string dep, string pil, string gua, string cat, string due, string estado, DateTime fecha, DateTime fecha1, string palabra)
        {
            return _LUP_LupADO.ListarLUP_LupFindXLS(dep, pil, gua, cat, due, estado, fecha, fecha1, palabra);
        }
    }
}
