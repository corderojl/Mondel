using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_TipoDanioADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_TipoDanio_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_TipoDanio_All";
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
        public List<TB_TipoDanioBE> ListarTB_TipoDanioO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_TipoDanioBE> lTB_TipoDanioBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_TipoDanio_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_TipoDanioBE = new List<TB_TipoDanioBE>();
                int posTipoDanio_id = drd.GetOrdinal("TipoDanio_id");
                int posTipoDanio_desc = drd.GetOrdinal("TipoDanio_desc");
                TB_TipoDanioBE obeTipoDanioBE = null;
                while (drd.Read())
                {
                    obeTipoDanioBE = new TB_TipoDanioBE();
                    obeTipoDanioBE.TipoDanio_id = drd.GetInt16(posTipoDanio_id);
                    obeTipoDanioBE.TipoDanio_desc = drd.GetString(posTipoDanio_desc);
                    lTB_TipoDanioBE.Add(obeTipoDanioBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_TipoDanioBE);
        }
        public DataTable ListarTB_TipoDanio_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_TipoDanio_Act";
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

        public int InsertarTB_TipoDanio(TB_TipoDanioBE _TB_TipoDanioBE)
        {
            int IdTipoDanio = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_TipoDanio";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@TipoDanio_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@TipoDanio_desc"].Value = _TB_TipoDanioBE.TipoDanio_desc;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdTipoDanio = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdTipoDanio = -1;
            }
            catch (Exception x)
            {
                IdTipoDanio = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdTipoDanio);
        }
        public bool ActualizarTB_TipoDanio(TB_TipoDanioBE _TB_TipoDanioBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_TipoDanio";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@TipoDanio_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@TipoDanio_id"].Value = _TB_TipoDanioBE.TipoDanio_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@TipoDanio_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@TipoDanio_desc"].Value = _TB_TipoDanioBE.TipoDanio_desc;
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
        public bool EliminarTB_TipoDanio(int _TipoDanio_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_TipoDanio";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@TipoDanio_id", SqlDbType.Int));
                cmd.Parameters["@TipoDanio_id"].Value = _TipoDanio_id;
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
