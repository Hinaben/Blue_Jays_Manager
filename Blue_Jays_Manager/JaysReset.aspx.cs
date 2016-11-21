using Blue_Jays_Manager.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blue_Jays_Manager
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string value = Request.QueryString["id"];

                if (value == null)
                {
                    Server.Transfer("ErrorPage.aspx");
                }
                else if (value == "password")
                {
                    LblReset.Text = "Username:";
                    LblPageHeader.Text = "Request Password Reset <span style=\"color: #EF2F24\" class=\"glyphicon glyphicon-cog\"></span>";
                    BtnnReset.Text = "Reset Password  <span class=\"glyphicon glyphicon-send\"></span>";
                }
                else if (value == "username")
                {
                    LblReset.Text = "Email Address:";
                    LblPageHeader.Text = "Request Coach Username <span style=\"color: #EF2F24\" class=\"glyphicon glyphicon-cog\"></span>";
                    BtnnReset.Text = "Submit <span  class=\"glyphicon glyphicon-send\"></span>";
                }
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int success = 0;
                if (Request.QueryString["id"] == "password")
                {
                    success = AdminUserDataLayer.RequestPasswordReset(reset.Text);

                    if (success == 1)
                    {
                        ConfirmLbl.Text = "Email has been sent to reset password";
                        ConfirmLbl.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        ConfirmLbl.Text = "Username could not be found";
                        ConfirmLbl.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else if (Request.QueryString["id"] == "username")
                {

                    success = AdminUserDataLayer.RequestUserName(reset.Text);


                    if (success == 1)
                    {
                        ConfirmLbl.Text = "Your username has been sent to the registered email.";
                        ConfirmLbl.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (success == 2)
                    {
                        ConfirmLbl.Text = "Email provided is either invalid or does not exist in admin database.";
                        ConfirmLbl.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        ConfirmLbl.Text = "There has been an error requesting username. Please speak to administration.";
                        ConfirmLbl.ForeColor = System.Drawing.Color.Red;
                    }

                }
            }

        }
    }
}