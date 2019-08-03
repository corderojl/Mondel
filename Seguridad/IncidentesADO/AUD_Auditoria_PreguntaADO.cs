using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class AUD_Auditoria_PreguntaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarAUD_Auditoria_Pregunta_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_Auditoria_Pregunta_All";
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
        public List<AUD_Auditoria_PreguntaBE> ListarAUD_Auditoria_PreguntaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<AUD_Auditoria_PreguntaBE> lAUD_Auditoria_PreguntaBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAUD_Auditoria_Pregunta_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lAUD_Auditoria_PreguntaBE = new List<AUD_Auditoria_PreguntaBE>();
                    int posRegistro_id = drd.GetOrdinal("Registro_id");
                    int posAuditoria_id = drd.GetOrdinal("Auditoria_id");
                    int posPregunta_id = drd.GetOrdinal("Pregunta_id");
                    int posValor = drd.GetOrdinal("Valor");
                    int posActivo = drd.GetOrdinal("Activo");
                    AUD_Auditoria_PreguntaBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new AUD_Auditoria_PreguntaBE();
                        obeCategoriaBE.Registro_id = drd.GetInt32(posPregunta_id);
                        obeCategoriaBE.Auditoria_id = drd.GetInt32(posPregunta_id);
                        obeCategoriaBE.Pregunta_id = drd.GetInt32(posPregunta_id);
                        obeCategoriaBE.Valor = drd.GetInt16(posValor);
                        obeCategoriaBE.Activo = drd.GetBoolean(posActivo);
                        lAUD_Auditoria_PreguntaBE.Add(obeCategoriaBE);
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
            return (lAUD_Auditoria_PreguntaBE);
        }

        public DataTable ListarAUD_Auditoria_Pregunta_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_Auditoria_Pregunta_Act";
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
        public int InsertarAUD_Auditoria_Pregunta(AUD_Auditoria_PreguntaBE _AUD_Auditoria_PreguntaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarAUD_Auditoria_Pregunta";
            SqlParameter par1;
            int _Categoria_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Auditoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Auditoria_id"].Value = _AUD_Auditoria_PreguntaBE.Auditoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Pregunta_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pregunta_id"].Value = _AUD_Auditoria_PreguntaBE.Pregunta_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Valor"].Value = _AUD_Auditoria_PreguntaBE.Valor;
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
        public bool ActualizarAUD_Auditoria_Pregunta(AUD_Auditoria_PreguntaBE _AUD_Auditoria_PreguntaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarAUD_Auditoria_Pregunta";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Registro_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registro_id"].Value = _AUD_Auditoria_PreguntaBE.Registro_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Bit));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Valor"].Value = _AUD_Auditoria_PreguntaBE.Valor;
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
        public bool ActualizarAUD_Auditoria_PreguntaFin(AUD_Auditoria_PreguntaBE _AUD_Auditoria_PreguntaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarAUD_Auditoria_PreguntaFin";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Registro_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registro_id"].Value = _AUD_Auditoria_PreguntaBE.Registro_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Auditoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Auditoria_id"].Value = _AUD_Auditoria_PreguntaBE.Auditoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Bit));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Valor"].Value = _AUD_Auditoria_PreguntaBE.Valor;
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
        public bool EliminarAUD_Auditoria_Pregunta(int _Registro_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarAUD_Auditoria_Pregunta";
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

        public AUD_Auditoria_PreguntaBE TraerAUD_Auditoria_PreguntaById(int _Pregunta_id)
        {
            AUD_Auditoria_PreguntaBE _AUD_Auditoria_PreguntaBE = new AUD_Auditoria_PreguntaBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerAUD_Auditoria_PreguntaById";
                cmd.Parameters.Add(new SqlParameter("@Pregunta_id", SqlDbType.Int));
                cmd.Parameters["@Pregunta_id"].Value = _Pregunta_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _AUD_Auditoria_PreguntaBE;
                    _with1.Registro_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Pregunta_id")));
                    _with1.Auditoria_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Pregunta_id")));
                    _with1.Registro_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Pregunta_id")));
                    _with1.Valor = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Valor")));
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
            return _AUD_Auditoria_PreguntaBE;
        }

        public DataTable BuscarAUD_Auditoria_PreguntaByAuditoria(int _Auditoria_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_Auditoria_PreguntaByAuditoria";
                cmd.Parameters.Add(new SqlParameter("@Auditoria_id", SqlDbType.Int));
                cmd.Parameters["@Auditoria_id"].Value = _Auditoria_id;
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
