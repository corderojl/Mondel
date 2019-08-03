using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_EquipoAfectadoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_EquipoAfectado_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_EquipoAfectado_All";
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
        public List<TB_EquipoAfectadoBE> ListarTB_EquipoAfectadoO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_EquipoAfectadoBE> lTB_EquipoAfectadoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_EquipoAfectado_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_EquipoAfectadoBE = new List<TB_EquipoAfectadoBE>();
                int posEquipoAfectado_id = drd.GetOrdinal("EquipoAfectado_id");
                int posEquipoAfectado_desc = drd.GetOrdinal("EquipoAfectado_desc");
                TB_EquipoAfectadoBE obeEquipoAfectadoBE = null;
                while (drd.Read())
                {
                    obeEquipoAfectadoBE = new TB_EquipoAfectadoBE();
                    obeEquipoAfectadoBE.EquipoAfectado_id = drd.GetInt16(posEquipoAfectado_id);
                    obeEquipoAfectadoBE.EquipoAfectado_desc = drd.GetString(posEquipoAfectado_desc);
                    lTB_EquipoAfectadoBE.Add(obeEquipoAfectadoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_EquipoAfectadoBE);
        }
        public DataTable ListarTB_EquipoAfectado_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_EquipoAfectado_Act";
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
