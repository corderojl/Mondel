using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class EVA_AreaLaborADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarEVA_AreaLabor_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_AreaLabor_All";
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
        public List<EVA_AreaLaborBE> ListarEVA_AreaLaborO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<EVA_AreaLaborBE> lEVA_AreaLaborBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEVA_AreaLabor_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lEVA_AreaLaborBE = new List<EVA_AreaLaborBE>();
                    int posAreaLabor_id = drd.GetOrdinal("AreaLabor_id");
                    int posAreaLabor_desc = drd.GetOrdinal("AreaLabor_desc");
                    EVA_AreaLaborBE obeAreaLaborBE = null;
                    while (drd.Read())
                    {
                        obeAreaLaborBE = new EVA_AreaLaborBE();
                        obeAreaLaborBE.AreaLabor_id = drd.GetInt16(posAreaLabor_id);
                        obeAreaLaborBE.AreaLabor_desc = drd.GetString(posAreaLabor_desc);

                        lEVA_AreaLaborBE.Add(obeAreaLaborBE);
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
            return (lEVA_AreaLaborBE);
        }
        
        public DataTable ListarEVA_AreaLabor_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_AreaLabor_Act";
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
        public int InsertarEVA_AreaLabor(EVA_AreaLaborBE _EVA_AreaLaborBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarEVA_AreaLabor";
            SqlParameter par1;
            int _AreaLabor_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor_desc"].Value = _EVA_AreaLaborBE.AreaLabor_desc;      
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _AreaLabor_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("@@identity")));
            }
            catch (SqlException x)
            {
                _AreaLabor_id = 0;
            }
            catch (Exception x)
            {
                _AreaLabor_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _AreaLabor_id;
        }
        public bool ActualizarEVA_AreaLabor(EVA_AreaLaborBE _EVA_AreaLaborBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarEVA_AreaLabor";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor_id"].Value = _EVA_AreaLaborBE.AreaLabor_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor_desc"].Value = _EVA_AreaLaborBE.AreaLabor_desc;
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

        public EVA_AreaLaborBE TraerEVA_AreaLaborById(int _AreaLabor_id)
        {
            string conexion = MiConexion.GetCnx();
            EVA_AreaLaborBE obeAreaLaborBE = null;
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerEVA_AreaLaborById";
                cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.Int));
                cmd.Parameters["@AreaLabor_id"].Value = _AreaLabor_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    obeAreaLaborBE = new EVA_AreaLaborBE();
                    obeAreaLaborBE.AreaLabor_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("AreaLabor_id")));
                    obeAreaLaborBE.AreaLabor_desc = dtr.GetValue(dtr.GetOrdinal("AreaLabor_desc")).ToString();
                    dtr.Close();

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (obeAreaLaborBE);
        }
    }
}
