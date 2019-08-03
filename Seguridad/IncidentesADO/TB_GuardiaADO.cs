using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_GuardiaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_Guardia_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Guardia_All";
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
        public List<TB_GuardiaBE> ListarTB_GuardiaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_GuardiaBE> lTB_GuardiaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_Guardia_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_GuardiaBE = new List<TB_GuardiaBE>();
                int posGuardia_id = drd.GetOrdinal("Guardia_id");
                int posGuardia_desc = drd.GetOrdinal("Guardia_desc");
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                TB_GuardiaBE obeGuardiaBE = null;
                while (drd.Read())
                {
                    obeGuardiaBE = new TB_GuardiaBE();
                    obeGuardiaBE.Guardia_id = drd.GetInt16(posGuardia_id);
                    obeGuardiaBE.Guardia_desc = drd.GetString(posGuardia_desc);
                    obeGuardiaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    lTB_GuardiaBE.Add(obeGuardiaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_GuardiaBE);
        }
        public DataTable ListarTB_Guardia_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Guardia_Act";
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

        public DataTable ConsultarFunc_Grupo_Id(int vgrupo)
        {
            DataSet dts = new DataSet();
            TB_GuardiaBE _TurnoBE = new TB_GuardiaBE();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[sp_Guardia_consultar_ID]";
                //Agregamos el parametro para el SP
                cmd.Parameters.Add(new SqlParameter("@vcod", SqlDbType.Int));
                cmd.Parameters["@vcod"].Value = vgrupo;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Turno");
                dtv = dts.Tables["Turno"].DefaultView;
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
            return dts.Tables["Turno"];
        }
        public List<TB_GuardiaBE> ListarTB_GuardiaByDepartamento(short _Departamento_id)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_GuardiaBE> lTB_GuardiaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlParameter par1;
            SqlCommand cmd = new SqlCommand("sp_ListarTB_GuardiaByDepartamento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
            par1.Direction = ParameterDirection.Input;
            cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_GuardiaBE = new List<TB_GuardiaBE>();
                int posGuardia_id = drd.GetOrdinal("Guardia_id");
                int posGuardia_desc = drd.GetOrdinal("Guardia_desc");
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                TB_GuardiaBE obeGuardiaBE = null;
                while (drd.Read())
                {
                    obeGuardiaBE = new TB_GuardiaBE();
                    obeGuardiaBE.Guardia_id = drd.GetInt16(posGuardia_id);
                    obeGuardiaBE.Guardia_desc = drd.GetString(posGuardia_desc);
                    obeGuardiaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    lTB_GuardiaBE.Add(obeGuardiaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_GuardiaBE);
        }

        public int InsertarTB_Guardia(TB_GuardiaBE _TB_GuardiaBE)
        {
            int IdGuardia = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_Guardia";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_desc"].Value = _TB_GuardiaBE.Guardia_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _TB_GuardiaBE.Departamento_id;
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdGuardia = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdGuardia = -1;
            }
            catch (Exception x)
            {
                IdGuardia = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdGuardia);
        }
        public bool ActualizarTB_Guardia(TB_GuardiaBE _TB_GuardiaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_Guardia";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _TB_GuardiaBE.Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_desc"].Value = _TB_GuardiaBE.Guardia_desc;
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
        public bool EliminarTB_Guardia(int _Guardia_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_Guardia";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.Int));
                cmd.Parameters["@Guardia_id"].Value = _Guardia_id;
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
