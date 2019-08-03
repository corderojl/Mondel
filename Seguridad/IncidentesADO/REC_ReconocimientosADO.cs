using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class REC_ReconocimientosADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        Boolean _vcod = false;
        int _Reconocimiento_Id = 0;
        REC_ReconocimientosBE _REC_ReconocimientosBE = new REC_ReconocimientosBE();

        public DataTable ListarREC_ReconocimientosAll()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarREC_Reconocimientos_All";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Alerta"];
        }
        public DataTable ListarREC_ReconocimientosAct()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarREC_Reconocimientos_Act";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Alerta"];
        }

        public DataTable ListarREC_ReconocimientosFind(string _EmpleadoReconocido, string _Originador
            , string _Categoria_id, DateTime _Fecha_Reconocimiento, DateTime _Fecha_Reconocimiento1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarREC_Reconocimientos_find";
                cmd.Parameters.Add(new SqlParameter("@EmpleadoReconocido", SqlDbType.VarChar, 6));
                cmd.Parameters["@EmpleadoReconocido"].Value = _EmpleadoReconocido;
                cmd.Parameters["@Originador"].Value = _Originador;
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Categoria_id"].Value = _Categoria_id;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Reconocimiento", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Reconocimiento"].Value = _Fecha_Reconocimiento;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Reconocimiento1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Reconocimiento1"].Value = _Fecha_Reconocimiento1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Alerta"];
        }

        public DataTable EstadisticaREC_ReconocimientosRegistroByFecha(DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_EstadisticaREC_ReconocimientosRegistroByFecha";
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta"].Value = _Fecha_Alerta;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta1"].Value = _Fecha_Alerta1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Alerta"];
        }
        public REC_ReconocimientosBE TraerREC_ReconocimientosById(int _Alerta_id)
        {
            REC_ReconocimientosBE _AlertasBE = new REC_ReconocimientosBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerREC_ReconocimientosById";
                cmd.Parameters.Add(new SqlParameter("@Alerta_id", SqlDbType.Int));
                cmd.Parameters["@Alerta_id"].Value = _Alerta_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _AlertasBE;
                    _with1.Reconocimiento_Id = Convert.ToInt64(dtr.GetValue(dtr.GetOrdinal("Reconocimiento_Id")));
                    _with1.EmpleadoReconocido = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("EmpleadoReconocido")));
                    _with1.Originador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Originador")));
                    _with1.Categoria_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Categoria_id")));
                    _with1.Motivo = dtr.GetValue(dtr.GetOrdinal("Motivo")).ToString();
                    _with1.Lider = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Lider")));
                    _with1.Fecha_Reconocimiento = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_Reconocimiento")));
                    _with1.Fecha_Reg = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_Reg")));
                    _with1.activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("activo")));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _AlertasBE;
        }
        public int InsertarREC_Reconocimientos(REC_ReconocimientosBE _ReconocimientoBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarREC_Reconocimientos";
            SqlParameter par1;
            int IdReconocimiento = -1;
            try
            {
                //SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                //par4.Direction = ParameterDirection.ReturnValue;
                par1 = cmd.Parameters.Add(new SqlParameter("@EmpleadoReconocido", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EmpleadoReconocido"].Value = _ReconocimientoBE.EmpleadoReconocido;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _ReconocimientoBE.Originador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _ReconocimientoBE.Categoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Motivo", SqlDbType.VarChar, 120));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Motivo"].Value = _ReconocimientoBE.Motivo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider"].Value = _ReconocimientoBE.Lider;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_Reconocimiento", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_Reconocimiento"].Value = _ReconocimientoBE.Fecha_Reconocimiento;
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdReconocimiento = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdReconocimiento = -1;
            }
            catch (Exception x)
            {
                IdReconocimiento = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return IdReconocimiento;
        }
        public bool ActualizarREC_Reconocimientos(REC_ReconocimientosBE _ReconocimientoBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarREC_Reconocimientos";
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Reconocimiento_Id", SqlDbType.BigInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Reconocimiento_Id"].Value = _ReconocimientoBE.Reconocimiento_Id;
                par1 = cmd.Parameters.Add(new SqlParameter("@EmpleadoReconocido", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EmpleadoReconocido"].Value = _ReconocimientoBE.EmpleadoReconocido;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _ReconocimientoBE.Originador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _ReconocimientoBE.Categoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Motivo", SqlDbType.VarChar, 120));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Motivo"].Value = _ReconocimientoBE.Motivo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider"].Value = _ReconocimientoBE.Lider;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_Reconocimiento", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_Reconocimiento"].Value = _ReconocimientoBE.Fecha_Reconocimiento;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;

            }
            catch (SqlException x)
            {
                _vcod = false;
            }
            catch (Exception x)
            {
                _vcod = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return _vcod;
        }
        public bool EliminarREC_Reconocimientos(int _Reconocimiento_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarREC_Reconocimientos";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@Reconocimiento_id", SqlDbType.Int));
                cmd.Parameters["@Reconocimiento_id"].Value = _Reconocimiento_id;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;
            }
            catch (SqlException x)
            {
                _vcod = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return _vcod;

        }

        public DataTable BuscarREC_ReconocimientosByUsuario(int _Usuario_id, short _Permiso)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                if (_Permiso == 1)
                {
                    cmd.CommandText = "sp_BuscarALR_AlertaByAdministrador";
                }
                else
                {
                    cmd.CommandText = "sp_BuscarALR_AlertaByUsuario";
                    cmd.Parameters.Add(new SqlParameter("@Usuario_id", SqlDbType.Int));
                    cmd.Parameters["@Usuario_id"].Value = _Usuario_id;
                }
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Alerta"];
        }



        public DataTable ListarREC_Reconocimientos_Estadistica(string EmpleadoReconocido, string Originador
            , string Categoria_id, DateTime Fecha_Reconocimiento, DateTime Fecha_Reconocimiento1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarREC_Reconocimientos_Estadistica";

                cmd.Parameters.Add(new SqlParameter("@EmpleadoReconocido", SqlDbType.SmallInt));
                cmd.Parameters["@EmpleadoReconocido"].Value = EmpleadoReconocido;
                cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.SmallInt));
                cmd.Parameters["@Originador"].Value = Originador;
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.SmallInt));
                cmd.Parameters["@Categoria_id"].Value = Categoria_id;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Reconocimiento", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Reconocimiento"].Value = Fecha_Reconocimiento;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Reconocimiento1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Reconocimiento1"].Value = Fecha_Reconocimiento1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Alerta"];
        }

        public DataTable ListarREC_ReconocimientosFindXLS(string EmpleadoReconocido, string Originador
            , string Categoria_id, DateTime Fecha_Reconocimiento, DateTime Fecha_Reconocimiento1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarREC_Reconocimientos_findXLS";
                cmd.Parameters.Add(new SqlParameter("@EmpleadoReconocido", SqlDbType.SmallInt));
                cmd.Parameters["@EmpleadoReconocido"].Value = EmpleadoReconocido;
                cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.SmallInt));
                cmd.Parameters["@Originador"].Value = Originador;
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.SmallInt));
                cmd.Parameters["@Categoria_id"].Value = Categoria_id;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Reconocimiento", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Reconocimiento"].Value = Fecha_Reconocimiento;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Reconocimiento1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Reconocimiento1"].Value = Fecha_Reconocimiento1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Alerta"];
        }


        public DataTable ListarREC_ReconocimientosByDepartamento(DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarREC_ReconocimientosByDepartamento";
                cmd.Parameters.Add(new SqlParameter("@Fecha_alerta", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_alerta"].Value = _Fecha_Alerta;
                cmd.Parameters.Add(new SqlParameter("@Fecha_alerta1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_alerta1"].Value = _Fecha_Alerta1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Alerta"];
        }

        public DataTable ListarREC_ReconocimientosByDepartamentoFuncionario(int _Departamento_id, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarREC_ReconocimientosByDepartamentoFuncionario";
                cmd.Parameters.Add(new SqlParameter("@Fecha_alerta", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_alerta"].Value = _Fecha_Alerta;
                cmd.Parameters.Add(new SqlParameter("@Fecha_alerta1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_alerta1"].Value = _Fecha_Alerta1;
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return dts.Tables["Alerta"];
        }

        public List<REC_CategoriasBE> ListarREC_ReconocimientosO_Act()
        {
            throw new NotImplementedException();
        }
    }
}
