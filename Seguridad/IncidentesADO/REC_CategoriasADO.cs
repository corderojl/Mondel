using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class REC_CategoriasADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarREC_Categorias_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarREC_Categorias_All";
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
        public List<REC_CategoriasBE> ListarREC_CategoriasO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<REC_CategoriasBE> lREC_CategoriasBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarREC_Categorias_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lREC_CategoriasBE = new List<REC_CategoriasBE>();
                    int posCategoria_id = drd.GetOrdinal("Categoria_id");
                    int posCategoria_desc = drd.GetOrdinal("Categoria_desc");
                    REC_CategoriasBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new REC_CategoriasBE();
                        obeCategoriaBE.Categoria_id = drd.GetInt16(posCategoria_id);
                        obeCategoriaBE.Categoria_desc = drd.GetString(posCategoria_desc);
                        lREC_CategoriasBE.Add(obeCategoriaBE);
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
            return (lREC_CategoriasBE);
        }
        public DataTable ListarREC_Categorias_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarREC_Categorias_Act";
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
        public int InsertarREC_Categoria(REC_CategoriasBE _REC_CategoriasBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarREC_Categoria";
            SqlParameter par1;
            int _Categoria_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_desc"].Value = _REC_CategoriasBE.Categoria_desc;
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
        public bool ActualizarREC_Categoria(REC_CategoriasBE _REC_CategoriasBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarREC_Categoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _REC_CategoriasBE.Categoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_desc"].Value = _REC_CategoriasBE.Categoria_desc;
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

        public REC_CategoriasBE TraerREC_CategoriaById(int _Categoria_id)
        {
            string conexion = MiConexion.GetCnx();
            REC_CategoriasBE obeCategoriaBE = null;
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerREC_CategoriasById";
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.Int));
                cmd.Parameters["@Categoria_id"].Value = _Categoria_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    obeCategoriaBE = new REC_CategoriasBE();
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
