using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class AUD_AuditoriaTipoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarAUD_AuditoriaTipo_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_AuditoriaTipoAll";
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
        public List<AUD_AuditoriaTipoBE> ListarAUD_AuditoriaTipoO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<AUD_AuditoriaTipoBE> lAUD_AuditoriaTipoBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAUD_AuditoriaTipoAct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lAUD_AuditoriaTipoBE = new List<AUD_AuditoriaTipoBE>();
                    int posAuditoriaTipo_id = drd.GetOrdinal("AuditoriaTipo_id");
                    int posAuditoria_Desc = drd.GetOrdinal("Auditoria_Desc");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    AUD_AuditoriaTipoBE obeAuditoriaTipoBE = null;
                    while (drd.Read())
                    {
                        obeAuditoriaTipoBE = new AUD_AuditoriaTipoBE();
                        obeAuditoriaTipoBE.AuditoriaTipo_id = drd.GetInt16(posAuditoriaTipo_id);
                        obeAuditoriaTipoBE.Auditoria_Desc = drd.GetString(posAuditoria_Desc);
                        obeAuditoriaTipoBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                        lAUD_AuditoriaTipoBE.Add(obeAuditoriaTipoBE);
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
            return (lAUD_AuditoriaTipoBE);
        }
        public List<AUD_AuditoriaTipoBE> ListarAUD_AuditoriaTipoByDepartamento(Int16 _Departamento_id)
        {
            string conexion = MiConexion.GetCnx();
            List<AUD_AuditoriaTipoBE> lAUD_AuditoriaTipoBE = null;
            SqlParameter par1;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAUD_AuditoriaTipoByDepartamento", con);
                cmd.CommandType = CommandType.StoredProcedure;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lAUD_AuditoriaTipoBE = new List<AUD_AuditoriaTipoBE>();
                    int posAuditoriaTipo_id = drd.GetOrdinal("AuditoriaTipo_id");
                    int posAuditoria_Desc = drd.GetOrdinal("Auditoria_Desc");
                    AUD_AuditoriaTipoBE obeAuditoriaTipoBE = null;
                    while (drd.Read())
                    {
                        obeAuditoriaTipoBE = new AUD_AuditoriaTipoBE();
                        obeAuditoriaTipoBE.AuditoriaTipo_id = drd.GetInt16(posAuditoriaTipo_id);
                        obeAuditoriaTipoBE.Auditoria_Desc = drd.GetString(posAuditoria_Desc);
                        lAUD_AuditoriaTipoBE.Add(obeAuditoriaTipoBE);
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
            return (lAUD_AuditoriaTipoBE);
        }
        public DataTable ListarAUD_AuditoriaTipoAct()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_AuditoriaTipoAct";
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
        public int InsertarAUD_AuditoriaTipo(AUD_AuditoriaTipoBE _AUD_AuditoriaTipoBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarAUD_AuditoriaTipo";
            SqlParameter par1;
            int _AuditoriaTipo_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Auditoria_Desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Auditoria_Desc"].Value = _AUD_AuditoriaTipoBE.Auditoria_Desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _AUD_AuditoriaTipoBE.Departamento_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _AuditoriaTipo_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("@@identity")));
            }
            catch (SqlException x)
            {
                _AuditoriaTipo_id = 0;
            }
            catch (Exception x)
            {
                _AuditoriaTipo_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _AuditoriaTipo_id;
        }
        public bool ActualizarAUD_AuditoriaTipo(AUD_AuditoriaTipoBE _AUD_AuditoriaTipoBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarAUD_AuditoriaTipo";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@AuditoriaTipo_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AuditoriaTipo_id"].Value = _AUD_AuditoriaTipoBE.AuditoriaTipo_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Auditoria_Desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Auditoria_Desc"].Value = _AUD_AuditoriaTipoBE.Auditoria_Desc;
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

        public AUD_AuditoriaTipoBE TraerAUD_AuditoriaTipoById(int _AuditoriaTipo_id)
        {
            string conexion = MiConexion.GetCnx();
            AUD_AuditoriaTipoBE obeAuditoriaTipoBE = null;
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerAUD_AuditoriaTipoById";
                cmd.Parameters.Add(new SqlParameter("@AuditoriaTipo_id", SqlDbType.Int));
                cmd.Parameters["@AuditoriaTipo_id"].Value = _AuditoriaTipo_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    obeAuditoriaTipoBE = new AUD_AuditoriaTipoBE();
                    obeAuditoriaTipoBE.AuditoriaTipo_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("AuditoriaTipo_id")));
                    obeAuditoriaTipoBE.Auditoria_Desc = dtr.GetValue(dtr.GetOrdinal("Auditoria_Desc")).ToString();
                    obeAuditoriaTipoBE.Departamento_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Departamento_id")));
                    dtr.Close();

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (obeAuditoriaTipoBE);
        }
    }
}
