using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_IncidentesBL
    {
        TB_IncidentesADO _TB_IncidentesADO = new TB_IncidentesADO();

        public DataTable ListarTB_IncidentesAll()
        {
            return _TB_IncidentesADO.ListarTB_IncidentesAll();
        }
        public DataTable ListarTB_IncidentesAct()
        {
            return _TB_IncidentesADO.ListarTB_IncidentesAct();
        }
        //public DataTable ListarTB_IncidentesFind(string vcod)
        //{
        //    return _TB_IncidentesADO.ListarTB_IncidentesFind(vcod);
        //}
        public int InsertarTB_Incidentes(TB_IncidentesBE _inseBE)
        {
            return _TB_IncidentesADO.InsertarTB_Incidentes(_inseBE);
        }

        public bool ActualizarTB_Incidentes(TB_IncidentesBE _inseBE)
        {
            return _TB_IncidentesADO.ActualizarTB_Incidentes(_inseBE);
        }

        public bool EliminarTB_Incidentes(int vcod)
        {
            return _TB_IncidentesADO.EliminarTB_Incidentes(vcod);
        }

        public TB_IncidentesBE TraerTB_IncidentesById(int vcod)
        {
            return _TB_IncidentesADO.TraerTB_IncidentesById(vcod);
        }

        public DataTable ListarTB_IncidentesFind(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _Tipo_emp
            , string _Rol_id, string _Rol_tiempo, string _Compania_tiempo
            , string _Turno, string _Estatus_ope, string _Comportamiento_inv_id, string _Condicion_inv_id
            , string _CausaInmediata_id, string _Tecnologia_id, string _ElementoClave_id
            , string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1, int _Usuario_id)
        {
            return _TB_IncidentesADO.ListarTB_IncidentesFind(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id, _Rol_tiempo, _Compania_tiempo, _Turno,
                _Estatus_ope, _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id, _ElementoClave_id,
                _Estado, _Fecha_incidente, _Fecha_incidente1, _Usuario_id);
        }

        public DataTable BuscarTB_IncidentesByUsuario(int _Usuario_id, Int16 _Permiso)
        {
            return _TB_IncidentesADO.BuscarTB_IncidentesByUsuario(_Usuario_id, _Permiso);
        }

        public DataTable ListarTB_Incidentes_Estadistica(string _Departamento_id, string _Guardia_id, string _Area_id, string _Clasificacion_id, string _Tipo_emp, string _Rol_id, string _Rol_tiempo, string _Compania_tiempo, string _Turno, string _Estatus_ope, string _Comportamiento_inv_id, string _Condicion_inv_id, string _CausaInmediata_id, string _Tecnologia_id, string _ElementoClave_id, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _TB_IncidentesADO.ListarTB_Incidentes_Estadistica(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id, _Rol_tiempo, _Compania_tiempo, _Turno,
                _Estatus_ope, _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id, _ElementoClave_id,
                _Estado, _Fecha_incidente, _Fecha_incidente1);
        }

        public DataTable ListarTB_IncidentesFindXLS(string _Departamento_id, string _Guardia_id, string _Area_id, string _Clasificacion_id, string _Tipo_emp, string _Rol_id, string _Rol_tiempo, string _Compania_tiempo, string _Turno, string _Estatus_ope, string _Comportamiento_inv_id, string _Condicion_inv_id, string _CausaInmediata_id, string _Tecnologia_id, string _ElementoClave_id, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _TB_IncidentesADO.ListarTB_IncidentesFindXLS(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id, _Rol_tiempo, _Compania_tiempo, _Turno,
                _Estatus_ope, _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id, _ElementoClave_id,
                _Estado, _Fecha_incidente, _Fecha_incidente1);
        }
        public TB_IncidentesBE TraerTB_IncidenteUltimoRegistrable(DateTime _Fecha_registro)
        {
            return _TB_IncidentesADO.TraerTB_IncidenteUltimoRegistrable(_Fecha_registro);
        }
        public TB_IncidentesBE TraerTB_IncidenteUltimoClaseIByDepartamento(DateTime _Fecha_registro, short _Departamento_id)
        {
            return _TB_IncidentesADO.TraerTB_IncidenteUltimoClaseIByDepartamento(_Fecha_registro, _Departamento_id);
        }

        public DataTable ListarTB_IncidentesByDepartamento(DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _TB_IncidentesADO.ListarTB_IncidentesByDepartamento(_Fecha_incidente, _Fecha_incidente1);
        }

        public DataTable ContarIncidentesByClasificacion(string _Departamento_id, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _TB_IncidentesADO.ContarIncidentesByClasificacion(_Departamento_id, _Fecha_incidente, _Fecha_incidente1);
        }
    }
}
