using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    public class ExceptionLogger
    {
        public static void Log(Exception ex)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = null;
                cmd = new SqlCommand("spInsertException", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ExceptionMessage", ex.Message);
                cmd.Parameters.AddWithValue(@"StackTrace", ex.StackTrace);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}