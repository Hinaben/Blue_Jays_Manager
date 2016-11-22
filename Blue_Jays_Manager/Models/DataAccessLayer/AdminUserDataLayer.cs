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

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    public class AdminUserDataLayer
    {
        public static int Register(string password, string firstName, string lastName, string email, string userName, string role)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("spRegisterUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                cmd.Parameters.Add(new OracleParameter("FirstName", firstName));
                cmd.Parameters.Add(new OracleParameter("LastName", lastName));
                cmd.Parameters.Add(new OracleParameter("Email", email));
                cmd.Parameters.Add(new OracleParameter("UserName", userName));
                cmd.Parameters.Add(new OracleParameter("Password", encryptedPassword));
                cmd.Parameters.Add(new OracleParameter("Role", role));

                conn.Open();

                return (int)cmd.ExecuteScalar();
            }
        }

        public static object LogIn(string userName, string password)
        {
            AdminUser admin = null;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("spAuthenticateUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                string ecryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                cmd.Parameters.Add(new OracleParameter("UserName", userName));
                cmd.Parameters.Add(new OracleParameter("Password", ecryptedPassword));

                con.Open();

                OracleDataReader reader = cmd.ExecuteReader();


                if (reader.FieldCount > 3)

                {
                    admin = new AdminUser();
                    while (reader.Read())
                    {
                        admin.Id = Convert.ToInt32(reader["Id"]);
                        admin.FirstName = reader["FirstName"].ToString();
                        admin.LastName = reader["LastName"].ToString();
                        admin.Email = reader["Email"].ToString();
                        admin.UserName = reader["UserName"].ToString();
                        admin.Password = reader["Password"].ToString();
                        admin.Role = reader["Role"].ToString();
                    }

                    return admin;
                }
                else
                {
                    int col = reader.FieldCount;

                    string message = String.Empty;

                    while (reader.Read())
                    {
                        int attempts = Convert.ToInt32(reader["RetryAttempts"]);

                        if (Convert.ToBoolean(reader["AccountLocked"]))
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
                    return message;
                }
            }
        }

        public static int EnableUserAccount(string firstName, string lastName)
        {
            int rowAffected = 0;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("spEnableAdminUser", con);
                cmd.CommandType = CommandType.StoredProcedure;


                //This is new???...........message received after visual studio update 3 stating that mircosoft has deprecated "Add"
                cmd.Parameters.Add("FirstName", firstName);
                cmd.Parameters.Add("FirstName", firstName);
                cmd.Parameters.Add("LastName", lastName);

                con.Open();

                rowAffected = cmd.ExecuteNonQuery();
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
                OracleCommand cmd = new OracleCommand(@"select FirstName, LastName, UserName, Role, IsLocked, Email from tblUsers where IsLocked = 1", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                OracleDataReader reader = cmd.ExecuteReader();

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
                OracleCommand cmd = new OracleCommand("update tblUsers set Password = Password where id = @Id", con);
                cmd.Parameters.Add("Password", newPassword);
                cmd.Parameters.Add("Id", id);

                con.Open();

                rowChanges = cmd.ExecuteNonQuery();
            }

            return rowChanges;
        }

        public static int RequestPasswordReset(string username)
        {
            int success = 0;
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("spResetPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("UserName", username);

                con.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.ToBoolean(reader["ReturnCode"]))
                    {
                        success = Email.SendPasswordResetEmail(reader["Email"].ToString(), reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["UniqueId"].ToString());
                    }
                    else
                    {
                        success = 2;
                    }
                }
            }
            return success;
        }
        public static bool PasswordResetLinkValid(string uid)
        {
            bool valid = false;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("spIsPasswordResetLinkValid ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("GUID", uid);

                con.Open();

                valid = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            return valid;
        }

        public static string[] ResetPassword(string uid, string password)
        {
            string[] values = new string[4];

            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("spChangePassword ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("GUID", uid);
                cmd.Parameters.Add("Password", password);

                con.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.FieldCount > 1)
                {
                    while (reader.Read())
                    {
                        values[0] = reader["FirstName"].ToString();
                        values[1] = reader["LastName"].ToString();
                        values[2] = reader["Email"].ToString();
                        values[3] = reader["UserName"].ToString();
                    }

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

                OracleCommand cmd = new OracleCommand("spUsernameRequest ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Email", email);

                con.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    if (Convert.ToBoolean(reader["ReturnCode"]))
                    {
                        success = Email.SendUserNameEmail(email, reader["FirstName"].ToString(), reader["LastName"].ToString(), reader["UserName"].ToString());
                    }
                    else
                    {
                        success = 2;
                    }
                }  
            }
            return success;
        }
    }
}