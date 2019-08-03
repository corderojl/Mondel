using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_PilarADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public List<TB_PilarBE> ListarTB_PilarO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_PilarBE> lTB_PilarBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_Pilar_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_PilarBE = new List<TB_PilarBE>();
                int posPilar_id = drd.GetOrdinal("Pilar_id");
                int posPilar_desc = drd.GetOrdinal("Pilar_desc");
                TB_PilarBE obePilarBE = null;
                while (drd.Read())
                {
                    obePilarBE = new TB_PilarBE();
                    obePilarBE.Pilar_id = drd.GetInt16(posPilar_id);
                    obePilarBE.Pilar_desc = drd.GetString(posPilar_desc);
                    lTB_PilarBE.Add(obePilarBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_PilarBE);
        }

        public int InsertarTB_Pilar(TB_PilarBE _TB_PilarBE)
        {
            int IdPilar = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_Pilar";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Pilar_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pilar_desc"].Value = _TB_PilarBE.Pilar_desc;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdPilar = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdPilar = -1;
            }
            catch (Exception x)
            {
                IdPilar = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdPilar);
        }

        public bool ActualizarTB_Pilar(TB_PilarBE _TB_PilarBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_Pilar";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pilar_id"].Value = _TB_PilarBE.Pilar_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Pilar_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pilar_desc"].Value = _TB_PilarBE.Pilar_desc;
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

        public bool EliminarTB_Pilar(int _Pilar_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_Pilar";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.Int));
                cmd.Parameters["@Pilar_id"].Value = _Pilar_id;
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
