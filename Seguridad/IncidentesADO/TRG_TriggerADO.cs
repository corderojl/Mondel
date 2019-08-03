using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TRG_TriggerADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarTRG_Trigger_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTRG_Trigger_All";
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
        public List<TRG_TriggerBE> ListarTRG_TriggerO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TRG_TriggerBE> lTRG_TriggerBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTRG_Trigger_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lTRG_TriggerBE = new List<TRG_TriggerBE>();
                    int posTrigger_id = drd.GetOrdinal("Trigger_id");
                    int posTrigger_fecha = drd.GetOrdinal("Trigger_fecha");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    int posGuardia_id = drd.GetOrdinal("Guardia_id");
                    int posComp_crit_dia = drd.GetOrdinal("Comp_crit_dia");
                    int posComp_crit_sem = drd.GetOrdinal("Comp_crit_sem");
                    int posAccidente_donde = drd.GetOrdinal("Accidente_donde");
                    int posCompletar = drd.GetOrdinal("Completar");
                    int posActivo = drd.GetOrdinal("Activo");
                    TRG_TriggerBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new TRG_TriggerBE();
                        obeCategoriaBE.Trigger_id = drd.GetInt32(posTrigger_id);
                        obeCategoriaBE.Trigger_fecha = drd.GetDateTime(posTrigger_fecha);
                        obeCategoriaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                        obeCategoriaBE.Guardia_id = drd.GetInt16(posGuardia_id);
                        obeCategoriaBE.Comp_crit_dia = drd.GetString(posComp_crit_dia);
                        obeCategoriaBE.Comp_crit_sem = drd.GetString(posComp_crit_sem);
                        obeCategoriaBE.Accidente_donde = drd.GetString(posAccidente_donde);
                        obeCategoriaBE.Completar = drd.GetInt16(posCompletar);
                        obeCategoriaBE.Activo = drd.GetBoolean(posActivo);
                        lTRG_TriggerBE.Add(obeCategoriaBE);
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
            return (lTRG_TriggerBE);
        }

        public DataTable ListarTRG_Trigger_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTRG_Trigger_Act";
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
        public int InsertarTRG_Trigger(TRG_TriggerBE _TRG_TriggerBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTRG_Trigger";
            SqlParameter par1;
            int _Trigger_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@trigger_fecha", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@trigger_fecha"].Value = _TRG_TriggerBE.Trigger_fecha;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _TRG_TriggerBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _TRG_TriggerBE.Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@comp_crit_dia", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@comp_crit_dia"].Value = _TRG_TriggerBE.Comp_crit_dia;
                par1 = cmd.Parameters.Add(new SqlParameter("@comp_crit_sem", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@comp_crit_sem"].Value = _TRG_TriggerBE.Comp_crit_sem;
                par1 = cmd.Parameters.Add(new SqlParameter("@accidente_donde", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@accidente_donde"].Value = _TRG_TriggerBE.Accidente_donde;
                par1 = cmd.Parameters.Add(new SqlParameter("@Completar", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Completar"].Value = _TRG_TriggerBE.Completar;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _TRG_TriggerBE.Originador;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Trigger_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Trigger_id")));
            }
            catch (SqlException x)
            {
                _Trigger_id = 0;
            }
            catch (Exception x)
            {
                _Trigger_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Trigger_id;
        }
        public bool ActualizarTRG_Trigger(TRG_TriggerBE _TRG_TriggerBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTRG_Trigger";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@trigger_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@trigger_id"].Value = _TRG_TriggerBE.Trigger_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _TRG_TriggerBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _TRG_TriggerBE.Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@comp_crit_dia", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@comp_crit_dia"].Value = _TRG_TriggerBE.Comp_crit_dia;
                par1 = cmd.Parameters.Add(new SqlParameter("@comp_crit_sem", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@comp_crit_sem"].Value = _TRG_TriggerBE.Comp_crit_sem;
                par1 = cmd.Parameters.Add(new SqlParameter("@accidente_donde", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@accidente_donde"].Value = _TRG_TriggerBE.Accidente_donde;
                par1 = cmd.Parameters.Add(new SqlParameter("@Completar", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Completar"].Value = _TRG_TriggerBE.Completar;
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
        
        public bool EliminarTRG_Trigger(int _Trigger_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTRG_Trigger";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Trigger_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Trigger_id"].Value = _Trigger_id;
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

        public TRG_TriggerBE TraerTRG_TriggerById(int _Trigger_id)
        {
            TRG_TriggerBE _TRG_TriggerBE = new TRG_TriggerBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTRG_TriggerById";
                cmd.Parameters.Add(new SqlParameter("@Trigger_id", SqlDbType.Int));
                cmd.Parameters["@Trigger_id"].Value = _Trigger_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _TRG_TriggerBE;
                    _with1.Trigger_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Trigger_id")));
                    _with1.Trigger_fecha = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Trigger_fecha")));
                    _with1.Departamento_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Departamento_id")));
                    _with1.Guardia_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Guardia_id")));
                    _with1.Comp_crit_dia = Convert.ToString(dtr.GetValue(dtr.GetOrdinal("Comp_crit_dia")));
                    _with1.Comp_crit_sem = Convert.ToString(dtr.GetValue(dtr.GetOrdinal("Comp_crit_sem")));
                    _with1.Accidente_donde = Convert.ToString(dtr.GetValue(dtr.GetOrdinal("Accidente_donde")));
                    _with1.Incidente_reg = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Incidente_reg")));
                    _with1.Incidente_cls = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Incidente_cls")));
                    _with1.Activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("Activo")));
                    _with1.Completar = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Completar")));
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
            return _TRG_TriggerBE;
        }

        public DataTable TraerTRG_TriggerSemaforo(short _Departamento_id)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTRG_TriggerSemaforo";
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                
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
        public DataTable ListarTRG_TriggerFind(string _Departamento_id, string _Guardia_id, DateTime _Fecha_Trigger, DateTime _Fecha_Trigger1)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTRG_TriggerFind";
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_Trigger", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_Trigger"].Value = _Fecha_Trigger;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_Trigger1", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_Trigger1"].Value = _Fecha_Trigger1;
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
        public int TraerTRG_TriggerUltimo(short _Departamento_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_TraerTRG_TriggerUltimo";
            SqlParameter par1;
            int _Trigger_id;
            try
            {
               
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Trigger_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Trigger_id")));
            }
            catch (SqlException x)
            {
                _Trigger_id = 0;
            }
            catch (Exception x)
            {
                _Trigger_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Trigger_id;
        }
    }
}
