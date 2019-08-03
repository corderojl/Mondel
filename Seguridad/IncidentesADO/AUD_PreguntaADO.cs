using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class AUD_PreguntaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarAUD_Pregunta_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_Pregunta_All";
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
        public List<AUD_PreguntaBE> ListarAUD_PreguntaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<AUD_PreguntaBE> lAUD_PreguntaBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAUD_Pregunta_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lAUD_PreguntaBE = new List<AUD_PreguntaBE>();
                    int posPregunta_id = drd.GetOrdinal("Pregunta_id");
                    int posPregunta_desc = drd.GetOrdinal("Pregunta_desc");
                    int posPregunta_donde = drd.GetOrdinal("Pregunta_donde");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    int posValor = drd.GetOrdinal("Valor");
                    int posActivo = drd.GetOrdinal("Activo");
                    AUD_PreguntaBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new AUD_PreguntaBE();
                        obeCategoriaBE.Pregunta_id = drd.GetInt32(posPregunta_id);
                        obeCategoriaBE.Pregunta_desc = drd.GetString(posPregunta_desc);
                        obeCategoriaBE.Pregunta_donde = drd.GetString(posPregunta_donde);
                        obeCategoriaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                        obeCategoriaBE.Valor = drd.GetInt32(posValor);
                        obeCategoriaBE.activo = drd.GetBoolean(posActivo);
                        lAUD_PreguntaBE.Add(obeCategoriaBE);
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
            return (lAUD_PreguntaBE);
        }

        public DataTable ListarAUD_Pregunta_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_Pregunta_Act";
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
        public int InsertarAUD_Pregunta(AUD_PreguntaBE _AUD_PreguntaBE)
        {
            int IdElementoClave = -1;
            SqlParameter par1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarAUD_Pregunta";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Pregunta_desc", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pregunta_desc"].Value = _AUD_PreguntaBE.Pregunta_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@QuienAuditar_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@QuienAuditar_id"].Value = _AUD_PreguntaBE.QuienAuditar_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Pregunta_donde", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pregunta_donde"].Value = _AUD_PreguntaBE.Pregunta_donde;
                par1 = cmd.Parameters.Add(new SqlParameter("@AuditoriaTipo_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AuditoriaTipo_id"].Value = _AUD_PreguntaBE.AuditoriaTipo_id;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdElementoClave = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdElementoClave = -1;
            }
            catch (Exception x)
            {
                IdElementoClave = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdElementoClave);
        }
       
        public bool ActualizarAUD_Pregunta(AUD_PreguntaBE _AUD_PreguntaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarAUD_Pregunta";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Pregunta_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pregunta_id"].Value = _AUD_PreguntaBE.Pregunta_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Pregunta_desc", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pregunta_desc"].Value = _AUD_PreguntaBE.Pregunta_desc;
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
        public bool EliminarAUD_Pregunta(int _Pregunta_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarAUD_Pregunta";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Pregunta_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pregunta_id"].Value = _Pregunta_id;
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

        public AUD_PreguntaBE TraerAUD_PreguntaById(int _Pregunta_id)
        {
            AUD_PreguntaBE _AUD_PreguntaBE = new AUD_PreguntaBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerAUD_PreguntaById";
                cmd.Parameters.Add(new SqlParameter("@Pregunta_id", SqlDbType.Int));
                cmd.Parameters["@Pregunta_id"].Value = _Pregunta_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _AUD_PreguntaBE;
                    _with1.Pregunta_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Pregunta_id")));
                    _with1.Pregunta_desc = dtr.GetValue(dtr.GetOrdinal("Pregunta_desc")).ToString();
                    _with1.Departamento_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Departamento_id")));
                    _with1.Valor = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Valor")));
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
            return _AUD_PreguntaBE;
        }

        public List<AUD_PreguntaBE> ListarAUD_PreguntaByDepartamento(short _Departamento_id)
        {
            string conexion = MiConexion.GetCnx();
            List<AUD_PreguntaBE> lAUD_PreguntaBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAUD_PreguntaByDepartamento", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lAUD_PreguntaBE = new List<AUD_PreguntaBE>();
                    int posPregunta_id = drd.GetOrdinal("Pregunta_id");
                    int posPregunta_desc = drd.GetOrdinal("Pregunta_desc");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    int posValor = drd.GetOrdinal("Valor");
                    int posActivo = drd.GetOrdinal("Activo");
                    AUD_PreguntaBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new AUD_PreguntaBE();
                        obeCategoriaBE.Pregunta_id = drd.GetInt32(posPregunta_id);
                        obeCategoriaBE.Pregunta_desc = drd.GetString(posPregunta_desc);
                        obeCategoriaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                        obeCategoriaBE.Valor = drd.GetInt32(posValor);
                        obeCategoriaBE.activo = drd.GetBoolean(posActivo);
                        lAUD_PreguntaBE.Add(obeCategoriaBE);
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
            return (lAUD_PreguntaBE);
        }

        public DataTable ListarAUD_PreguntaAct()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_Pregunta_Act";
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
        public DataTable ListarAUD_PreguntaByAuditoriaTipo(short _AuditoriaTipo_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_PreguntaByAuditoriaTipo";
                cmd.Parameters.Add(new SqlParameter("@AuditoriaTipo_id", SqlDbType.SmallInt));
                cmd.Parameters["@AuditoriaTipo_id"].Value = _AuditoriaTipo_id;
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

        public List<AUD_PreguntaBE> ListarAUD_PreguntaByAuditoriaTipoO(short _AuditoriaTipo_id)
        {
            string conexion = MiConexion.GetCnx();
            List<AUD_PreguntaBE> lAUD_PreguntaBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAUD_PreguntaByAuditoriaTipoO", con);
                cmd.Parameters.Add(new SqlParameter("@AuditoriaTipo_id", SqlDbType.SmallInt));
                cmd.Parameters["@AuditoriaTipo_id"].Value = _AuditoriaTipo_id;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lAUD_PreguntaBE = new List<AUD_PreguntaBE>();
                    int posPregunta_id = drd.GetOrdinal("Pregunta_id");
                    int posPregunta_desc = drd.GetOrdinal("Pregunta_desc");
                    int posPregunta_donde = drd.GetOrdinal("Pregunta_donde");
                    int posQuienAuditar_id = drd.GetOrdinal("QuienAuditar_id");
                    int posValor = drd.GetOrdinal("Valor");
                    int posActivo = drd.GetOrdinal("Activo");
                    AUD_PreguntaBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new AUD_PreguntaBE();
                        obeCategoriaBE.Pregunta_id = drd.GetInt32(posPregunta_id);
                        obeCategoriaBE.Pregunta_desc = drd.GetString(posPregunta_desc);
                        obeCategoriaBE.Pregunta_donde = drd.GetString(posPregunta_donde);
                        obeCategoriaBE.QuienAuditar_id = drd.GetInt16(posQuienAuditar_id);
                        obeCategoriaBE.Valor = drd.GetInt32(posValor);
                        obeCategoriaBE.activo = drd.GetBoolean(posActivo);
                        lAUD_PreguntaBE.Add(obeCategoriaBE);
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
            return (lAUD_PreguntaBE);
        }
    }
}
