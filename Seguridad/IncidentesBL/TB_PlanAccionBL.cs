using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_PlanAccionBL
    {
        TB_PlanAccionADO _TB_PlanAccionADO = new TB_PlanAccionADO();

        public DataTable ListarTB_PlanAccion_All()
        {
            return _TB_PlanAccionADO.ListarTB_PlanAccion_All();
        }
        public DataTable ListarTB_PlanAccion_Act()
        {
            return _TB_PlanAccionADO.ListarTB_PlanAccion_Act();
        }
        public List<TB_PlanAccionBE> ListarTB_PlanAccionO_Act()
        {
            return _TB_PlanAccionADO.ListarTB_PlanAccionO_Act();
        }
        public List<TB_PlanAccionBE> BuscarTB_PlanAccionByIncidente(int _Id_Incidente, Int16 _tipoPlan)
        {
            return _TB_PlanAccionADO.BuscarTB_PlanAccionByIncidente(_Id_Incidente, _tipoPlan);
        }
        public DataTable BuscarTB_PlanAccionByTrigger(int _Id_Incidente)
        {
            return _TB_PlanAccionADO.BuscarTB_PlanAccionByTrigger(_Id_Incidente);
        }
        public DataTable BuscarTB_PlanAccionByIncidenteResponsable(int _Id_Incidente, Int16 _tipoPlan, Int16 _Sistema_id)
        {
            return _TB_PlanAccionADO.BuscarTB_PlanAccionByIncidenteResponsable(_Id_Incidente, _tipoPlan, _Sistema_id);
        }
        public List<TB_PlanAccionBE> TraerTB_PlanAccionByIdO(Int16 _PlanAccion_id)
        {
            return _TB_PlanAccionADO.TraerTB_PlanAccionByIdO(_PlanAccion_id);
        }
        public bool InsertarTB_PlanAccion(TB_PlanAccionBE _TB_PlanAccionBE)
        {
            return _TB_PlanAccionADO.InsertarTB_PlanAccion(_TB_PlanAccionBE);
        }
        public bool ActualizarTB_PlanAccion(TB_PlanAccionBE _TB_PlanAccionBE)
        {
            return _TB_PlanAccionADO.ActualizarTB_PlanAccion(_TB_PlanAccionBE);
        }
        public bool EliminarTB_PlanAccion(int _PlanAccion_id)
        {
            return _TB_PlanAccionADO.EliminarTB_PlanAccion(_PlanAccion_id);
        }
        public bool CerrarTB_PlanAccion(int _PlanAccion_id)
        {
            return _TB_PlanAccionADO.CerrarTB_PlanAccion(_PlanAccion_id);
        }
        public TB_PlanAccionBE TraerTB_PlanAccionById(int _PlanAccion_id)
        {
            return _TB_PlanAccionADO.TraerTB_PlanAccionById(_PlanAccion_id);
        }
        public DataTable ListarTB_PlanAccionFind(string _Departamento_id, string _tipoPlan, string _Responsable, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _TB_PlanAccionADO.ListarTB_PlanAccionFind(_Departamento_id, _tipoPlan,
               _Responsable, _Estado, _Fecha_incidente, _Fecha_incidente1);
        }
        public DataTable ListarTB_PlanAccionFind_ALR(string _Departamento_id, string _tipoPlan, string _Responsable, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _TB_PlanAccionADO.ListarTB_PlanAccionFind_ALR(_Departamento_id, _tipoPlan,
               _Responsable, _Estado, _Fecha_incidente, _Fecha_incidente1);
        }

        public int ContarTB_PlanAccionByRegistro(int _Incidente_id, short _Sistema_id)
        {
            return _TB_PlanAccionADO.ContarTB_PlanAccionByRegistro(_Incidente_id, _Sistema_id);
        }
        public int[] ContarTB_PlanAccionByFuncionario(int _Funcionario_id)
        {
            return _TB_PlanAccionADO.ContarTB_PlanAccionByFuncionario(_Funcionario_id);
        }
        public DataTable ListarTB_PlanAccionFind_XLS(string _Departamento_id, string _tipoPlan, string _Responsable, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _TB_PlanAccionADO.ListarTB_PlanAccionFind_XLS(_Departamento_id, _tipoPlan,
              _Responsable, _Estado, _Fecha_incidente, _Fecha_incidente1);
        }

        public DataTable BuscarTB_PlanAccionPendiente(short _Responsable, short _Tipo)
        {
            return _TB_PlanAccionADO.BuscarTB_PlanAccionPendiente(_Responsable, _Tipo);
        }

        public DataTable BuscarTB_PlanAccionByAuditoria(int _Auditoria_id)
        {
            return _TB_PlanAccionADO.BuscarTB_PlanAccionByAuditoria(_Auditoria_id);
        }

        public DataTable ListarTB_PlanAccionFind_AUD(string _Departamento_id, string _tipoPlan, string _Responsable, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _TB_PlanAccionADO.ListarTB_PlanAccionFind_AUD(_Departamento_id, _tipoPlan,
                _Responsable, _Estado, _Fecha_incidente, _Fecha_incidente1);
        }
    }
}
