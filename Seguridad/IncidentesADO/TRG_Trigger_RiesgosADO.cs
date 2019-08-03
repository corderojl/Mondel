using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TRG_Trigger_RiesgosADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarTRG_Trigger_Riesgos_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTRG_Trigger_Riesgos_All";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
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
            return dts.Tables["Sistemas"];
        }
        public List<TRG_Trigger_RiesgosBE> ListarTRG_Trigger_RiesgosO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TRG_Trigger_RiesgosBE> lTRG_Trigger_RiesgosBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTRG_Trigger_Riesgos_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lTRG_Trigger_RiesgosBE = new List<TRG_Trigger_RiesgosBE>();
                    int posRegistro_id = drd.GetOrdinal("Registro_id");
                    int posTrigger_id = drd.GetOrdinal("Trigger_id");
                    int posRiesgo_id = drd.GetOrdinal("Riesgo_id");
                    int posUsuario_update = drd.GetOrdinal("usuario_update");
                    int posActivo = drd.GetOrdinal("Activo");
                    TRG_Trigger_RiesgosBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new TRG_Trigger_RiesgosBE();
                        obeCategoriaBE.Registro_id = drd.GetInt32(posRiesgo_id);
                        obeCategoriaBE.Trigger_id = drd.GetInt32(posRiesgo_id);
                        obeCategoriaBE.Riesgo_id = drd.GetInt32(posRiesgo_id);
                        obeCategoriaBE.Usuario_update = drd.GetInt16(posUsuario_update);
                        obeCategoriaBE.Activo = drd.GetBoolean(posActivo);
                        lTRG_Trigger_RiesgosBE.Add(obeCategoriaBE);
                    }
                    drd.Close();

                }
                con.Close();
            }
            catch (SqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            return (lTRG_Trigger_RiesgosBE);
        }

        public DataTable ListarTRG_Trigger_Riesgos_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTRG_Trigger_Riesgos_Act";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
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
            return dts.Tables["Sistemas"];
        }
        public int InsertarTRG_Trigger_Riesgos(TRG_Trigger_RiesgosBE _TRG_Trigger_RiesgosBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTRG_Trigger_Riesgos";
            SqlParameter par1;
            int _Categoria_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Trigger_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Trigger_id"].Value = _TRG_Trigger_RiesgosBE.Trigger_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Riesgo_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Riesgo_id"].Value = _TRG_Trigger_RiesgosBE.Riesgo_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@usuario_update", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@usuario_update"].Value = _TRG_Trigger_RiesgosBE.Usuario_update;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Categoria_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("@@identity")));
            }
            catch (SqlException x)
            {
                _Categoria_id = 0;
            }
            catch (Exception x)
            {
                _Categoria_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Categoria_id;
        }
        public bool ActualizarTRG_Trigger_Riesgos(TRG_Trigger_RiesgosBE _TRG_Trigger_RiesgosBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTRG_Trigger_Riesgos";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Registro_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registro_id"].Value = _TRG_Trigger_RiesgosBE.Registro_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Trigger_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Trigger_id"].Value = _TRG_Trigger_RiesgosBE.Trigger_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Bit));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _TRG_Trigger_RiesgosBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@usuario_update", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@usuario_update"].Value = _TRG_Trigger_RiesgosBE.Usuario_update;
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
        public bool ActualizarTRG_Trigger_RiesgosFin(TRG_Trigger_RiesgosBE _TRG_Trigger_RiesgosBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTRG_Trigger_RiesgosFin";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Registro_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registro_id"].Value = _TRG_Trigger_RiesgosBE.Registro_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Trigger_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Trigger_id"].Value = _TRG_Trigger_RiesgosBE.Trigger_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Bit));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _TRG_Trigger_RiesgosBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@usuario_update", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@usuario_update"].Value = _TRG_Trigger_RiesgosBE.Usuario_update;
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
        public bool EliminarTRG_Trigger_Riesgos(int _Registro_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTRG_Trigger_Riesgos";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Registro_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registro_id"].Value = _Registro_id;
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

        public TRG_Trigger_RiesgosBE TraerTRG_Trigger_RiesgosById(int _Riesgo_id)
        {
            TRG_Trigger_RiesgosBE _TRG_Trigger_RiesgosBE = new TRG_Trigger_RiesgosBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTRG_Trigger_RiesgosById";
                cmd.Parameters.Add(new SqlParameter("@Riesgo_id", SqlDbType.Int));
                cmd.Parameters["@Riesgo_id"].Value = _Riesgo_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _TRG_Trigger_RiesgosBE;
                    _with1.Registro_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Riesgo_id")));
                    _with1.Trigger_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Riesgo_id")));
                    _with1.Registro_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Riesgo_id")));
                    _with1.Usuario_update = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Valor")));
                    _with1.Activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("activo")));
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
            return _TRG_Trigger_RiesgosBE;
        }

        public DataTable BuscarTRG_Trigger_RiesgosByTrigger(int _Trigger_Id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTRG_Trigger_RiesgosByTrigger";
                cmd.Parameters.Add(new SqlParameter("@Trigger_Id", SqlDbType.Int));
                cmd.Parameters["@Trigger_Id"].Value = _Trigger_Id;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
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
            return dts.Tables["Sistemas"];
        }
    }
}
