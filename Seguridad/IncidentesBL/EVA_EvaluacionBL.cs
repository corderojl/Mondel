using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class EVA_EvaluacionBL
    {
        EVA_EvaluacionADO _EVA_EvaluacionADO = new EVA_EvaluacionADO();

        public DataTable ListarEVA_Evaluacion_All()
        {
            return _EVA_EvaluacionADO.ListarEVA_Evaluacion_All();
        }
        public DataTable ListarEVA_Evaluacion_Act()
        {
            return _EVA_EvaluacionADO.ListarEVA_Evaluacion_Act();
        }
        public List<EVA_EvaluacionBE> ListarEVA_EvaluacionO_Act()
        {
            return _EVA_EvaluacionADO.ListarEVA_EvaluacionO_Act();
        }
        public int InsertarEVA_Evaluacion(EVA_EvaluacionBE _inseBE)
        {
            return _EVA_EvaluacionADO.InsertarEVA_Evaluacion(_inseBE);
        }
        public bool ActualizarEVA_Evaluacion(EVA_EvaluacionBE _inseBE)
        {
            return _EVA_EvaluacionADO.ActualizarEVA_Evaluacion(_inseBE);
        }
        public bool EliminarEVA_Evaluacion(int vcod)
        {
            return _EVA_EvaluacionADO.EliminarEVA_Evaluacion(vcod);
        }
        public EVA_EvaluacionBE TraerEVA_EvaluacionById(int vcod)
        {
            return _EVA_EvaluacionADO.TraerEVA_EvaluacionById(vcod);
        }
        public DataTable TraerEVA_EvaluacionSemaforo(short vcod)
        {
            return _EVA_EvaluacionADO.TraerEVA_EvaluacionSemaforo(vcod);
        }
        public DataTable ListarEVA_EvaluacionFind(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            return _EVA_EvaluacionADO.ListarEVA_EvaluacionFind(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,_Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral);
        }
        public int TraerEVA_EvaluacionUltimo(short _Departamento_id)
        {
            return _EVA_EvaluacionADO.TraerEVA_EvaluacionUltimo(_Departamento_id);
        }

        public bool FirmarEVA_Evaluacion(int _Evaluacion_id, DateTime Hoy)
        {
            return _EVA_EvaluacionADO.FirmarEVA_Evaluacion(_Evaluacion_id, Hoy);
        }

        public int ExisteEva_Evaluacion(short Empleado_id, string Anio)
        {
            return _EVA_EvaluacionADO.ExisteEva_Evaluacion(Empleado_id, Anio);
        }
        public string TraerEVA_LimiteCalsificacion(int _Evaluacion_id)
        {
            return _EVA_EvaluacionADO.TraerEVA_LimiteCalsificacion(_Evaluacion_id);
        }


        public bool ActualizarEVA_EvaluacionNota(int _Evaluacion_id, float _Suma)
        {
            return _EVA_EvaluacionADO.ActualizarEVA_EvaluacionNota(_Evaluacion_id, _Suma);
        }

        public List<EVA_CurvaBE> TraerEVA_EvaluacionCurva(string _Departamento_id, string _Lider_id, string _Anio, string _Tipo, string _AreaLabor, string _Categoria)
        {
            return _EVA_EvaluacionADO.TraerEVA_EvaluacionCurva(_Departamento_id, _Lider_id, _Anio, _Tipo, _AreaLabor, _Categoria);
        }

        public DataTable ListarEVA_EvaluacionEstadistica(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            return _EVA_EvaluacionADO.ListarEVA_EvaluacionEstadistica(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id, _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral);
       
        }

        public DataTable TraerEVA_EvaluacionEstadisticaCurva(string _Departamento_id, string _Lider_id, string _Anio, string _Tipo, string _AreaLabor, string _Categoria)
        {
            return _EVA_EvaluacionADO.TraerEVA_EvaluacionEstadisticaCurva(_Departamento_id, _Lider_id, _Anio, _Tipo, _AreaLabor, _Categoria);
        }

        public DataTable ListarEVA_EvaluacionFindXML(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            return _EVA_EvaluacionADO.ListarEVA_EvaluacionFindXML(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id, _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral);
        
        }

        public object ListarEVA_EvaluacionByCarta(string p1, string lider, string p2)
        {
            return _EVA_EvaluacionADO.ListarEVA_EvaluacionByCarta(p1, lider, p2);
        }
    }
}
