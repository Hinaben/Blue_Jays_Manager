using Blue_Jays_Manager.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    public class DataRetrieval
    {
        public List<PlayerRoster> SelectAllPlayers()
        {
            List<PlayerRoster> roster = new List<PlayerRoster>();
            PlayerRoster playerRoster = null;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spSelectPlayerRoster", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                bool count = reader.HasRows;

                while (reader.Read())
                {
                    playerRoster = new PlayerRoster();

                    playerRoster.PlayerNum = Convert.ToInt32(reader["PlayerNum"]);
                    playerRoster.Name = reader["Name"].ToString();
                    playerRoster.Position = reader["Position"].ToString();
                    playerRoster.Height = Convert.ToInt32(reader["Height"]);
                    playerRoster.Weight = Convert.ToInt32(reader["Weight"]);
                    playerRoster.SkillOrientation = reader["SkillOrientation"].ToString();
                    playerRoster.DateOfBirth = (reader["DateOfBirth"].ToString().Length > 12) ? reader["DateOfBirth"].ToString().Substring(0, reader["DateOfBirth"].ToString().IndexOf("12:00AM")) : reader["DateOfBirth"].ToString();

                    roster.Add(playerRoster);
                }
            }

            return roster;
        }

        public static List<PlayerBio> SelectPlayerBioWherePlayerNumEquals(int playerNum)
        {
            List<PlayerBio> resultSet = new List<PlayerBio>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spSelectPlayerBio", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerNum", playerNum);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultSet.Add
                    (
                        new PlayerBio()
                        {
                            PlayerNum = Convert.ToInt32(reader["PlayerNum"]),
                            Name = reader["Name"].ToString(),
                            Born = reader["Born"].ToString(),
                            Draft = reader["Draft"].ToString(),
                            HighSchool = reader["HighSchool"].ToString(),
                            College = reader["College"].ToString(),
                            Debut = reader["Debut"].ToString().Substring(0, reader["Debut"].ToString().IndexOf("12:00AM")),
                        }
                    );
                }
            }
            return resultSet;
        }

        public static List<PlayerStatsSummary> SelectPlayerStatsSummaryWherePlayerNumEquals(int playerNum)
        {
            List<PlayerStatsSummary> resultSet = new List<PlayerStatsSummary>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spSelectPlayerStatsSummary", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerNum", playerNum);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultSet.Add
                    (
                        new PlayerStatsSummary()
                        {
                            PlayerNum = Convert.ToInt32(reader["PlayerNum"]),
                            SummaryYear = reader["SummaryYear"].ToString(),
                            Wins = Convert.ToInt32(reader["Wins"]),
                            Losses = Convert.ToInt32(reader["Losses"]),
                            Games = Convert.ToInt32(reader["Games"]),
                            GamesStarted = Convert.ToInt32(reader["GamesStarted"]),
                            Saves = Convert.ToInt32(reader["Saves"]),
                            StrikeOuts = Convert.ToInt32(reader["StrikeOuts"]),
                            EarnedRunsAverage = Convert.ToDouble(reader["EarnedRunsAverage"]),
                            InningsPitched = Convert.ToDouble(reader["InningsPitched"]),
                            WalkAndHitsPerInningsPitched = Convert.ToDouble(reader["WalkAndHitsPerInningsPitched"])
                        }
                    );
                }
            }
            return resultSet;
        }

        public static List<PitchingStats> SelectPitchingStatsyWherePlayerNumEquals(int playerNum)
        {
            List<PitchingStats> resultSet = new List<PitchingStats>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spSelectPitchingStats", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerNum", playerNum);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultSet.Add
                    (
                        new PitchingStats()
                        {
                            PlayerNum = Convert.ToInt32(reader["PlayerNum"]),
                            PitchStatYear = reader["PitchStatYear"].ToString(),
                            Team = reader["Team"].ToString(),
                            League = reader["League"].ToString(),
                            Wins = Convert.ToInt32(reader["Wins"]),
                            Losses = Convert.ToInt32(reader["Losses"]),
                            EarnedRunsAverage = Convert.ToDouble(reader["EarnedRunsAverage"]),
                            Games = Convert.ToInt32(reader["Games"]),
                            GamesStarted = Convert.ToInt32(reader["GamesStarted"]),
                            CompleteGames = Convert.ToInt32(reader["CompleteGames"]),
                            ShutOuts = Convert.ToInt32(reader["ShutOuts"]),
                            Saves = Convert.ToInt32(reader["Saves"]),
                            SaveOpportunities = Convert.ToInt32(reader["SaveOpportunities"]),
                            InningsPitched = Convert.ToDouble(reader["InningsPitched"]),
                            Hits = Convert.ToInt32(reader["Hits"]),
                            Runs = Convert.ToInt32(reader["Runs"]),
                            EarnedRuns = Convert.ToInt32(reader["EarnedRuns"]),
                            HomeRuns = Convert.ToInt32(reader["HomeRuns"]),
                            HitBatsmen = Convert.ToInt32(reader["HitBatsmen"]),
                            BasesOnBalls = Convert.ToInt32(reader["BasesOnBalls"]),
                            IntentionalBasesOnBalls = Convert.ToInt32(reader["IntentionalBasesOnBalls"]),
                            StrikeOuts = Convert.ToInt32(reader["StrikeOuts"]),
                            BattingAverage = Convert.ToDouble(reader["BattingAverage"]),
                            WalksAndHitsPerInningsPitched = Convert.ToDouble(reader["WalksAndHitsPerInningsPitched"]),
                            GroundOrAirOuts = Convert.ToDouble(reader["GroundOrAirOuts"])
                        }
                    );
                }
            }
            return resultSet;
        }

        public static List<BattingStats> SelectBattingStatsyWherePlayerNumEquals(int playerNum)
        {
            List<BattingStats> resultSet = new List<BattingStats>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spSelectBattingStats", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerNum", playerNum);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultSet.Add
                    (
                        new BattingStats()
                        {
                            PlayerNum = Convert.ToInt32(reader["PlayerNum"]),
                            BatStatYear = reader["BatStatYear"].ToString(),
                            Team = reader["Team"].ToString(),
                            League = reader["League"].ToString(),
                            Games = Convert.ToInt32(reader["Games"]),
                            AtBats = Convert.ToInt32(reader["AtBats"]),
                            Runs = Convert.ToInt32(reader["Runs"]),
                            Hits = Convert.ToInt32(reader["Hits"]),
                            TotalBases = Convert.ToInt32(reader["TotalBases"]),
                            Doubles = Convert.ToInt32(reader["Doubles"]),
                            Triples = Convert.ToInt32(reader["Triples"]),
                            HomeRuns = Convert.ToInt32(reader["HomeRuns"]),
                            RunsBattedIn = Convert.ToInt32(reader["RunsBattedIn"]),
                            BasesOnBalls = Convert.ToInt32(reader["BasesOnBalls"]),
                            IntentionalBasesOnBalls = Convert.ToInt32(reader["IntentionalBasesOnBalls"]),
                            Strikeouts = Convert.ToInt32(reader["Strikeouts"]),
                            StolenBases = Convert.ToInt32(reader["StolenBases"]),
                            CaughtStealing = Convert.ToInt32(reader["CaughtStealing"]),
                            BattingAverage = Convert.ToDouble(reader["BattingAverage"]),
                            OnBasePercentage = Convert.ToDouble(reader["OnBasePercentage"]),
                            SluggingPercentage = Convert.ToDouble(reader["SluggingPercentage"]),
                            OnBasePlusSlugging = Convert.ToDouble(reader["OnBasePlusSlugging"]),
                            GroundOrAirOuts = Convert.ToDouble(reader["GroundOrAirOuts"])
                        }
                    );
                }
            }
            return resultSet;
        }

        public static List<FieldingStats> SelectFieldingStatsyWherePlayerNumEquals(int playerNum)
        {
            List<FieldingStats> resultSet = new List<FieldingStats>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spSelectFieldingStats", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerNum", playerNum);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    resultSet.Add
                    (
                        new FieldingStats()
                        {
                            PlayerNum = Convert.ToInt32(reader["PlayerNum"]),
                            FieldStatYear = reader["FieldStatYear"].ToString(),
                            Team = reader["Team"].ToString(),
                            League = reader["League"].ToString(),
                            Position = reader["Position"].ToString(),
                            Games = Convert.ToInt32(reader["Games"]),
                            GamesStarted = Convert.ToInt32(reader["GamesStarted"]),
                            InningsAtThisPosition = Convert.ToDouble(reader["InningsAtThisPosition"]),
                            TotalChances = Convert.ToInt32(reader["TotalChances"]),
                            Putouts = Convert.ToInt32(reader["Putouts"]),
                            Assists = Convert.ToInt32(reader["Assists"]),
                            Errors = Convert.ToInt32(reader["Errors"]),
                            DoublePlays = Convert.ToInt32(reader["DoublePlays"]),
                            PassedBall = Convert.ToInt32(reader["PassedBall"]),
                            StolenBases = Convert.ToInt32(reader["StolenBases"]),
                            CaughtStealing = Convert.ToInt32(reader["CaughtStealing"]),
                            RangeFactor = Convert.ToDouble(reader["RangeFactor"]),
                            FieldingPercentage = Convert.ToDouble(reader["FieldingPercentage"]),
                        }
                    );
                }
            }
            return resultSet;
        }

        public List<CoachRoster> SelectAllCoaches()
        {
            List<CoachRoster> roster = new List<CoachRoster>();
            CoachRoster coachRoster = null;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spSelectCoachRoster", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                int islocked;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    coachRoster = new CoachRoster()
                    {
                        Name = reader["Name"].ToString(),
                        Position = reader["Position"].ToString(),
                        CoachNumber = Convert.ToInt32(reader["CoachNumber"]),
                        IsLocked = (reader["IsLocked"] != DBNull.Value) ? "Locked" : "Access"

                    };

                    roster.Add(coachRoster);
                }
            }
            return roster;
        }
    }
}