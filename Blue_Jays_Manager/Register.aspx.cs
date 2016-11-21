using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using Blue_Jays_Manager.Models.DataAccessLayer;
using Blue_Jays_Manager.Models.DataModels;

namespace Blue_Jays_Manager
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"].ToString() == "loggedIn")
                {
                    Server.Transfer("~/User.aspx", false);
                }
            }
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int coachId = int.Parse(CoachId.Text);


                if (Cache["CoachRoster"] == null)
                {
                    DataRetrieval retrieve = new DataRetrieval();
                    List<CoachRoster> coachRoster = retrieve.SelectAllCoaches();
                    Cache.Insert("CoachRoster", coachRoster);
                }
                List<CoachRoster> roster = (List<CoachRoster>)Cache["CoachRoster"];
                var exist = roster.Find(x => x.CoachNumber == coachId);

                //Write code here to check first and last name of the coach 'exist' against first and last name entered in text fields

                if (exist != null)
                {
                    string[] name = exist.Name.Split(' ');


                    if (name[0] == FirstName.Text && name[1] == LastName.Text)
                    {
                        int returnCode = AdminUserDataLayer.Register(Password.Text, FirstName.Text, LastName.Text, Email.Text, UserName.Text, "coach");

                        if (returnCode == -1)
                        {
                            UserExists.Text = "Username is already in use. Please try again";
                            UserExists.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (returnCode == -2)
                        {
                            UserExists.Text = "Email is already registered to another user.";
                            UserExists.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            Models.Correspondence.Email.RegistrationConfirmation(UserName.Text, Password.Text, FirstName.Text, LastName.Text, Email.Text, exist.CoachNumber);
                            UserExists.Text = "Succesfull Registration. Email Confirmation has been sent to your email";
                            UserExists.ForeColor = System.Drawing.Color.Green;
                            CoachId.Text = "";
                            FirstName.Text = "";
                            LastName.Text = "";
                            Email.Text = "";
                            UserName.Text = "";
                            Password.Text = "";
                        }
                    }
                    else
                    {
                        UserExists.Text = "Coach name is either invalid or Coach Id is already assigned";
                        UserExists.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {

                    UserExists.Text = "Coach Number does not exists in database. Please see Administration or try again";
                    UserExists.ForeColor = System.Drawing.Color.Red;

                }



            }
        }
    }
}