using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_TecnologiaADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_Tecnologia_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Tecnologia_All";
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
        public List<TB_TecnologiaBE> ListarTB_TecnologiaO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_TecnologiaBE> lTB_TecnologiaBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTB_Tecnologia_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (drd != null)
                {
                    lTB_TecnologiaBE = new List<TB_TecnologiaBE>();
                    int posTecnologia_id = drd.GetOrdinal("Tecnologia_id");
                    int posTecnologia_desc = drd.GetOrdinal("Tecnologia_desc");
                    TB_TecnologiaBE obeTecnologiaBE = null;
                    while (drd.Read())
                    {
                        obeTecnologiaBE = new TB_TecnologiaBE();
                        obeTecnologiaBE.Tecnologia_id = drd.GetInt16(posTecnologia_id);
                        obeTecnologiaBE.Tecnologia_desc = drd.GetString(posTecnologia_desc);
                        lTB_TecnologiaBE.Add(obeTecnologiaBE);
                    }
                    drd.Close();
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return (lTB_TecnologiaBE);
        }
        public DataTable ListarTB_Tecnologia_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Tecnologia_Act";
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
    }
}
