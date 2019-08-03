using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TRG_RiesgosADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);

        public DataTable ListarTRG_Riesgos_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTRG_Riesgos_All";
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
        public List<TRG_RiesgosBE> ListarTRG_RiesgosO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TRG_RiesgosBE> lTRG_RiesgosBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTRG_Riesgos_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lTRG_RiesgosBE = new List<TRG_RiesgosBE>();
                    int posRiesgo_id = drd.GetOrdinal("Riesgo_id");
                    int posRiesgo_desc = drd.GetOrdinal("Riesgo_desc");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    int posValor = drd.GetOrdinal("Valor");
                    int posActivo = drd.GetOrdinal("Activo");
                    TRG_RiesgosBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new TRG_RiesgosBE();
                        obeCategoriaBE.Riesgo_id = drd.GetInt32(posRiesgo_id);
                        obeCategoriaBE.Riesgo_desc = drd.GetString(posRiesgo_desc);
                        obeCategoriaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                        obeCategoriaBE.Valor = drd.GetInt32(posValor);
                        obeCategoriaBE.activo = drd.GetBoolean(posActivo);
                        lTRG_RiesgosBE.Add(obeCategoriaBE);
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
            return (lTRG_RiesgosBE);
        }

        public DataTable ListarTRG_Riesgos_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTRG_Riesgos_Act";
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
        public int InsertarTRG_Riesgos(TRG_RiesgosBE _TRG_RiesgosBE)
        {
            int IdElementoClave = -1;
            SqlParameter par1;
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTRG_Riesgos";
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Riesgo_desc", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Riesgo_desc"].Value = _TRG_RiesgosBE.Riesgo_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _TRG_RiesgosBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Valor"].Value = _TRG_RiesgosBE.Valor;
                SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                par4.Direction = ParameterDirection.ReturnValue;
                cnx.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0) IdElementoClave = (int)par4.Value;
            }
            catch (SqlException x)
            {
                IdElementoClave = -1;
            }
            catch (Exception x)
            {
                IdElementoClave = -1;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return (IdElementoClave);
        }
        //public int InsertarTRG_Riesgos(TRG_RiesgosBE _TRG_RiesgosBE)
        //{
        //    cnx.ConnectionString = MiConexion.GetCnx();
        //    cmd.Connection = cnx;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "sp_InsertarTRG_Riesgos";
        //    SqlParameter par1;
        //    int _Categoria_id;
        //    try
        //    {
        //        par1 = cmd.Parameters.Add(new SqlParameter("@Riesgo_desc", SqlDbType.VarChar, 550));
        //        par1.Direction = ParameterDirection.Input;
        //        cmd.Parameters["@Riesgo_desc"].Value = _TRG_RiesgosBE.Riesgo_desc;
        //        par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
        //        par1.Direction = ParameterDirection.Input;
        //        cmd.Parameters["@Departamento_id"].Value = _TRG_RiesgosBE.Departamento_id;
        //        par1 = cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Int));
        //        par1.Direction = ParameterDirection.Input;
        //        cmd.Parameters["@Valor"].Value = _TRG_RiesgosBE.Valor;
        //        SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
        //        par4.Direction = ParameterDirection.ReturnValue;
        //        cnx.Open();
        //        int n = cmd.ExecuteNonQuery();
        //        if (n > 0) _Categoria_id = (int)par4.Value;

        //        cnx.Open();
        //        dtr = cmd.ExecuteReader();
        //        dtr.Read();
        //        _Categoria_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("@@identity")));
        //    }
        //    catch (SqlException x)
        //    {
        //        _Categoria_id = 0;
        //    }
        //    catch (Exception x)
        //    {
        //        _Categoria_id = 0;
        //    }
        //    finally
        //    {
        //        if (cnx.State == ConnectionState.Open)
        //        {
        //            cnx.Close();
        //        }
        //        cmd.Parameters.Clear();
        //    }
        //    return _Categoria_id;
        //}
        public bool ActualizarTRG_Riesgos(TRG_RiesgosBE _TRG_RiesgosBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarTRG_Riesgos";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Riesgo_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Riesgo_id"].Value = _TRG_RiesgosBE.Riesgo_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Riesgo_desc", SqlDbType.VarChar, 550));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Riesgo_desc"].Value = _TRG_RiesgosBE.Riesgo_desc;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _TRG_RiesgosBE.Departamento_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Valor"].Value = _TRG_RiesgosBE.Valor;
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
        public bool EliminarTRG_Riesgos(int _Riesgo_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTRG_Riesgos";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Riesgo_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Riesgo_id"].Value = _Riesgo_id;
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

        public TRG_RiesgosBE TraerTRG_RiesgosById(int _Riesgo_id)
        {
            TRG_RiesgosBE _TRG_RiesgosBE = new TRG_RiesgosBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTRG_RiesgosById";
                cmd.Parameters.Add(new SqlParameter("@Riesgo_id", SqlDbType.Int));
                cmd.Parameters["@Riesgo_id"].Value = _Riesgo_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _TRG_RiesgosBE;
                    _with1.Riesgo_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Riesgo_id")));
                    _with1.Riesgo_desc = dtr.GetValue(dtr.GetOrdinal("Riesgo_desc")).ToString();
                    _with1.Departamento_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Departamento_id")));
                    _with1.Valor = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Valor")));
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
            return _TRG_RiesgosBE;
        }

        public List<TRG_RiesgosBE> ListarTRG_RiesgosByDepartamento(short _Departamento_id)
        {
            string conexion = MiConexion.GetCnx();
            List<TRG_RiesgosBE> lTRG_RiesgosBE = null;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTRG_RiesgosByDepartamento", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lTRG_RiesgosBE = new List<TRG_RiesgosBE>();
                    int posRiesgo_id = drd.GetOrdinal("Riesgo_id");
                    int posRiesgo_desc = drd.GetOrdinal("Riesgo_desc");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    int posValor = drd.GetOrdinal("Valor");
                    int posActivo = drd.GetOrdinal("Activo");
                    TRG_RiesgosBE obeCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeCategoriaBE = new TRG_RiesgosBE();
                        obeCategoriaBE.Riesgo_id = drd.GetInt32(posRiesgo_id);
                        obeCategoriaBE.Riesgo_desc = drd.GetString(posRiesgo_desc);
                        obeCategoriaBE.Departamento_id = drd.GetInt16(posDepartamento_id);
                        obeCategoriaBE.Valor = drd.GetInt32(posValor);
                        obeCategoriaBE.activo = drd.GetBoolean(posActivo);
                        lTRG_RiesgosBE.Add(obeCategoriaBE);
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
            return (lTRG_RiesgosBE);
        }

    }
}
