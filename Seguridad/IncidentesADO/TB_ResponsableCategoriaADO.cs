using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
   public class TB_ResponsableCategoriaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        public DataTable ListarTB_ResponsableCategoria_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_ResponsableCategoria_All";
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
        public DataTable ListarTB_ResponsableCategoriaByCategoria(short Categoria_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_ResponsableCategoriaByCategoria";
                SqlParameter par1 = cmd.Parameters.Add("@Categoria_id", SqlDbType.SmallInt);
                par1.Direction = ParameterDirection.Input;
                par1.Value = Categoria_id;
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

        public List<TB_ResponsableCategoriaBE> ListarTB_ResponsableCategoriaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_ResponsableCategoriaBE> lTB_ResponsableCategoriaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_ResponsableCategoria_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_ResponsableCategoriaBE = new List<TB_ResponsableCategoriaBE>();
                int posCategoria_id = drd.GetOrdinal("Categoria_id");
                int posFuncionario_id = drd.GetOrdinal("Funcionario_id");
                TB_ResponsableCategoriaBE obeResponsableCategoriaBE = null;
                while (drd.Read())
                {
                    obeResponsableCategoriaBE = new TB_ResponsableCategoriaBE();
                    obeResponsableCategoriaBE.Categoria_id = drd.GetInt16(posCategoria_id);
                    obeResponsableCategoriaBE.Funcionario_id = drd.GetInt16(posFuncionario_id);
                    lTB_ResponsableCategoriaBE.Add(obeResponsableCategoriaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_ResponsableCategoriaBE);
        }
        public TB_ResponsableCategoriaBE TraerTB_ResponsableCategoriaByCategoria(int _Categoria_id)
        {
            TB_ResponsableCategoriaBE _TB_ResponsableCategoriaBE = new TB_ResponsableCategoriaBE();
            SqlDataReader dtr = default(SqlDataReader);
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTB_ResponsableCategoriaByCategoria";
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.SmallInt));
                cmd.Parameters["@Categoria_id"].Value = _Categoria_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _TB_ResponsableCategoriaBE;
                    _with1.Categoria_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Categoria_id")));
                    _with1.Funcionario_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Funcionario_id")));
                    _with1.Funcionario_nome = dtr.GetValue(dtr.GetOrdinal("Funcionario_nome")).ToString();

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
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
            return (_TB_ResponsableCategoriaBE);
        }


        public bool EliminarTB_ResponsableCategoria(short _Categoria_id, short _Funcionario_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_ResponsableCategoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _Categoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_id"].Value = _Funcionario_id;
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

        public string InsertarTB_ResponsableCategoria(short dpt, short emp)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_ResponsableCategoria";
            SqlParameter par1;
            string _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = dpt;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_id"].Value = emp;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = "Exito";

            }
            catch (SqlException x)
            {
                if (x.ErrorCode == -2146232060)
                    _vcod = "existe";
                else
                    _vcod = "error";
            }
            catch (Exception x)
            {
                _vcod = "error";
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
