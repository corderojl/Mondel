using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_SectorADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public List<TB_SectorBE> ListarTB_SectorO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_SectorBE> lTB_SectorBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_Sector_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                lTB_SectorBE = new List<TB_SectorBE>();
                int posSector_id = drd.GetOrdinal("Sector_id");
                int posSector_desc = drd.GetOrdinal("Sector_desc");
                int posSigla = drd.GetOrdinal("Sigla");
                TB_SectorBE obeSectorBE = null;
                while (drd.Read())
                {
                    obeSectorBE = new TB_SectorBE();
                    obeSectorBE.Sector_id = drd.GetInt16(posSector_id);
                    obeSectorBE.Sector_desc = drd.GetString(posSector_desc);
                    obeSectorBE.Sigla = drd.GetString(posSigla);
                    lTB_SectorBE.Add(obeSectorBE);
                }
                drd.Close();

            }
            con.Close();
            return (lTB_SectorBE);
        }
        public DataTable ListarTB_Sector_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Sector_Act";
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

        public List<TB_SectorBE> ListarTB_SectorSuperiorO_Act(short _Superior)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_SectorBE> lTB_SectorBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_SectorSuperior_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = cmd.Parameters.Add("@Superior", SqlDbType.SmallInt);
            par1.Direction = ParameterDirection.Input;
            par1.Value = _Superior;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                lTB_SectorBE = new List<TB_SectorBE>();
                int posSector_id = drd.GetOrdinal("Sector_id");
                int posSector_desc = drd.GetOrdinal("Sector_desc");
                TB_SectorBE obeSectorBE = null;
                while (drd.Read())
                {
                    obeSectorBE = new TB_SectorBE();
                    obeSectorBE.Sector_id = drd.GetInt16(posSector_id);
                    obeSectorBE.Sector_desc = drd.GetString(posSector_desc);
                    lTB_SectorBE.Add(obeSectorBE);
                }
                drd.Close();

            }
            con.Close();
            return (lTB_SectorBE);
        }

        public List<TB_SectorBE> ListarTB_Sector_All(string Sistema_id)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_SectorBE> lTB_SectorBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_Sector_All", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = cmd.Parameters.Add("@Sistema_id", SqlDbType.VarChar, 8);
            par1.Direction = ParameterDirection.Input;
            par1.Value = Sistema_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                lTB_SectorBE = new List<TB_SectorBE>();
                int posSector_id = drd.GetOrdinal("Sector_id");
                int posSector_desc = drd.GetOrdinal("Sector_desc");
                TB_SectorBE obeSectorBE = null;
                while (drd.Read())
                {
                    obeSectorBE = new TB_SectorBE();
                    obeSectorBE.Sector_id = drd.GetInt16(posSector_id);
                    obeSectorBE.Sector_desc = drd.GetString(posSector_desc);
                    lTB_SectorBE.Add(obeSectorBE);
                }
                drd.Close();

            }
            con.Close();
            return (lTB_SectorBE);
        }

        public int InsertarTB_Sector(TB_SectorBE _TB_SectorBE)
        {
            int IdSector = -1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_Sector";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Sector_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sector_desc"].Value = _TB_SectorBE.Sector_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Sigla", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sigla"].Value = _TB_SectorBE.Sigla;

                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdSector = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdSector = -1;
            }
            catch (Exception x)
            {
                IdSector = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdSector);
        }
        public bool ActualizarTB_Sector(TB_SectorBE _TB_SectorBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_Sector";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Sector_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sector_id"].Value = _TB_SectorBE.Sector_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Sector_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sector_desc"].Value = _TB_SectorBE.Sector_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Sigla", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sigla"].Value = _TB_SectorBE.Sigla;
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
        public bool EliminarTB_Sector(int _Sector_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_Sector";
            bool _vcod;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@Sector_id", SqlDbType.Int));
                cmd.Parameters["@Sector_id"].Value = _Sector_id;
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
