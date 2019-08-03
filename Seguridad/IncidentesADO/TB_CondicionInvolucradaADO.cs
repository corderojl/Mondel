using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_CondicionInvolucradaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_CondicionInvolucrada_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_CondicionInvolucrada_All";
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
        public List<TB_CondicionInvolucradaBE> ListarTB_CondicionInvolucradaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_CondicionInvolucradaBE> lTB_CondicionInvolucradaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_CondicionInvolucrada_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_CondicionInvolucradaBE = new List<TB_CondicionInvolucradaBE>();
                int posCondicion_inv_id = drd.GetOrdinal("Condicion_inv_id");
                int posCondicion_inv_desc = drd.GetOrdinal("Condicion_inv_desc");
                TB_CondicionInvolucradaBE obeCondicionInvolucradaBE = null;
                while (drd.Read())
                {
                    obeCondicionInvolucradaBE = new TB_CondicionInvolucradaBE();
                    obeCondicionInvolucradaBE.Condicion_inv_id = drd.GetInt16(posCondicion_inv_id);
                    obeCondicionInvolucradaBE.Condicion_inv_desc = drd.GetString(posCondicion_inv_desc);
                    lTB_CondicionInvolucradaBE.Add(obeCondicionInvolucradaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_CondicionInvolucradaBE);
        }
        public DataTable ListarTB_CondicionInvolucrada_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_CondicionInvolucrada_Act";
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

        public int InsertarTB_CondicionInvolucrada(TB_CondicionInvolucradaBE _TB_CondicionInvolucradaBE)
        {
            int IdCondicionInvolucrada = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_CondicionInvolucrada";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CondicionInvolucrada_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CondicionInvolucrada_desc"].Value = _TB_CondicionInvolucradaBE.Condicion_inv_desc;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdCondicionInvolucrada = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdCondicionInvolucrada = -1;
            }
            catch (Exception x)
            {
                IdCondicionInvolucrada = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdCondicionInvolucrada);
        }
        public bool ActualizarTB_CondicionInvolucrada(TB_CondicionInvolucradaBE _TB_CondicionInvolucradaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_CondicionInvolucrada";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@CondicionInvolucrada_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CondicionInvolucrada_id"].Value = _TB_CondicionInvolucradaBE.Condicion_inv_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@CondicionInvolucrada_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CondicionInvolucrada_desc"].Value = _TB_CondicionInvolucradaBE.Condicion_inv_desc;
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
        public bool EliminarTB_CondicionInvolucrada(int _CondicionInvolucrada_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_CondicionInvolucrada";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@CondicionInvolucrada_id", SqlDbType.Int));
                cmd.Parameters["@CondicionInvolucrada_id"].Value = _CondicionInvolucrada_id;
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
