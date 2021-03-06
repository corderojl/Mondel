﻿using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesADO
{
    public class TB_ResponsablePilarADO
    {
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataView dtv = new DataView();
        public DataTable ListarTB_ResponsablePilar_All()
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_ResponsablePilar_All";
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
        public DataTable ListarTB_ResponsablePilarByPilar(short Pilar_id)
        {
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ListarTB_ResponsablePilarByPilar";
                SqlParameter par1 = cmd.Parameters.Add("@Pilar_id", SqlDbType.SmallInt);
                par1.Direction = ParameterDirection.Input;
                par1.Value = Pilar_id;
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

        public List<TB_ResponsablePilarBE> ListarTB_ResponsablePilarO_Act()
        {
            string conexion = MiConexion.GetCnx();
            List<TB_ResponsablePilarBE> lTB_ResponsablePilarBE = null;
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarTB_ResponsablePilar_Act", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lTB_ResponsablePilarBE = new List<TB_ResponsablePilarBE>();
                int posPilar_id = drd.GetOrdinal("Pilar_id");
                int posFuncionario_id = drd.GetOrdinal("Funcionario_id");
                TB_ResponsablePilarBE obeResponsablePilarBE = null;
                while (drd.Read())
                {
                    obeResponsablePilarBE = new TB_ResponsablePilarBE();
                    obeResponsablePilarBE.Pilar_id = drd.GetInt16(posPilar_id);
                    obeResponsablePilarBE.Funcionario_id = drd.GetInt16(posFuncionario_id);
                    lTB_ResponsablePilarBE.Add(obeResponsablePilarBE);
                }
                drd.Close();
            }
            con.Close();
            return (lTB_ResponsablePilarBE);
        }
        public TB_ResponsablePilarBE TraerTB_ResponsablePilarByPilar(int _Pilar_id)
        {
            TB_ResponsablePilarBE _TB_ResponsablePilarBE = new TB_ResponsablePilarBE();
            SqlDataReader dtr = default(SqlDataReader);
            DataSet dts = new DataSet();
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TraerTB_ResponsablePilarByPilar";
                cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.SmallInt));
                cmd.Parameters["@Pilar_id"].Value = _Pilar_id;
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    var _with1 = _TB_ResponsablePilarBE;
                    _with1.Pilar_id = Convert.ToInt32(dtr.GetValue(dtr.GetOrdinal("Pilar_id")));
                    _with1.Funcionario_id = Convert.ToInt16(dtr.GetValue(dtr.GetOrdinal("Funcionario_id")));
                    _with1.Funcionario_nome = dtr.GetValue(dtr.GetOrdinal("Funcionario_nome")).ToString();

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
            return (_TB_ResponsablePilarBE);
        }


        public bool EliminarTB_ResponsablePilar(short _Pilar_id, short _Funcionario_id)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_EliminarTB_ResponsablePilar";
            SqlParameter par1;
            bool _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pilar_id"].Value = _Pilar_id;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_id"].Value = _Funcionario_id;
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

        public string InsertarTB_ResponsablePilar(short dpt, short emp)
        {
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_InsertarTB_ResponsablePilar";
            SqlParameter par1;
            string _vcod;
            try
            {
                par1 = cmd.Parameters.Add(new SqlParameter("@Pilar_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Pilar_id"].Value = dpt;
                par1 = cmd.Parameters.Add(new SqlParameter("@Funcionario_id", SqlDbType.SmallInt));
                par1.Direction = ParameterDirection.Input;
                cmd.Parameters["@Funcionario_id"].Value = emp;
                cnx.Open();
                cmd.ExecuteNonQuery();
                _vcod = "Exito";

            }
            catch (SqlException x)
            {
                if (x.ErrorCode == -2146232060)
                    _vcod = "existe";
                else
                    _vcod = "error";
            }
            catch (Exception x)
            {
                _vcod = "error";
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
