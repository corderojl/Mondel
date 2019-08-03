using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_CausaRaizADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_CausaRaiz_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_CausaRaiz_All";
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
        public List<TB_CausaRaizBE> ListarTB_CausaRaizO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_CausaRaizBE> lTB_CausaRaizBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_CausaRaiz_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_CausaRaizBE = new List<TB_CausaRaizBE>();
                int posCausaRaiz_id = drd.GetOrdinal("CausaRaiz_id");
                int posCausaRaiz_desc = drd.GetOrdinal("CausaRaiz_desc");
                TB_CausaRaizBE obeCausaRaizBE = null;
                while (drd.Read())
                {
                    obeCausaRaizBE = new TB_CausaRaizBE();
                    obeCausaRaizBE.CausaRaiz_id = drd.GetInt16(posCausaRaiz_id);
                    obeCausaRaizBE.CausaRaiz_desc = drd.GetString(posCausaRaiz_desc);
                    lTB_CausaRaizBE.Add(obeCausaRaizBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_CausaRaizBE);
        }
        public DataTable ListarTB_CausaRaiz_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_CausaRaiz_Act";
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

        public int InsertarTB_CausaRaiz(TB_CausaRaizBE _TB_CausaRaizBE)
        {
            int IdCausaRaiz = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_CausaRaiz";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CausaRaiz_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CausaRaiz_desc"].Value = _TB_CausaRaizBE.CausaRaiz_desc;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdCausaRaiz = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdCausaRaiz = -1;
            }
            catch (Exception x)
            {
                IdCausaRaiz = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdCausaRaiz);
        }
        public bool ActualizarTB_CausaRaiz(TB_CausaRaizBE _TB_CausaRaizBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_CausaRaiz";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CausaRaiz_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CausaRaiz_id"].Value = _TB_CausaRaizBE.CausaRaiz_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@CausaRaiz_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CausaRaiz_desc"].Value = _TB_CausaRaizBE.CausaRaiz_desc;
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
        public bool EliminarTB_CausaRaiz(int _CausaRaiz_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_CausaRaiz";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@CausaRaiz_id", SqlDbType.Int));
                cmd.Parameters["@CausaRaiz_id"].Value = _CausaRaiz_id;
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
