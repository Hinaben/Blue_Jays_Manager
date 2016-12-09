using Blue_Jays_Manager.Models.DataAccessLayer;
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
            CoachRoster _newCoach = new CoachRoster();

            bool existCoach = false;
            coachRoster = (List<CoachRoster>)Cache["CoachRoster"];

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
                _newCoach.CoachRosterID = coachRoster.Count + 10;
                _newCoach.CoachNumber = int.Parse(CoachNum.Text);
                _newCoach.Name = FirstName.Text + " " + LastName.Text;
                _newCoach.Position = pos.Text;
                _newCoach.IsLocked = "Access";

                bool updated = DatabaseUpdate.AddNewCoach(_newCoach);

                if(updated)
                {
                    coachRoster.Add(_newCoach);
                    Cache["CoachRoster"] = coachRoster;
                    Server.Transfer("Coaches.aspx");
                }
                else
                {
                    CoachExists.Text = "There was an issue adding coach to Roster";
                }
            }
            else
            {
                CoachExists.Text = "There is already an existing coach with the number " + CoachNum.Text + "!";
            }
        }
    }
}