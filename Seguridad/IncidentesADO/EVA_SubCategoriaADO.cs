using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class EVA_SubCategoriaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarEVA_SubCategoria_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_SubCategoria_All";
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
        public List<EVA_SubCategoriaBE> ListarEVA_SubCategoriaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<EVA_SubCategoriaBE> lEVA_SubCategoriaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarEVA_SubCategoria_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lEVA_SubCategoriaBE = new List<EVA_SubCategoriaBE>();
                int posSubCategoria_id = drd.GetOrdinal("SubCategoria_id");
                int posSubCategoria_desc = drd.GetOrdinal("SubCategoria_desc");
                int posCategoria_id = drd.GetOrdinal("Categoria_id");
                EVA_SubCategoriaBE obeSubCategoriaBE = null;
                while (drd.Read())
                {
                    obeSubCategoriaBE = new EVA_SubCategoriaBE();
                    obeSubCategoriaBE.SubCategoria_id = drd.GetInt32(posSubCategoria_id);
                    obeSubCategoriaBE.SubCategoria_desc = drd.GetString(posSubCategoria_desc);
                    obeSubCategoriaBE.Categoria_id = drd.GetInt32(posCategoria_id);
                    lEVA_SubCategoriaBE.Add(obeSubCategoriaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lEVA_SubCategoriaBE);
        }
        public DataTable ListarEVA_SubCategoria_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_SubCategoria_Act";
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
        public int InsertarEVA_SubCategoria(EVA_SubCategoriaBE _EVA_SubCategoriaBE)
        {
            int IdSubCategoria = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarEVA_SubCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter par1 = cmd.Parameters.Add("@SubCategoria_desc", SqlDbType.NVarChar, 200);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _EVA_SubCategoriaBE.SubCategoria_desc;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdSubCategoria = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdSubCategoria = -1;
            }
            catch (Exception x)
            {
                IdSubCategoria = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdSubCategoria);
        }
        public bool ActualizarEVA_SubCategoria(EVA_SubCategoriaBE _EVA_SubCategoriaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarEVA_SubCategoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _EVA_SubCategoriaBE.SubCategoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_desc"].Value = _EVA_SubCategoriaBE.SubCategoria_desc;
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
        public bool EliminarEVA_SubCategoria(Int16 SubCategoria_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarEVA_SubCategoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = SubCategoria_id;
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

        public string[] TraerSubCategoria(int SubCategoria_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_TraerNombreCategoriaSubCategoria";
            SqlParameter par1;
            string[] cat;
            string _Evaluacion_id;
            try
            {

                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = SubCategoria_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Evaluacion_id = dtr.GetValue(dtr.GetOrdinal("SubCategoria_desc")).ToString();
                cat = new string[2] { dtr.GetValue(dtr.GetOrdinal("SubCategoria_desc")).ToString(), dtr.GetValue(dtr.GetOrdinal("Categoria_desc")).ToString() };
            }
            catch (SqlException x)
            {
                cat = new string[2] { "",""};
            }
            catch (Exception x)
            {
                cat = new string[2] { "", "" }; 
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return cat;
        }

    }
}
