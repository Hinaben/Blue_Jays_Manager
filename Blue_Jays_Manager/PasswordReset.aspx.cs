using Blue_Jays_Manager.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blue_Jays_Manager
{
    public partial class PasswordReset : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uid = Request.QueryString["uid"];

                if (uid != null)
                {
                    bool valid = AdminUserDataLayer.PasswordResetLinkValid(uid);

                    if (!valid)
                    {
                        Server.Transfer("ErrorPage.aspx");
                    }
                }
                else
                {
                    Server.Transfer("ErrorPage.aspx");
                }
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            string newPassword = NewPassword.Text;

            string[] arr = AdminUserDataLayer.ResetPassword(Request.QueryString["uid"], newPassword);

            if (arr != null)
            {
                int sent = Models.Correspondence.Email.SendPasswordChangeConfirmation(newPassword, arr[0], arr[1], arr[2], arr[3]);
                if (sent == 1)
                {
                    confirmLabel.Text = "Password has been reset. Email confirmation has been sent with the details";
                    confirmLabel.ForeColor = System.Drawing.Color.Green;

                    HttpCookie cookie = Request.Cookies["AdminUser"];


                    if (cookie != null)
                    {
                        cookie.Values.Remove("password");
                        cookie["password"] = newPassword;
                        Response.Cookies.Add(cookie);
                    }
                }
                else
                {
                    confirmLabel.Text = "Email could not be sent";
                    confirmLabel.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                confirmLabel.Text = "Username could not be found";
                confirmLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}