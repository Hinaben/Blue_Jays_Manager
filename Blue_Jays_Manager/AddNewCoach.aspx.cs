using Blue_Jays_Manager.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blue_Jays_Manager
{
    public partial class AddNewCoach : System.Web.UI.Page
    {
        List<CoachRoster> coachRoster;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 
                if ((AdminUser)Session["AdminUser"] == null)
                {
                    Server.Transfer("ErrorPage.aspx");
                }
                else
                {
                    coachRoster = (List<CoachRoster>)Cache["CoachRoster"];
                }
                
            }

        }

        protected void AddCoachButton_Click(object sender, EventArgs e)
        {
            bool existCoach = false;

            foreach (CoachRoster coach in coachRoster)
            {
                if (coach.CoachNumber == int.Parse(CoachNum.Text))
                {
                    existCoach = true;
                    break;
                }
            }

            if (!existCoach)
            {

                coachRoster.Add
                (
                    new CoachRoster()
                    {
                        CoachNumber = int.Parse(CoachNum.Text),
                        Name = FirstName.Text + " " + LastName.Text,
                        Position = pos.Text,
                        IsLocked = "Access"
                    }
                );

                Cache["CoachRoster"] = coachRoster;

                Server.Transfer("Coaches.aspx");
            }

            else
            {
                CoachExists.Text = "There is already an existing coach with the number " + CoachNum.Text + "!";
            }

        }
    }
}