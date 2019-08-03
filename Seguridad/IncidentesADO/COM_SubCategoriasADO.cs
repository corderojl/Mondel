using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class COM_SubCategoriasADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarCOM_SubCategorias_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarCOM_SubCategorias_All";
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
        public List<COM_SubCategoriasBE> ListarCOM_SubCategoriasO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<COM_SubCategoriasBE> lCOM_SubCategoriasBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCOM_SubCategorias_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lCOM_SubCategoriasBE = new List<COM_SubCategoriasBE>();
                    int posSubCategoria_id = drd.GetOrdinal("SubCategoria_id");
                    int posSubCategoria_desc = drd.GetOrdinal("SubCategoria_desc");
                    int posSubCategoria_codigo = drd.GetOrdinal("SubCategoria_codigo");
                    int posAreaLabor_id = drd.GetOrdinal("AreaLabor_id");
                    COM_SubCategoriasBE obeSubCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeSubCategoriaBE = new COM_SubCategoriasBE();
                        obeSubCategoriaBE.SubCategoria_id = drd.GetInt16(posSubCategoria_id);
                        obeSubCategoriaBE.SubCategoria_desc = drd.GetString(posSubCategoria_desc);
                        obeSubCategoriaBE.SubCategoria_codigo = drd.GetString(posSubCategoria_codigo);
                        obeSubCategoriaBE.AreaLabor_id = drd.GetInt16(posAreaLabor_id);
                        lCOM_SubCategoriasBE.Add(obeSubCategoriaBE);
                    }
                    drd.Close();
                    con.Close();
                }
                
            }
            catch(SqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            return (lCOM_SubCategoriasBE);
        }
        public List<COM_SubCategoriasBE> ListarCOM_SubCategoriasByCategoria(Int16 _AreaLabor_id)
        {
            string conexion = MiConexion.GetCnx();
            List<COM_SubCategoriasBE> lCOM_SubCategoriasBE = null;
            SqlParameter par1;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCOM_SubCategoriasByAreaLabor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor_id"].Value = _AreaLabor_id;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lCOM_SubCategoriasBE = new List<COM_SubCategoriasBE>();
                    int posSubCategoria_id = drd.GetOrdinal("SubCategoria_id");
                    int posSubCategoria_desc = drd.GetOrdinal("SubCategoria_desc");
                    int posSubCategoria_codigo = drd.GetOrdinal("SubCategoria_codigo");
                    int posAreaLabor_id = drd.GetOrdinal("AreaLabor_id");
                    COM_SubCategoriasBE obeSubCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeSubCategoriaBE = new COM_SubCategoriasBE();
                        obeSubCategoriaBE.SubCategoria_id = drd.GetInt16(posSubCategoria_id);
                        obeSubCategoriaBE.SubCategoria_desc = drd.GetString(posSubCategoria_desc);
                        obeSubCategoriaBE.SubCategoria_codigo = drd.GetString(posSubCategoria_codigo);
                        obeSubCategoriaBE.AreaLabor_id = drd.GetInt16(posAreaLabor_id);
                        lCOM_SubCategoriasBE.Add(obeSubCategoriaBE);
                    }
                    drd.Close();
                    con.Close();
                }

            }
            catch (SqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            return (lCOM_SubCategoriasBE);
        }
        public DataTable ListarCOM_SubCategorias_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarCOM_SubCategorias_Act";
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
        public int InsertarCOM_SubCategoria(COM_SubCategoriasBE _COM_SubCategoriasBE)
        {
            int IdSubCategoria = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarCOM_SubCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter par1 = cmd.Parameters.Add("@SubCategoria_desc", SqlDbType.NVarChar, 200);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _COM_SubCategoriasBE.SubCategoria_desc;

                SqlParameter par2 = cmd.Parameters.Add("@SubCategoria_codigo", SqlDbType.NChar, 6);
                par2.Direction = ParameterDirection.Input;
                par2.Value = _COM_SubCategoriasBE.SubCategoria_codigo;

                SqlParameter par3 = cmd.Parameters.Add("@AreaLabor_id", SqlDbType.SmallInt);
                par3.Direction = ParameterDirection.Input;
                par3.Value = _COM_SubCategoriasBE.AreaLabor_id;

                par1 = cmd.Parameters.Add("@FSeguro", SqlDbType.NVarChar, 50);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _COM_SubCategoriasBE.FSeguro;

                par1 = cmd.Parameters.Add("@FInseguro", SqlDbType.NVarChar, 50);
                par1.Direction = ParameterDirection.Input;
                par1.Value = _COM_SubCategoriasBE.FInseguro;

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
        public bool ActualizarCOM_SubCategoria(COM_SubCategoriasBE _COM_SubCategoriasBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarCOM_SubCategoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _COM_SubCategoriasBE.SubCategoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_desc", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_desc"].Value = _COM_SubCategoriasBE.SubCategoria_desc;
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
        public bool EliminarCOM_SubCategoria(Int16 SubCategoria_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarCOM_SubCategoria";
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

        public COM_SubCategoriasBE TraerCOM_SubCategoriaByID(short SubCategoria_id)
        {
            string conexion = MiConexion.GetCnx();
            COM_SubCategoriasBE obeSubCategoriasBE = null;
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerCOM_SubCategoriasById";
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = SubCategoria_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    obeSubCategoriasBE = new COM_SubCategoriasBE();
                    obeSubCategoriasBE.SubCategoria_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("SubCategoria_id")));
                    obeSubCategoriasBE.SubCategoria_desc = dtr.GetValue(dtr.GetOrdinal("SubCategoria_desc")).ToString();

                    obeSubCategoriasBE.SubCategoria_codigo = dtr.GetValue(dtr.GetOrdinal("SubCategoria_codigo")).ToString();
                    obeSubCategoriasBE.AreaLabor_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("AreaLabor_id")));
                    obeSubCategoriasBE.fecha_reg = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fecha_reg")));
                    obeSubCategoriasBE.activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("activo")));
                    obeSubCategoriasBE.FSeguro = dtr.GetValue(dtr.GetOrdinal("FSeguro")).ToString();
                    obeSubCategoriasBE.FInseguro = dtr.GetValue(dtr.GetOrdinal("FInseguro")).ToString();
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
            return (obeSubCategoriasBE);
        }

        public List<COM_SubCategoriasBE> ListarCOM_SubCategoriasBySector(short _AreaLabor_id)
        {
            string conexion = MiConexion.GetCnx();
            List<COM_SubCategoriasBE> lCOM_SubCategoriasBE = null;
            SqlParameter par1;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCOM_SubCategoriasByAreaLabor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor_id"].Value = _AreaLabor_id;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lCOM_SubCategoriasBE = new List<COM_SubCategoriasBE>();
                    int posSubCategoria_id = drd.GetOrdinal("SubCategoria_id");
                    int posSubCategoria_desc = drd.GetOrdinal("SubCategoria_desc");
                    int posSubCategoria_codigo = drd.GetOrdinal("SubCategoria_codigo");
                    int posAreaLabor_id = drd.GetOrdinal("AreaLabor_id");
                    int posFSeguro = drd.GetOrdinal("FSeguro");
                    int posFInseguro = drd.GetOrdinal("FInseguro");
                    COM_SubCategoriasBE obeSubCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeSubCategoriaBE = new COM_SubCategoriasBE();
                        obeSubCategoriaBE.SubCategoria_id = drd.GetInt16(posSubCategoria_id);
                        obeSubCategoriaBE.SubCategoria_desc = drd.GetString(posSubCategoria_desc);
                        obeSubCategoriaBE.SubCategoria_codigo = drd.GetString(posSubCategoria_codigo);
                        obeSubCategoriaBE.AreaLabor_id = drd.GetInt16(posAreaLabor_id);
                        obeSubCategoriaBE.FSeguro = drd.GetString(posFSeguro);
                        obeSubCategoriaBE.FInseguro = drd.GetString(posFInseguro);
                        lCOM_SubCategoriasBE.Add(obeSubCategoriaBE);
                    }
                    drd.Close();
                    con.Close();
                }

            }
            catch (SqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            return (lCOM_SubCategoriasBE);
        }
    }
}
