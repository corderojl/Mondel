using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_DepartamentoADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        
        public List<TB_DepartamentoBE> ListarTB_DepartamentoO_Act(string Sistema_id)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_DepartamentoBE> lTB_DepartamentoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_Departamento_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = cmd.Parameters.Add("@Sistema_id", SqlDbType.VarChar,8);
            par1.Direction = ParameterDirection.Input;
            par1.Value = Sistema_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            
            if (drd != null)
            {
                lTB_DepartamentoBE = new List<TB_DepartamentoBE>();
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                int posDepartamento_desc = drd.GetOrdinal("Departamento_desc");
                int posSigla = drd.GetOrdinal("Sigla");
                int posSector_id = drd.GetOrdinal("Sector_id");
                TB_DepartamentoBE obeDepartamentoBE = null;
                while (drd.Read())
                {
                    obeDepartamentoBE = new TB_DepartamentoBE();
                    obeDepartamentoBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    obeDepartamentoBE.Departamento_desc = drd.GetString(posDepartamento_desc);
                    obeDepartamentoBE.Sigla = drd.GetString(posSigla);
                    obeDepartamentoBE.Sector_id = drd.GetInt16(posSector_id);
                    lTB_DepartamentoBE.Add(obeDepartamentoBE);
                }
                drd.Close();

            }
            con.Close();
            return (lTB_DepartamentoBE);
        }
        public DataTable ListarTB_Departamento_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Departamento_Act";
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

        public List<TB_DepartamentoBE> ListarTB_DepartamentoSuperiorO_Act(short _Superior)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_DepartamentoBE> lTB_DepartamentoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_DepartamentoSuperior_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = cmd.Parameters.Add("@Superior", SqlDbType.SmallInt);
            par1.Direction = ParameterDirection.Input;
            par1.Value = _Superior;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                lTB_DepartamentoBE = new List<TB_DepartamentoBE>();
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                int posDepartamento_desc = drd.GetOrdinal("Departamento_desc");
                int posSector_id = drd.GetOrdinal("Sector_id");
                TB_DepartamentoBE obeDepartamentoBE = null;
                while (drd.Read())
                {
                    obeDepartamentoBE = new TB_DepartamentoBE();
                    obeDepartamentoBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    obeDepartamentoBE.Departamento_desc = drd.GetString(posDepartamento_desc);
                    obeDepartamentoBE.Sector_id = drd.GetInt16(posSector_id);
                    lTB_DepartamentoBE.Add(obeDepartamentoBE);
                }
                drd.Close();

            }
            con.Close();
            return (lTB_DepartamentoBE);
        }

        public List<TB_DepartamentoBE> ListarTB_Departamento_All(string Sistema_id)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_DepartamentoBE> lTB_DepartamentoBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_Departamento_All", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = cmd.Parameters.Add("@Sistema_id", SqlDbType.VarChar, 8);
            par1.Direction = ParameterDirection.Input;
            par1.Value = Sistema_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
          
            if (drd != null)
            {
                lTB_DepartamentoBE = new List<TB_DepartamentoBE>();
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                int posDepartamento_desc = drd.GetOrdinal("Departamento_desc");
                int posSector_id = drd.GetOrdinal("Sector_id");
                TB_DepartamentoBE obeDepartamentoBE = null;
                while (drd.Read())
                {
                    obeDepartamentoBE = new TB_DepartamentoBE();
                    obeDepartamentoBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    obeDepartamentoBE.Departamento_desc = drd.GetString(posDepartamento_desc);
                    obeDepartamentoBE.Sector_id = drd.GetInt16(posSector_id);
                    lTB_DepartamentoBE.Add(obeDepartamentoBE);
                }
                drd.Close();

            }
            con.Close();
            return (lTB_DepartamentoBE);
        }

        public int InsertarTB_Departamento(TB_DepartamentoBE _TB_DepartamentoBE)
        {
            int IdDepartamento = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_Departamento";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_desc"].Value = _TB_DepartamentoBE.Departamento_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Sigla", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sigla"].Value = _TB_DepartamentoBE.Sigla;
                par1 = cmd.Parameters.Add(new SqlParameter("@Sector_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sector_id"].Value = _TB_DepartamentoBE.Sector_id; 
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdDepartamento = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdDepartamento = -1;
            }
            catch (Exception x)
            {
                IdDepartamento = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdDepartamento);
        }
        public bool ActualizarTB_Departamento(TB_DepartamentoBE _TB_DepartamentoBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_Departamento";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _TB_DepartamentoBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_desc"].Value = _TB_DepartamentoBE.Departamento_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Sigla", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sigla"].Value = _TB_DepartamentoBE.Sigla;      
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
        public bool EliminarTB_Departamento(int _Departamento_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_Departamento";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
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

        public DataTable ListarTB_DepartamentoBySector()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_DepartamentoBySector";
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
    }
}
