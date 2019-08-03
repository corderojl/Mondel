using ComportamientosADO;
using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class COM_ComportamientoBL
    {
        COM_ComportamientoADO _COM_ComportamientoADO = new COM_ComportamientoADO();
        public DataTable BuscarCOM_ComportamientoByOriginador(short _Originador)
        {
            return _COM_ComportamientoADO.BuscarCOM_ComportamientoByOriginador(_Originador);
        }
        public List<COM_ComportamientoBE> ListarCOM_Comportamiento_Dia()
        {
            return _COM_ComportamientoADO.ListarCOM_Comportamiento_Dia();
        }
        public List<COM_ComportamientoBE> ListarCOM_Comportamiento_Semana()
        {
            return _COM_ComportamientoADO.ListarCOM_Comportamiento_Semana();
        }
        public int InsertarCOM_Comportamiento(COM_ComportamientoBE _COM_ComportamientoBE)
        {
            return _COM_ComportamientoADO.InsertarCOM_Comportamiento(_COM_ComportamientoBE);
        }

        public bool EliminarCOM_Comportamiento(int _Comportamiento_id)
        {
            return _COM_ComportamientoADO.EliminarCOM_Comportamiento(_Comportamiento_id);
        }

        public DataTable ListarCOM_ComportamientoFind(string _Departamento_id, string _Area_id, string _Guardia_id, string _Funcionario_id, string _Formato_id, string _SubCategoria_id, string _Tipo_emp, string _Valor, DateTime _Fecha_Comportamiento, DateTime _Fecha_Comportamiento1)
        {
            return _COM_ComportamientoADO.ListarCOM_ComportamientoFind(_Departamento_id,_Area_id, _Guardia_id, _Funcionario_id, _Formato_id,
                _SubCategoria_id, _Tipo_emp, _Valor
            , _Fecha_Comportamiento, _Fecha_Comportamiento1);
        }
        public DataTable ListarCOM_ComportamientoFindXML(string _Departamento_id, string _Area_id, string _Guardia_id, string _Funcionario_id, string _Formato_id, string _SubCategoria_id, string _Tipo_emp, string _Valor, DateTime _Fecha_Comportamiento, DateTime _Fecha_Comportamiento1)
        {
            return _COM_ComportamientoADO.ListarCOM_ComportamientoFindXML(_Departamento_id, _Area_id, _Guardia_id, _Funcionario_id, _Formato_id,
                _SubCategoria_id, _Tipo_emp, _Valor
            , _Fecha_Comportamiento, _Fecha_Comportamiento1);
        }


        public TEM_ComportamientoEstadistica TraerCOM_ComportamientoEstadistica(string _Departamento_id, string _Area_id, string _Guardia_id, string _Funcionario_id, string _Formato_id, string _SubCategoria_id, string _Tipo_emp, string _Valor, DateTime _Fecha_Comportamiento, DateTime _Fecha_Comportamiento1)
        {
            return _COM_ComportamientoADO.TraerCOM_ComportamientoEstadistica(_Departamento_id, _Area_id, _Guardia_id, _Funcionario_id, _Formato_id,
                _SubCategoria_id, _Tipo_emp, _Valor
            , _Fecha_Comportamiento, _Fecha_Comportamiento1);
        }

        public int ContarCOM_Comportamiento(string _Departamento_id, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _COM_ComportamientoADO.ContarCOM_Comportamiento(_Departamento_id, _Fecha_incidente, _Fecha_incidente1); ;
        }
    }
}
