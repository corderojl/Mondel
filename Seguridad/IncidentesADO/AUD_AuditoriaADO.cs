using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class AUD_AuditoriaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarAUD_Auditoria_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_Auditoria_All";
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
        public List<AUD_AuditoriaBE> ListarAUD_AuditoriaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<AUD_AuditoriaBE> lAUD_AuditoriaBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAUD_Auditoria_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lAUD_AuditoriaBE = new List<AUD_AuditoriaBE>();
                    int posAuditoria_id = drd.GetOrdinal("Auditoria_id");
                    int posFecha_Auditoria = drd.GetOrdinal("Fecha_Auditoria");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    int posGuardia_id = drd.GetOrdinal("Guardia_id");
                    int posOperador = drd.GetOrdinal("Operador");
                    int posOriginador = drd.GetOrdinal("Originador");
                    int posFecha_firmaOpe = drd.GetOrdinal("Fecha_firmaOpe");
                    int posFecha_Registro = drd.GetOrdinal("Fecha_Registro");
                    int posActivo = drd.GetOrdinal("Activo");
                    AUD_AuditoriaBE obeAuditoriaBE = null;
                    while (drd.Read())
                    {
                        obeAuditoriaBE = new AUD_AuditoriaBE();
                        obeAuditoriaBE.Auditoria_id = drd.GetInt32(posAuditoria_id);
                        obeAuditoriaBE.Fecha_Auditoria = drd.GetDateTime(posFecha_Auditoria);
                        obeAuditoriaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                        obeAuditoriaBE.Guardia_id = drd.GetInt16(posGuardia_id);
                        obeAuditoriaBE.Operador = drd.GetInt16(posOperador);
                        obeAuditoriaBE.Originador = drd.GetInt16(posOriginador);
                        obeAuditoriaBE.Fecha_firmaOpe = drd.GetDateTime(posFecha_firmaOpe);
                        obeAuditoriaBE.Fecha_Registro = drd.GetDateTime(posFecha_Registro);
                        obeAuditoriaBE.Activo = drd.GetBoolean(posActivo);
                        lAUD_AuditoriaBE.Add(obeAuditoriaBE);
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
            return (lAUD_AuditoriaBE);
        }

        public DataTable ListarAUD_Auditoria_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_Auditoria_Act";
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
        public int InsertarAUD_Auditoria(AUD_AuditoriaBE _AUD_AuditoriaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarAUD_Auditoria";
            SqlParameter par1;
            int _Auditoria_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_Auditoria", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_Auditoria"].Value = _AUD_AuditoriaBE.Fecha_Auditoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _AUD_AuditoriaBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _AUD_AuditoriaBE.Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_id"].Value = _AUD_AuditoriaBE.Area_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Operador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Operador"].Value = _AUD_AuditoriaBE.Operador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _AUD_AuditoriaBE.Originador;
                par1 = cmd.Parameters.Add(new SqlParameter("@AuditoriaTipo_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AuditoriaTipo_id"].Value = _AUD_AuditoriaBE.AuditoriaTipo_id;

                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Auditoria_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Auditoria_id")));
            }
            catch (SqlException x)
            {
                _Auditoria_id = 0;
            }
            catch (Exception x)
            {
                _Auditoria_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Auditoria_id;
        }
        public bool ActualizarAUD_Auditoria(AUD_AuditoriaBE _AUD_AuditoriaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarAUD_Auditoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Auditoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Auditoria_id"].Value = _AUD_AuditoriaBE.Auditoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_Auditoria", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_Auditoria"].Value = _AUD_AuditoriaBE.Fecha_Auditoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _AUD_AuditoriaBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _AUD_AuditoriaBE.Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Operador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Operador"].Value = _AUD_AuditoriaBE.Operador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_id"].Value = _AUD_AuditoriaBE.Area_id;
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

        public bool EliminarAUD_Auditoria(int _Auditoria_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarAUD_Auditoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Auditoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Auditoria_id"].Value = _Auditoria_id;
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

        public AUD_AuditoriaBE TraerAUD_AuditoriaById(int _Auditoria_id)
        {
            AUD_AuditoriaBE _AUD_AuditoriaBE = new AUD_AuditoriaBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerAUD_AuditoriaById";
                cmd.Parameters.Add(new SqlParameter("@Auditoria_id", SqlDbType.Int));
                cmd.Parameters["@Auditoria_id"].Value = _Auditoria_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _AUD_AuditoriaBE;
                    _with1.Auditoria_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Auditoria_id")));
                    _with1.Fecha_Auditoria = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_Auditoria")));
                    _with1.Departamento_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Departamento_id")));
                    _with1.Guardia_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Guardia_id")));
                    _with1.Area_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Area_id")));
                    _with1.Operador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Operador")));
                    _with1.Originador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Originador")));
                    _with1.Fecha_firmaOpe = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_firmaOpe")));
                    _with1.Fecha_Registro = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_Registro")));
                    _with1.AuditoriaTipo_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("AuditoriaTipo_id")));
                    _with1.Activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("Activo")));

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
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
            return _AUD_AuditoriaBE;
        }

        public DataTable TraerAUD_AuditoriaSemaforo(short _Departamento_id)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerAUD_AuditoriaSemaforo";
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;

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
        public DataTable ListarAUD_AuditoriaFind(string _Departamento_id, string _Guardia_id, string _Area_id, string _Auditoria_id, string _Operador, string _Originador, DateTime _Fecha_Auditoria, DateTime _Fecha_Auditoria1)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_AuditoriaFind";
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_id"].Value = _Area_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Auditoria_id", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Auditoria_id"].Value = _Auditoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Operador", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Operador"].Value = _Operador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _Originador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_Auditoria", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_Auditoria"].Value = _Fecha_Auditoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_Auditoria1", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_Auditoria1"].Value = _Fecha_Auditoria1;
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
        public int TraerAUD_AuditoriaUltimo(short _Departamento_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_TraerAUD_AuditoriaUltimo";
            SqlParameter par1;
            int _Auditoria_id;
            try
            {

                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Auditoria_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Auditoria_id")));
            }
            catch (SqlException x)
            {
                _Auditoria_id = 0;
            }
            catch (Exception x)
            {
                _Auditoria_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Auditoria_id;
        }

        public bool FirmarAUD_Auditoria(int Auditoria_id, DateTime Hoy)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_FirmarAUD_Auditoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Auditoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Auditoria_id"].Value = Auditoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Hoy", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Hoy"].Value = Hoy;
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
    }
}
