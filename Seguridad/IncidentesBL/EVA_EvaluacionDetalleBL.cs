using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
   public class EVA_EvaluacionDetalleBL
    {
        EVA_EvaluacionDetalleADO _EVA_EvaluacionDetalleADO = new EVA_EvaluacionDetalleADO();

        public DataTable ListarEVA_EvaluacionDetalle_All()
        {
            return _EVA_EvaluacionDetalleADO.ListarEVA_EvaluacionDetalle_All();
        }
        public DataTable ListarEVA_EvaluacionDetalle_Act()
        {
            return _EVA_EvaluacionDetalleADO.ListarEVA_EvaluacionDetalle_Act();
        }
        public List<EVA_EvaluacionDetalleBE> ListarEVA_EvaluacionDetalleO_Act()
        {
            return _EVA_EvaluacionDetalleADO.ListarEVA_EvaluacionDetalleO_Act();
        }
        public int InsertarEVA_EvaluacionDetalle(EVA_EvaluacionDetalleBE _inseBE)
        {
            return _EVA_EvaluacionDetalleADO.InsertarEVA_EvaluacionDetalle(_inseBE);
        }
        public bool ActualizarEVA_EvaluacionDetalle(EVA_EvaluacionDetalleBE _inseBE)
        {
            return _EVA_EvaluacionDetalleADO.ActualizarEVA_EvaluacionDetalle(_inseBE);
        }
        public bool ActualizarEVA_EvaluacionDetalleFin(EVA_EvaluacionDetalleBE _inseBE)
        {
            return _EVA_EvaluacionDetalleADO.ActualizarEVA_EvaluacionDetalleFin(_inseBE);
        }
        public bool EliminarEVA_EvaluacionDetalle(int vcod)
        {
            return _EVA_EvaluacionDetalleADO.EliminarEVA_EvaluacionDetalle(vcod);
        }
        public EVA_EvaluacionDetalleBE TraerEVA_EvaluacionDetalleById(int vcod)
        {
            return _EVA_EvaluacionDetalleADO.TraerEVA_EvaluacionDetalleById(vcod);
        }

        public DataTable BuscarEVA_EvaluacionDetalleByEvaluacion(int _EvaluacionDetalle_id, string _Var)
        {
            return _EVA_EvaluacionDetalleADO.BuscarEVA_EvaluacionDetalleByEvaluacion(_EvaluacionDetalle_id, _Var);
        }

        public bool ActualizarEVA_EvaluacionDetalleObservacion(int _EvaluacionDetalle_id, string _Observacion)
        {
            return _EVA_EvaluacionDetalleADO.ActualizarEVA_EvaluacionDetalleObservacion(_EvaluacionDetalle_id, _Observacion);
        }

        public bool TraerEVA_EvaluacionDetalleExistePunto0(int _Evaluacion_id)
        {
            return _EVA_EvaluacionDetalleADO.TraerEVA_EvaluacionDetalleExistePunto0(_Evaluacion_id);
        }
    }
}
