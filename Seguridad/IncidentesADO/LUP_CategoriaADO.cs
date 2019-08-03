using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class LUP_CategoriaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public List<LUP_CategoriaBE> ListarLUP_CategoriaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<LUP_CategoriaBE> lLUP_CategoriaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarLUP_Categoria_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lLUP_CategoriaBE = new List<LUP_CategoriaBE>();
                int posCategoria_id = drd.GetOrdinal("Categoria_id");
                int posCategoria_desc = drd.GetOrdinal("Categoria_desc");
                int posPilar_id = drd.GetOrdinal("Pilar_id");
                LUP_CategoriaBE obeCategoriaBE = null;
                while (drd.Read())
                {
                    obeCategoriaBE = new LUP_CategoriaBE();
                    obeCategoriaBE.Categoria_id = drd.GetInt16(posCategoria_id);
                    obeCategoriaBE.Categoria_desc = drd.GetString(posCategoria_desc);
                    obeCategoriaBE.Pilar_id = drd.GetInt16(posPilar_id);
                    lLUP_CategoriaBE.Add(obeCategoriaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lLUP_CategoriaBE);
        }
        public List<LUP_CategoriaBE> ListarLUP_CategoriaByPilar(short _Pilar_id)
        {
            string conexion = MiConexion.GetCnx();
            List<LUP_CategoriaBE> lLUP_CategoriaBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlParameter par1;
            SqlCommand cmd = new SqlCommand("sp_ListarLUP_CategoriaByPilar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            par1 = cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.Int));
            par1.Direction = ParameterDirection.Input;
            cmd.Parameters["@Pilar_id"].Value = _Pilar_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lLUP_CategoriaBE = new List<LUP_CategoriaBE>();
                int posCategoria_id = drd.GetOrdinal("Categoria_id");
                int posCategoria_desc = drd.GetOrdinal("Categoria_desc");
                int posPilar_id = drd.GetOrdinal("Pilar_id");
                LUP_CategoriaBE obeCategoriaBE = null;
                while (drd.Read())
                {
                    obeCategoriaBE = new LUP_CategoriaBE();
                    obeCategoriaBE.Categoria_id = drd.GetInt16(posCategoria_id);
                    obeCategoriaBE.Categoria_desc = drd.GetString(posCategoria_desc);
                    obeCategoriaBE.Pilar_id = drd.GetInt16(posPilar_id);
                    lLUP_CategoriaBE.Add(obeCategoriaBE);
                }
                drd.Close();
            }
            con.Close();
            return (lLUP_CategoriaBE);
        }

        public int InsertarLUP_Categoria(LUP_CategoriaBE _LUP_CategoriaBE)
        {
            int IdCategoria = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarLUP_Categoria";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_desc"].Value = _LUP_CategoriaBE.Categoria_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pilar_id"].Value = _LUP_CategoriaBE.Pilar_id;
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdCategoria = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdCategoria = -1;
            }
            catch (Exception x)
            {
                IdCategoria = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdCategoria);
        }
        public bool ActualizarLUP_Categoria(LUP_CategoriaBE _LUP_CategoriaBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarLUP_Categoria";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _LUP_CategoriaBE.Categoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_desc"].Value = _LUP_CategoriaBE.Categoria_desc;
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

        public bool EliminarLUP_Categoria(int _Categoria_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarLUP_Categoria";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.Int));
                cmd.Parameters["@Categoria_id"].Value = _Categoria_id;
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
