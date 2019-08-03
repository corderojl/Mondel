using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class REC_ReconocimientosBL
    {
        REC_ReconocimientosADO _REC_ReconocimientosADO = new REC_ReconocimientosADO();

        public DataTable ListarREC_ReconocimientosAll()
        {
            return _REC_ReconocimientosADO.ListarREC_ReconocimientosAll();
        }
        public DataTable ListarREC_ReconocimientosAct()
        {
            return _REC_ReconocimientosADO.ListarREC_ReconocimientosAct();
        }
        public int InsertarREC_Reconocimientos(REC_ReconocimientosBE _inseBE)
        {
            return _REC_ReconocimientosADO.InsertarREC_Reconocimientos(_inseBE);
        }

        public bool ActualizarREC_Reconocimientos(REC_ReconocimientosBE _inseBE)
        {
            return _REC_ReconocimientosADO.ActualizarREC_Reconocimientos(_inseBE);
        }

        public bool EliminarREC_Reconocimientos(int vcod)
        {
            return _REC_ReconocimientosADO.EliminarREC_Reconocimientos(vcod);
        }

        public REC_ReconocimientosBE TraerREC_ReconocimientosById(int vcod)
        {
            return _REC_ReconocimientosADO.TraerREC_ReconocimientosById(vcod);
        }

        public DataTable ListarREC_ReconocimientosFind(string _EmpleadoReconocido, string _Originador
            , string _Categoria_id, DateTime _Fecha_Reconocimiento, DateTime _Fecha_Reconocimiento1)
        {
            return _REC_ReconocimientosADO.ListarREC_ReconocimientosFind(_EmpleadoReconocido, _Originador,
                _Categoria_id, _Fecha_Reconocimiento, _Fecha_Reconocimiento1);
        }

        public DataTable BuscarREC_ReconocimientosByUsuario(int _Usuario_id, Int16 _Permiso)
        {
            return _REC_ReconocimientosADO.BuscarREC_ReconocimientosByUsuario(_Usuario_id, _Permiso);
        }

        public DataTable ListarREC_Reconocimientos_Estadistica(string _EmpleadoReconocido, string _Originador
            , string _Categoria_id, DateTime _Fecha_Reconocimiento, DateTime _Fecha_Reconocimiento1)
        {
            return _REC_ReconocimientosADO.ListarREC_Reconocimientos_Estadistica(_EmpleadoReconocido, _Originador,
                _Categoria_id, _Fecha_Reconocimiento, _Fecha_Reconocimiento1);
        }

        public DataTable ListarREC_ReconocimientosFindXLS(string _EmpleadoReconocido, string _Originador
            , string _Categoria_id, DateTime _Fecha_Reconocimiento, DateTime _Fecha_Reconocimiento1)
        {
            return _REC_ReconocimientosADO.ListarREC_ReconocimientosFindXLS(_EmpleadoReconocido, _Originador,
                _Categoria_id, _Fecha_Reconocimiento, _Fecha_Reconocimiento1);
        }

        public DataTable ListarREC_ReconocimientosByDepartamento(DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            return _REC_ReconocimientosADO.ListarREC_ReconocimientosByDepartamento(_Fecha_Alerta, _Fecha_Alerta1);
        }

        public DataTable ListarREC_ReconocimientosByDepartamentoFuncionario(int _Departamento_id, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            return _REC_ReconocimientosADO.ListarREC_ReconocimientosByDepartamentoFuncionario(_Departamento_id, _Fecha_Alerta, _Fecha_Alerta1);
        }

        public List<REC_CategoriasBE> ListarREC_ReconocimientosO_Act()
        {
            return _REC_ReconocimientosADO.ListarREC_ReconocimientosO_Act();
        }

    }
}
