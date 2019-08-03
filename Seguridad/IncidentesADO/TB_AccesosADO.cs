using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_AccesosADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();

        public DataTable ListarTB_Accesos_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Accesos_All";
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
        public TB_AccesosBE TraerTB_Accesos(Int16 _Funcionario_id, Int16 _Sistema_id)
        {
            SqlDataReader dtr = default(SqlDataReader);
            TB_AccesosBE _TB_AccesosBE = new TB_AccesosBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTB_Accesos";
                cmd.Parameters.Add(new SqlParameter("@Funcionario_id", SqlDbType.VarChar, 20));
                cmd.Parameters["@Funcionario_id"].Value = _Funcionario_id;
                cmd.Parameters.Add(new SqlParameter("@Sistema_id", SqlDbType.SmallInt));
                cmd.Parameters["@Sistema_id"].Value = _Sistema_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _TB_AccesosBE;
                    _with1.Usuario_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Usuario_Id")));
                    _with1.Permiso = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Permiso")));
                    _with1.Departamento_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Departamento_id")));
                    _with1.Activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("Activo")));
                }
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
            return _TB_AccesosBE;
        }
        
        public List<TB_AccesosBE> ListarTB_AccesosO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_AccesosBE> lTB_AccesosBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_Accesos_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_AccesosBE = new List<TB_AccesosBE>();
                int posUsuario_id = drd.GetOrdinal("Usuario_id");
                int posPermiso = drd.GetOrdinal("Permiso");
                int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                int posActivo = drd.GetOrdinal("Activo");
                TB_AccesosBE obeAccesosBE = null;
                while (drd.Read())
                {
                    obeAccesosBE = new TB_AccesosBE();
                    obeAccesosBE.Usuario_id = drd.GetInt16(posUsuario_id);
                    obeAccesosBE.Permiso = drd.GetInt16(posPermiso);
                    obeAccesosBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                    obeAccesosBE.Activo = drd.GetBoolean(posActivo);
                    lTB_AccesosBE.Add(obeAccesosBE);
                }
                drd.Close();
            }

            return (lTB_AccesosBE);
        }
        public DataTable ListarTB_Accesos_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Accesos_Act";
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
        public List<string> ListarTB_AccesosEmailByDeparatmento(Int16 _Departamento_id, Int16 _Sistema_id)
        {
            string conexion = MiConexion.GetCnx();
            List<string> lTB_AccesosList = new List<string>();
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_AccesosEmailbyDeparatmento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
            cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
            cmd.Parameters.Add(new SqlParameter("@Sistema_id", SqlDbType.SmallInt));
            cmd.Parameters["@Sistema_id"].Value = _Sistema_id;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                int posFuncionario_email = drd.GetOrdinal("Funcionario_email");
                while (drd.Read())
                {
                    lTB_AccesosList.Add(drd.GetString(posFuncionario_email));
                }
                drd.Close();
            }

            return (lTB_AccesosList);
        }
    }
}
