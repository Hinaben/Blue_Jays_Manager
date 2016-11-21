using Blue_Jays_Manager.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blue_Jays_Manager
{
    public partial class AddNewPlayer : System.Web.UI.Page
    {
        List<PlayerRoster> playerRoster;
        DateTime startDate = Convert.ToDateTime("1/1/1950");

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
                   
                    _populateYear(dobYearDropDownList);
                    _populateMonth(dobMonthDropDownList);
                    _populateDay(dobDayDropDownList);
                }

               
            }
            if (playerRoster == null)
            {
                playerRoster = (List<PlayerRoster>)Cache["PlayerRoster"];
            }
        }

        #region Method to Fill the a DropDownList with Month Names and set the Current Month Selected
        /// <summary>
        /// fills a dropDownlist with month list.
        /// </summary>
        /// The DropDown List that will Hold the Months.
        /// if set to <c>true</c> the Current Month will be selected.
        private void _populateMonth(DropDownList monthDDL, bool setCurretMonth = true)
        {
            monthDDL.Items.Clear();

            for (int i = 0; i < 12; i++)
            {
                DateTime NextMonth = startDate.AddMonths(i);
                ListItem lt = new ListItem();
                lt.Text = NextMonth.ToString("MMM");
                lt.Value = NextMonth.Month.ToString();
                monthDDL.Items.Add(lt);
            }
            if (setCurretMonth == true)
            {
                monthDDL.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
            }
        }


        #endregion

        private void _populateDay(DropDownList dayDDL, bool setCurrentDay = true)
        {
            dayDDL.Items.Clear();

            int totalDays = DateTime.DaysInMonth(int.Parse(dobYearDropDownList.SelectedValue), int.Parse(dobMonthDropDownList.SelectedValue));


            for (int i = 1; i <= totalDays; i++)
            {
                ListItem lt = new ListItem();
                lt.Text = i.ToString();
                lt.Value = i.ToString();
                dayDDL.Items.Add(lt);
            }

            if (setCurrentDay == true)
            {
                dayDDL.Items.FindByValue(DateTime.Now.Day.ToString()).Selected = true;
            }

        }

        private void _populateYear(DropDownList yearDDL, bool setCurrentYear = true)
        {
            yearDDL.Items.Clear();

            int totalYears = 50;
            int endYear = DateTime.Now.Year;
            int startYear = endYear - totalYears;

            for (int i = startYear; i <= endYear; i++)
            {
                ListItem lt = new ListItem();
                lt.Text = i.ToString();
                lt.Value = i.ToString();
                yearDDL.Items.Add(lt);
            }

            if (setCurrentYear == true)
            {
                yearDDL.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
            }

        }

        protected void dobYearDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _populateDay(dobDayDropDownList);

        }

        protected void dobMonthDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _populateDay(dobDayDropDownList);

        }

        protected void AddPlayerButton_Click(object sender, EventArgs e)
        {
            bool existPlayer = false;

            foreach (PlayerRoster player in playerRoster)
            {
                if (player.PlayerNum == int.Parse(PlayerNum.Text))
                {
                    existPlayer = true;
                    break;
                }
            }

            if (!existPlayer)
            {
                //string month = dobMonthDropDownList.SelectedValue;
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[Convert.ToInt32(dobMonthDropDownList.SelectedValue) - 1];

                monthName = monthName.Substring(0, 1).ToUpper() + monthName.Substring(1,2).ToLower();

                playerRoster.Add
                (
                    new PlayerRoster()
                    {
                        PlayerNum = int.Parse(PlayerNum.Text),
                        Name = FirstName.Text + " " + LastName.Text,
                        Position = positionDropDownList.SelectedValue,
                        Height = int.Parse(playerHeight.Text),
                        Weight = int.Parse(playerWeight.Text),
                        DateOfBirth = monthName + " " +
                        dobDayDropDownList.SelectedValue + " " + dobYearDropDownList.SelectedValue,
                        SkillOrientation = playerBattingHand + "/" + playerThrowingHand
                    }
                );

                Cache["PlayerRoster"] = playerRoster;

                Server.Transfer("Players.aspx");
            }

            else
            {
                PlayerExists.Text = "There is already an existing player with the number " + PlayerNum.Text + "!";
            }

        }
    }
}