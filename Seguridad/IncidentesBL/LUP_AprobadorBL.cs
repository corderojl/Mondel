using IncidentesADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class LUP_AprobadorBL
    {
        LUP_AprobadorADO _LUP_AprobadorADO =new LUP_AprobadorADO();
        public System.Data.DataTable ListarLUP_AprobadorByLup(int Lup_id)
        {
            return _LUP_AprobadorADO.ListarLUP_AprobadorByLup(Lup_id);
        }

        public bool InsertarLUP_Aprobador(int Lup_id, short Funcionario_id)
        {
            return _LUP_AprobadorADO.InsertarLUP_Aprobador(Lup_id, Funcionario_id);
        }

        public bool ProcesarLUP_Aprobador(IncidentesBE.LUP_AprobadorBE _LUP_AprobadorBE)
        {
            return _LUP_AprobadorADO.ProcesarLUP_Aprobador(_LUP_AprobadorBE);
        }

        public bool EliminarLUP_Aprobador(int Lup_id, short Funcionario_Id)
        {
            return _LUP_AprobadorADO.EliminarLUP_Aprobador(Lup_id, Funcionario_Id);
        }

        public System.Data.DataTable BuscarLUP_AprobadorPendiente(int _Usuario_id, short _Permiso)
        {
            return _LUP_AprobadorADO.BuscarLUP_AprobadorPendiente(_Usuario_id, _Permiso);
        }
    }
}
