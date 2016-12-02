using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using Blue_Jays_Manager.Models.DataModels;
using System.Data;
using Blue_Jays_Manager.Models.Correspondence;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    public class AdminUserDataLayer
    {
        public static int Register(string password, string firstName, string lastName, string email, string userName, string role)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("registerUser_sp", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                cmd.Parameters.Add(new OracleParameter("FirstName", firstName));
                cmd.Parameters.Add(new OracleParameter("LastName", lastName));
                cmd.Parameters.Add(new OracleParameter("Email", email));
                cmd.Parameters.Add(new OracleParameter("UserName", userName));
                cmd.Parameters.Add(new OracleParameter("Password", encryptedPassword));
                cmd.Parameters.Add(new OracleParameter("Role", role));
                cmd.Parameters.Add(new OracleParameter("u_exists", OracleDbType.Int16));
                cmd.Parameters["u_exists"].Direction = ParameterDirection.Output;
                conn.Open();

                cmd.ExecuteNonQuery();

                string retVal = cmd.Parameters["u_exists"].Value.ToString();
                int convert_Val = Convert.ToInt16(retVal);
                return convert_Val;
            }
        }

        public static object LogIn(string userName, string password)
        {
            AdminUser admin = null;
            string message = String.Empty;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("AuthenticateUser_sp", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                cmd.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2, ParameterDirection.Input)).Value = userName;

                cmd.Parameters.Add(new OracleParameter("password", OracleDbType.Varchar2, ParameterDirection.Input)).Value =encryptedPassword ;

                cmd.Parameters.Add(new OracleParameter("return_Val", OracleDbType.Varchar2, 300));
                cmd.Parameters["return_Val"].Direction = ParameterDirection.Output;

                con.Open();

                cmd.ExecuteNonQuery();

                string[] retVal = cmd.Parameters["return_Val"].Value.ToString().Split(','); // read return value


                if (retVal.Length > 3)

                {
                    admin = new AdminUser();

                    admin.Id = Convert.ToInt32(retVal[0]);
                    admin.FirstName = retVal[1].ToString();
                    admin.LastName = retVal[2].ToString();
                    admin.Email = retVal[3].ToString();
                    admin.UserName = retVal[4].ToString();
                    admin.Password = retVal[5].ToString();
                    admin.Role = retVal[6].ToString();
                    return admin;
                }
                else
                {
                    int col = retVal.Length;

                    int attempts = Convert.ToInt32(retVal[2]);

                    if (retVal[0] == " 1")
                    {
                        message = "Account Locked. Please Contact Administrator";
                    }
                    else if (attempts > 0)
                    {
                        int attemptsLeft = (4 - attempts);

                        message = "Invalid username or password. " + attemptsLeft.ToString() + " attempts remaining";
                    }
                    else
                    {
                        message = "Invalid username or password";
                    }
                }
            }
                return message; 
        }

        public static int EnableUserAccount(string firstName, string lastName)
        {
            int rowAffected = 0;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("spEnableAdminUser", con);
                cmd.CommandType = CommandType.StoredProcedure;


                //This is new???...........message received after visual studio update 3 stating that mircosoft has deprecated "Add"
                cmd.Parameters.Add(new OracleParameter("first_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = firstName;
                cmd.Parameters.Add(new OracleParameter("last_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = lastName;

                cmd.Parameters.Add(new OracleParameter("affected_row", OracleDbType.Varchar2, 30));
                cmd.Parameters["affected_row"].Direction = ParameterDirection.Output;


                con.Open();

                cmd.ExecuteNonQuery();

                string retVal = cmd.Parameters["affected_row"].Value.ToString();
                int.TryParse(retVal, out rowAffected);

            }
            return rowAffected;
        }

        //Changes made to stored procedure in database
        public static List<LockedUser> GetLockedUsers()
        {
            List<LockedUser> lockedList = new List<LockedUser>();
            LockedUser lockedUser = new LockedUser();

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("getLockedUserss_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("ref_cur", OracleDbType.RefCursor));
                cmd.Parameters["ref_cur"].Direction = ParameterDirection.Output;

                con.Open();

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["ref_cur"].Value).GetDataReader();

                while (reader.Read())
                {

                    lockedUser.FirstName = reader["FirstName"].ToString();
                    lockedUser.LastName = reader["LastName"].ToString();
                    lockedUser.Role = reader["Role"].ToString();
                    lockedUser.IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                    lockedUser.UserName = reader["UserName"].ToString();
                    lockedUser.Email = reader["Email"].ToString();

                    lockedList.Add(lockedUser);
                }
            }
            return lockedList;
        }

        public static int ChangeUserPassword(int id, string newPassword)
        {
            int rowChanges = 0;
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("changeUserPassword_sp", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("user_id", OracleDbType.Varchar2, ParameterDirection.Input)).Value = id;
                cmd.Parameters.Add(new OracleParameter("pass_word", OracleDbType.Varchar2, ParameterDirection.Input)).Value = newPassword;

                cmd.Parameters.Add(new OracleParameter("retVal", OracleDbType.Varchar2,30));
                cmd.Parameters["retVal"].Direction = ParameterDirection.Output;

                con.Open();

                cmd.ExecuteNonQuery();

                string retVal = cmd.Parameters["retVal"].Value.ToString();
                int.TryParse(retVal, out rowChanges);
            }

            return rowChanges;
        }

        public static int RequestPasswordReset(string username)
        {
            int success = 0;
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("resetPasswordRequest_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = username;

                cmd.Parameters.Add(new OracleParameter("user_details", OracleDbType.Varchar2, 300));
                cmd.Parameters["user_details"].Direction = ParameterDirection.Output;

                con.Open();

                cmd.ExecuteNonQuery();

                string [] reVal = cmd.Parameters["user_details"].Value.ToString().Split(','); // read return value

                
                if (reVal[0] == "1")
                {
                    success = Email.SendPasswordResetEmail(reVal[2].ToString(), reVal[3].ToString(), reVal[4].ToString(), reVal[1].ToString());
                }
                else if (reVal[0] == "8")
                {
                    success = 2;
                }
                else
                {
                    success = 3;
                }
            }
            return success;
        }
        public static bool PasswordResetLinkValid(string uid)
        {
            string val = null;
            int valid = 0;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("isPasswordResetLinkValid_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("user_guid", OracleDbType.Varchar2, ParameterDirection.Input)).Value = uid;
                cmd.Parameters.Add(new OracleParameter("return_val", OracleDbType.Int16));
                cmd.Parameters["return_val"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                val = cmd.Parameters["return_val"].Value.ToString();
                valid = Convert.ToInt16(val);
            }
            return Convert.ToBoolean(valid);
        }

        public static string[] ResetPassword(string uid, string password)
        {
            string[] values = new string[4];

            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("changePassword_sp ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("user_guid", OracleDbType.Varchar2, ParameterDirection.Input)).Value = uid;
                cmd.Parameters.Add(new OracleParameter("pass_word", OracleDbType.Varchar2, ParameterDirection.Input)).Value = password;
                cmd.Parameters.Add(new OracleParameter("return_val", OracleDbType.Varchar2, 300));
                cmd.Parameters["return_val"].Direction = ParameterDirection.Output;

                con.Open();

                cmd.ExecuteNonQuery();

                values = cmd.Parameters["return_val"].Value.ToString().Split(',');

                if (values.Length > 1)
                {
                    return values;
                }
                else
                {
                    return null;
                }
            }
        }

        public static int RequestUserName(string email)
        {

            int success = 0;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("usernameRequest_sp ", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("u_email", OracleDbType.Varchar2, ParameterDirection.Input)).Value = email;

                cmd.Parameters.Add(new OracleParameter("retVal", OracleDbType.Varchar2, 300));
                cmd.Parameters["retVal"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();

                string[] values = cmd.Parameters["retVal"].Value.ToString().Split(',');

                    if (values[0] == "1")
                    {
                        success = Email.SendUserNameEmail(email, values[2].ToString(), values[3].ToString(), values[1].ToString());
                    }
                    else
                    {
                        success = 2;
                    }    
            }
            return success;
        }
    }
}