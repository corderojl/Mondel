using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class LUP_LupADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        Boolean _vcod = false;
        int _id_Lup = 0;
        LUP_LupBE _LUP_LupBE = new LUP_LupBE();


        public DataTable ListarLUP_LupAll()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarLUP_Lup_All";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Lup");
                dtv = dts.Tables["Lup"].DefaultView;
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
            return dts.Tables["Lup"];
        }
        public DataTable ListarLUP_LupAct()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarLUP_Lup_Act";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Lup");
                dtv = dts.Tables["Lup"].DefaultView;
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
            return dts.Tables["Lup"];
        }

        
        /*Falta usar*/
        public DataTable EstadisticaLUP_LupRegistroByFecha(DateTime _Fecha_Lup, DateTime _Fecha_Lup1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_EstadisticaLUP_LupRegistroByFecha";
                cmd.Parameters.Add(new SqlParameter("@Fecha_Lup", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Lup"].Value = _Fecha_Lup;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Lup1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Lup1"].Value = _Fecha_Lup1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Lup");
                dtv = dts.Tables["Lup"].DefaultView;
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
            return dts.Tables["Lup"];
        }
        public LUP_LupBE TraerLUP_LupById(int _Lup_id)
        {
            LUP_LupBE _LupsBE = new LUP_LupBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerLUP_LupById";
                cmd.Parameters.Add(new SqlParameter("@Lup_id", SqlDbType.Int));
                cmd.Parameters["@Lup_id"].Value = _Lup_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _LupsBE;
                    _with1.Lup_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Lup_id")));
                    _with1.Lup_Titulo = dtr.GetValue(dtr.GetOrdinal("Lup_Titulo")).ToString();
                    _with1.Lup_desc = dtr.GetValue(dtr.GetOrdinal("Lup_desc")).ToString();
                    _with1.Pilar_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Pilar_id")));
                    _with1.Departamento_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Departamento_id")));
                    _with1.Guardia_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("guardia_id")));
                    _with1.Categoria_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Categoria_id")));
                    _with1.Encargado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Encargado")));
                    _with1.adjunto_lup = dtr.GetValue(dtr.GetOrdinal("adjunto_lup")).ToString();
                    _with1.fecha_reg = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fecha_reg")));
                    _with1.fecha_ven = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fecha_ven")));
                    _with1.Registrador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Registrador")));
                    _with1.Estado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Estado")));
                    _with1.activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("activo")));
                    _with1.adjunto_aprob = dtr.GetValue(dtr.GetOrdinal("adjunto_aprob")).ToString();
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
            return _LupsBE;
        }
        public int InsertarLUP_Lup(LUP_LupBE _LupsBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarLUP_Lup";
            SqlParameter par1;
            try
            {
                //SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                //par4.Direction = ParameterDirection.ReturnValue;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lup_Titulo", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lup_Titulo"].Value = _LupsBE.Lup_Titulo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lup_desc", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lup_desc"].Value = _LupsBE.Lup_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pilar_id"].Value = _LupsBE.Pilar_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _LupsBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@guardia_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@guardia_id"].Value = _LupsBE.Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _LupsBE.Categoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Encargado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Encargado"].Value = _LupsBE.Encargado;
                par1 = cmd.Parameters.Add(new SqlParameter("@adjunto_lup", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@adjunto_lup"].Value = _LupsBE.adjunto_lup;
                par1 = cmd.Parameters.Add(new SqlParameter("@fecha_ven", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@fecha_ven"].Value = _LupsBE.fecha_ven;
                par1 = cmd.Parameters.Add(new SqlParameter("@Registrador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registrador"].Value = _LupsBE.Registrador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _LupsBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@adjunto_aprob", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@adjunto_aprob"].Value = _LupsBE.adjunto_aprob;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _id_Lup = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Lup_ID")));
            }
            catch (SqlException x)
            {
                _id_Lup = 0;
            }
            catch (Exception x)
            {
                _id_Lup = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _id_Lup;
        }
        public bool ActualizarLUP_Lup(LUP_LupBE _LupsBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarLUP_Lup";
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Lup_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lup_id"].Value = _LupsBE.Lup_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lup_Titulo", SqlDbType.VarChar, 200));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lup_Titulo"].Value = _LupsBE.Lup_Titulo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Lup_desc", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lup_desc"].Value = _LupsBE.Lup_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pilar_id"].Value = _LupsBE.Pilar_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _LupsBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@guardia_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@guardia_id"].Value = _LupsBE.Guardia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Categoria_id"].Value = _LupsBE.Categoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Encargado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Encargado"].Value = _LupsBE.Encargado;
                par1 = cmd.Parameters.Add(new SqlParameter("@adjunto_lup", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@adjunto_lup"].Value = _LupsBE.adjunto_lup;
                par1 = cmd.Parameters.Add(new SqlParameter("@fecha_ven", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@fecha_ven"].Value = _LupsBE.fecha_ven;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _LupsBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@adjunto_aprob", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@adjunto_aprob"].Value = _LupsBE.adjunto_aprob;
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
        public bool EliminarLUP_Lup(int _Lup_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarLUP_Lup";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@Lup_id", SqlDbType.Int));
                cmd.Parameters["@Lup_id"].Value = _Lup_id;
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

        public DataTable BuscarLUP_LupByUsuario(int _Usuario_id, short _Permiso)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                if (_Permiso == 1)
                {
                    cmd.CommandText = "sp_BuscarALR_LupByAdministrador";
                }
                else
                {
                    cmd.CommandText = "sp_BuscarALR_LupByUsuario";
                    cmd.Parameters.Add(new SqlParameter("@Usuario_id", SqlDbType.Int));
                    cmd.Parameters["@Usuario_id"].Value = _Usuario_id;
                }
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Lup");
                dtv = dts.Tables["Lup"].DefaultView;
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
            return dts.Tables["Lup"];
        }



        public DataTable ListarLUP_Lup_Estadistica(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador, string _Estado, DateTime _Fecha_Lup, DateTime _Fecha_Lup1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarLUP_Lup_Estadistica";
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
                cmd.Parameters.Add(new SqlParameter("@Fecha_Lup", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Lup"].Value = _Fecha_Lup;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Lup1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Lup1"].Value = _Fecha_Lup1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Lup");
                dtv = dts.Tables["Lup"].DefaultView;
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
            return dts.Tables["Lup"];
        }

        public DataTable ListarLUP_LupFind(string dep, string pil, string gua, string cat, string due, string estado, DateTime fecha, DateTime fecha1,string palabra)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarLUP_LUP_Find";
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Departamento_id"].Value = dep;
                cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Pilar_id"].Value = pil;
                cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Guardia_id"].Value = gua;
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Categoria_id"].Value = cat;
                cmd.Parameters.Add(new SqlParameter("@Duenio_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Duenio_id"].Value = due;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 8));
                cmd.Parameters["@Estado"].Value = estado;
                cmd.Parameters.Add(new SqlParameter("@Palabra", SqlDbType.VarChar, 200));
                cmd.Parameters["@Palabra"].Value = palabra;
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime));
                cmd.Parameters["@Fecha"].Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@Fecha1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha1"].Value = fecha1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Lup");
                dtv = dts.Tables["Lup"].DefaultView;
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
            return dts.Tables["Lup"];
        }

        public short ContarLUP_LupAprobacion(short Lup_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ContarLUP_LupAprobacion";
            SqlParameter par1;
            short _NumPlan;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Lup_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Lup_id"].Value = Lup_id;               
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _NumPlan = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("numAprob")));
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

        public DataTable ListarLUP_LupFindXLS(string dep, string pil, string gua, string cat, string due, string estado, DateTime fecha, DateTime fecha1, string palabra)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarLUP_LUP_Find";
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Departamento_id"].Value = dep;
                cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Pilar_id"].Value = pil;
                cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Guardia_id"].Value = gua;
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Categoria_id"].Value = cat;
                cmd.Parameters.Add(new SqlParameter("@Duenio_id", SqlDbType.VarChar, 8));
                cmd.Parameters["@Duenio_id"].Value = due;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 8));
                cmd.Parameters["@Estado"].Value = estado;
                cmd.Parameters.Add(new SqlParameter("@Palabra", SqlDbType.VarChar, 200));
                cmd.Parameters["@Palabra"].Value = palabra;
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime));
                cmd.Parameters["@Fecha"].Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@Fecha1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha1"].Value = fecha1;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Lup");
                dtv = dts.Tables["Lup"].DefaultView;
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
            return dts.Tables["Lup"];
        }
    }
}
