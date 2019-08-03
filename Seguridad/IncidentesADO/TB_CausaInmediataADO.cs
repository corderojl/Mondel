using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IncidentesBE;

namespace IncidentesADO
{
    public class TB_CausaInmediataADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_CausaInmediata_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_CausaInmediata_All";
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
        public List<TB_CausaInmediataBE> ListarTB_CausaInmediataO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_CausaInmediataBE> lTB_CausaInmediataBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_CausaInmediata_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_CausaInmediataBE = new List<TB_CausaInmediataBE>();
                int posCausainmediata_id = drd.GetOrdinal("Causainmediata_id");
                int posCausainmediata_desc = drd.GetOrdinal("Causainmediata_desc");
                TB_CausaInmediataBE obeCausaInmediataBE = null;
                while (drd.Read())
                {
                    obeCausaInmediataBE = new TB_CausaInmediataBE();
                    obeCausaInmediataBE.Causainmediata_id = drd.GetInt16(posCausainmediata_id);
                    obeCausaInmediataBE.Causainmediata_desc = drd.GetString(posCausainmediata_desc);
                    lTB_CausaInmediataBE.Add(obeCausaInmediataBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_CausaInmediataBE);
        }
        public DataTable ListarTB_CausaInmediata_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_CausaInmediata_Act";
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

        public int InsertarTB_CausaInmediata(TB_CausaInmediataBE _TB_CausaInmediataBE)
        {
            int IdCausaInmediata = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_CausaInmediata";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CausaInmediata_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CausaInmediata_desc"].Value = _TB_CausaInmediataBE.Causainmediata_desc;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdCausaInmediata = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdCausaInmediata = -1;
            }
            catch (Exception x)
            {
                IdCausaInmediata = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdCausaInmediata);
        }
        public bool ActualizarTB_CausaInmediata(TB_CausaInmediataBE _TB_CausaInmediataBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_CausaInmediata";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CausaInmediata_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CausaInmediata_id"].Value = _TB_CausaInmediataBE.Causainmediata_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@CausaInmediata_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CausaInmediata_desc"].Value = _TB_CausaInmediataBE.Causainmediata_desc;
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
        public bool EliminarTB_CausaInmediata(int _CausaInmediata_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_CausaInmediata";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@CausaInmediata_id", SqlDbType.Int));
                cmd.Parameters["@CausaInmediata_id"].Value = _CausaInmediata_id;
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
    }
}
