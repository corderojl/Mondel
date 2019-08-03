using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_AreaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_Area_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Area_All";
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
        public List<TB_AreaBE> ListarTB_AreaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_AreaBE> lTB_AreaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_Area_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_AreaBE = new List<TB_AreaBE>();
                int posArea_id = drd.GetOrdinal("Area_id");
                int posArea_desc = drd.GetOrdinal("Area_desc");
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                TB_AreaBE obeAreaBE = null;
                while (drd.Read())
                {
                    obeAreaBE = new TB_AreaBE();
                    obeAreaBE.Area_id = drd.GetInt16(posArea_id);
                    obeAreaBE.Area_desc = drd.GetString(posArea_desc);
                    obeAreaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    lTB_AreaBE.Add(obeAreaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_AreaBE);
        }
        public DataTable ListarTB_Area_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Area_Act";
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

        public List<TB_AreaBE> ListarTB_AreaByDepartamento(short _Departamento_id)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_AreaBE> lTB_AreaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlParameter par1;
            SqlCommand cmd = new SqlCommand("sp_ListarTB_AreaByDepartamento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
            par1.Direction = ParameterDirection.Input;
            cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_AreaBE = new List<TB_AreaBE>();
                int posArea_id = drd.GetOrdinal("Area_id");
                int posArea_desc = drd.GetOrdinal("Area_desc");
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                TB_AreaBE obeAreaBE = null;
                while (drd.Read())
                {
                    obeAreaBE = new TB_AreaBE();
                    obeAreaBE.Area_id = drd.GetInt16(posArea_id);
                    obeAreaBE.Area_desc = drd.GetString(posArea_desc);
                    obeAreaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    lTB_AreaBE.Add(obeAreaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_AreaBE);
        }

        public int InsertarTB_Area(TB_AreaBE _TB_AreaBE)
        {
            int IdArea = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_Area";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_desc"].Value = _TB_AreaBE.Area_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _TB_AreaBE.Departamento_id;
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdArea = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdArea = -1;
            }
            catch (Exception x)
            {
                IdArea = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdArea);
        }
        public bool ActualizarTB_Area(TB_AreaBE _TB_AreaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_Area";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_id"].
                    Value = _TB_AreaBE.Area_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_desc"].Value = _TB_AreaBE.Area_desc;
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
        public bool EliminarTB_Area(int _Area_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_Area";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.Int));
                cmd.Parameters["@Area_id"].Value = _Area_id;
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
