using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class ALR_SistemaqaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarALR_Sistemaqa_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_Sistemaqa_All";
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
        public List<ALR_SistemaqaBE> ListarALR_SistemaqaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<ALR_SistemaqaBE> lALR_SistemaqaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarALR_Sistemaqa_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lALR_SistemaqaBE = new List<ALR_SistemaqaBE>();
                int posSistemaQA_id = drd.GetOrdinal("SistemaQA_id");
                int posSistemaQA_desc = drd.GetOrdinal("SistemaQA_desc");
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                int posSistemaQA_nom = drd.GetOrdinal("SistemaQA_nom");
                ALR_SistemaqaBE obeSistemaBE = null;
                while (drd.Read())
                {
                    obeSistemaBE = new ALR_SistemaqaBE();
                    obeSistemaBE.SistemaQA_id = drd.GetInt16(posSistemaQA_id);
                    obeSistemaBE.SistemaQA_desc = drd.GetString(posSistemaQA_desc);
                    obeSistemaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    obeSistemaBE.SistemaQA_nom = drd.GetString(posSistemaQA_nom);
                    lALR_SistemaqaBE.Add(obeSistemaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lALR_SistemaqaBE);
        }
        public List<ALR_SistemaqaBE> ListarALR_SistemaqaByDepartamento(Int16 _Departamento_id)
        {
            string conexion = MiConexion.GetCnx();
            List<ALR_SistemaqaBE> lALR_SistemaqaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarALR_SistemaQAByDepartamento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = cmd.Parameters.Add("@Departamento_id", SqlDbType.SmallInt);
            par1.Direction = ParameterDirection.Input;
            par1.Value = _Departamento_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lALR_SistemaqaBE = new List<ALR_SistemaqaBE>();
                int posSistemaQA_id = drd.GetOrdinal("SistemaQA_id");
                int posSistemaQA_desc = drd.GetOrdinal("SistemaQA_desc");
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                int posSistemaQA_nom = drd.GetOrdinal("SistemaQA_nom");
                ALR_SistemaqaBE obeSistemaBE = null;
                while (drd.Read())
                {
                    obeSistemaBE = new ALR_SistemaqaBE();
                    obeSistemaBE.SistemaQA_id = drd.GetInt16(posSistemaQA_id);
                    obeSistemaBE.SistemaQA_desc = drd.GetString(posSistemaQA_desc);
                    obeSistemaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    obeSistemaBE.SistemaQA_nom = drd.GetString(posSistemaQA_nom);
                    lALR_SistemaqaBE.Add(obeSistemaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lALR_SistemaqaBE);
        }
        public DataTable ListarALR_Sistemaqa_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_Sistemaqa_Act";
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
        public int InsertarALR_SistemaQA(ALR_SistemaqaBE _ALR_SistemaQABE)
        {
            int IdSistemaQA = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarALR_SistemaQA";
            try
            {
                SqlParameter par1 = cmd.Parameters.Add("@SistemaQA_desc", SqlDbType.NVarChar, 200);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _ALR_SistemaQABE.SistemaQA_desc;
                par1 = cmd.Parameters.Add("@Departamento_id", SqlDbType.SmallInt);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _ALR_SistemaQABE.Departamento_id;
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdSistemaQA = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdSistemaQA = -1;
            }
            catch (Exception x)
            {
                IdSistemaQA = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdSistemaQA);
        }
        public bool ActualizarALR_SistemaQA(ALR_SistemaqaBE _ALR_SistemaQABE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarALR_SistemaQA";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@SistemaQA_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SistemaQA_id"].Value = _ALR_SistemaQABE.SistemaQA_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@SistemaQA_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SistemaQA_desc"].Value = _ALR_SistemaQABE.SistemaQA_desc;
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
        public bool EliminarALR_SistemaQA(Int16 SistemaQA_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarALR_SistemaQA";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@SistemaQA_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SistemaQA_id"].Value = SistemaQA_id;
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

        public List<ALR_SistemaqaBE> ListarALR_SistemaqaO_All()
        {
            List<ALR_SistemaqaBE> lALR_SistemaqaBE = null;
            try
            {
                string conexion = MiConexion.GetCnx();

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarALR_SistemaQA_All", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (drd != null)
                {
                    lALR_SistemaqaBE = new List<ALR_SistemaqaBE>();
                    int posSistemaQA_id = drd.GetOrdinal("SistemaQA_id");
                    int posSistemaQA_desc = drd.GetOrdinal("SistemaQA_desc");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    int posSistemaQA_nom = drd.GetOrdinal("SistemaQA_nom");
                    ALR_SistemaqaBE obeSistemaBE = null;
                    while (drd.Read())
                    {
                        obeSistemaBE = new ALR_SistemaqaBE();
                        obeSistemaBE.SistemaQA_id = drd.GetInt16(posSistemaQA_id);
                        obeSistemaBE.SistemaQA_desc = drd.GetString(posSistemaQA_desc);
                        obeSistemaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                        obeSistemaBE.SistemaQA_nom = drd.GetString(posSistemaQA_nom);
                        lALR_SistemaqaBE.Add(obeSistemaBE);
                    }
                    drd.Close();
                }
                con.Close();
            }
            catch (SqlException x)
            {

            }
            catch (Exception ex)
            {
            }

            return (lALR_SistemaqaBE);

        }
    }
}
