using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_RiesgoInvolucradoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_RiesgoInvolucrado_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_RiesgoInvolucrado_All";
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
        public List<TB_RiesgoInvolucradoBE> ListarTB_RiesgoInvolucradoO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_RiesgoInvolucradoBE> lTB_RiesgoInvolucradoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_RiesgoInvolucrado_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_RiesgoInvolucradoBE = new List<TB_RiesgoInvolucradoBE>();
                int posRiesgo_inv_id = drd.GetOrdinal("Riesgo_inv_id");
                int posRiesgo_inv_desc = drd.GetOrdinal("Riesgo_inv_desc");
                TB_RiesgoInvolucradoBE obeRiesgoInvolucradoBE = null;
                while (drd.Read())
                {
                    obeRiesgoInvolucradoBE = new TB_RiesgoInvolucradoBE();
                    obeRiesgoInvolucradoBE.Riesgo_inv_id = drd.GetInt16(posRiesgo_inv_id);
                    obeRiesgoInvolucradoBE.Riesgo_inv_desc = drd.GetString(posRiesgo_inv_desc);
                    lTB_RiesgoInvolucradoBE.Add(obeRiesgoInvolucradoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_RiesgoInvolucradoBE);
        }
        public DataTable ListarTB_RiesgoInvolucrado_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_RiesgoInvolucrado_Act";
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

        public int InsertarTB_RiesgoInvolucrado(TB_RiesgoInvolucradoBE _TB_RiesgoInvolucradoBE)
        {
            int IdRiesgoInvolucrado = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_RiesgoInvolucrado";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@RiesgoInvolucrado_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@RiesgoInvolucrado_desc"].Value = _TB_RiesgoInvolucradoBE.Riesgo_inv_desc;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdRiesgoInvolucrado = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdRiesgoInvolucrado = -1;
            }
            catch (Exception x)
            {
                IdRiesgoInvolucrado = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdRiesgoInvolucrado);
        }
        public bool ActualizarTB_RiesgoInvolucrado(TB_RiesgoInvolucradoBE _TB_RiesgoInvolucradoBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_RiesgoInvolucrado";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@RiesgoInvolucrado_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@RiesgoInvolucrado_id"].Value = _TB_RiesgoInvolucradoBE.Riesgo_inv_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@RiesgoInvolucrado_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@RiesgoInvolucrado_desc"].Value = _TB_RiesgoInvolucradoBE.Riesgo_inv_desc;
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
        public bool EliminarTB_RiesgoInvolucrado(int _RiesgoInvolucrado_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_RiesgoInvolucrado";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@RiesgoInvolucrado_id", SqlDbType.Int));
                cmd.Parameters["@RiesgoInvolucrado_id"].Value = _RiesgoInvolucrado_id;
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
