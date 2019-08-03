using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class ALR_AlertasADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        Boolean _vcod = false;
        int _id_Alerta = 0;
        ALR_AlertasBE _ALR_AlertasBE = new ALR_AlertasBE();


        public DataTable ListarALR_AlertasAll()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_Alertas_All";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
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
            return dts.Tables["Alerta"];
        }
        public DataTable ListarALR_AlertasAct()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_Alertas_Act";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
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
            return dts.Tables["Alerta"];
        }

        public DataTable ListarALR_AlertasFind(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador,  string _Estado, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1, int _Usuario_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_Alertas_find";
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Guardia_id"].Value = _Guardia_id;
                cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Area_id"].Value = _Area_id;
                cmd.Parameters.Add(new SqlParameter("@Clasificacion", SqlDbType.VarChar, 6));
                cmd.Parameters["@Clasificacion"].Value = _Clasificacion_id;
                cmd.Parameters.Add(new SqlParameter("@SistemaQA_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@SistemaQA_id"].Value = _SistemaQA_id;
                cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@ElementoClave_id"].Value = _ElementoClave_id;
                cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.VarChar, 6));
                cmd.Parameters["@Originador"].Value = _Originador;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 6));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta"].Value = _Fecha_Alerta;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta1"].Value = _Fecha_Alerta1;
                //cmd.Parameters.Add(new SqlParameter("@FECHA2", SqlDbType.DateTime));
                //cmd.Parameters["@FECHA2"].Value = _fecha2;
                //cmd.Parameters.Add(new SqlParameter("@FECHA3", SqlDbType.DateTime));
                //cmd.Parameters["@FECHA3"].Value = _fecha3;
                cmd.Parameters.Add(new SqlParameter("@Usuario_id", SqlDbType.Int));
                cmd.Parameters["@Usuario_id"].Value = _Usuario_id;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
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
            return dts.Tables["Alerta"];
        }

        public DataTable EstadisticaALR_AlertasRegistroByFecha(DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_EstadisticaALR_AlertasRegistroByFecha";
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta"].Value = _Fecha_Alerta;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta1"].Value = _Fecha_Alerta1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
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
            return dts.Tables["Alerta"];
        }
        public ALR_AlertasBE TraerALR_AlertasById(int _Alerta_id)
        {
            ALR_AlertasBE _AlertasBE = new ALR_AlertasBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerALR_AlertasById";
                cmd.Parameters.Add(new SqlParameter("@Alerta_id", SqlDbType.Int));
                cmd.Parameters["@Alerta_id"].Value = _Alerta_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _AlertasBE;
                    _with1.Alerta_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Alerta_id")));
                    _with1.Alerta_desc = dtr.GetValue(dtr.GetOrdinal("Alerta_desc")).ToString();
                    _with1.Clasificacion = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Clasificacion")));
                    _with1.Departamento_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Departamento_id")));
                    _with1.Area_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Area_id")));
                    _with1.Guardia_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("guardia_id")));
                    _with1.ElementoClave_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("ElementoClave_id")));
                    _with1.SistemaQA_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("SistemaQA_id")));
                    _with1.Originador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Originador")));
                    _with1.Estado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("estado")));
                    _with1.Fecha_alerta = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_alerta")));
                    _with1.Fecha_registro = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_registro")));
                    _with1.Registrador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Registrador")));
                    _with1.activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("activo")));

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
            return _AlertasBE;
        }
        public int InsertarALR_Alertas(ALR_AlertasBE _AlertasBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarALR_Alertas";
            SqlParameter par1;
            try
            {
                //SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                //par4.Direction = ParameterDirection.ReturnValue;
                par1 = cmd.Parameters.Add(new SqlParameter("@Alerta_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Alerta_desc"].Value = _AlertasBE.Alerta_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _AlertasBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_id"].Value = _AlertasBE.Area_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _AlertasBE.Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@SistemaQA_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SistemaQA_id"].Value = _AlertasBE.SistemaQA_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ElementoClave_id"].Value = _AlertasBE.ElementoClave_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Clasificacion", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Clasificacion"].Value = _AlertasBE.Clasificacion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _AlertasBE.Originador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _AlertasBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_alerta", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_alerta"].Value = _AlertasBE.Fecha_alerta;
                par1 = cmd.Parameters.Add(new SqlParameter("@Registrador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registrador"].Value = _AlertasBE.Registrador;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _id_Alerta = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Alerta_ID")));
            }
            catch (SqlException x)
            {
                _id_Alerta = 0;
            }
            catch (Exception x)
            {
                _id_Alerta = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _id_Alerta;
        }
        public bool ActualizarALR_Alertas(ALR_AlertasBE _AlertasBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarALR_Alertas";
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Alerta_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Alerta_id"].Value = _AlertasBE.Alerta_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Alerta_desc", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Alerta_desc"].Value = _AlertasBE.Alerta_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _AlertasBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_id"].Value = _AlertasBE.Area_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _AlertasBE.Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@SistemaQA_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SistemaQA_id"].Value = _AlertasBE.SistemaQA_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ElementoClave_id"].Value = _AlertasBE.ElementoClave_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _AlertasBE.Originador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Clasificacion", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Clasificacion"].Value = _AlertasBE.Clasificacion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _AlertasBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_alerta", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_alerta"].Value = _AlertasBE.Fecha_alerta;
                par1 = cmd.Parameters.Add(new SqlParameter("@Registrador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registrador"].Value = _AlertasBE.Registrador;
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
        public bool EliminarALR_Alertas(int _Alerta_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarALR_Alertas";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@Alerta_id", SqlDbType.Int));
                cmd.Parameters["@Alerta_id"].Value = _Alerta_id;
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

        public DataTable BuscarALR_AlertasByUsuario(int _Usuario_id, short _Permiso)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                if (_Permiso == 1)
                {
                    cmd.CommandText = "sp_BuscarALR_AlertaByAdministrador";
                }
                else
                {
                    cmd.CommandText = "sp_BuscarALR_AlertaByUsuario";
                    cmd.Parameters.Add(new SqlParameter("@Usuario_id", SqlDbType.Int));
                    cmd.Parameters["@Usuario_id"].Value = _Usuario_id;
                }
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
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
            return dts.Tables["Alerta"];
        }



        public DataTable ListarALR_Alertas_Estadistica(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador, string _Estado, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_Alertas_Estadistica";
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Guardia_id"].Value = _Guardia_id;
                cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Area_id"].Value = _Area_id;
                cmd.Parameters.Add(new SqlParameter("@Clasificacion_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Clasificacion_id"].Value = _Clasificacion_id;
                cmd.Parameters.Add(new SqlParameter("@SistemaQA_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@SistemaQA_id"].Value = _SistemaQA_id;
                cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@ElementoClave_id"].Value = _ElementoClave_id;
                cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.VarChar, 6));
                cmd.Parameters["@Originador"].Value = _Originador;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 6));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta"].Value = _Fecha_Alerta;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta1"].Value = _Fecha_Alerta1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
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
            return dts.Tables["Alerta"];
        }

        public DataTable ListarALR_AlertasFindXLS(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador, string _Estado, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_Alertas_findXLS";
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Guardia_id"].Value = _Guardia_id;
                cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Area_id"].Value = _Area_id;
                cmd.Parameters.Add(new SqlParameter("@Clasificacion", SqlDbType.VarChar, 6));
                cmd.Parameters["@Clasificacion"].Value = _Clasificacion;
                cmd.Parameters.Add(new SqlParameter("@SistemaQA_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@SistemaQA_id"].Value = _SistemaQA_id;
                cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@ElementoClave_id"].Value = _ElementoClave_id;
                cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.VarChar, 6));
                cmd.Parameters["@Originador"].Value = _Originador;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 6));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta"].Value = _Fecha_Alerta;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Alerta1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Alerta1"].Value = _Fecha_Alerta1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
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
            return dts.Tables["Alerta"];
        }

        public int ContarTB_PlanAccionByAlerta(int _Alerta_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ContarTB_PlanAccionByAlerta";
            SqlParameter par1;
            int _NumPlan;
            try
            {
                //SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                //par4.Direction = ParameterDirection.ReturnValue;
                par1 = cmd.Parameters.Add(new SqlParameter("@Alerta_id", SqlDbType.VarChar, 100));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Alerta_id"].Value = _Alerta_id;
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


        public DataTable ListarALR_AlertasByDepartamento(DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_AlertasByDepartamento";
                cmd.Parameters.Add(new SqlParameter("@Fecha_alerta", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_alerta"].Value = _Fecha_Alerta;
                cmd.Parameters.Add(new SqlParameter("@Fecha_alerta1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_alerta1"].Value = _Fecha_Alerta1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
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
            return dts.Tables["Alerta"];
        }

        public DataTable ListarALR_AlertasByDepartamentoFuncionario(int _Departamento_id, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarALR_AlertasByDepartamentoFuncionario";
                cmd.Parameters.Add(new SqlParameter("@Fecha_alerta", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_alerta"].Value = _Fecha_Alerta;
                cmd.Parameters.Add(new SqlParameter("@Fecha_alerta1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_alerta1"].Value = _Fecha_Alerta1;
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.Int));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Alerta");
                dtv = dts.Tables["Alerta"].DefaultView;
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
            return dts.Tables["Alerta"];
        }
    }
}
