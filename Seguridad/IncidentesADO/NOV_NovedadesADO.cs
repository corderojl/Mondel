using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class NOV_NovedadesADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        Boolean _vcod = false;
        int _id_Novedades = 0;
        NOV_NovedadesBE _NOV_NovedadesBE = new NOV_NovedadesBE();


        public DataTable ListarNOV_NovedadesAll()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarNOV_Novedades_All";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Novedades");
                dtv = dts.Tables["Novedades"].DefaultView;
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
            return dts.Tables["Novedades"];
        }
        public List<NOV_NovedadesBE> ListarNOV_NovedadesO_All()
        {
            string conexion = MiConexion.GetCnx();
            List<NOV_NovedadesBE> lNOV_NovedadesBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarNOV_Novedades_All", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (drd != null)
                {
                    lNOV_NovedadesBE = new List<NOV_NovedadesBE>();

                    NOV_NovedadesBE obeFuncionariosBE = null;
                    while (drd.Read())
                    {
                        ReadSingleRow((IDataRecord)drd);
                        obeFuncionariosBE = new NOV_NovedadesBE();
                        obeFuncionariosBE.Novedades_id = Convert.ToInt16(drd[0]);
                        obeFuncionariosBE.Titulo = drd[1].ToString();
                        obeFuncionariosBE.Descripcion = drd[2].ToString();
                        obeFuncionariosBE.Foto = drd[3].ToString();
                        obeFuncionariosBE.Originador = Convert.ToInt16(drd[4]);
                        obeFuncionariosBE.Activo = Convert.ToBoolean(drd[5]);
                        obeFuncionariosBE.Fecha_Reg = Convert.ToDateTime(drd[6]);
                        lNOV_NovedadesBE.Add(obeFuncionariosBE);
                    }
                    drd.Close();
                }
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return (lNOV_NovedadesBE);
        }
        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }
        public DataTable ListarNOV_NovedadesAct()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarNOV_Novedades_Act";
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Novedades");
                dtv = dts.Tables["Novedades"].DefaultView;
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
            return dts.Tables["Novedades"];
        }

        public DataTable ListarNOV_NovedadesFind(string _Titulo, string _Descripcion)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarNOV_Novedades_find";
                cmd.Parameters.Add(new SqlParameter("@Titulo", SqlDbType.VarChar, 200));
                cmd.Parameters["@Titulo"].Value = _Titulo;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 6));
                cmd.Parameters["@Descripcion"].Value = _Descripcion;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Novedades");
                dtv = dts.Tables["Novedades"].DefaultView;
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
            return dts.Tables["Novedades"];
        }

        public NOV_NovedadesBE TraerNOV_NovedadesById(int _Novedades_id)
        {
            NOV_NovedadesBE _NovedadessBE = new NOV_NovedadesBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerNOV_NovedadesById";
                cmd.Parameters.Add(new SqlParameter("@Novedades_id", SqlDbType.Int));
                cmd.Parameters["@Novedades_id"].Value = _Novedades_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _NovedadessBE;
                    _with1.Novedades_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Novedades_id")));
                    _with1.Descripcion = dtr.GetValue(dtr.GetOrdinal("Descripcion")).ToString();
                    _with1.Foto = dtr.GetValue(dtr.GetOrdinal("Foto")).ToString();
                    _with1.Originador = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Originador")));
                    _with1.Activo = Convert.ToBoolean(dtr.GetValue(dtr.GetOrdinal("activo")));
                    _with1.Fecha_Reg = Convert.ToDateTime(dtr.GetValue(dtr.GetOrdinal("Fecha_reg")));
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
            return _NovedadessBE;
        }
        public int InsertarNOV_Novedades(NOV_NovedadesBE _NovedadessBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarNOV_Novedades";
            SqlParameter par1;
            int IdElementoClave = -1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Titulo", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Titulo"].Value = _NovedadessBE.Titulo;
                par1 = cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 8000));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Descripcion"].Value = _NovedadessBE.Descripcion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Foto", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Foto"].Value = _NovedadessBE.Foto;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _NovedadessBE.Originador;
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
            return IdElementoClave;
        }
        public bool ActualizarNOV_Novedades(NOV_NovedadesBE _NovedadessBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarNOV_Novedades";
            SqlParameter par1;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Novedades_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Novedades_id"].Value = _NovedadessBE.Novedades_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 8000));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Descripcion"].Value = _NovedadessBE.Descripcion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Foto", SqlDbType.VarChar, 800));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Foto"].Value = _NovedadessBE.Foto;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _NovedadessBE.Originador;
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
        public bool EliminarNOV_Novedades(int _Novedades_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarNOV_Novedades";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@Novedades_id", SqlDbType.Int));
                cmd.Parameters["@Novedades_id"].Value = _Novedades_id;
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
    }
}
