using Blue_Jays_Manager.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    /// <summary>
    /// Update, insert and delete players using this class.
    /// </summary>
    public class DatabaseUpdate
    {
        public static int SaveAllPlayers(List<PlayerRoster> roster)
        {
            int updated = 0;
            int i = 1;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                con.Open();
                    foreach (PlayerRoster p in roster)
                    {
                        updated += UpdatePlayerRoster(con, p);
                        i++;
                    }
            }
            return updated;
        }

        private static int UpdatePlayerRoster(OracleConnection con, PlayerRoster p)
        {
            OracleCommand cmd = new OracleCommand("updatePlayerRoster_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("playerNum", p.PlayerNum));
            cmd.Parameters.Add(new OracleParameter("name", p.Name));
            cmd.Parameters.Add(new OracleParameter("position", p.Position));
            cmd.Parameters.Add(new OracleParameter("height", p.Height));
            cmd.Parameters.Add(new OracleParameter("weight", p.Weight));

            return cmd.ExecuteNonQuery();
        }

        public static int SaveAllCoaches(List<CoachRoster> roster)
        {
            int updated = 0;
            int i = 1;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                con.Open();
                //truncated = cmd.ExecuteNonQuery();
                
                    foreach (CoachRoster c in roster)
                    {
                        updated += UpdateCoachRoster(con, c);
                        i++;
                    } 
            }
            return updated;
        }

        private static int UpdateCoachRoster(OracleConnection con, CoachRoster c)
        {
            OracleCommand cmd = new OracleCommand("updateCoachRoster_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("coachNum", c.CoachNumber));
            cmd.Parameters.Add(new OracleParameter("name", c.Name));
            cmd.Parameters.Add(new OracleParameter("position", c.Position));

            return cmd.ExecuteNonQuery();
        }

        public static bool AddNewPlayer(PlayerRoster _newPlayer)
        {
            string val = null;
            int valid = 0;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("addNewPlayer_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("playerID", _newPlayer.PlayerRosterID));
                cmd.Parameters.Add(new OracleParameter("playerNum", _newPlayer.PlayerNum));
                cmd.Parameters.Add(new OracleParameter("name", _newPlayer.Name));
                cmd.Parameters.Add(new OracleParameter("position", _newPlayer.Position));
                cmd.Parameters.Add(new OracleParameter("height", _newPlayer.Height));
                cmd.Parameters.Add(new OracleParameter("weight", _newPlayer.Weight));
                cmd.Parameters.Add(new OracleParameter("skillOrientation", _newPlayer.SkillOrientation));
                cmd.Parameters.Add(new OracleParameter("dateOfBirth", _newPlayer.DateOfBirth));

                cmd.Parameters.Add(new OracleParameter("retVal", OracleDbType.Varchar2, 30));
                cmd.Parameters["retVal"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                val = cmd.Parameters["retVal"].Value.ToString();
                valid = Convert.ToInt16(val);
            }
            return Convert.ToBoolean(valid);
        }

        public static bool AddNewCoach(CoachRoster _newCoach)
        {
            string val = null;
            int valid = 0;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("addNewCoach_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("coachID", _newCoach.CoachRosterID));
                cmd.Parameters.Add(new OracleParameter("coachNum", _newCoach.CoachNumber));
                cmd.Parameters.Add(new OracleParameter("c_name", _newCoach.Name));
                cmd.Parameters.Add(new OracleParameter("c_position", _newCoach.Position));

                cmd.Parameters.Add(new OracleParameter("retVal", OracleDbType.Varchar2, 30));
                cmd.Parameters["retVal"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                val = cmd.Parameters["retVal"].Value.ToString();
                valid = Convert.ToInt16(val);
            }
            return Convert.ToBoolean(valid);
        }

        public static bool DeleteCoach(int coachNum)
        {
            int valid = 0;
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("deleteCoach_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("coach_num", coachNum));
                
                //cmd.Parameters.Add(new OracleParameter("retVal", OracleDbType.Varchar2, 30));
                //cmd.Parameters["retVal"].Direction = ParameterDirection.Output;

                con.Open();
                valid = cmd.ExecuteNonQuery();
            }
            return Convert.ToBoolean(valid);
        }

        public static bool DeletePlayer(int playerNum)
        {
            int valid = 0;
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("deletePlayer_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("player_num", playerNum));

                //cmd.Parameters.Add(new OracleParameter("retVal", OracleDbType.Varchar2, 30));
                //cmd.Parameters["retVal"].Direction = ParameterDirection.Output;

                con.Open();
                valid = cmd.ExecuteNonQuery();
            }
            return Convert.ToBoolean(valid);
        }
    }
}