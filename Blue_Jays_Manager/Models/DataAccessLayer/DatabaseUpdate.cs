using Blue_Jays_Manager.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    public class DatabaseUpdate
    {
        public static int SaveAllPlayers(List<PlayerRoster> roster)
        {
            int truncated = 0;
            int inserted = 0;
            int i = 1;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = null;
                cmd = new SqlCommand("truncate table PlayerRoster", con);

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

        private static int InsertIntoPlayerRoster(SqlConnection con, PlayerRoster p, int i)
        {
            SqlCommand cmd = new SqlCommand("spInsertIntoPlayerRoster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@playerID", i));
            cmd.Parameters.Add(new SqlParameter("@playerNum", p.PlayerNum));
            cmd.Parameters.Add(new SqlParameter("@name", p.Name));
            cmd.Parameters.Add(new SqlParameter("@position", p.Position));
            cmd.Parameters.Add(new SqlParameter("@height", p.Height));
            cmd.Parameters.Add(new SqlParameter("@weight", p.Weight));
            cmd.Parameters.Add(new SqlParameter("@skillOrientation", p.SkillOrientation));
            cmd.Parameters.Add(new SqlParameter("@dateOfBirth", p.DateOfBirth));
            return cmd.ExecuteNonQuery();
        }

        public static int SaveAllCoaches(List<CoachRoster> roster)
        {
            int truncated = 0;
            int inserted = 0;
            int i = 1;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = null;
                cmd = new SqlCommand("truncate table CoachRoster", con);

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

        private static int InsertIntoCoachRoster(SqlConnection con, CoachRoster c, int i)
        {
            SqlCommand cmd = new SqlCommand("spInsertIntoCoachRoster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@coachID", i));
            cmd.Parameters.Add(new SqlParameter("@coachNumber", c.CoachNumber));
            cmd.Parameters.Add(new SqlParameter("@name", c.Name));
            cmd.Parameters.Add(new SqlParameter("@position", c.Position));

            return cmd.ExecuteNonQuery();
        }
    }
}