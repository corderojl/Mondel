using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ComportamientosADO
{
    public class COM_ComportamientoADO
    {

        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        SqlDataReader dtr = default(SqlDataReader);
        Boolean _vcod = false;
        int _id_Comportamiento = 0;
        COM_ComportamientoBE _COM_ComportamientoBE = new COM_ComportamientoBE();

        public DataTable BuscarCOM_ComportamientoByOriginador(short _Originador)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BuscarCOM_ComportamientoByOriginador";
                cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.VarChar, 6));
                cmd.Parameters["@Originador"].Value = _Originador;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Comportamiento");
                dtv = dts.Tables["Comportamiento"].DefaultView;
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
            return dts.Tables["Comportamiento"];
        }

        public int InsertarCOM_Comportamiento(COM_ComportamientoBE _ComportamientoBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarCOM_Comportamiento";
            SqlParameter par1;
            try
            {
                //SqlParameter par4 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                //par4.Direction = ParameterDirection.ReturnValue;
                par1 = cmd.Parameters.Add(new SqlParameter("@Auditor", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Auditor"].Value = _ComportamientoBE.Auditor;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_Comportamiento", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_Comportamiento"].Value = _ComportamientoBE.Fecha_Comportamiento;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia"].Value = _ComportamientoBE.Guardia;
                par1 = cmd.Parameters.Add(new SqlParameter("@Turno", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Turno"].Value = _ComportamientoBE.Turno;
                par1 = cmd.Parameters.Add(new SqlParameter("@Tipo_emp", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Tipo_emp"].Value = _ComportamientoBE.Tipo_emp;
                par1 = cmd.Parameters.Add(new SqlParameter("@Sector_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Sector_id"].Value = _ComportamientoBE.Sector_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _ComportamientoBE.SubCategoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Char, 6));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Valor"].Value = _ComportamientoBE.Valor;
                par1 = cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 2000));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Descripcion"].Value = _ComportamientoBE.Descripcion;
                par1 = cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Departamento_id"].Value = _ComportamientoBE.Departamento;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_id"].Value = _ComportamientoBE.Area_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Estado"].Value = _ComportamientoBE.Estado;
                par1 = cmd.Parameters.Add(new SqlParameter("@Originador", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Originador"].Value = _ComportamientoBE.Originador;
                par1 = cmd.Parameters.Add(new SqlParameter("@Motivo", SqlDbType.VarChar, 500));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Motivo"].Value = _ComportamientoBE.Motivo;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _id_Comportamiento = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Comportamiento_ID")));
            }
            catch (SqlException x)
            {
                _id_Comportamiento = 0;
            }
            catch (Exception x)
            {
                _id_Comportamiento = 0;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _id_Comportamiento;
        }
        public List<COM_ComportamientoBE> ListarCOM_Comportamiento_Dia()
        {
            string conexion = MiConexion.GetCnx();
            List<COM_ComportamientoBE> lCOM_ComportamientoBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCOM_ComportamientoDia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (drd != null)
                {
                    lCOM_ComportamientoBE = new List<COM_ComportamientoBE>();
                    int posComportamiento_id = drd.GetOrdinal("Comportamiento_id");
                    int posDescripcion = drd.GetOrdinal("Descripcion");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    COM_ComportamientoBE obeSubCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeSubCategoriaBE = new COM_ComportamientoBE();
                        obeSubCategoriaBE.Comportamiento_id = drd.GetInt32(posComportamiento_id);
                        obeSubCategoriaBE.Descripcion = drd.GetString(posDescripcion);
                        obeSubCategoriaBE.Departamento = drd.GetInt16(posDepartamento_id);
                        lCOM_ComportamientoBE.Add(obeSubCategoriaBE);
                    }
                    drd.Close();
                    con.Close();
                }

            }
            catch (SqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            return (lCOM_ComportamientoBE);
        }
        public List<COM_ComportamientoBE> ListarCOM_Comportamiento_Semana()
        {
            string conexion = MiConexion.GetCnx();
            List<COM_ComportamientoBE> lCOM_ComportamientoBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCOM_ComportamientoSemana", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {
                    lCOM_ComportamientoBE = new List<COM_ComportamientoBE>();
                    int posComportamiento_id = drd.GetOrdinal("Comportamiento_id");
                    int posDescripcion = drd.GetOrdinal("Descripcion");
                    int posDepartamento_id = drd.GetOrdinal("Departamento_id");
                    COM_ComportamientoBE obeSubCategoriaBE = null;
                    while (drd.Read())
                    {
                        obeSubCategoriaBE = new COM_ComportamientoBE();
                        obeSubCategoriaBE.Comportamiento_id = drd.GetInt32(posComportamiento_id);
                        obeSubCategoriaBE.Descripcion = drd.GetString(posDescripcion);
                        obeSubCategoriaBE.Departamento = drd.GetInt16(posDepartamento_id);
                        lCOM_ComportamientoBE.Add(obeSubCategoriaBE);
                    }
                    drd.Close();
                    con.Close();
                }

            }
            catch (SqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            return (lCOM_ComportamientoBE);
        }
        public bool EliminarCOM_Comportamiento(int _Comportamientos_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarCOM_Comportamiento";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@Comportamiento_id", SqlDbType.Int));
                cmd.Parameters["@Comportamiento_id"].Value = _Comportamientos_id;
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

        public DataTable ListarCOM_ComportamientoFind(string _Departamento_id, string _Area_id, string _Guardia_id, string _Funcionario_id, string _Sector_id
            , string _SubCategoria_id, string _Tipo_emp, string _Valor, DateTime _Fecha_Comportamiento, DateTime _Fecha_Comportamiento1)
        {
            {
                DataSet dts = new DataSet();
                try
                {
                    cnx.ConnectionString = MiConexion.GetCnx();
                    cmd.Connection = cnx;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ListarCOM_ComportamientoFind";
                    cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                    cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Area_id"].Value = _Area_id;
                    cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Guardia_id"].Value = _Guardia_id;
                    cmd.Parameters.Add(new SqlParameter("@Auditor", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Auditor"].Value = _Funcionario_id;
                    cmd.Parameters.Add(new SqlParameter("@Sector_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Sector_id"].Value = _Sector_id;
                    cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@SubCategoria_id"].Value = _SubCategoria_id;
                    cmd.Parameters.Add(new SqlParameter("@Tipo_emp", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Tipo_emp"].Value = _Tipo_emp;
                    cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Valor"].Value = _Valor;
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Comportamiento", SqlDbType.DateTime));
                    cmd.Parameters["@Fecha_Comportamiento"].Value = _Fecha_Comportamiento;
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Comportamiento1", SqlDbType.DateTime));
                    cmd.Parameters["@Fecha_Comportamiento1"].Value = _Fecha_Comportamiento1;
                    SqlDataAdapter miada = default(SqlDataAdapter);
                    miada = new SqlDataAdapter(cmd);
                    miada.Fill(dts, "Comportamiento");
                    dtv = dts.Tables["Comportamiento"].DefaultView;
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
                return dts.Tables["Comportamiento"];
            }
        }
        public DataTable ListarCOM_ComportamientoFindXML(string _Departamento_id, string _Area_id, string _Guardia_id, string _Funcionario_id, string _Sector_id
            , string _SubCategoria_id, string _Tipo_emp, string _Valor, DateTime _Fecha_Comportamiento, DateTime _Fecha_Comportamiento1)
        {
            {
                DataSet dts = new DataSet();
                try
                {
                    cnx.ConnectionString = MiConexion.GetCnx();
                    cmd.Connection = cnx;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ListarCOM_ComportamientoFindXML";
                    cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                    cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Area_id"].Value = _Area_id;
                    cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Guardia_id"].Value = _Guardia_id;
                    cmd.Parameters.Add(new SqlParameter("@Auditor", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Auditor"].Value = _Funcionario_id;
                    cmd.Parameters.Add(new SqlParameter("@Sector_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Sector_id"].Value = _Sector_id;
                    cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.VarChar, 6));
                    cmd.Parameters["@SubCategoria_id"].Value = _SubCategoria_id;
                    cmd.Parameters.Add(new SqlParameter("@Tipo_emp", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Tipo_emp"].Value = _Tipo_emp;
                    cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.VarChar, 6));
                    cmd.Parameters["@Valor"].Value = _Valor;
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Comportamiento", SqlDbType.DateTime));
                    cmd.Parameters["@Fecha_Comportamiento"].Value = _Fecha_Comportamiento;
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Comportamiento1", SqlDbType.DateTime));
                    cmd.Parameters["@Fecha_Comportamiento1"].Value = _Fecha_Comportamiento1;
                    SqlDataAdapter miada = default(SqlDataAdapter);
                    miada = new SqlDataAdapter(cmd);
                    miada.Fill(dts, "Comportamiento");
                    dtv = dts.Tables["Comportamiento"].DefaultView;
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
                return dts.Tables["Comportamiento"];
            }
        }

        public TEM_ComportamientoEstadistica TraerCOM_ComportamientoEstadistica(string _Departamento_id, string _Area_id, string _Guardia_id, string _Funcionario_id, string _Sector_id, string _SubCategoria_id, string _Tipo_emp, string _Valor, DateTime _Fecha_Comportamiento, DateTime _Fecha_Comportamiento1)
        {
            TEM_ComportamientoEstadistica _TEM_ComportamientoEstadistica = new TEM_ComportamientoEstadistica();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerCOM_ComportamientoEstadisticas";
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Area_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Area_id"].Value = _Area_id;
                cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Guardia_id"].Value = _Guardia_id;
                cmd.Parameters.Add(new SqlParameter("@Auditor", SqlDbType.VarChar, 6));
                cmd.Parameters["@Auditor"].Value = _Funcionario_id;
                cmd.Parameters.Add(new SqlParameter("@Sector_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Sector_id"].Value = _Sector_id;
                cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@SubCategoria_id"].Value = _SubCategoria_id;
                cmd.Parameters.Add(new SqlParameter("@Tipo_emp", SqlDbType.VarChar, 6));
                cmd.Parameters["@Tipo_emp"].Value = _Tipo_emp;
                cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.VarChar, 6));
                cmd.Parameters["@Valor"].Value = _Valor;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Comportamiento", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Comportamiento"].Value = _Fecha_Comportamiento;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Comportamiento1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Comportamiento1"].Value = _Fecha_Comportamiento1;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _TEM_ComportamientoEstadistica;
                    _with1.Valor1 = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Valor1")));
                    _with1.Valor2 = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Valor2")));
                    _with1.Valor3 = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Valor3")));
                   

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
            return _TEM_ComportamientoEstadistica;
        }


        public int ContarCOM_Comportamiento(string _Departamento_id, DateTime _Fecha_Comportamiento, DateTime _Fecha_Comportamiento1)
        {
            string conexion = MiConexion.GetCnx();
            List<COM_ComportamientoBE> lCOM_ComportamientoBE = null;
            int numComp = 0;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ContarCOM_Comportamiento", con);
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 6));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Comportamiento", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Comportamiento"].Value = _Fecha_Comportamiento;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Comportamiento1", SqlDbType.DateTime));
                cmd.Parameters["@Fecha_Comportamiento1"].Value = _Fecha_Comportamiento1;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (drd != null)
                {

                    int numero = drd.GetOrdinal("numero");
                    COM_ComportamientoBE obeSubCategoriaBE = null;
                    while (drd.Read())
                    {
                        numComp = drd.GetInt32(numero);
                    }
                    drd.Close();
                    con.Close();
                }

            }
            catch (SqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            return (numComp);
        }
    }
}
