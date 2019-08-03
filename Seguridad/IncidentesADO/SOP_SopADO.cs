using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class SOP_SopADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarALR_ElementoClave_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnxI();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_ElementoClave_All";
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
        public DataTable sp_ListarSOP_DuenoCaducado()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarSOP_DuenoCaducado";
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
        //public List<ALR_ElementoClaveBE> ListarALR_ElementoClaveO_Act()
        //{
        //    string conexion = MiConexion.GetCnx();
        //    List<ALR_ElementoClaveBE> lALR_ElementoClaveBE = null;
        //    SqlConnection con = new SqlConnection(conexion);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("sp_ListarALR_ElementoClave_Act", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
        //    if (drd != null)
        //    {
        //        lALR_ElementoClaveBE = new List<ALR_ElementoClaveBE>();
        //        int posElementoClave_id = drd.GetOrdinal("ElementoClave_id");
        //        int posElementoClave_desc = drd.GetOrdinal("ElementoClave_desc");
        //        ALR_ElementoClaveBE obeElementoClaveBE = null;
        //        while (drd.Read())
        //        {
        //            obeElementoClaveBE = new ALR_ElementoClaveBE();
        //            obeElementoClaveBE.ElementoClave_id = drd.GetInt16(posElementoClave_id);
        //            obeElementoClaveBE.ElementoClave_desc = drd.GetString(posElementoClave_desc);
        //            lALR_ElementoClaveBE.Add(obeElementoClaveBE);
        //        }
        //        drd.Close();
        //    }
        //    con.Close();
        //    return (lALR_ElementoClaveBE);
        //}
        public DataTable ListarALR_ElementoClave_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_ElementoClave_Act";
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
        //public int InsertarALR_ElementoClave(ALR_ElementoClaveBE _ALR_ElementoClaveBE)
        //{
        //    int IdElementoClave = -1;
        //    cnx.ConnectionString = MiConexion.GetCnx();
        //    cmd.Connection = cnx;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "sp_InsertarALR_ElementoClave";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        SqlParameter par1 = cmd.Parameters.Add("@ElementoClave_desc", SqlDbType.NVarChar, 200);
        //        par1.Direction = ParameterDirection.Input;
        //        par1.Value = _ALR_ElementoClaveBE.ElementoClave_desc;

        //        SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
        //        par4.Direction = ParameterDirection.ReturnValue;
        //        cnx.Open();
        //        int n = cmd.ExecuteNonQuery();
        //        if (n > 0) IdElementoClave = (int)par4.Value;
        //    }
        //    catch (SqlException x)
        //    {
        //        IdElementoClave = -1;
        //    }
        //    catch (Exception x)
        //    {
        //        IdElementoClave = -1;
        //    }
        //    finally
        //    {
        //        if (cnx.State == ConnectionState.Open)
        //        {
        //            cnx.Close();
        //        }
        //        cmd.Parameters.Clear();
        //    }
        //    return (IdElementoClave);
        //}
        //public bool ActualizarALR_ElementoClave(ALR_ElementoClaveBE _ALR_ElementoClaveBE)
        //{
        //    cnx.ConnectionString = MiConexion.GetCnx();
        //    cmd.Connection = cnx;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "sp_ActualizarALR_ElementoClave";
        //    SqlParameter par1;
        //    bool _vcod;
        //    try
        //    {
        //        par1 = cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.Int));
        //        par1.Direction = ParameterDirection.Input;
        //        cmd.Parameters["@ElementoClave_id"].Value = _ALR_ElementoClaveBE.ElementoClave_id;
        //        par1 = cmd.Parameters.Add(new SqlParameter("@ElementoClave_desc", SqlDbType.VarChar, 200));
        //        par1.Direction = ParameterDirection.Input;
        //        cmd.Parameters["@ElementoClave_desc"].Value = _ALR_ElementoClaveBE.ElementoClave_desc;
        //        cnx.Open();
        //        cmd.ExecuteNonQuery();
        //        _vcod = true;

        //    }
        //    catch (SqlException x)
        //    {
        //        _vcod = false;
        //    }
        //    catch (Exception x)
        //    {
        //        _vcod = false;
        //    }
        //    finally
        //    {
        //        if (cnx.State == ConnectionState.Open)
        //        {
        //            cnx.Close();
        //        }
        //        cmd.Parameters.Clear();
        //    }

        //    return _vcod;
        //}
        public bool EliminarALR_ElementoClave(Int16 ElementoClave_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarALR_ElementoClave";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ElementoClave_id"].Value = ElementoClave_id;
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
    }
}
