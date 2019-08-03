using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class Fnc_FuncionariosBL
    {
        Fnc_FuncionariosADO _Fnc_FuncionariosADO = new Fnc_FuncionariosADO();

        public DataTable ListarFnc_Funcionarios_All()
        {
            return _Fnc_FuncionariosADO.ListarFnc_Funcionarios_All();
        }
        public DataTable ListarFnc_Funcionarios_Act()
        {
            return _Fnc_FuncionariosADO.ListarFnc_Funcionarios_Act();
        }
        public List<Fnc_FuncionariosBE> ListarFnc_FuncionariosO_Act()
        {
            return _Fnc_FuncionariosADO.ListarFnc_FuncionariosO_Act();
        }
        public Fnc_FuncionariosBE LoguearFuncionario(string _Usuario, string _Password)
        {
            return _Fnc_FuncionariosADO.LoguearFuncionario(_Usuario, _Password);
        }
        public Fnc_FuncionariosBE TraerFnc_Funcionario(int _Funcionario_id)
        {
            return _Fnc_FuncionariosADO.TraerFnc_Funcionario(_Funcionario_id);
        }

        public DataTable ListarFnc_FuncionariosByGuardia( string _departamento_id,string _guardia_id)
        {
            return _Fnc_FuncionariosADO.ListarFnc_FuncionariosByGuardia(_departamento_id, _guardia_id);
        }
        public bool ActualizarFnc_FuncionariosGuardia(int _departamento_id, int _guardia_id, int _funcionario_id)
        {
            return _Fnc_FuncionariosADO.ActualizarFnc_FuncionariosGuardia(_departamento_id, _guardia_id, _funcionario_id);
        }
        public DataTable BuscarFuncionario_Nombre(string vnombre)
        {
            return _Fnc_FuncionariosADO.BuscarFnc_FuncionarioByNombre(vnombre);
        }
        public bool DeshabilitarFuncionario(int vIdGrupo)
        {
            return _Fnc_FuncionariosADO.DeshabilitarFuncionario(vIdGrupo);
        }
        public bool HabilitarFuncionario(int vIdGrupo)
        {
            return _Fnc_FuncionariosADO.HabilitarFuncionario(vIdGrupo);
        }

        public bool ActualizarFNC_FuncionariosEmail(int _Funcionario_ID, string _Funcionario_Email)
        {
            return _Fnc_FuncionariosADO.ActualizarFNC_FuncionariosEmail(_Funcionario_ID, _Funcionario_Email);
        }
        public DataTable ListarEVA_FuncionariosBySuperior(string _Anio, string _Superior, string _Departamento_id, string _Estado)
        {
            return _Fnc_FuncionariosADO.ListarEVA_FuncionariosBySuperior(_Anio, _Superior, _Departamento_id, _Estado);
        }

        public bool comprobarFnc_FuncionariosPassword(short _Funcionario_ID)
        {
            return _Fnc_FuncionariosADO.comprobarFnc_FuncionariosPassword(_Funcionario_ID);
        }

        public bool cambiarFnc_FuncionariosPassword(short _Funcionario_ID, string _Password)
        {
            return _Fnc_FuncionariosADO.cambiarFnc_FuncionariosPassword(_Funcionario_ID, _Password);
        }

        public List<Fnc_FuncionariosBE> ListarFNC_FuncionariosLideresO_Act()
        {
            return _Fnc_FuncionariosADO.ListarFNC_FuncionariosLideresO_Act();
        }

        public DataTable ListarFnc_FuncionariosFill(string _Funcionario_nome, string _Categoria_id, string _SubCategoria_id, string _Departamento_id, 
            string _Rol_id, string _AreaLabor_id, string _Estado, string _Lider)
        {
            return _Fnc_FuncionariosADO.ListarFnc_FuncionariosFill(_Funcionario_nome, _Categoria_id, _SubCategoria_id, _Departamento_id, _Rol_id, _AreaLabor_id, _Estado, _Lider);
        }

        public bool ActualizarFNC_Funcionarios(Fnc_FuncionariosBE _Fnc_FuncionariosBE)
        {
            return _Fnc_FuncionariosADO.ActualizarFNC_Funcionarios(_Fnc_FuncionariosBE);
        }

        public bool Contenido(List<Fnc_FuncionariosBE> ltFuncionariosLider, Fnc_FuncionariosBE _Fnc_FuncionariosBE)
        {
            bool mivar = false;
            foreach (Fnc_FuncionariosBE objEmp in ltFuncionariosLider)
            {
                if (objEmp.Funcionario_Id == _Fnc_FuncionariosBE.Funcionario_Id)
                {
                    mivar = true;
                    break;
                }
            }
            return mivar;
        }

        public DataTable ListarEVA_FuncionariosBySuperiorXML(string _Anio, string _Superior, string _Departamento_id, string _Estado)
        {
            return _Fnc_FuncionariosADO.ListarEVA_FuncionariosBySuperiorXML(_Anio,_Superior,_Departamento_id,_Estado);
        }

        public DataTable ListarFNC_FuncionariosLideres_Act()
        {
            return _Fnc_FuncionariosADO.ListarFNC_FuncionariosLideres_Act();
        }

        public short InsertarFNC_Funcionarios(Fnc_FuncionariosBE _Fnc_FuncionariosBE)
        {
            return _Fnc_FuncionariosADO.InsertarFNC_Funcionarios(_Fnc_FuncionariosBE);
        }

        public bool RestaurarContraseña(int idEmp)
        {
            return _Fnc_FuncionariosADO.RestaurarContraseña(idEmp);
        }
    }
}
