using Microsoft.LabApplication.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Web.SessionState;

/// <summary>
/// Summary description for DB
/// </summary>
public class DBPROC
{
    public static string Get_Scaler(string query)
    {
        return Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.StoredProcedure, query));
    }

    public static string Get_ScalerQuery(string query)
    {
        return Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.Text, query));
    }


    public static int Get_ScalerInt(string query)
    {
        return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.Text, query));
    }

    public static SqlDataReader Get_temp(string query)
    {

        SqlDataReader DataReader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.Text, query);

        return DataReader;
    }

    public static string Set_temp(string query)
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        //if (con.State == ConnectionState.Open) { con.Close(); } else { con.Open(); }

        //SqlCommand command = new SqlCommand(query, con);
        //command.ExecuteNonQuery();

        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.Text, query);


        return "";
    }
    public static string Set_temp_proc(string procedureName, List<string> parameterNames, params object[] parameters)
    {
        string cs = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] procedureParams = new SqlParameter[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                procedureParams[i] = new SqlParameter(parameterNames[i], parameters[i]);
                cmd.Parameters.Add(procedureParams[i]);
            }
            con.Open();
            cmd.ExecuteNonQuery();
        }

        return "";
    }


    public static DataSet GetDataSet_Simple(string sql)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        try
        {
            if (con.State == ConnectionState.Open) { con.Close(); }// else { con.Open(); }

            //SqlCommand command = new SqlCommand(query, con);
            //command.ExecuteNonQuery();

            return SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
        }
        finally { con.Close(); }
    }


    public static decimal Get_ScalerDecimal(string query)
    {
        return Convert.ToDecimal(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.Text, query));
    }

    public string ExecuteScalar(string procedureName, List<string> parameterNames, params object[] parameters)
    {
        string ret;
        string cs = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlParameter[] procedureParams = new SqlParameter[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                procedureParams[i] = new SqlParameter(parameterNames[i], parameters[i]);
                cmd.Parameters.Add(procedureParams[i]);
            }
            cmd.CommandTimeout = 2000;
            ret = cmd.ExecuteScalar().ToString();
            con.Close();
        }
        return ret;
    }

    public static DataTable GetDataTable(string ProcName)
    {
       return SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.Text, ProcName).Tables[0];
    }


     public static string Sp_GetScalar(string procedureName)
    {

        return  SqlHelper.ExecuteScalar (ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.StoredProcedure, procedureName,null).ToString();
    }

    public static string Sp_GetScalarP(string procedureName ,SqlParameter [] sqlParameter)
    {

        return SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.StoredProcedure, procedureName, sqlParameter).ToString();
    }


    public static DataTable Sp_GetData(string ProcName)
    {
        return SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.StoredProcedure, ProcName, null).Tables[0];
    }
    public static DataTable Sp_GetDataTable(string ProcName, SqlParameter[] sqlParameter)
    {
        return SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.StoredProcedure, ProcName, sqlParameter).Tables[0];
    }


    public static DataSet Sp_GetDataSet(string ProcName, SqlParameter[] sqlParameter)
    {
        return SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["Con"].ConnectionString, CommandType.StoredProcedure, ProcName, sqlParameter);
    }

    public static int Sp_Insert(string ProcName, SqlParameter[] sqlParameter)
    {
        int Ret = -9;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        SqlCommand cmd = new SqlCommand(ProcName, cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddRange(sqlParameter);
        cn.Open();
        Ret = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        cn.Close();
        return Ret;

    
    }


    public static DataSet GetDataSet(string sql)
    {
        DataSet myDataSet = new DataSet();
        string strconn = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(strconn))
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(myDataSet);
            }
            conn.Close();
        }
        return myDataSet;
    }


}