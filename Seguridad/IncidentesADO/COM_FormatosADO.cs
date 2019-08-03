using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class COM_FormatosADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarCOM_Formatos_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarCOM_Formatos_All";
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
        public List<COM_FormatosBE> ListarCOM_FormatosO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<COM_FormatosBE> lCOM_FormatosBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarCOM_Formatos_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lCOM_FormatosBE = new List<COM_FormatosBE>();
                int posFormato_id = drd.GetOrdinal("Formato_id");
                int posFormato_desc = drd.GetOrdinal("Formato_desc");
                int posFormato_tipo = drd.GetOrdinal("Formato_tipo");
                int posAreaLabor_id = drd.GetOrdinal("AreaLabor_id");
                COM_FormatosBE obeFormatosBE = null;
                while (drd.Read())
                {
                    obeFormatosBE = new COM_FormatosBE();
                    obeFormatosBE.Formato_id = drd.GetInt16(posFormato_id);
                    obeFormatosBE.Formato_desc = drd.GetString(posFormato_desc);
                    obeFormatosBE.Formato_tipo = drd.GetInt16(posFormato_tipo);
                    obeFormatosBE.AreaLabor_id = drd.GetInt16(posAreaLabor_id);
                    lCOM_FormatosBE.Add(obeFormatosBE);
                }
                drd.Close();
            }
            con.Close();
            return (lCOM_FormatosBE);
        }
        public List<COM_FormatosBE> ListarCOM_FormatosByDepartamentoO_Act(Int16 _AreaLabor_id)
        {
            string conexion = MiConexion.GetCnx();
            List<COM_FormatosBE> lCOM_FormatosBE = null;
            SqlConnection con = new SqlConnection(conexion);
            SqlParameter par1;
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarCOM_FormatosByDepartamento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.SmallInt));
            par1.Direction = ParameterDirection.Input;
            cmd.Parameters["@AreaLabor_id"].Value = _AreaLabor_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lCOM_FormatosBE = new List<COM_FormatosBE>();
                int posFormato_id = drd.GetOrdinal("Formato_id");
                int posFormato_desc = drd.GetOrdinal("Formato_desc");
                int posFormato_tipo = drd.GetOrdinal("Formato_tipo");
                COM_FormatosBE obeFormatosBE = null;
                while (drd.Read())
                {
                    obeFormatosBE = new COM_FormatosBE();
                    obeFormatosBE.Formato_id = drd.GetInt16(posFormato_id);
                    obeFormatosBE.Formato_desc = drd.GetString(posFormato_desc);
                    obeFormatosBE.Formato_tipo = drd.GetInt16(posFormato_tipo);
                    lCOM_FormatosBE.Add(obeFormatosBE);
                }
                drd.Close();
            }
            con.Close();
            return (lCOM_FormatosBE);
        }
        public DataTable ListarCOM_Formatos_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarCOM_Formatos_Act";
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
        public int InsertarCOM_Formato(COM_FormatosBE _COM_FormatosBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarCOM_Formato";
            SqlParameter par1;
            int _Formato_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Formato_desc", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Formato_desc"].Value = _COM_FormatosBE.Formato_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Formato_tipo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Formato_tipo"].Value = _COM_FormatosBE.Formato_tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor_id"].Value = _COM_FormatosBE.AreaLabor_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Formato_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("@@identity")));
            }
            catch (SqlException x)
            {
                _Formato_id = 0;
            }
            catch (Exception x)
            {
                _Formato_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Formato_id;
        }
        public bool ActualizarCOM_Formato(COM_FormatosBE _COM_FormatosBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarCOM_Formato";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Formato_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Formato_id"].Value = _COM_FormatosBE.Formato_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Formato_desc", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Formato_desc"].Value = _COM_FormatosBE.Formato_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Formato_tipo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Formato_tipo"].Value = _COM_FormatosBE.Formato_tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor_id"].Value = _COM_FormatosBE.AreaLabor_id;
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
