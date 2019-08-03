using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_PlanAccionADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        bool vexito;

        public DataTable ListarTB_PlanAccion_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_PlanAccion_All";
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

        public List<TB_PlanAccionBE> ListarTB_PlanAccionO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_PlanAccionBE> lTB_PlanAccionBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_PlanAccion_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_PlanAccionBE = new List<TB_PlanAccionBE>();
                int posPlanAccion_id = drd.GetOrdinal("PlanAccion_id");
                int posPlanAccion_desc = drd.GetOrdinal("PlanAccion_desc");
                int posEstado = drd.GetOrdinal("Estado");
                TB_PlanAccionBE obePlanAccionBE = null;
                while (drd.Read())
                {
                    obePlanAccionBE = new TB_PlanAccionBE();
                    obePlanAccionBE.PlanAccion_id = drd.GetInt32(posPlanAccion_id);
                    obePlanAccionBE.PlanAccion_desc = drd.GetString(posPlanAccion_desc);
                    obePlanAccionBE.Estado = drd.GetBoolean(posEstado);
                    lTB_PlanAccionBE.Add(obePlanAccionBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_PlanAccionBE);
        }
        public List<TB_PlanAccionBE> BuscarTB_PlanAccionByIncidente(int _Id_Incidente, Int16 _tipoPlan)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_PlanAccionBE> lTB_PlanAccionBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarTB_PlanAccionByIncidente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Registro_id", SqlDbType.Int));
                cmd.Parameters["@Registro_id"].Value = _Id_Incidente;
                cmd.Parameters.Add(new SqlParameter("@tipoPlan", SqlDbType.Int));
                cmd.Parameters["@tipoPlan"].Value = _tipoPlan;
                SqlDataReader drd = cmd.ExecuteReader();
                if (drd != null)
                {
                    lTB_PlanAccionBE = new List<TB_PlanAccionBE>();
                    int posPlanAccion_id = drd.GetOrdinal("PlanAccion_id");
                    int posPlanAccion_desc = drd.GetOrdinal("PlanAccion_desc");
                    int posResponsable = drd.GetOrdinal("Responsable");
                    int postipoPlan = drd.GetOrdinal("tipoPlan");
                    int posEstado = drd.GetOrdinal("Estado");
                    int posFecha = drd.GetOrdinal("Fecha");
                    int posRegistro_id = drd.GetOrdinal("Registro_id");
                    TB_PlanAccionBE obePlanAccionBE = null;
                    while (drd.Read())
                    {
                        obePlanAccionBE = new TB_PlanAccionBE();
                        obePlanAccionBE.PlanAccion_id = drd.GetInt32(posPlanAccion_id);
                        obePlanAccionBE.PlanAccion_desc = drd.GetString(posPlanAccion_desc);
                        obePlanAccionBE.Responsable = drd.GetInt32(posResponsable);
                        obePlanAccionBE.tipoPlan = drd.GetInt16(postipoPlan);
                        obePlanAccionBE.Estado = drd.GetBoolean(posEstado);
                        obePlanAccionBE.Fecha = drd.GetDateTime(posFecha);
                        obePlanAccionBE.Registro_id = drd.GetInt32(posRegistro_id);
                        lTB_PlanAccionBE.Add(obePlanAccionBE);
                    }
                    drd.Close();
                }
            }
            catch (SqlException x)
            {
                
            }
            catch (Exception x)
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
            return (lTB_PlanAccionBE);
        }
        public DataTable BuscarTB_PlanAccionByTrigger(int _Trigger_id)
        {
            string conexion = MiConexion.GetCnx();
            SqlConnection con = new SqlConnection(conexion);
            DataSet dts = new DataSet();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarTB_PlanAccionByTrigger", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Trigger_id", SqlDbType.Int));
                cmd.Parameters["@Trigger_id"].Value = _Trigger_id;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Planes");
                dtv = dts.Tables["Planes"].DefaultView;
            }
            catch (SqlException x)
            {

            }
            catch (Exception x)
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
            return dts.Tables["Planes"]; 
        }
        public DataTable BuscarTB_PlanAccionByAuditoria(int _Auditoria_id)
        {
            string conexion = MiConexion.GetCnx();
            SqlConnection con = new SqlConnection(conexion);
            DataSet dts = new DataSet();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarTB_PlanAccionByAuditoria", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Auditoria_id", SqlDbType.Int));
                cmd.Parameters["@Auditoria_id"].Value = _Auditoria_id;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Planes");
                dtv = dts.Tables["Planes"].DefaultView;
            }
            catch (SqlException x)
            {

            }
            catch (Exception x)
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
            return dts.Tables["Planes"];
        }
        public DataTable BuscarTB_PlanAccionByIncidenteResponsable(int _Id_Incidente, Int16 _tipoPlan, Int16 _Sistema_id)
        {
            string conexion = MiConexion.GetCnx();
            SqlConnection con = new SqlConnection(conexion);
            DataSet dts = new DataSet();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarTB_PlanAccionByIncidente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Registro_id", SqlDbType.Int));
                cmd.Parameters["@Registro_id"].Value = _Id_Incidente;
                cmd.Parameters.Add(new SqlParameter("@tipoPlan", SqlDbType.Int));
                cmd.Parameters["@tipoPlan"].Value = _tipoPlan;
                cmd.Parameters.Add(new SqlParameter("@Sistema_id", SqlDbType.Int));
                cmd.Parameters["@Sistema_id"].Value = _Sistema_id;  
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Planes");
                dtv = dts.Tables["Planes"].DefaultView;
            }
            catch (SqlException x)
            {

            }
            catch (Exception x)
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
            return dts.Tables["Planes"]; 
        }
        public bool InsertarTB_PlanAccion(TB_PlanAccionBE _TB_PlanAccionBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_PlanAccion";
            SqlParameter par1;
            try
            {
                cmd.Parameters.Add(new SqlParameter("@PlanAccion_desc", SqlDbType.VarChar, 150));
                cmd.Parameters["@PlanAccion_desc"].Value = _TB_PlanAccionBE.PlanAccion_desc;
                cmd.Parameters.Add(new SqlParameter("@Registro_id", SqlDbType.SmallInt));
                cmd.Parameters["@Registro_id"].Value = _TB_PlanAccionBE.Registro_id;
                cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.SmallInt));
                cmd.Parameters["@responsable"].Value = _TB_PlanAccionBE.Responsable;
                cmd.Parameters.Add(new SqlParameter("@tipoPlan", SqlDbType.SmallInt));
                cmd.Parameters["@tipoPlan"].Value = _TB_PlanAccionBE.tipoPlan;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Int));
                cmd.Parameters["@Estado"].Value = _TB_PlanAccionBE.Estado;
                cmd.Parameters.Add(new SqlParameter("@Sistema_id", SqlDbType.Int));
                cmd.Parameters["@Sistema_id"].Value = _TB_PlanAccionBE.Sistema_id;
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                cmd.Parameters["@fecha"].Value = _TB_PlanAccionBE.Fecha;
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;

            }
            catch (SqlException x)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return vexito;
        }

        public bool ActualizarTB_PlanAccion(TB_PlanAccionBE _TB_PlanAccionBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_PlanAccion";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@PlanAccion_id", SqlDbType.SmallInt));
                cmd.Parameters["@PlanAccion_id"].Value = _TB_PlanAccionBE.PlanAccion_id;
                cmd.Parameters.Add(new SqlParameter("@PlanAccion_desc", SqlDbType.VarChar, 150));
                cmd.Parameters["@PlanAccion_desc"].Value = _TB_PlanAccionBE.PlanAccion_desc;
                cmd.Parameters.Add(new SqlParameter("@responsable", SqlDbType.Int));
                cmd.Parameters["@responsable"].Value = _TB_PlanAccionBE.Responsable;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.SmallInt));
                cmd.Parameters["@Estado"].Value = _TB_PlanAccionBE.Estado;
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));
                cmd.Parameters["@fecha"].Value = _TB_PlanAccionBE.Fecha;
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;

            }
            catch (SqlException x)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return vexito;
        }
        public bool EliminarTB_PlanAccion(int _PlanAccion_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_PlanAccion";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@PlanAccion_id", SqlDbType.Int));
                cmd.Parameters["@PlanAccion_id"].Value = _PlanAccion_id;
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException x)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return vexito;

        }
        public bool CerrarTB_PlanAccion(int _PlanAccion_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_CerrarTB_PlanAccion";
            try
            {
                cmd.Parameters.Add(new SqlParameter("@PlanAccion_id", SqlDbType.Int));
                cmd.Parameters["@PlanAccion_id"].Value = _PlanAccion_id;
                cnx.Open();
                cmd.ExecuteNonQuery();
                vexito = true;
            }
            catch (SqlException x)
            {
                vexito = false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }

            return vexito;

        }
        public List<TB_PlanAccionBE> TraerTB_PlanAccionByIdO(Int16 _PlanAccion_id)
        {
            string conexion = MiConexion.GetCnx();
            List<TB_PlanAccionBE> lTB_PlanAccionBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_TraerTB_PlanAccionById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PlanAccion_id", SqlDbType.SmallInt));
            cmd.Parameters["@PlanAccion_id"].Value = _PlanAccion_id;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                lTB_PlanAccionBE = new List<TB_PlanAccionBE>();
                int posPlanAccion_id = drd.GetOrdinal("PlanAccion_id");
                int posPlanAccion_desc = drd.GetOrdinal("PlanAccion_desc");
                int posResponsable = drd.GetOrdinal("Responsable");
                int postipoPlan = drd.GetOrdinal("tipoPlan");
                int posEstado = drd.GetOrdinal("Estado");
                int posFecha = drd.GetOrdinal("Fecha");
                int posRegistro_id = drd.GetOrdinal("Registro_id");
                TB_PlanAccionBE obePlanAccionBE = null;
                while (drd.Read())
                {
                    obePlanAccionBE = new TB_PlanAccionBE();
                    obePlanAccionBE.PlanAccion_id = drd.GetInt16(posPlanAccion_id);
                    obePlanAccionBE.PlanAccion_desc = drd.GetString(posPlanAccion_desc);
                    obePlanAccionBE.Responsable = drd.GetInt32(posResponsable);
                    obePlanAccionBE.tipoPlan = drd.GetInt16(postipoPlan);
                    obePlanAccionBE.Estado = drd.GetBoolean(posEstado);
                    obePlanAccionBE.Fecha = drd.GetDateTime(posFecha);
                    obePlanAccionBE.Registro_id = drd.GetInt16(posRegistro_id);
                    lTB_PlanAccionBE.Add(obePlanAccionBE);
                }
                drd.Close();
            }

            return (lTB_PlanAccionBE);
        }
        public TB_PlanAccionBE TraerTB_PlanAccionById(int _PlanAccion_id)
        {
            TB_PlanAccionBE _Etq_PlanosBE = new TB_PlanAccionBE();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTB_PlanAccionById";
                //Agregamos el parametro para el SP
                cmd.Parameters.Add(new SqlParameter("@PlanAccion_id", SqlDbType.Int));
                cmd.Parameters["@PlanAccion_id"].Value = _PlanAccion_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _Etq_PlanosBE;
                    _with1.PlanAccion_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("PlanAccion_id")));
                    _with1.PlanAccion_desc = dtr.GetValue(dtr.GetOrdinal("PlanAccion_desc")).ToString();
                    _with1.Responsable = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Responsable")));
                    _with1.Estado = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("Estado")));
                    _with1.Fecha = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha")));
                    _with1.Registro_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Registro_id")));
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
            return _Etq_PlanosBE;
        }
        public DataTable ListarTB_PlanAccion_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_PlanAccion_Act";
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
        public DataTable ListarTB_PlanAccionFind(string _Departamento_id, string _tipoPlan, string _Responsable, string _Estado, DateTime _Fecha, DateTime _Fecha1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_PlanAccionFind";
                cmd.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@tipoPlan", SqlDbType.VarChar, 6));
                cmd.Parameters["@tipoPlan"].Value = _tipoPlan;
                cmd.Parameters.Add(new SqlParameter("@Responsable", SqlDbType.VarChar, 6));
                cmd.Parameters["@Responsable"].Value = _Responsable;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 2));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime));
                cmd.Parameters["@Fecha"].Value = _Fecha;
                cmd.Parameters.Add(new SqlParameter("@Fecha1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha1"].Value = _Fecha1;
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
        public DataTable ListarTB_PlanAccionFind_ALR(string _Departamento_id, string _tipoPlan, string _Responsable, string _Estado, DateTime _Fecha, DateTime _Fecha1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_PlanAccionFind_ALR";
                cmd.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@tipoPlan", SqlDbType.VarChar, 6));
                cmd.Parameters["@tipoPlan"].Value = _tipoPlan;
                cmd.Parameters.Add(new SqlParameter("@Responsable", SqlDbType.VarChar, 6));
                cmd.Parameters["@Responsable"].Value = _Responsable;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 2));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime));
                cmd.Parameters["@Fecha"].Value = _Fecha;
                cmd.Parameters.Add(new SqlParameter("@Fecha1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha1"].Value = _Fecha1;
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
        public DataTable ListarTB_PlanAccionFind_XLS(string _Departamento_id, string _tipoPlan, string _Responsable, string _Estado, DateTime _Fecha, DateTime _Fecha1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_PlanAccionFind_XLS";
                cmd.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@tipoPlan", SqlDbType.VarChar, 6));
                cmd.Parameters["@tipoPlan"].Value = _tipoPlan;
                cmd.Parameters.Add(new SqlParameter("@Responsable", SqlDbType.VarChar, 6));
                cmd.Parameters["@Responsable"].Value = _Responsable;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 2));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime));
                cmd.Parameters["@Fecha"].Value = _Fecha;
                cmd.Parameters.Add(new SqlParameter("@Fecha1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha1"].Value = _Fecha1;
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
        public int ContarTB_PlanAccionByRegistro(int _Registro_id, short _Sistema_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ContarTB_PlanAccionByRegistro";
            SqlParameter par1;
            int _NumPlan;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Registro_id", SqlDbType.VarChar, 100));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registro_id"].Value = _Registro_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Sistema_id", SqlDbType.VarChar, 100));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sistema_id"].Value = _Sistema_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _NumPlan = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("numplan")));
            }
            catch (SqlException x)
            {
                _NumPlan = 0;
            }
            catch (Exception x)
            {
                _NumPlan = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _NumPlan;
        }
        public int[] ContarTB_PlanAccionByFuncionario(int _Funcionario_id)
        {
            int[] _NumPlan=new int[3];
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ContarTB_PlanAccionByFuncionario";
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_id", SqlDbType.VarChar, 100));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_id"].Value = _Funcionario_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _NumPlan[0] = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("numplan")));
                _NumPlan[1] = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Pend")));
                _NumPlan[2] = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Cadu")));
            }
            catch (SqlException x)
            {
                _NumPlan[0] = 0;
                _NumPlan[1] = 0;
                _NumPlan[2] = 0;
            }
            catch (Exception x)
            {
                _NumPlan[0] = 0;
                _NumPlan[1] = 0;
                _NumPlan[2] = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _NumPlan;
        }

        public DataTable BuscarTB_PlanAccionPendiente(short _Responsable, short _Tipo)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BuscarTP_PlanAccionPendiente";
                cmd.Parameters.Add(new SqlParameter("@Responsable", SqlDbType.SmallInt));
                cmd.Parameters["@Responsable"].Value = _Responsable;
                cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.SmallInt));
                cmd.Parameters["@Tipo"].Value = _Tipo;
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

        public DataTable ListarTB_PlanAccionFind_AUD(string _Departamento_id, string _tipoPlan, string _Responsable, string _Estado, DateTime _Fecha, DateTime _Fecha1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_PlanAccionFind_AUD";
                cmd.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@tipoPlan", SqlDbType.VarChar, 6));
                cmd.Parameters["@tipoPlan"].Value = _tipoPlan;
                cmd.Parameters.Add(new SqlParameter("@Responsable", SqlDbType.VarChar, 6));
                cmd.Parameters["@Responsable"].Value = _Responsable;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 2));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime));
                cmd.Parameters["@Fecha"].Value = _Fecha;
                cmd.Parameters.Add(new SqlParameter("@Fecha1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha1"].Value = _Fecha1;
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
    }
}
