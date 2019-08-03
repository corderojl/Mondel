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
    public class EVA_EvaluacionDetalleADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        private static readonly ILog log = LogManager.GetLogger(typeof(EVA_EvaluacionADO));

        public DataTable ListarEVA_EvaluacionDetalle_All()
        {
            DataSet dts = new DataSet();

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_EvaluacionDetalle_All";

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

        public List<EVA_EvaluacionDetalleBE> ListarEVA_EvaluacionDetalleO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<EVA_EvaluacionDetalleBE> lEVA_EvaluacionDetalleBE = null;

            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEVA_EvaluacionDetalle_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lEVA_EvaluacionDetalleBE = new List<EVA_EvaluacionDetalleBE>();

                    int posEvaluacionDetalle_id = drd.GetOrdinal("EvaluacionDetalle_id");
                    int posEvaluacion_id = drd.GetOrdinal("Evaluacion_id");
                    int posIndicador_id = drd.GetOrdinal("Indicador_id");

                    int posPuntos = drd.GetOrdinal("Puntos");
                    int posPuntosOpt = drd.GetOrdinal("PuntosOpt");
                    int posActivo = drd.GetOrdinal("Activo");
                    EVA_EvaluacionDetalleBE obeCategoriaBE = null;

                    while (drd.Read())
                    {
                        obeCategoriaBE = new EVA_EvaluacionDetalleBE();
                        obeCategoriaBE.EvaluacionDetalle_id = drd.GetInt32(posEvaluacionDetalle_id);
                        obeCategoriaBE.Evaluacion_id = drd.GetInt32(posEvaluacion_id);
                        obeCategoriaBE.Indicador_id = drd.GetInt32(posIndicador_id);

                        obeCategoriaBE.Puntos = drd.GetInt32(posPuntos);
                        obeCategoriaBE.PuntosOpt = drd.GetInt16(posPuntosOpt);
                        lEVA_EvaluacionDetalleBE.Add(obeCategoriaBE);
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
            return (lEVA_EvaluacionDetalleBE);
        }

        public DataTable ListarEVA_EvaluacionDetalle_Act()
        {
            DataSet dts = new DataSet();

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_EvaluacionDetalle_Act";

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

        public int InsertarEVA_EvaluacionDetalle(EVA_EvaluacionDetalleBE _EVA_EvaluacionDetalleBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarEVA_EvaluacionDetalle";

            SqlParameter par1;
            int _Categoria_id;

            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Evaluacion_id"].Value = _EVA_EvaluacionDetalleBE.Evaluacion_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Indicador_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Indicador_id"].Value = _EVA_EvaluacionDetalleBE.Indicador_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Puntos", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Puntos"].Value = _EVA_EvaluacionDetalleBE.Puntos;
                par1 = cmd.Parameters.Add(new SqlParameter("@PuntosOpt", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@PuntosOpt"].Value = _EVA_EvaluacionDetalleBE.PuntosOpt;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _Categoria_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("@@identity")));
                log.DebugFormat("Esquema: [DBO] SP: sp_InsertarEVA_EvaluacionDetalle Parametros In: Evaluacion_id:{0}, Indicador_id:{1}, Puntos:{2}, PuntosOpt:{3}"
                    , _EVA_EvaluacionDetalleBE.Evaluacion_id, _EVA_EvaluacionDetalleBE.Indicador_id, _EVA_EvaluacionDetalleBE.Puntos, _EVA_EvaluacionDetalleBE.PuntosOpt);
            }
            catch (SqlException x)
            {
                log.Error(x.Message, x.InnerException);
                _Categoria_id = 0;
            }
            catch (Exception x)
            {
                _Categoria_id = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _Categoria_id;
        }

        public bool ActualizarEVA_EvaluacionDetalle(EVA_EvaluacionDetalleBE _EVA_EvaluacionDetalleBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarEVA_EvaluacionDetalle";

            SqlParameter par1;
            bool _vcod;

            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@EvaluacionDetalle_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EvaluacionDetalle_id"].Value = _EVA_EvaluacionDetalleBE.EvaluacionDetalle_id;

                par1 = cmd.Parameters.Add(new SqlParameter("@PuntosOpt", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@PuntosOpt"].Value = _EVA_EvaluacionDetalleBE.PuntosOpt;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;
                log.DebugFormat("Esquema: [DBO] SP: sp_ActualizarEVA_EvaluacionDetalle Parametros In: EvaluacionDetalle_id:{0}, PuntosOpt:{1}"
                    , _EVA_EvaluacionDetalleBE.EvaluacionDetalle_id, _EVA_EvaluacionDetalleBE.PuntosOpt);
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

        public bool ActualizarEVA_EvaluacionDetalleFin(EVA_EvaluacionDetalleBE _EVA_EvaluacionDetalleBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarEVA_EvaluacionDetalleFin";

            SqlParameter par1;
            bool _vcod;

            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@EvaluacionDetalle_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EvaluacionDetalle_id"].Value = _EVA_EvaluacionDetalleBE.EvaluacionDetalle_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Evaluacion_id"].Value = _EVA_EvaluacionDetalleBE.Evaluacion_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Puntos", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Puntos"].Value = _EVA_EvaluacionDetalleBE.Puntos;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;
                log.DebugFormat("Esquema: [DBO] SP: sp_ActualizarEVA_EvaluacionDetalleFin Parametros In: EvaluacionDetalle_id:{0}, Evaluacion_id:{1}, Puntos:{2}"
                   , _EVA_EvaluacionDetalleBE.EvaluacionDetalle_id, _EVA_EvaluacionDetalleBE.Evaluacion_id, _EVA_EvaluacionDetalleBE.Puntos);
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

        public bool EliminarEVA_EvaluacionDetalle(int _EvaluacionDetalle_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarEVA_EvaluacionDetalle";

            SqlParameter par1;
            bool _vcod;

            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@EvaluacionDetalle_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EvaluacionDetalle_id"].Value = _EvaluacionDetalle_id;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;
                log.DebugFormat("Esquema: [DBO] SP: sp_EliminarEVA_EvaluacionDetalle Parametros In: _EvaluacionDetalle_id:{0}"
                  , _EvaluacionDetalle_id);
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

        public EVA_EvaluacionDetalleBE TraerEVA_EvaluacionDetalleById(int _EvaluacionDetalle_id)
        {
            EVA_EvaluacionDetalleBE _EVA_EvaluacionDetalleBE = new EVA_EvaluacionDetalleBE();
            DataSet dts = new DataSet();

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerEVA_EvaluacionDetalleById";
                cmd.Parameters.Add(new SqlParameter("@EvaluacionDetalle_id", SqlDbType.Int));
                cmd.Parameters["@EvaluacionDetalle_id"].Value = _EvaluacionDetalle_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();

                    var _with1 = _EVA_EvaluacionDetalleBE;
                    _with1.EvaluacionDetalle_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Indicador_id")));
                    _with1.Evaluacion_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Evaluacion_id")));
                    _with1.Indicador_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Indicador_id")));
                    _with1.PuntosOpt = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("PuntosOpt")));
                    _with1.Puntos = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Puntos")));
                }
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
            return _EVA_EvaluacionDetalleBE;
        }

        public DataTable BuscarEVA_EvaluacionDetalleByEvaluacion(int _Evaluacion_id, string _Var)
        {
            DataSet dts = new DataSet();

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_EvaluacionDetalleByEvaluacion" + _Var;
                cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.Int));
                cmd.Parameters["@Evaluacion_id"].Value = _Evaluacion_id;

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

        public bool ActualizarEVA_EvaluacionDetalleObservacion(int _EvaluacionDetalle_id, string _Observacion)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarEVA_EvaluacionDetalleObservacion";

            SqlParameter par1;
            bool _vcod;

            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@EvaluacionDetalle_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EvaluacionDetalle_id"].Value = _EvaluacionDetalle_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Observacion", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Observacion"].Value = _Observacion;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = true;
                log.DebugFormat("Esquema: [DBO] SP: sp_ActualizarEVA_EvaluacionDetalleObservacion Parametros In: EvaluacionDetalle_id:{0}, Observacion:{1}"
                  , _EvaluacionDetalle_id, _Observacion);
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

        public bool TraerEVA_EvaluacionDetalleExistePunto0(int _Evaluacion_id)
        {
            SqlDataReader dtr = default(SqlDataReader);
            DataSet dts = new DataSet();
            bool vexito = false;

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerEVA_EvaluacionDetalleExistePunto0";
                cmd.Parameters.Add(new SqlParameter("@Evaluacion_id", SqlDbType.SmallInt));
                cmd.Parameters["@Evaluacion_id"].Value = _Evaluacion_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    vexito = true;
                }
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
            return vexito;
        }
    }
}