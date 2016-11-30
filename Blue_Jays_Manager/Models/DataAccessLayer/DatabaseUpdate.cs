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
            int truncated = 0;
            int inserted = 0;
            int i = 1;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = null;
                cmd = new OracleCommand("truncate table PlayerRoster", con);

                con.Open();
                truncated = cmd.ExecuteNonQuery();

                if (truncated < 0)
                {
                    foreach (PlayerRoster p in roster)
                    {
                        inserted += InsertIntoPlayerRoster(con, p, i);
                        i++;
                    }
                }
            }
            return inserted;
        }

        private static int InsertIntoPlayerRoster(OracleConnection con, PlayerRoster p, int i)
        {
            OracleCommand cmd = new OracleCommand("spInsertIntoPlayerRoster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("playerID", i));
            cmd.Parameters.Add(new OracleParameter("playerNum", p.PlayerNum));
            cmd.Parameters.Add(new OracleParameter("name", p.Name));
            cmd.Parameters.Add(new OracleParameter("position", p.Position));
            cmd.Parameters.Add(new OracleParameter("height", p.Height));
            cmd.Parameters.Add(new OracleParameter("weight", p.Weight));
            cmd.Parameters.Add(new OracleParameter("skillOrientation", p.SkillOrientation));
            cmd.Parameters.Add(new OracleParameter("dateOfBirth", p.DateOfBirth));

            return cmd.ExecuteNonQuery();
        }

        public static int SaveAllCoaches(List<CoachRoster> roster)
        {
            int truncated = 0;
            int inserted = 0;
            int i = 1;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = null;
                cmd = new OracleCommand("truncate table CoachRoster", con);

                con.Open();
                truncated = cmd.ExecuteNonQuery();

                if (truncated < 0)
                {
                    foreach (CoachRoster c in roster)
                    {
                        inserted += InsertIntoCoachRoster(con, c, i);
                        i++;
                    }
                }
            }
            return inserted;
        }

        private static int InsertIntoCoachRoster(OracleConnection con, CoachRoster c, int i)
        {
            OracleCommand cmd = new OracleCommand("spInsertIntoCoachRoster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("coachID", i));
            cmd.Parameters.Add(new OracleParameter("coachNumber", c.CoachNumber));
            cmd.Parameters.Add(new OracleParameter("name", c.Name));
            cmd.Parameters.Add(new OracleParameter("position", c.Position));

            return cmd.ExecuteNonQuery();
        }
    }
}