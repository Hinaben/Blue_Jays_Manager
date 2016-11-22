using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    public class ExceptionLogger
    {
        public static void Log(Exception ex)
        {
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = null;
                cmd = new OracleCommand("spInsertException", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("ExceptionMessage", ex.Message);
                cmd.Parameters.Add(@"StackTrace", ex.StackTrace);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}