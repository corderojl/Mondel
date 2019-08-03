using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class EVA_CategoriaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarEVA_Categoria_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_Categoria_All";
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
        public List<EVA_CategoriaBE> ListarEVA_CategoriaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<EVA_CategoriaBE> lEVA_CategoriaBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEVA_Categoria_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lEVA_CategoriaBE = new List<EVA_CategoriaBE>();
                    int posCategoria_id = drd.GetOrdinal("Categoria_id");
                    int posCategoria_desc = drd.GetOrdinal("Categoria_desc");

                    EVA_CategoriaBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new EVA_CategoriaBE();
                        obeCategoriaBE.Categoria_id = drd.GetInt32(posCategoria_id);
                        obeCategoriaBE.Categoria_desc = drd.GetString(posCategoria_desc);
     
                        lEVA_CategoriaBE.Add(obeCategoriaBE);
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
            return (lEVA_CategoriaBE);
        }
        public List<EVA_CategoriaBE> ListarEVA_CategoriaByFormato(Int16 _Formato_id)
        {
            string conexion = MiConexion.GetCnx();
            List<EVA_CategoriaBE> lEVA_CategoriaBE = null;
            SqlParameter par1;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEVA_CategoriaByFormato", con);
                cmd.CommandType = CommandType.StoredProcedure;
                par1 = cmd.Parameters.Add(new SqlParameter("@Formato_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Formato_id"].Value = _Formato_id;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lEVA_CategoriaBE = new List<EVA_CategoriaBE>();
                    int posCategoria_id = drd.GetOrdinal("Categoria_id");
                    int posCategoria_desc = drd.GetOrdinal("Categoria_desc");

                    EVA_CategoriaBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new EVA_CategoriaBE();
                        obeCategoriaBE.Categoria_id = drd.GetInt16(posCategoria_id);
                        obeCategoriaBE.Categoria_desc = drd.GetString(posCategoria_desc);
                        lEVA_CategoriaBE.Add(obeCategoriaBE);
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
            return (lEVA_CategoriaBE);
        }
        public DataTable ListarEVA_Categoria_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_Categoria_Act";
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
        public int InsertarCOM_Categoria(EVA_CategoriaBE _EVA_CategoriaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarCOM_Categoria";
            SqlParameter par1;
            int _Categoria_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_desc"].Value = _EVA_CategoriaBE.Categoria_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_tipo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Categoria_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("@@identity")));
            }
            catch (SqlException x)
            {
                _Categoria_id = 0;
            }
            catch (Exception x)
            {
                _Categoria_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Categoria_id;
        }
        public bool ActualizarCOM_Categoria(EVA_CategoriaBE _EVA_CategoriaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarCOM_Categoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _EVA_CategoriaBE.Categoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_desc"].Value = _EVA_CategoriaBE.Categoria_desc;
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

        public EVA_CategoriaBE TraerCOM_CategoriaById(int _Categoria_id)
        {
            string conexion = MiConexion.GetCnx();
            EVA_CategoriaBE obeCategoriaBE = null;
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerEVA_CategoriaById";
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.Int));
                cmd.Parameters["@Categoria_id"].Value = _Categoria_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    obeCategoriaBE = new EVA_CategoriaBE();
                    obeCategoriaBE.Categoria_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Categoria_id")));
                    obeCategoriaBE.Categoria_desc = dtr.GetValue(dtr.GetOrdinal("Categoria_desc")).ToString();
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
            return (obeCategoriaBE);
        }
    }
}
