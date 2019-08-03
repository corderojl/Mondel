using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class Fnc_FuncionariosADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        bool vexito;

        public DataTable ListarFnc_Funcionarios_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarFnc_FuncionariosBE_All";
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
        public List<Fnc_FuncionariosBE> ListarFnc_FuncionariosO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<Fnc_FuncionariosBE> lFnc_FuncionariosBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarFnc_FuncionariosBE_Act", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (drd != null)
                {
                    lFnc_FuncionariosBE = new List<Fnc_FuncionariosBE>();

                    Fnc_FuncionariosBE obeFuncionariosBE = null;
                    while (drd.Read())
                    {
                        ReadSingleRow((IDataRecord)drd);
                        obeFuncionariosBE = new Fnc_FuncionariosBE();
                        obeFuncionariosBE.Funcionario_Id = Convert.ToInt16(drd[0]);
                        obeFuncionariosBE.Funcionario_Nome = drd[1].ToString();
                        obeFuncionariosBE.Funcionario_Drt = drd[2].ToString();
                        obeFuncionariosBE.Funcionario_Status = Convert.ToByte(drd[3]);
                        obeFuncionariosBE.Funcionario_Email = drd[4].ToString();
                        obeFuncionariosBE.Funcionario_Tnumber = drd[5].ToString();
                        obeFuncionariosBE.Area_Id = Convert.ToInt32(drd[6]);
                        obeFuncionariosBE.Grupo_Id = Convert.ToInt16(drd[7]);
                        lFnc_FuncionariosBE.Add(obeFuncionariosBE);
                    }
                    drd.Close();
                }
            }
            catch(SqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return (lFnc_FuncionariosBE);
        }
        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }
        public DataTable ListarFnc_Funcionarios_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarFnc_Funcionarios_Act";
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
        public bool DeshabilitarFuncionario(int _vcod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Fnc_Funcionario_Status";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@vcod", SqlDbType.Int));
                cmd.Parameters["@vcod"].Value = _vcod;
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));
                cmd.Parameters["@status"].Value = 0;
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
        public bool HabilitarFuncionario(int _vcod)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Fnc_Funcionario_Status";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@vcod", SqlDbType.Int));
                cmd.Parameters["@vcod"].Value = _vcod;
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Int));
                cmd.Parameters["@status"].Value = 1;
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
        public DataTable BuscarFnc_FuncionarioByNombre(string vnom)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BuscarFnc_FuncionarioByNombre";
                //Agregamos el parametro para el SP
                cmd.Parameters.Add(new SqlParameter("@texto", SqlDbType.VarChar, 200));
                cmd.Parameters["@texto"].Value = vnom;
                SqlDataAdapter miada = default(SqlDataAdapter);
                miada = new SqlDataAdapter(cmd);
                miada.Fill(dts, "Turno");
                dtv = dts.Tables["Turno"].DefaultView;
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
            return dts.Tables["Turno"];
        }
        public Fnc_FuncionariosBE LoguearFuncionario(string vusuario, string vpass)
        {
            SqlDataReader dtr = default(SqlDataReader);
            Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_LoguearUsuario";
                cmd.Parameters.Add(new SqlParameter("@vusuario", SqlDbType.VarChar, 20));
                cmd.Parameters["@vusuario"].Value = vusuario;
                cmd.Parameters.Add(new SqlParameter("@vpass", SqlDbType.VarChar, 20));
                cmd.Parameters["@vpass"].Value = vpass;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _Fnc_FuncionariosBE;
                    _with1.Funcionario_Id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Funcionario_Id")));
                    _with1.Funcionario_Nome = dtr.GetValue(dtr.GetOrdinal("Funcionario_Nome")).ToString();
                    _with1.Funcionario_Email = dtr.GetValue(dtr.GetOrdinal("Funcionario_Email")).ToString();
                    _with1.Funcionario_Drt = dtr.GetValue(dtr.GetOrdinal("Funcionario_Drt")).ToString();
                    _with1.Area_Id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Area_Id")));
                    _with1.Grupo_Id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Grupo_id")));
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
            return _Fnc_FuncionariosBE;
        }
        public Fnc_FuncionariosBE TraerFnc_Funcionario(int _Funcionario_id)
        {
            SqlDataReader dtr = default(SqlDataReader);
            Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerFnc_FuncionarioById";
                cmd.Parameters.Add(new SqlParameter("@Funcionario_id", SqlDbType.VarChar, 20));
                cmd.Parameters["@Funcionario_id"].Value = _Funcionario_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _Fnc_FuncionariosBE;
                    _with1.Funcionario_Id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Funcionario_Id")));
                    _with1.Funcionario_Nome = dtr.GetValue(dtr.GetOrdinal("Funcionario_Nome")).ToString();
                    _with1.Funcionario_Email = dtr.GetValue(dtr.GetOrdinal("Funcionario_Email")).ToString();
                    _with1.Funcionario_Drt = dtr.GetValue(dtr.GetOrdinal("Funcionario_Drt")).ToString();
                    _with1.Area_Id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Area_Id")));
                    _with1.Funcionario_Tnumber = dtr.GetValue(dtr.GetOrdinal("FUNCIONARIO_TNUMBER")).ToString();
                    _with1.Funcionario_Status = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("FUNCIONARIO_STATUS")));
                    _with1.Rol_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("ROL_ID")));
                    _with1.AreaLabor_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("AREALABOR_ID")));
                    _with1.Superior = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("SUPERIOR")));
                    _with1.Categoria_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Categoria_Id")));
                    _with1.SubCategoria_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("SubCategoria_Id")));
                    _with1.CE_Coste = dtr.GetValue(dtr.GetOrdinal("CE_COSTE")).ToString();
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
            return _Fnc_FuncionariosBE;
        }

        public DataTable ListarFnc_FuncionariosByGuardia(string _departamento_id, string _guardia_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarFnc_FuncionariosByGuardia";
                cmd.Parameters.Add(new SqlParameter("@AREA_ID", SqlDbType.VarChar, 5));
                cmd.Parameters["@AREA_ID"].Value = _departamento_id;
                cmd.Parameters.Add(new SqlParameter("@GRUPO_ID", SqlDbType.VarChar, 5));
                cmd.Parameters["@GRUPO_ID"].Value = _guardia_id;
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
        public bool ActualizarFnc_FuncionariosGuardia(int _departamento_id, int _guardia_id, int _funcionario_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarFnc_FuncionariosGuardia";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@area_id", SqlDbType.Int));
                cmd.Parameters["@area_id"].Value = _departamento_id;
                cmd.Parameters.Add(new SqlParameter("@grupo_id", SqlDbType.Int));
                cmd.Parameters["@grupo_id"].Value = _guardia_id;
                cmd.Parameters.Add(new SqlParameter("@funcionario_id", SqlDbType.Int));
                cmd.Parameters["@funcionario_id"].Value = _funcionario_id;
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

        public bool ActualizarFNC_FuncionariosEmail(int _FUNCIONARIO_ID, string _FUNCIONARIO_EMAIL)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarFNC_FuncionariosEmail";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@FUNCIONARIO_EMAIL", SqlDbType.VarChar, 30));
                cmd.Parameters["@FUNCIONARIO_EMAIL"].Value = _FUNCIONARIO_EMAIL;
                cmd.Parameters.Add(new SqlParameter("@FUNCIONARIO_ID", SqlDbType.Int));
                cmd.Parameters["@FUNCIONARIO_ID"].Value = _FUNCIONARIO_ID;
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

        public DataTable ListarEVA_FuncionariosBySuperior(string _Anio, string _Superior, string _Departamento_id, string _Estado)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_FuncionarioBySuperior";
                cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 12));
                cmd.Parameters["@Anio"].Value = _Anio;
                cmd.Parameters.Add(new SqlParameter("@Superior", SqlDbType.VarChar, 12));
                cmd.Parameters["@Superior"].Value = _Superior;
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 10));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 3));
                cmd.Parameters["@Estado"].Value = _Estado;
               
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
        public bool comprobarFnc_FuncionariosPassword(int _funcionario_id)
        {
            SqlDataReader dtr = default(SqlDataReader);
            DataSet dts = new DataSet();
            bool vexito=false;
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_comprobarFnc_FuncionariosPassword";
                cmd.Parameters.Add(new SqlParameter("@Funcionario_id", SqlDbType.SmallInt));
                cmd.Parameters["@Funcionario_id"].Value = _funcionario_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    vexito = true;

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
            return vexito;
        }

        public bool cambiarFnc_FuncionariosPassword(short _Funcionario_ID, string _Password)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_CambiarFnc_FuncionariosPassword";

            try
            {
                cmd.Parameters.Add(new SqlParameter("@FUNCIONARIO_SENHA", SqlDbType.VarChar, 30));
                cmd.Parameters["@FUNCIONARIO_SENHA"].Value = _Password;
                cmd.Parameters.Add(new SqlParameter("@FUNCIONARIO_ID", SqlDbType.Int));
                cmd.Parameters["@FUNCIONARIO_ID"].Value = _Funcionario_ID;
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

        public List<Fnc_FuncionariosBE> ListarFNC_FuncionariosLideresO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<Fnc_FuncionariosBE> lFnc_FuncionariosBE = null;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarFNC_FuncionariosLideres", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (drd != null)
                {
                    lFnc_FuncionariosBE = new List<Fnc_FuncionariosBE>();

                    Fnc_FuncionariosBE obeFuncionariosBE = null;
                    while (drd.Read())
                    {
                        ReadSingleRow((IDataRecord)drd);
                        obeFuncionariosBE = new Fnc_FuncionariosBE();
                        obeFuncionariosBE.Funcionario_Id = Convert.ToInt16(drd[0]);
                        obeFuncionariosBE.Funcionario_Nome = drd[1].ToString();                        
                        lFnc_FuncionariosBE.Add(obeFuncionariosBE);
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
            return (lFnc_FuncionariosBE);
        }

        public DataTable ListarFnc_FuncionariosFill(string _Funcionario_nome, string _Categoria_id, string _SubCategoria_id, 
            string _Departamento_id, string _Rol_id, string _AreaLabor_id, string _Estado, string _Lider_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarFNC_FuncionariosFill";
                cmd.Parameters.Add(new SqlParameter("@FUNCIONARIO_NOME", SqlDbType.VarChar, 50));
                cmd.Parameters["@FUNCIONARIO_NOME"].Value = _Funcionario_nome;
                cmd.Parameters.Add(new SqlParameter("@Categoria_id", SqlDbType.VarChar, 7));
                cmd.Parameters["@Categoria_id"].Value = _Categoria_id;
                cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.VarChar, 7));
                cmd.Parameters["@SubCategoria_id"].Value = _SubCategoria_id;
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 7));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Rol_id", SqlDbType.VarChar, 7));
                cmd.Parameters["@Rol_id"].Value = _Rol_id;
                cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.VarChar, 7));
                cmd.Parameters["@AreaLabor_id"].Value = _AreaLabor_id;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 3));
                cmd.Parameters["@Estado"].Value = _Estado;
                cmd.Parameters.Add(new SqlParameter("@Superior", SqlDbType.VarChar, 7));
                cmd.Parameters["@Superior"].Value = _Lider_id;

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

        public bool ActualizarFNC_Funcionarios(Fnc_FuncionariosBE _Fnc_FuncionariosBE)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ActualizarFNC_Funcionarios";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Id"].Value = _Fnc_FuncionariosBE.Funcionario_Id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Nome", SqlDbType.VarChar, 250));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Nome"].Value = _Fnc_FuncionariosBE.Funcionario_Nome;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Drt", SqlDbType.VarChar, 12));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Drt"].Value = _Fnc_FuncionariosBE.Funcionario_Drt;
                par1 = cmd.Parameters.Add(new SqlParameter("@Superior", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Superior"].Value = _Fnc_FuncionariosBE.Superior;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_Id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_Id"].Value = _Fnc_FuncionariosBE.Area_Id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Email", SqlDbType.VarChar, 30));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Email"].Value = _Fnc_FuncionariosBE.Funcionario_Email;
                par1 = cmd.Parameters.Add(new SqlParameter("@CE_Coste", SqlDbType.VarChar, 12));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CE_Coste"].Value = _Fnc_FuncionariosBE.CE_Coste;
                par1 = cmd.Parameters.Add(new SqlParameter("@Rol_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Rol_id"].Value = _Fnc_FuncionariosBE.Rol_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor_id"].Value = _Fnc_FuncionariosBE.AreaLabor_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _Fnc_FuncionariosBE.SubCategoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Status", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Status"].Value = _Fnc_FuncionariosBE.Funcionario_Status;
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

        public DataTable ListarEVA_FuncionariosBySuperiorXML(string _Anio, string _Superior, string _Departamento_id, string _Estado)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarEVA_FuncionarioBySuperiorXML";
                cmd.Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 12));
                cmd.Parameters["@Anio"].Value = _Anio;
                cmd.Parameters.Add(new SqlParameter("@Superior", SqlDbType.VarChar, 12));
                cmd.Parameters["@Superior"].Value = _Superior;
                cmd.Parameters.Add(new SqlParameter("@Departamento_id", SqlDbType.VarChar, 10));
                cmd.Parameters["@Departamento_id"].Value = _Departamento_id;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.VarChar, 3));
                cmd.Parameters["@Estado"].Value = _Estado;

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

        public DataTable ListarFNC_FuncionariosLideres_Act()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarFNC_FuncionariosLideres";
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

        public short InsertarFNC_Funcionarios(Fnc_FuncionariosBE _Fnc_FuncionariosBE)
        {
            SqlDataReader dtr = default(SqlDataReader);
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarFNC_Funcionarios";
            SqlParameter par1;
            short _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Nome", SqlDbType.VarChar, 250));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Nome"].Value = _Fnc_FuncionariosBE.Funcionario_Nome;
                par1 = cmd.Parameters.Add(new SqlParameter("@FUNCIONARIO_TNUMBER", SqlDbType.VarChar, 12));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@FUNCIONARIO_TNUMBER"].Value = _Fnc_FuncionariosBE.Funcionario_Tnumber;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Drt", SqlDbType.VarChar, 12));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Drt"].Value = _Fnc_FuncionariosBE.Funcionario_Drt;
                par1 = cmd.Parameters.Add(new SqlParameter("@Superior", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Superior"].Value = _Fnc_FuncionariosBE.Superior;
                par1 = cmd.Parameters.Add(new SqlParameter("@Area_Id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Area_Id"].Value = _Fnc_FuncionariosBE.Area_Id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Email", SqlDbType.VarChar, 30));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Email"].Value = _Fnc_FuncionariosBE.Funcionario_Email;
                par1 = cmd.Parameters.Add(new SqlParameter("@CE_Coste", SqlDbType.VarChar, 12));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@CE_Coste"].Value = _Fnc_FuncionariosBE.CE_Coste;
                par1 = cmd.Parameters.Add(new SqlParameter("@Rol_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Rol_id"].Value = _Fnc_FuncionariosBE.Rol_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@AreaLabor_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@AreaLabor_id"].Value = _Fnc_FuncionariosBE.AreaLabor_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Guardia_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Guardia_id"].Value = _Fnc_FuncionariosBE.Grupo_Id;
                par1 = cmd.Parameters.Add(new SqlParameter("@SubCategoria_id", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@SubCategoria_id"].Value = _Fnc_FuncionariosBE.SubCategoria_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Status", SqlDbType.Int));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Status"].Value = _Fnc_FuncionariosBE.Funcionario_Status;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_ingreso", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_ingreso"].Value = _Fnc_FuncionariosBE.Fecha_ingreso;
                par1 = cmd.Parameters.Add(new SqlParameter("@Fecha_naci", SqlDbType.DateTime));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Fecha_naci"].Value = _Fnc_FuncionariosBE.Fecha_naci;
                par1 = cmd.Parameters.Add(new SqlParameter("@Genero", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Genero"].Value = _Fnc_FuncionariosBE.Genero;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                dtr.Read();
                _vcod = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Funcionario_id")));

            }
            catch (SqlException x)
            {
                _vcod = -1;
            }
            catch (Exception x)
            {
                _vcod = -1;
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

        public bool RestaurarContraseña(int idEmp)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_RestaurarContraseña";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_Id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_Id"].Value = idEmp;
                
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
    }
}
