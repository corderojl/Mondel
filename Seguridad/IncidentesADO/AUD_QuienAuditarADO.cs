using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class AUD_QuienAuditarADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarAUD_QuienAuditar_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_QuienAuditarAll";
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
        public List<AUD_QuienAuditarBE> ListarAUD_QuienAuditarO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<AUD_QuienAuditarBE> lAUD_QuienAuditarBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAUD_QuienAuditarAct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lAUD_QuienAuditarBE = new List<AUD_QuienAuditarBE>();
                    int posQuienAuditar_id = drd.GetOrdinal("QuienAuditar_id");
                    int posQuienAuditar_Desc = drd.GetOrdinal("QuienAuditar_Desc");
                    AUD_QuienAuditarBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new AUD_QuienAuditarBE();
                        obeCategoriaBE.QuienAuditar_id = drd.GetInt16(posQuienAuditar_id);
                        obeCategoriaBE.QuienAuditar_Desc = drd.GetString(posQuienAuditar_Desc);
                        lAUD_QuienAuditarBE.Add(obeCategoriaBE);
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
            return (lAUD_QuienAuditarBE);
        }

        public DataTable ListarAUD_QuienAuditar_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarAUD_QuienAuditarAct";
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
