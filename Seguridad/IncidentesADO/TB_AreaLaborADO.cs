using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
   public class TB_AreaLaborADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_AreaLabor_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_AreaLabor_All";
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
        public List<TB_AreaLaborBE> ListarTB_AreaLaborO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_AreaLaborBE> lTB_AreaLaborBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_AreaLabor_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_AreaLaborBE = new List<TB_AreaLaborBE>();
                int posAreaLabor_id = drd.GetOrdinal("AreaLabor_id");
                int posAreaLabor_desc = drd.GetOrdinal("AreaLabor_desc");
                TB_AreaLaborBE obeAreaLaborBE = null;
                while (drd.Read())
                {
                    obeAreaLaborBE = new TB_AreaLaborBE();
                    obeAreaLaborBE.AreaLabor_id = drd.GetInt16(posAreaLabor_id);
                    obeAreaLaborBE.AreaLabor_desc = drd.GetString(posAreaLabor_desc);
                    lTB_AreaLaborBE.Add(obeAreaLaborBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_AreaLaborBE);
        }
        public DataTable ListarTB_AreaLabor_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_AreaLabor_Act";
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
