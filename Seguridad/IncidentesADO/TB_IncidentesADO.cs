using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_IncidentesADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        Boolean _vcod = false;
        int _id_Incidente = 0;
        TB_IncidentesBE _TB_IncidentesBE = new TB_IncidentesBE();


        public DataTable ListarTB_IncidentesAll()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Incidentes_All";
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
        public DataTable ListarTB_IncidentesAct()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Incidentes_Act";
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

        public DataTable ListarTB_IncidentesFind(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _Tipo_emp, string _Rol_id
            , string _Rol_tiempo, string _Compania_tiempo, string _Turno, string _Estatus_ope
            , string _Comportamiento_inv_id, string _Condicion_inv_id, string _CausaInmediata_id
            , string _Tecnologia_id, string _ElementoClave_id, string _Estado
            , DateTime _Fecha_incidente, DateTime _Fecha_incidente1, int _Usuario_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Incidentes_find";
                cmd.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Guardia", SqlDbType.VarChar, 6));
                cmd.Parameters["@Guardia"].Value = _Guardia_id;
                cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Area_id"].Value = _Area_id;
                cmd.Parameters.Add(new SqlParameter("@Clasificacion_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Clasificacion_id"].Value = _Clasificacion_id;
                cmd.Parameters.Add(new SqlParameter("@Tipo_emp", SqlDbType.VarChar, 6));
                cmd.Parameters["@Tipo_emp"].Value = _Tipo_emp;
                cmd.Parameters.Add(new SqlParameter("@Rol_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Rol_id"].Value = _Rol_id;
                cmd.Parameters.Add(new SqlParameter("@Rol_tiempo", SqlDbType.VarChar, 6));
                cmd.Parameters["@Rol_tiempo"].Value = _Rol_tiempo;
                cmd.Parameters.Add(new SqlParameter("@Compania_tiempo", SqlDbType.VarChar, 6));
                cmd.Parameters["@Compania_tiempo"].Value = _Compania_tiempo;
                cmd.Parameters.Add(new SqlParameter("@Turno", SqlDbType.VarChar, 6));
                cmd.Parameters["@Turno"].Value = _Turno;
                cmd.Parameters.Add(new SqlParameter("@Estatus_ope", SqlDbType.VarChar, 6));
                cmd.Parameters["@Estatus_ope"].Value = _Estatus_ope;
                cmd.Parameters.Add(new SqlParameter("@Riesgo_inv_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Riesgo_inv_id"].Value = _Comportamiento_inv_id;
                cmd.Parameters.Add(new SqlParameter("@Condicion_inv_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Condicion_inv_id"].Value = _Condicion_inv_id;
                cmd.Parameters.Add(new SqlParameter("@CausaInmediata_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@CausaInmediata_id"].Value = _CausaInmediata_id;
                cmd.Parameters.Add(new SqlParameter("@Tecnologia_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Tecnologia_id"].Value = _Tecnologia_id;
                cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@ElementoClave_id"].Value = _ElementoClave_id;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 6));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente"].Value = _Fecha_incidente;
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente1"].Value = _Fecha_incidente1;
                //cmd.Parameters.Add(new SqlParameter("@FECHA2", SqlDbType.DateTime));
                //cmd.Parameters["@FECHA2"].Value = _fecha2;
                //cmd.Parameters.Add(new SqlParameter("@FECHA3", SqlDbType.DateTime));
                //cmd.Parameters["@FECHA3"].Value = _fecha3;
                cmd.Parameters.Add(new SqlParameter("@Usuario_id", SqlDbType.Int));
                cmd.Parameters["@Usuario_id"].Value = _Usuario_id;
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

        public DataTable EstadisticaTB_IncidentesRegistroByFecha(DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_EstadisticaTB_IncidentesRegistroByFecha";
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente"].Value = _Fecha_incidente;
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente1"].Value = _Fecha_incidente1;
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
        public TB_IncidentesBE TraerTB_IncidentesById(int _Incidentes_id)
        {
            TB_IncidentesBE _IncidenteBE = new TB_IncidentesBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTB_IncidentesById";
                cmd.Parameters.Add(new SqlParameter("@Incidente_id", SqlDbType.Int));
                cmd.Parameters["@Incidente_id"].Value = _Incidentes_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _IncidenteBE;
                    _with1.Incidente_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Incidente_id")));
                    _with1.Titulo = dtr.GetValue(dtr.GetOrdinal("titulo")).ToString();
                    _with1.Descripcion = dtr.GetValue(dtr.GetOrdinal("Descripcion")).ToString();
                    _with1.Fecha_incidente = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_incidente")));
                    _with1.Fecha_estimada = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_estimada")));
                    _with1.Fecha_registro = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fecha_registro")));
                    _with1.Turno = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Turno")));
                    _with1.Tiempo_ext = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("tiempo_ext")));
                    _with1.Estatus_ope = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("estatus_ope")));
                    _with1.Departamento = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("departamento")));
                    _with1.Guardia = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("guardia")));
                    _with1.Area_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Area_id")));
                    _with1.Tipo_emp = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("tipo_emp")));
                    _with1.Contratista_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Contratista_id")));
                    _with1.Rol_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Rol_id")));
                    _with1.Rol_tiempo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("rol_tiempo")));
                    _with1.Compania_tiempo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("compania_tiempo")));
                    _with1.ParteCuerpo_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("ParteCuerpo_id")));
                    _with1.EquipoAfectado_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("EquipoAfectado_id")));
                    _with1.Clasificacion_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Clasificacion_id")));
                    _with1.Daño_tipo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("daño_tipo")));
                    _with1.Causainmediata_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Causainmediata_id")));
                    _with1.CausaRaiz_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("CausaRaiz_id")));
                    _with1.Tecnologia_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Tecnologia_id")));
                    _with1.ElementoClave_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("ElementoClave_id")));
                    _with1.Riesgo_inv_desc = dtr.GetValue(dtr.GetOrdinal("Riesgo_inv_desc")).ToString();
                    _with1.Condicion_inv_desc = dtr.GetValue(dtr.GetOrdinal("condicion_inv_desc")).ToString();
                    _with1.Riesgo_inv_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("riesgo_inv_id")));
                    _with1.Condicion_inv_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("condicion_inv_id")));
                    _with1.Originador = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("originador")));
                    _with1.Registro = dtr.GetValue(dtr.GetOrdinal("Registro")).ToString();
                    _with1.Estado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("estado")));
                    _with1.activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("activo")));
                    _with1.EmpleadoAfectado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("EmpleadoAfectado")));
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
            return _IncidenteBE;
        }
        public int InsertarTB_Incidentes(TB_IncidentesBE _IncidenteBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_Incidentes";
            SqlParameter par1;
            try
            {
                //SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                //par4.Direction = ParameterDirection.ReturnValue;
                par1 = cmd.Parameters.Add(new SqlParameter("@titulo", SqlDbType.VarChar, 100));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@titulo"].Value = _IncidenteBE.Titulo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Descripcion"].Value = _IncidenteBE.Descripcion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_incidente", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_incidente"].Value = _IncidenteBE.Fecha_incidente;
                par1 = cmd.Parameters.Add(new SqlParameter("@Turno", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Turno"].Value = _IncidenteBE.Turno;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tiempo_ext", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tiempo_ext"].Value = _IncidenteBE.Tiempo_ext;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estatus_ope", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estatus_ope"].Value = _IncidenteBE.Estatus_ope;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento"].Value = _IncidenteBE.Departamento;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia"].Value = _IncidenteBE.Guardia;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_id"].Value = _IncidenteBE.Area_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo_emp", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo_emp"].Value = _IncidenteBE.Tipo_emp;
                par1 = cmd.Parameters.Add(new SqlParameter("@contratista_id", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@contratista_id"].Value = _IncidenteBE.Contratista_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Rol_id", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Rol_id"].Value = 12;
                par1 = cmd.Parameters.Add(new SqlParameter("@Rol_tiempo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Rol_tiempo"].Value = _IncidenteBE.Rol_tiempo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Compania_tiempo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Compania_tiempo"].Value = _IncidenteBE.Compania_tiempo;
                par1 = cmd.Parameters.Add(new SqlParameter("@ParteCuerpo_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ParteCuerpo_id"].Value = _IncidenteBE.ParteCuerpo_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@EquipoAfectado_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EquipoAfectado_id"].Value = _IncidenteBE.EquipoAfectado_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Clasificacion_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Clasificacion_id"].Value = _IncidenteBE.Clasificacion_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Daño_tipo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Daño_tipo"].Value = _IncidenteBE.Daño_tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Causainmediata_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Causainmediata_id"].Value = _IncidenteBE.Causainmediata_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@CausaRaiz_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CausaRaiz_id"].Value = _IncidenteBE.CausaRaiz_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tecnologia_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tecnologia_id"].Value = _IncidenteBE.Tecnologia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ElementoClave_id"].Value = _IncidenteBE.ElementoClave_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Riesgo_inv_desc", SqlDbType.VarChar, 120));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Riesgo_inv_desc"].Value = "";
                par1 = cmd.Parameters.Add(new SqlParameter("@Condicion_inv_desc", SqlDbType.VarChar, 120));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Condicion_inv_desc"].Value = "";
                par1 = cmd.Parameters.Add(new SqlParameter("@Riesgo_inv_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Riesgo_inv_id"].Value = _IncidenteBE.Riesgo_inv_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Condicion_inv_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Condicion_inv_id"].Value = _IncidenteBE.Condicion_inv_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Registro", SqlDbType.Char, 20));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registro"].Value = _IncidenteBE.Registro;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _IncidenteBE.Originador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _IncidenteBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@EmpleadoAfectado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EmpleadoAfectado"].Value = _IncidenteBE.EmpleadoAfectado;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _id_Incidente = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Incidente_ID")));
            }
            catch (SqlException x)
            {
                _id_Incidente = 0;
            }
            catch (Exception x)
            {
                _id_Incidente = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _id_Incidente;
        }
        public bool ActualizarTB_Incidentes(TB_IncidentesBE _IncidenteBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTB_Incidentes";
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Incidente_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Incidente_id"].Value = _IncidenteBE.Incidente_id;

                par1 = cmd.Parameters.Add(new SqlParameter("@titulo", SqlDbType.VarChar, 100));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@titulo"].Value = _IncidenteBE.Titulo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Descripcion"].Value = _IncidenteBE.Descripcion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_incidente", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_incidente"].Value = _IncidenteBE.Fecha_incidente;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_estimada", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_estimada"].Value = _IncidenteBE.Fecha_estimada;
                par1 = cmd.Parameters.Add(new SqlParameter("@Turno", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Turno"].Value = _IncidenteBE.Turno;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tiempo_ext", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tiempo_ext"].Value = _IncidenteBE.Tiempo_ext;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estatus_ope", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estatus_ope"].Value = _IncidenteBE.Estatus_ope;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento"].Value = _IncidenteBE.Departamento;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia"].Value = _IncidenteBE.Guardia;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_id"].Value = _IncidenteBE.Area_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo_emp", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo_emp"].Value = _IncidenteBE.Tipo_emp;
                par1 = cmd.Parameters.Add(new SqlParameter("@Contratista_id", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Contratista_id"].Value = _IncidenteBE.Contratista_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Rol_id", SqlDbType.VarChar, 50));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Rol_id"].Value = 12;
                par1 = cmd.Parameters.Add(new SqlParameter("@Rol_tiempo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Rol_tiempo"].Value = _IncidenteBE.Rol_tiempo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Compania_tiempo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Compania_tiempo"].Value = _IncidenteBE.Compania_tiempo;
                par1 = cmd.Parameters.Add(new SqlParameter("@ParteCuerpo_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ParteCuerpo_id"].Value = _IncidenteBE.ParteCuerpo_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@EquipoAfectado_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EquipoAfectado_id"].Value = _IncidenteBE.EquipoAfectado_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Clasificacion_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Clasificacion_id"].Value = _IncidenteBE.Clasificacion_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Daño_tipo", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Daño_tipo"].Value = _IncidenteBE.Daño_tipo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Causainmediata_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Causainmediata_id"].Value = _IncidenteBE.Causainmediata_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@CausaRaiz_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CausaRaiz_id"].Value = _IncidenteBE.CausaRaiz_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tecnologia_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tecnologia_id"].Value = _IncidenteBE.Tecnologia_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@ElementoClave_id"].Value = _IncidenteBE.ElementoClave_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Riesgo_inv_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Riesgo_inv_id"].Value = _IncidenteBE.Riesgo_inv_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Condicion_inv_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Condicion_inv_id"].Value = _IncidenteBE.Condicion_inv_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Registro", SqlDbType.VarChar, 60));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Registro"].Value = _IncidenteBE.Registro;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _IncidenteBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@EmpleadoAfectado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@EmpleadoAfectado"].Value = _IncidenteBE.EmpleadoAfectado;
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
        public bool EliminarTB_Incidentes(int _Incidentes_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_Incidentes";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@Incidente_id", SqlDbType.Int));
                cmd.Parameters["@Incidente_id"].Value = _Incidentes_id;
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

        public DataTable BuscarTB_IncidentesByUsuario(int _Usuario_id, short _Permiso)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                if (_Permiso == 1)
                {
                    cmd.CommandText = "sp_BuscarTB_IncidentesByAdministrador";
                }
                else
                {
                    cmd.CommandText = "sp_BuscarTB_IncidentesByUsuario";
                    cmd.Parameters.Add(new SqlParameter("@Usuario_id", SqlDbType.Int));
                    cmd.Parameters["@Usuario_id"].Value = _Usuario_id;
                }
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



        public DataTable ListarTB_Incidentes_Estadistica(string _Departamento_id, string _Guardia_id, string _Area_id, string _Clasificacion_id, string _Tipo_emp, string _Rol_id, string _Rol_tiempo, string _Compania_tiempo, string _Turno, string _Estatus_ope, string _Comportamiento_inv_id, string _Condicion_inv_id, string _CausaInmediata_id, string _Tecnologia_id, string _ElementoClave_id, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Incidentes_Estadistica";
                cmd.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Guardia", SqlDbType.VarChar, 6));
                cmd.Parameters["@Guardia"].Value = _Guardia_id;
                cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Area_id"].Value = _Area_id;
                cmd.Parameters.Add(new SqlParameter("@Clasificacion_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Clasificacion_id"].Value = _Clasificacion_id;
                cmd.Parameters.Add(new SqlParameter("@Tipo_emp", SqlDbType.VarChar, 6));
                cmd.Parameters["@Tipo_emp"].Value = _Tipo_emp;
                cmd.Parameters.Add(new SqlParameter("@Rol_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Rol_id"].Value = _Rol_id;
                cmd.Parameters.Add(new SqlParameter("@Rol_tiempo", SqlDbType.VarChar, 6));
                cmd.Parameters["@Rol_tiempo"].Value = _Rol_tiempo;
                cmd.Parameters.Add(new SqlParameter("@Compania_tiempo", SqlDbType.VarChar, 6));
                cmd.Parameters["@Compania_tiempo"].Value = _Compania_tiempo;
                cmd.Parameters.Add(new SqlParameter("@Turno", SqlDbType.VarChar, 6));
                cmd.Parameters["@Turno"].Value = _Turno;
                cmd.Parameters.Add(new SqlParameter("@Estatus_ope", SqlDbType.VarChar, 6));
                cmd.Parameters["@Estatus_ope"].Value = _Estatus_ope;
                cmd.Parameters.Add(new SqlParameter("@Riesgo_inv_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Riesgo_inv_id"].Value = _Comportamiento_inv_id;
                cmd.Parameters.Add(new SqlParameter("@Condicion_inv_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Condicion_inv_id"].Value = _Condicion_inv_id;
                cmd.Parameters.Add(new SqlParameter("@CausaInmediata_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@CausaInmediata_id"].Value = _CausaInmediata_id;
                cmd.Parameters.Add(new SqlParameter("@Tecnologia_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Tecnologia_id"].Value = _Tecnologia_id;
                cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@ElementoClave_id"].Value = _ElementoClave_id;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 6));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente"].Value = _Fecha_incidente;
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente1"].Value = _Fecha_incidente1;
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

        public DataTable ListarTB_IncidentesFindXLS(string _Departamento_id, string _Guardia_id, string _Area_id, string _Clasificacion_id, string _Tipo_emp, string _Rol_id, string _Rol_tiempo, string _Compania_tiempo, string _Turno, string _Estatus_ope, string _Comportamiento_inv_id, string _Condicion_inv_id, string _CausaInmediata_id, string _Tecnologia_id, string _ElementoClave_id, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_Incidentes_findXLS";
                cmd.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Guardia", SqlDbType.VarChar, 6));
                cmd.Parameters["@Guardia"].Value = _Guardia_id;
                cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Area_id"].Value = _Area_id;
                cmd.Parameters.Add(new SqlParameter("@Clasificacion_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Clasificacion_id"].Value = _Clasificacion_id;
                cmd.Parameters.Add(new SqlParameter("@Tipo_emp", SqlDbType.VarChar, 6));
                cmd.Parameters["@Tipo_emp"].Value = _Tipo_emp;
                cmd.Parameters.Add(new SqlParameter("@Rol_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Rol_id"].Value = _Rol_id;
                cmd.Parameters.Add(new SqlParameter("@Rol_tiempo", SqlDbType.VarChar, 6));
                cmd.Parameters["@Rol_tiempo"].Value = _Rol_tiempo;
                cmd.Parameters.Add(new SqlParameter("@Compania_tiempo", SqlDbType.VarChar, 6));
                cmd.Parameters["@Compania_tiempo"].Value = _Compania_tiempo;
                cmd.Parameters.Add(new SqlParameter("@Turno", SqlDbType.VarChar, 6));
                cmd.Parameters["@Turno"].Value = _Turno;
                cmd.Parameters.Add(new SqlParameter("@Estatus_ope", SqlDbType.VarChar, 6));
                cmd.Parameters["@Estatus_ope"].Value = _Estatus_ope;
                cmd.Parameters.Add(new SqlParameter("@Riesgo_inv_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Riesgo_inv_id"].Value = _Comportamiento_inv_id;
                cmd.Parameters.Add(new SqlParameter("@Condicion_inv_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Condicion_inv_id"].Value = _Condicion_inv_id;
                cmd.Parameters.Add(new SqlParameter("@CausaInmediata_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@CausaInmediata_id"].Value = _CausaInmediata_id;
                cmd.Parameters.Add(new SqlParameter("@Tecnologia_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Tecnologia_id"].Value = _Tecnologia_id;
                cmd.Parameters.Add(new SqlParameter("@ElementoClave_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@ElementoClave_id"].Value = _ElementoClave_id;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 6));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente"].Value = _Fecha_incidente;
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente1"].Value = _Fecha_incidente1;
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
        public TB_IncidentesBE TraerTB_IncidenteUltimoRegistrable(DateTime _Fecha_registro)
        {
            TB_IncidentesBE _IncidenteBE = new TB_IncidentesBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTB_IncidenteUltimoRegistrable";
                cmd.Parameters.Add(new SqlParameter("@Fecha_registro", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_registro"].Value = _Fecha_registro;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _IncidenteBE;
                    _with1.Incidente_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Incidente_id")));
                    _with1.Titulo = dtr.GetValue(dtr.GetOrdinal("titulo")).ToString();
                    _with1.Descripcion = dtr.GetValue(dtr.GetOrdinal("Descripcion")).ToString();
                    _with1.Fecha_incidente = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_incidente")));
                    _with1.Fecha_estimada = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_estimada")));
                    _with1.Fecha_registro = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fecha_registro")));
                    _with1.Turno = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Turno")));
                    _with1.Tiempo_ext = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("tiempo_ext")));
                    _with1.Estatus_ope = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("estatus_ope")));
                    _with1.Departamento = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("departamento")));
                    _with1.Guardia = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("guardia")));
                    _with1.Area_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Area_id")));
                    _with1.Tipo_emp = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("tipo_emp")));
                    _with1.Contratista_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Contratista_id")));
                    _with1.Rol_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Rol_id")));
                    _with1.Rol_tiempo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("rol_tiempo")));
                    _with1.Compania_tiempo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("compania_tiempo")));
                    _with1.ParteCuerpo_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("ParteCuerpo_id")));
                    _with1.EquipoAfectado_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("EquipoAfectado_id")));
                    _with1.Clasificacion_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Clasificacion_id")));
                    _with1.Daño_tipo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("daño_tipo")));
                    _with1.Causainmediata_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Causainmediata_id")));
                    _with1.CausaRaiz_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("CausaRaiz_id")));
                    _with1.Tecnologia_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Tecnologia_id")));
                    _with1.ElementoClave_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("ElementoClave_id")));
                    _with1.Riesgo_inv_desc = dtr.GetValue(dtr.GetOrdinal("Riesgo_inv_desc")).ToString();
                    _with1.Condicion_inv_desc = dtr.GetValue(dtr.GetOrdinal("condicion_inv_desc")).ToString();
                    _with1.Riesgo_inv_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("riesgo_inv_id")));
                    _with1.Condicion_inv_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("condicion_inv_id")));
                    _with1.Originador = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("originador")));
                    _with1.Registro = dtr.GetValue(dtr.GetOrdinal("Registro")).ToString();
                    _with1.Estado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("estado")));
                    _with1.activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("activo")));
                    _with1.EmpleadoAfectado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("EmpleadoAfectado")));

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
            return _IncidenteBE;
        }
        public TB_IncidentesBE TraerTB_IncidenteUltimoClaseIByDepartamento(DateTime _Fecha_registro, short _Departamento_id)
        {
            TB_IncidentesBE _IncidenteBE = new TB_IncidentesBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTB_IncidenteUltimoClaseIByDepartamento";
                cmd.Parameters.Add(new SqlParameter("@Fecha_registro", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_registro"].Value = _Fecha_registro;
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _IncidenteBE;
                    _with1.Incidente_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Incidente_id")));
                    _with1.Titulo = dtr.GetValue(dtr.GetOrdinal("titulo")).ToString();
                    _with1.Descripcion = dtr.GetValue(dtr.GetOrdinal("Descripcion")).ToString();
                    _with1.Fecha_incidente = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_incidente")));
                    _with1.Fecha_estimada = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_estimada")));
                    _with1.Fecha_registro = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("fecha_registro")));
                    _with1.Turno = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Turno")));
                    _with1.Tiempo_ext = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("tiempo_ext")));
                    _with1.Estatus_ope = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("estatus_ope")));
                    _with1.Departamento = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("departamento")));
                    _with1.Guardia = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("guardia")));
                    _with1.Area_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Area_id")));
                    _with1.Tipo_emp = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("tipo_emp")));
                    _with1.Contratista_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Contratista_id")));
                    _with1.Rol_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Rol_id")));
                    _with1.Rol_tiempo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("rol_tiempo")));
                    _with1.Compania_tiempo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("compania_tiempo")));
                    _with1.ParteCuerpo_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("ParteCuerpo_id")));
                    _with1.EquipoAfectado_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("EquipoAfectado_id")));
                    _with1.Clasificacion_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Clasificacion_id")));
                    _with1.Daño_tipo = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("daño_tipo")));
                    _with1.Causainmediata_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Causainmediata_id")));
                    _with1.CausaRaiz_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("CausaRaiz_id")));
                    _with1.Tecnologia_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Tecnologia_id")));
                    _with1.ElementoClave_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("ElementoClave_id")));
                    _with1.Riesgo_inv_desc = dtr.GetValue(dtr.GetOrdinal("Riesgo_inv_desc")).ToString();
                    _with1.Condicion_inv_desc = dtr.GetValue(dtr.GetOrdinal("condicion_inv_desc")).ToString();
                    _with1.Riesgo_inv_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("riesgo_inv_id")));
                    _with1.Condicion_inv_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("condicion_inv_id")));
                    _with1.Originador = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("originador")));
                    _with1.Registro = dtr.GetValue(dtr.GetOrdinal("Registro")).ToString();
                    _with1.Estado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("estado")));
                    _with1.activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("activo")));
                    _with1.EmpleadoAfectado = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("EmpleadoAfectado")));
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
            return _IncidenteBE;
        }

        public DataTable ListarTB_IncidentesByDepartamento(DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_InicdentesByDepartamento";
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente"].Value = _Fecha_incidente;
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente1"].Value = _Fecha_incidente1;
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


        public DataTable ContarIncidentesByClasificacion(string _Departamento_id, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ContarIncidentesByClasificacion";
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente"].Value = _Fecha_incidente;
                cmd.Parameters.Add(new SqlParameter("@Fecha_incidente1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_incidente1"].Value = _Fecha_incidente1;
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 16));
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
    }
}
