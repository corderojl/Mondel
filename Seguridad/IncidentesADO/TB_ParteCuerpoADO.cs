using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_ParteCuerpoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_ParteCuerpo_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_ParteCuerpo_All";
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
        public List<TB_ParteCuerpoBE> ListarTB_ParteCuerpoO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_ParteCuerpoBE> lTB_ParteCuerpoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_ParteCuerpo_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_ParteCuerpoBE = new List<TB_ParteCuerpoBE>();
                int posParteCuerpo_id = drd.GetOrdinal("ParteCuerpo_id");
                int posParteCuerpo_desc = drd.GetOrdinal("ParteCuerpo_desc");
                int posTipoDanio = drd.GetOrdinal("TipoDanio");
                TB_ParteCuerpoBE obeParteCuerpoBE = null;
                while (drd.Read())
                {
                    obeParteCuerpoBE = new TB_ParteCuerpoBE();
                    obeParteCuerpoBE.ParteCuerpo_id = drd.GetInt16(posParteCuerpo_id);
                    obeParteCuerpoBE.ParteCuerpo_desc = drd.GetString(posParteCuerpo_desc);
                    obeParteCuerpoBE.TipoDanio = drd.GetInt32(posTipoDanio);
                    lTB_ParteCuerpoBE.Add(obeParteCuerpoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_ParteCuerpoBE);
        }
        public DataTable ListarTB_ParteCuerpo_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_ParteCuerpo_Act";
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
        public List<TB_ParteCuerpoBE> ListarTB_ParteCuerpoByTipoIncidente(short _TipoIncidente_id)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_ParteCuerpoBE> lTB_ParteCuerpoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlParameter par1;
            SqlCommand cmd = new SqlCommand("sp_ListarTB_ParteCuerpoByTipoDanio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            par1 = cmd.Parameters.Add(new SqlParameter("@TipoDanio", SqlDbType.Int));
            par1.Direction = ParameterDirection.Input;
            cmd.Parameters["@TipoDanio"].Value = _TipoIncidente_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_ParteCuerpoBE = new List<TB_ParteCuerpoBE>();
                int posParteCuerpo_id = drd.GetOrdinal("ParteCuerpo_id");
                int posParteCuerpo_desc = drd.GetOrdinal("ParteCuerpo_desc");
                int posTipoDanio = drd.GetOrdinal("TipoDanio");
                TB_ParteCuerpoBE obeParteCuerpoBE = null;
                while (drd.Read())
                {
                    obeParteCuerpoBE = new TB_ParteCuerpoBE();
                    obeParteCuerpoBE.ParteCuerpo_id = drd.GetInt16(posParteCuerpo_id);
                    obeParteCuerpoBE.ParteCuerpo_desc = drd.GetString(posParteCuerpo_desc);
                    obeParteCuerpoBE.TipoDanio = drd.GetInt32(posTipoDanio);
                    lTB_ParteCuerpoBE.Add(obeParteCuerpoBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_ParteCuerpoBE);
        }

        public int InsertarTB_ParteCuerpo(TB_ParteCuerpoBE _TB_ParteCuerpoBE)
        {
            int IdParteCuerpo = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_ParteCuerpo";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@ParteCuerpo_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ParteCuerpo_desc"].Value = _TB_ParteCuerpoBE.ParteCuerpo_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@TipoDanio", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@TipoDanio"].Value = _TB_ParteCuerpoBE.TipoDanio;
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdParteCuerpo = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdParteCuerpo = -1;
            }
            catch (Exception x)
            {
                IdParteCuerpo = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdParteCuerpo);
        }
        public bool ActualizarTB_ParteCuerpo(TB_ParteCuerpoBE _TB_ParteCuerpoBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_ParteCuerpo";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@ParteCuerpo_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ParteCuerpo_id"].Value = _TB_ParteCuerpoBE.ParteCuerpo_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@ParteCuerpo_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ParteCuerpo_desc"].Value = _TB_ParteCuerpoBE.ParteCuerpo_desc;
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
        public bool EliminarTB_ParteCuerpo(int _ParteCuerpo_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_ParteCuerpo";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@ParteCuerpo_id", SqlDbType.Int));
                cmd.Parameters["@ParteCuerpo_id"].Value = _ParteCuerpo_id;
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
