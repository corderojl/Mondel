using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class COM_CategoriasADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarCOM_Categorias_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarCOM_Categorias_All";
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
        public List<COM_CategoriasBE> ListarCOM_CategoriasO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<COM_CategoriasBE> lCOM_CategoriasBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCOM_Categorias_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lCOM_CategoriasBE = new List<COM_CategoriasBE>();
                    int posCategoria_id = drd.GetOrdinal("Categoria_id");
                    int posCategoria_desc = drd.GetOrdinal("Categoria_desc");
                    int posCategoria_tipo = drd.GetOrdinal("Categoria_tipo");
                    int posFormato_id = drd.GetOrdinal("Formato_id");
                    int posGrado = drd.GetOrdinal("Grado");
                    COM_CategoriasBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new COM_CategoriasBE();
                        obeCategoriaBE.Categoria_id = drd.GetInt16(posCategoria_id);
                        obeCategoriaBE.Categoria_desc = drd.GetString(posCategoria_desc);
                        obeCategoriaBE.Categoria_tipo = drd.GetInt16(posCategoria_tipo);
                        obeCategoriaBE.Formato_id = drd.GetInt16(posFormato_id);
                        obeCategoriaBE.Grado = drd.GetInt16(posGrado);
                        lCOM_CategoriasBE.Add(obeCategoriaBE);
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
            return (lCOM_CategoriasBE);
        }
        public List<COM_CategoriasBE> ListarCOM_CategoriasByFormato(Int16 _Formato_id)
        {
            string conexion = MiConexion.GetCnx();
            List<COM_CategoriasBE> lCOM_CategoriasBE = null;
            SqlParameter par1;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCOM_CategoriasByFormato", con);
                cmd.CommandType = CommandType.StoredProcedure;
                par1 = cmd.Parameters.Add(new SqlParameter("@Formato_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Formato_id"].Value = _Formato_id;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lCOM_CategoriasBE = new List<COM_CategoriasBE>();
                    int posCategoria_id = drd.GetOrdinal("Categoria_id");
                    int posCategoria_desc = drd.GetOrdinal("Categoria_desc");
                    int posCategoria_tipo = drd.GetOrdinal("Categoria_tipo");
                    int posFormato_id = drd.GetOrdinal("Formato_id");
                    int posGrado = drd.GetOrdinal("Grado");
                    COM_CategoriasBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new COM_CategoriasBE();
                        obeCategoriaBE.Categoria_id = drd.GetInt16(posCategoria_id);
                        obeCategoriaBE.Categoria_desc = drd.GetString(posCategoria_desc);
                        obeCategoriaBE.Categoria_tipo = drd.GetInt16(posCategoria_tipo);
                        obeCategoriaBE.Formato_id = drd.GetInt16(posFormato_id);
                        obeCategoriaBE.Grado = drd.GetInt16(posGrado);
                        lCOM_CategoriasBE.Add(obeCategoriaBE);
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
            return (lCOM_CategoriasBE);
        }
        public DataTable ListarCOM_Categorias_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarCOM_Categorias_Act";
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
        public int InsertarCOM_Categoria(COM_CategoriasBE _COM_CategoriasBE)
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
                cmd.Parameters["@Categoria_desc"].Value = _COM_CategoriasBE.Categoria_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_tipo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_tipo"].Value = _COM_CategoriasBE.Categoria_tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Formato_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Formato_id"].Value = _COM_CategoriasBE.Formato_id;
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
        public bool ActualizarCOM_Categoria(COM_CategoriasBE _COM_CategoriasBE)
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
                cmd.Parameters["@Categoria_id"].Value = _COM_CategoriasBE.Categoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_desc"].Value = _COM_CategoriasBE.Categoria_desc;
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

        public COM_CategoriasBE TraerCOM_CategoriaById(int _Categoria_id)
        {
            string conexion = MiConexion.GetCnx();
            COM_CategoriasBE obeCategoriaBE = null;
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerCOM_CategoriasById";
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.Int));
                cmd.Parameters["@Categoria_id"].Value = _Categoria_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    obeCategoriaBE = new COM_CategoriasBE();
                    obeCategoriaBE.Categoria_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Categoria_id")));
                    obeCategoriaBE.Categoria_desc = dtr.GetValue(dtr.GetOrdinal("Categoria_desc")).ToString();
                    obeCategoriaBE.Categoria_tipo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Categoria_tipo")));
                    obeCategoriaBE.Formato_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Formato_id")));
                    obeCategoriaBE.Grado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Grado")));
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

        public List<COM_CategoriasBE> ListarCOM_CategoriasBySector(short _Sector_id)
        {
            string conexion = MiConexion.GetCnx();
            List<COM_CategoriasBE> lCOM_CategoriasBE = null;
            SqlParameter par1;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCOM_CategoriasBySector", con);
                cmd.CommandType = CommandType.StoredProcedure;
                par1 = cmd.Parameters.Add(new SqlParameter("@Sector_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sector_id"].Value = _Sector_id;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lCOM_CategoriasBE = new List<COM_CategoriasBE>();
                    int posCategoria_id = drd.GetOrdinal("Categoria_id");
                    int posCategoria_desc = drd.GetOrdinal("Categoria_desc");
                    int posCategoria_tipo = drd.GetOrdinal("Categoria_tipo");
                    int posAreaLabor_id = drd.GetOrdinal("AreaLabor_id");
                    int posGrado = drd.GetOrdinal("Grado");
                    COM_CategoriasBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new COM_CategoriasBE();
                        obeCategoriaBE.Categoria_id = drd.GetInt16(posCategoria_id);
                        obeCategoriaBE.Categoria_desc = drd.GetString(posCategoria_desc);
                        obeCategoriaBE.Categoria_tipo = drd.GetInt16(posCategoria_tipo);
                        obeCategoriaBE.AreaLabor_id = drd.GetInt16(posAreaLabor_id);
                        obeCategoriaBE.Grado = drd.GetInt16(posGrado);
                        lCOM_CategoriasBE.Add(obeCategoriaBE);
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
            return (lCOM_CategoriasBE);
        }
    }
}
