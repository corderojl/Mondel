using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_ElementoClaveADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_ElementoClave_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_ElementoClave_All";
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
        public List<TB_ElementoClaveBE> ListarTB_ElementoClaveO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_ElementoClaveBE> lTB_ElementoClaveBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_ElementoClave_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_ElementoClaveBE = new List<TB_ElementoClaveBE>();
                int posElementoClave_id = drd.GetOrdinal("ElementoClave_id");
                int posElementoClave_desc = drd.GetOrdinal("ElementoClave_desc");
                TB_ElementoClaveBE obeElementoClaveBE = null;
                while (drd.Read())
                {
                    obeElementoClaveBE = new TB_ElementoClaveBE();
                    obeElementoClaveBE.ElementoClave_id = drd.GetInt16(posElementoClave_id);
                    obeElementoClaveBE.ElementoClave_desc = drd.GetString(posElementoClave_desc);
                    lTB_ElementoClaveBE.Add(obeElementoClaveBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_ElementoClaveBE);
        }
        public DataTable ListarTB_ElementoClave_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_ElementoClave_Act";
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
