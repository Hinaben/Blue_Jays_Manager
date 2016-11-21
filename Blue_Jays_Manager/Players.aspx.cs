﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Blue_Jays_Manager.Models.DataAccessLayer;
using Blue_Jays_Manager.Models.DataModels;
using System.Collections.Specialized;

namespace Blue_Jays_Manager
{
    public partial class Player : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataRetrieval retrieve = new DataRetrieval();

                List<PlayerRoster> playerRoster = retrieve.SelectAllPlayers();

                if (Session["login"].ToString() == "loggedIn")
                {
                    PlayerRosterGridView.AutoGenerateEditButton = true;
                    PlayerRosterGridView.AutoGenerateDeleteButton = true;
                    SavePlayerChanges.Visible = true;
                    if ((bool)Session["PlayerChanges"] == false)
                    {
                        SavePlayerChanges.Enabled = false;
                        SavePlayerChanges.Visible = false;
                    }
                    else
                    {
                        SavePlayerChanges.Enabled = true;
                    }

                    AddPlayer.Visible = true;
                }
                if (Cache["PlayerRoster"] == null)
                {
                    Cache.Insert("PlayerRoster", playerRoster);
                }
                PlayerRosterGridView.DataSource = (List<PlayerRoster>)Cache["PlayerRoster"];
                PlayerRosterGridView.DataBind();
            }
        }

        /**
         * <summary>
         * The user can search the player roster stored in cache based on three search criteria:
         * player number, name or position. The resulting set is returned to the gridview to be
         * dispalyed on the same page.
         * 
         * Querying with empty string will yield entire player roster.
         * </summary>
         */
        protected void submitButton_Click(object sender, EventArgs e)
        {
            string searchCriteria = searchCategory.SelectedValue;
            string searchText = "";
            int searchNum = 0;
            List<PlayerRoster> roster = (List<PlayerRoster>)Cache["PlayerRoster"];
            List<PlayerRoster> resultSet = new List<PlayerRoster>();

            if (searchTextBox.Text != "")
            {
                switch (searchCriteria)
                {
                    // player number search only accepts numbers
                    case "Player Number":
                        if (!int.TryParse(searchTextBox.Text, out searchNum))
                        {
                            NoRecords.Text = "Please enter a valid number!";
                            NoRecords.Visible = true;
                            PlayerRosterGridView.Visible = false;
                            return;
                        }
                        if (searchNum < 0)
                        {
                            NoRecords.Text = "Please enter a positive player number!";
                            NoRecords.Visible = true;
                            PlayerRosterGridView.Visible = false;
                            return;
                        }

                        break;

                    default: // position and player name would accept string
                        searchText = searchTextBox.Text;
                        break;
                }

                foreach (PlayerRoster player in roster)
                {
                    switch (searchCriteria)
                    {
                        case "Player Number":
                            if (player.PlayerNum == searchNum)
                                resultSet.Add(player);
                            break;
                        case "Name":
                            if (player.Name.ToLower().IndexOf(searchText.ToLower()) != -1)
                                resultSet.Add(player);
                            break;
                        default: // position
                            if (player.Position.ToLower() == searchText.ToLower())
                                resultSet.Add(player);
                            break;
                    }
                }
            }
            else
            {
                resultSet = (List<PlayerRoster>)Cache["PlayerRoster"];
            }

            PlayerRosterGridView.DataSource = resultSet;
            PlayerRosterGridView.DataBind();

            if (PlayerRosterGridView.Rows.Count < 1)
            {
                NoRecords.Text = "There are no players which match the search criteria.";
                NoRecords.Visible = true;
                PlayerRosterGridView.Visible = false;
            }
            else
            {
                NoRecords.Visible = false;
                PlayerRosterGridView.Visible = true;
            }
        }

        protected void PlayerRosterGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["login"].ToString() == "loggedIn")
            {
                Server.Transfer("PlayerDetails.aspx?playerNumber=" + PlayerRosterGridView.SelectedRow.Cells[2].Text);
            }
            else
            {
                Server.Transfer("PlayerDetails.aspx?playerNumber=" + PlayerRosterGridView.SelectedRow.Cells[1].Text);
            }
        }

        protected void PlayerRosterGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PlayerRosterGridView.EditIndex = e.NewEditIndex;
            PlayerRosterGridView.DataSource = (List<PlayerRoster>)Cache["PlayerRoster"];
            PlayerRosterGridView.DataBind();

        }

        protected void PlayerRosterGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Cache["PlayerRoster"] != null)
            {
                List<PlayerRoster> roster = (List<PlayerRoster>)Cache["PlayerRoster"];

                string playerNum = (Session["login"].ToString() == "loggedIn") ? PlayerRosterGridView.Rows[e.RowIndex].Cells[2].Text : PlayerRosterGridView.Rows[e.RowIndex].Cells[1].Text;

                PlayerRoster player = roster.SingleOrDefault(x => x.PlayerNum == Convert.ToInt32(playerNum));

                if (player != null)
                {
                    roster.Remove(player);
                    Cache.Insert("PlayerRoster", roster);
                }

                if ((bool)Session["PlayerChanges"] == false)
                {
                    Session["PlayerChanges"] = true;
                    SavePlayerChanges.Enabled = true;
                    SavePlayerChanges.Visible = true;
                }

                PlayerRosterGridView.EditIndex = -1;
                PlayerRosterGridView.DataSource = (List<PlayerRoster>)Cache["PlayerRoster"];
                PlayerRosterGridView.DataBind();
            }
        }

        protected void PlayerRosterGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PlayerRosterGridView.EditIndex = -1;
            PlayerRosterGridView.DataSource = (List<PlayerRoster>)Cache["PlayerRoster"];
            PlayerRosterGridView.DataBind();
        }

        protected void PlayerRosterGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["PlayerRoster"] != null)
            {

                List<PlayerRoster> roster = (List<PlayerRoster>)Cache["PlayerRoster"];

                IOrderedDictionary rowValues = e.NewValues;

                int playerNum = Convert.ToInt32(PlayerRosterGridView.Rows[e.RowIndex].Cells[2].Text);

                PlayerRoster player = roster.SingleOrDefault(x => x.PlayerNum == Convert.ToInt32(playerNum));

                int indexOfPlayer = roster.IndexOf(player);

                player.Name = rowValues["Name"].ToString();
                player.Position = rowValues["Position"].ToString();
                player.Height = Convert.ToInt32(rowValues["Height"]);
                player.Weight = Convert.ToInt32(rowValues["Weight"]);

                roster.RemoveAt(indexOfPlayer);

                roster.Insert(indexOfPlayer, player);

                if ((bool)Session["PlayerChanges"] == false)
                {
                    Session["PlayerChanges"] = true;
                    SavePlayerChanges.Enabled = true;
                    SavePlayerChanges.Visible = true;
                }

                PlayerRosterGridView.EditIndex = -1;

                PlayerRosterGridView.DataSource = roster;
                PlayerRosterGridView.DataBind();
                Cache["PlayerRoster"] = roster;
            }
        }

        protected void SavePlayerChanges_Click(object sender, EventArgs e)
        {
            int rowsInserted = 0;
            if ((bool)Session["PlayerChanges"] == true)
            {
                List<PlayerRoster> roster = (List<PlayerRoster>)Cache["PlayerRoster"];

                rowsInserted = DatabaseUpdate.SaveAllPlayers(roster);

                Session["PlayerChanges"] = false;
                SavePlayerChanges.Enabled = false;
                SavePlayerChanges.Visible = false;

            }

            if ((bool)Session["CoachChanges"] == true)
            {
                List<CoachRoster> roster = (List<CoachRoster>)Cache["CoachRoster"];

                rowsInserted = DatabaseUpdate.SaveAllCoaches(roster);

                Session["CoachChanges"] = false;
            }


        }

        protected void PlayerRosterGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<PlayerRoster> roster = null;

            if (ViewState["SortDirection"] != null)
            {
                if (e.SortExpression == "PlayerNum")
                {
                    roster = (List<PlayerRoster>)Cache["PlayerRoster"];

                    if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
                    {
                        roster = roster.OrderByDescending(x => x.PlayerNum).ToList();
                        ViewState["SortDirection"] = SortDirection.Descending;

                    }
                    else
                    {
                        roster = roster.OrderBy(x => x.PlayerNum).ToList();
                        ViewState["SortDirection"] = SortDirection.Ascending;
                    }
                }
                else if (e.SortExpression == "PlayerHeight")
                {
                    roster = (List<PlayerRoster>)Cache["PlayerRoster"];

                    if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
                    {
                        roster = roster.OrderByDescending(x => x.Height).ToList();
                        ViewState["SortDirection"] = SortDirection.Descending;

                    }
                    else
                    {
                        roster = roster.OrderBy(x => x.Height).ToList();
                        ViewState["SortDirection"] = SortDirection.Ascending;
                    }
                }
                else if (e.SortExpression == "PlayerWeight")
                {
                    roster = (List<PlayerRoster>)Cache["PlayerRoster"];

                    if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
                    {
                        roster = roster.OrderByDescending(x => x.Weight).ToList();
                        ViewState["SortDirection"] = SortDirection.Descending;

                    }
                    else
                    {
                        roster = roster.OrderBy(x => x.Weight).ToList();
                        ViewState["SortDirection"] = SortDirection.Ascending;
                    }
                }
            }
            else
            {
                ViewState["SortDirection"] = e.SortDirection; //This is ascending on the first time.

                if (e.SortExpression == "PlayerNum")
                {
                    roster = (List<PlayerRoster>)Cache["PlayerRoster"];
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        roster = roster.OrderBy(x => x.PlayerNum).ToList();
                    }
                }
                else if (e.SortExpression == "PlayerHeight")
                {
                    roster = (List<PlayerRoster>)Cache["PlayerRoster"];
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        roster = roster.OrderBy(x => x.Height).ToList();
                    }
                }
                else if (e.SortExpression == "PlayerWeight")
                {
                    roster = (List<PlayerRoster>)Cache["PlayerRoster"];
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        roster = roster.OrderBy(x => x.Weight).ToList();
                    }
                }
            }
            PlayerRosterGridView.DataSource = roster;
            PlayerRosterGridView.DataBind();
        }

        protected void AddPlayer_Click(object sender, EventArgs e)
        {
            Server.Transfer("AddNewPlayer.aspx");
        }
    }
}
