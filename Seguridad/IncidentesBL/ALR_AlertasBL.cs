using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class ALR_AlertasBL
    {
        ALR_AlertasADO _ALR_AlertasADO = new ALR_AlertasADO();

        public DataTable ListarALR_AlertasAll()
        {
            return _ALR_AlertasADO.ListarALR_AlertasAll();
        }
        public DataTable ListarALR_AlertasAct()
        {
            return _ALR_AlertasADO.ListarALR_AlertasAct();
        }
        public int InsertarALR_Alertas(ALR_AlertasBE _inseBE)
        {
            return _ALR_AlertasADO.InsertarALR_Alertas(_inseBE);
        }

        public bool ActualizarALR_Alertas(ALR_AlertasBE _inseBE)
        {
            return _ALR_AlertasADO.ActualizarALR_Alertas(_inseBE);
        }

        public bool EliminarALR_Alertas(int vcod)
        {
            return _ALR_AlertasADO.EliminarALR_Alertas(vcod);
        }

        public ALR_AlertasBE TraerALR_AlertasById(int vcod)
        {
            return _ALR_AlertasADO.TraerALR_AlertasById(vcod);
        }

        public DataTable ListarALR_AlertasFind(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador, string _Estado, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1, int _Usuario_id)
        {
            return _ALR_AlertasADO.ListarALR_AlertasFind(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _SistemaQA_id, _ElementoClave_id, _Originador, _Estado, _Fecha_Alerta, _Fecha_Alerta1, _Usuario_id);
        }

        public DataTable BuscarALR_AlertasByUsuario(int _Usuario_id, Int16 _Permiso)
        {
            return _ALR_AlertasADO.BuscarALR_AlertasByUsuario(_Usuario_id, _Permiso);
        }

        public DataTable ListarALR_Alertas_Estadistica(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador, string _Estado, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            return _ALR_AlertasADO.ListarALR_Alertas_Estadistica(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _SistemaQA_id, _ElementoClave_id, _Originador, _Estado, _Fecha_Alerta, _Fecha_Alerta1);
        }

        public DataTable ListarALR_AlertasFindXLS(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador, string _Estado, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            return _ALR_AlertasADO.ListarALR_AlertasFindXLS(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _SistemaQA_id, _ElementoClave_id, _Originador, _Estado, _Fecha_Alerta, _Fecha_Alerta1);
        }

        public DataTable ListarALR_AlertasByDepartamento(DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            return _ALR_AlertasADO.ListarALR_AlertasByDepartamento(_Fecha_Alerta, _Fecha_Alerta1);
        }

        public DataTable ListarALR_AlertasByDepartamentoFuncionario(int _Departamento_id, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            return _ALR_AlertasADO.ListarALR_AlertasByDepartamentoFuncionario(_Departamento_id, _Fecha_Alerta, _Fecha_Alerta1);
        }
    }
}
