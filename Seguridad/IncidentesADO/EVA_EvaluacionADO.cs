using IncidentesBE;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class EVA_EvaluacionADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        private static readonly ILog log = LogManager.GetLogger(typeof(EVA_EvaluacionADO));

        public DataTable ListarEVA_Evaluacion_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_Evaluacion_All";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
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
        public List<EVA_EvaluacionBE> ListarEVA_EvaluacionO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<EVA_EvaluacionBE> lEVA_EvaluacionBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEVA_Evaluacion_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lEVA_EvaluacionBE = new List<EVA_EvaluacionBE>();
                    int posEvaluacion_id = drd.GetOrdinal("Evaluacion_id");
                    int posEmpelado_id = drd.GetOrdinal("Empelado_id");
                    int posSubCategoria_id = drd.GetOrdinal("SubCategoria_id");
                    int posLider_id = drd.GetOrdinal("Lider_id");
                    int posFecha_registro = drd.GetOrdinal("Fecha_registro");                    
                    int posTipo = drd.GetOrdinal("Tipo");
                    int posActivo = drd.GetOrdinal("Activo");
                    EVA_EvaluacionBE obeEvaluacionBE = null;
                    while (drd.Read())
                    {
                        obeEvaluacionBE = new EVA_EvaluacionBE();
                        obeEvaluacionBE.Evaluacion_id = drd.GetInt32(posEvaluacion_id);
                        obeEvaluacionBE.Empleado_id = drd.GetInt32(posEvaluacion_id);
                        obeEvaluacionBE.SubCategoria_id = drd.GetInt16(posSubCategoria_id);
                        obeEvaluacionBE.Lider_id = drd.GetInt16(posFecha_registro);
                        obeEvaluacionBE.Fecha_registro = drd.GetDateTime(posFecha_registro);
                        obeEvaluacionBE.Tipo = drd.GetInt16(posFecha_registro);
                        obeEvaluacionBE.activo = drd.GetBoolean(posActivo);
                        lEVA_EvaluacionBE.Add(obeEvaluacionBE);
                    }
                    drd.Close();

                }
                con.Close();
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex.InnerException);
            }
            return (lEVA_EvaluacionBE);
        }

        public DataTable ListarEVA_Evaluacion_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_Evaluacion_Act";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
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
        public int InsertarEVA_Evaluacion(EVA_EvaluacionBE _EVA_EvaluacionBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarEVA_Evaluacion";
            SqlParameter par1;
            int _Evaluacion_id;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Empleado_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Empleado_id"].Value = _EVA_EvaluacionBE.Empleado_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider_id"].Value = _EVA_EvaluacionBE.Lider_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _EVA_EvaluacionBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo"].Value = _EVA_EvaluacionBE.Tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.Char, 7));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = _EVA_EvaluacionBE.Anio;

                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Evaluacion_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Evaluacion_id")));
                log.DebugFormat("Esquema: [DBO] SP: sp_InsertarEVA_Evaluacion Parametros In: Empleado_id:{0}, Lider_id:{1}, Departamento_id:{2}, Tipo:{3}, Anio:{4}"
                    , _EVA_EvaluacionBE.Empleado_id, _EVA_EvaluacionBE.Lider_id, _EVA_EvaluacionBE.Departamento_id, _EVA_EvaluacionBE.Tipo, _EVA_EvaluacionBE.Anio);

            }
            catch (SqlException x)
            {
                _Evaluacion_id = 0;
                log.Error(x.Message, x.InnerException);
            }
            catch (Exception x)
            {
                _Evaluacion_id = 0;
                log.Error(x.Message, x.InnerException);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Evaluacion_id;
        }
        public bool ActualizarEVA_Evaluacion(EVA_EvaluacionBE _EVA_EvaluacionBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarEVA_Evaluacion";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Evaluacion_id"].Value = _EVA_EvaluacionBE.Evaluacion_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Empleado_id", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Empleado_id"].Value = _EVA_EvaluacionBE.Empleado_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _EVA_EvaluacionBE.SubCategoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider_id"].Value = _EVA_EvaluacionBE.Lider_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _EVA_EvaluacionBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo"].Value = _EVA_EvaluacionBE.Tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.Char, 7));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = _EVA_EvaluacionBE.Anio;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;
                log.DebugFormat("Esquema: [DBO] SP: sp_ActualizarEVA_Evaluacion Parametros In: Evaluacion_id:{0}, Empleado_id:{2}, Lider_id:{3}, Departamento_id:{4}, Tipo:{5}, Anio:{6}"
                    , _EVA_EvaluacionBE.Evaluacion_id, _EVA_EvaluacionBE.Empleado_id, _EVA_EvaluacionBE.Lider_id, _EVA_EvaluacionBE.Departamento_id, _EVA_EvaluacionBE.Tipo, _EVA_EvaluacionBE.Anio);
            }
            catch (SqlException x)
            {
                _vcod = false;
                log.Error(x.Message, x.InnerException);
            }
            catch (Exception x)
            {
                _vcod = false;
                log.Error(x.Message, x.InnerException);
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

        public bool EliminarEVA_Evaluacion(int _Evaluacion_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarEVA_Evaluacion";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Evaluacion_id"].Value = _Evaluacion_id;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;

            }
            catch (SqlException x)
            {
                _vcod = false;
                log.Error(x.Message, x.InnerException);
            }
            catch (Exception x)
            {
                _vcod = false;
                log.Error(x.Message, x.InnerException);
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

        public EVA_EvaluacionBE TraerEVA_EvaluacionById(int _Evaluacion_id)
        {
            EVA_EvaluacionBE _EVA_EvaluacionBE = new EVA_EvaluacionBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerEVA_EvaluacionById";
                cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.Int));
                cmd.Parameters["@Evaluacion_id"].Value = _Evaluacion_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _EVA_EvaluacionBE;
                    _with1.Evaluacion_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Evaluacion_id")));
                    _with1.Empleado_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Empleado_id")));
                    _with1.SubCategoria_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("SubCategoria_id")));
                    _with1.Lider_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Lider_id")));
                    _with1.Fecha_registro = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_Registro")));
                    _with1.Departamento_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Departamento_id")));
                    _with1.Tipo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Tipo")));
                    _with1.Anio = (dtr.GetValue(dtr.GetOrdinal("Anio"))).ToString();
                    _with1.activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("Activo")));
                }
            }
            catch (SqlException x)
            {
                log.Error(x.Message, x.InnerException);
                throw new Exception(x.Message);                
            }
            catch (Exception x)
            {
                log.Error(x.Message, x.InnerException);
                throw new Exception(x.Message);                
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _EVA_EvaluacionBE;
        }
        public string TraerEVA_LimiteCalsificacion(int _Evaluacion_id)
        {
            string _Clasificacion="";
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerEVA_LimiteCalsificacion";
                cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.Int));
                cmd.Parameters["@Evaluacion_id"].Value = _Evaluacion_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    _Clasificacion = (dtr.GetValue(dtr.GetOrdinal("Clasificacion"))).ToString();
                    
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex.InnerException);
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
            return _Clasificacion;
        }
        public DataTable TraerEVA_EvaluacionSemaforo(short _Departamento_id)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerEVA_EvaluacionSemaforo";
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
                log.Error(ex.Message, ex.InnerException);
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
        public DataTable ListarEVA_EvaluacionFind(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_EvaluacionFind";
               
                par1 = cmd.Parameters.Add(new SqlParameter("@Empleado_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Empleado_id"].Value = _Empleado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _Categoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _SubCategoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 2));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo"].Value = _Tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = _Anio;
                par1 = cmd.Parameters.Add(new SqlParameter("@Clasificacion", SqlDbType.VarChar, 20));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Clasificacion"].Value = _Clasificacion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider"].Value = _Lider;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 2));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Arealabor", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Arealabor"].Value = _Arealaboral;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
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
        public int TraerEVA_EvaluacionUltimo(short _Departamento_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_TraerEVA_EvaluacionUltimo";
            SqlParameter par1;
            int _Evaluacion_id;
            try
            {

                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Evaluacion_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Evaluacion_id")));
            }
            catch (SqlException x)
            {
                log.Error(x.Message, x.InnerException);
                _Evaluacion_id = 0;
            }
            catch (Exception x)
            {
                log.Error(x.Message, x.InnerException);
                _Evaluacion_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Evaluacion_id;
        }

        public bool FirmarEVA_Evaluacion(int Evaluacion_id, DateTime Hoy)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_FirmarEVA_Evaluacion";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Evaluacion_id"].Value = Evaluacion_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Hoy", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Hoy"].Value = Hoy;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;
            }
            catch (SqlException x)
            {
                log.Error(x.Message, x.InnerException);
                _vcod = false;
            }
            catch (Exception x)
            {
                log.Error(x.Message, x.InnerException);
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

        public int ExisteEva_Evaluacion(short Empleado_id, string Anio)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_TraerEVA_EvaluacionExiste";
            SqlParameter par1;
            int _Evaluacion_id;
            try
            {

                par1 = cmd.Parameters.Add(new SqlParameter("@Empleado_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Empleado_id"].Value = Empleado_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.Char, 7));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = Anio;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Evaluacion_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Evaluacion_id")));
            }
            catch (SqlException x)
            {
                log.Error(x.Message, x.InnerException);
                _Evaluacion_id = 0;
            }
            catch (Exception x)
            {
                log.Error(x.Message, x.InnerException);
                _Evaluacion_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Evaluacion_id;
        }

        public bool ActualizarEVA_EvaluacionNota(int _Evaluacion_id, float _Suma)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarEVA_EvaluacionNota";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Evaluacion_id"].Value = _Evaluacion_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Puntos", SqlDbType.Real));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Puntos"].Value = _Suma;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;
            }
            catch (SqlException x)
            {
                log.Error(x.Message, x.InnerException);
                _vcod = false;
            }
            catch (Exception x)
            {
                log.Error(x.Message, x.InnerException);
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

        
        public DataTable ListarEVA_EvaluacionEstadistica(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_EvaluacionEstadistica";
                par1 = cmd.Parameters.Add(new SqlParameter("@Empleado_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Empleado_id"].Value = _Empleado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _Categoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _SubCategoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 2));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo"].Value = _Tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = _Anio;
                par1 = cmd.Parameters.Add(new SqlParameter("@Clasificacion", SqlDbType.VarChar, 20));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Clasificacion"].Value = _Clasificacion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider"].Value = _Lider;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Arealabor", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Arealabor"].Value = _Arealaboral;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
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
        public List<EVA_CurvaBE> TraerEVA_EvaluacionCurva(string _Departamento_id, string _Lider_id, string _Anio, string _Tipo, string _AreaLabor, string _Categoria)
        {
            string conexion = MiConexion.GetCnx();
            List<EVA_CurvaBE> lEVA_CurvaBE = null;
            try
            {
                SqlParameter par1;
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("[sp_TraerEVA_EvaluacionCurva]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 8));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider_id", SqlDbType.VarChar, 8));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider_id"].Value = _Lider_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = _Anio;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 3));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo"].Value = _Tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor"].Value = _AreaLabor;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria"].Value = _Categoria; 

                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lEVA_CurvaBE = new List<EVA_CurvaBE>();

                    EVA_CurvaBE obeCurvaBE = null;
                    while (drd.Read())
                    {
                        obeCurvaBE = new EVA_CurvaBE();
                        obeCurvaBE.Clasificacion = drd[0].ToString();
                        obeCurvaBE.Color = drd[1].ToString();
                        obeCurvaBE.Peso = Convert.ToDouble(drd[2]);
                        obeCurvaBE.Porcentaje = Convert.ToDouble(drd[3]);
                        lEVA_CurvaBE.Add(obeCurvaBE);
                    }
                    drd.Close();

                }
                con.Close();
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex.InnerException);
            }
            return (lEVA_CurvaBE);
        }

        public DataTable TraerEVA_EvaluacionEstadisticaCurva(string _Departamento_id, string _Lider_id, string _Anio, string _Tipo, string _AreaLabor, string _Categoria)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerEVA_EvaluacionEstadisticaCurva";
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 8));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider_id", SqlDbType.VarChar, 8));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider_id"].Value = _Lider_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = _Anio;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 3));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo"].Value = _Tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor"].Value = _AreaLabor;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria"].Value = _Categoria; 
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
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

        public DataTable ListarEVA_EvaluacionFindXML(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_EvaluacionFindXML";

                par1 = cmd.Parameters.Add(new SqlParameter("@Empleado_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Empleado_id"].Value = _Empleado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _Categoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _SubCategoria;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 2));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo"].Value = _Tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = _Anio;
                par1 = cmd.Parameters.Add(new SqlParameter("@Clasificacion", SqlDbType.VarChar, 20));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Clasificacion"].Value = _Clasificacion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lider", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lider"].Value = _Lider;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 2));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Arealabor", SqlDbType.VarChar, 10));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Arealabor"].Value = _Arealaboral;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
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

        public object ListarEVA_EvaluacionByCarta(string Empleado, string lider, string Anio)
        {
            DataSet dts = new DataSet();
            SqlParameter par1;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_EvaluacionByCarta";
                par1 = cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 7));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Anio"].Value = Anio;
                par1 = cmd.Parameters.Add(new SqlParameter("@FUNCIONARIO_NOME", SqlDbType.VarChar, 80));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@FUNCIONARIO_NOME"].Value = lider;
                par1 = cmd.Parameters.Add(new SqlParameter("@lider_id", SqlDbType.VarChar, 5));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@lider_id"].Value = lider;
                
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Sistemas");
                dtv = dts.Tables["Sistemas"].DefaultView;
            }
            catch (SqlException ex)
            {
                log.Error(ex.Message, ex.InnerException);
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
