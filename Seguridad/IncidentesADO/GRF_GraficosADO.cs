using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class GRF_GraficosADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable GraficoParetoIncidentes_Clasificación(short _Departamento_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GraficoParetoIncidentes_Clasificación";
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Incidente");
                dtv = dts.Tables["Incidente"].DefaultView;
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
            return dts.Tables["Incidente"];
        }
        public DataTable GraficoPareto_Comportamientos(short _Departamento_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GraficoPareto_Comportamientos";
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Comportamiento");
                dtv = dts.Tables["Comportamiento"].DefaultView;
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
            return dts.Tables["Comportamiento"];
        }
    }
}
