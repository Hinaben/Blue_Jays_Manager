using Blue_Jays_Manager.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    /// <summary>
    /// This class retieves all data i.e. all select statements are placed within this class.
    /// </summary>
    public class DataRetrieval
    {
        public List<PlayerRoster> SelectAllPlayers()
        {

            List<PlayerRoster> roster = new List<PlayerRoster>();
            PlayerRoster playerRoster = null;

            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("selectAllPlayers_sp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("ref_cur", OracleDbType.RefCursor));
                cmd.Parameters["ref_cur"].Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["ref_cur"].Value).GetDataReader();
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
                    playerRoster.DateOfBirth = (reader["DateOfBirth"].ToString().Length > 10) ? reader["DateOfBirth"].ToString().Substring(0, reader["DateOfBirth"].ToString().IndexOf("00.00.00.000000000 AM")) :reader["DateOfBirth"].ToString();

                    

                    roster.Add(playerRoster);
                }
            }
            return roster;
        }

        public static List<PlayerBio> SelectPlayerBioWherePlayerNumEquals(int playerNum)
        {
            //This table will need an index
            //This table will or may return multiple rows...therefore a output ref cursor can be used 
            
            List<PlayerBio> resultSet = new List<PlayerBio>();

            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("selectPlayerBio_sp", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("player_num", OracleDbType.Int32, ParameterDirection.Input)).Value = playerNum;
                cmd.Parameters.Add(new OracleParameter("ref_cur", OracleDbType.RefCursor));
                cmd.Parameters["ref_cur"].Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["ref_cur"].Value).GetDataReader();

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
                            Debut = (reader["Debut"].ToString().Length > 10) ? reader["Debut"].ToString().Substring(0, reader["Debut"].ToString().IndexOf("00.00.00.000000000 AM")) : reader["Debut"].ToString()
                       }
                            
                
                    );
                }
            }
            return resultSet;
        }

        public static List<PlayerStatsSummary> SelectPlayerStatsSummaryWherePlayerNumEquals(int playerNum)
        {
            //This table will need an index
            //This table will or may return multiple rows...therefore a output ref cursor can be used 


            List<PlayerStatsSummary> resultSet = new List<PlayerStatsSummary>();

            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("selectPlayerStatsSummary_sp", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("player_num", OracleDbType.Int32, ParameterDirection.Input)).Value = playerNum;
                cmd.Parameters.Add(new OracleParameter("ref_cur", OracleDbType.RefCursor));
                cmd.Parameters["ref_cur"].Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["ref_cur"].Value).GetDataReader();

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
            //This table will need an index
            //This table will or may return multiple rows...therefore a output ref cursor can be used 

            List<PitchingStats> resultSet = new List<PitchingStats>();

            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("selectPitchingStats_sp", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("player_num", OracleDbType.Int32, ParameterDirection.Input)).Value = playerNum;
                cmd.Parameters.Add(new OracleParameter("ref_cur", OracleDbType.RefCursor));
                cmd.Parameters["ref_cur"].Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["ref_cur"].Value).GetDataReader();

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
            //This table will need an index
            //This table will or may return multiple rows...therefore a output ref cursor can be used 

            List<BattingStats> resultSet = new List<BattingStats>();

            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("selectBattingStats_sp", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("player_num", OracleDbType.Int32, ParameterDirection.Input)).Value = playerNum;
                cmd.Parameters.Add(new OracleParameter("ref_cur", OracleDbType.RefCursor));
                cmd.Parameters["ref_cur"].Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["ref_cur"].Value).GetDataReader();

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
            //This table will need an index
            //This table will or may return multiple rows...therefore a output ref cursor can be used 

            List<FieldingStats> resultSet = new List<FieldingStats>();

            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {
                OracleCommand cmd = new OracleCommand("selectFieldingStats_sp", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("player-num", OracleDbType.Int32, ParameterDirection.Input)).Value = playerNum;
                cmd.Parameters.Add(new OracleParameter("ref_cur", OracleDbType.RefCursor));
                cmd.Parameters["ref_cur"].Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["ref_cur"].Value).GetDataReader();

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

            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString))
            {

                OracleCommand cmd = new OracleCommand("selectAllCoaches_sp", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("ref_cur", OracleDbType.RefCursor));
                cmd.Parameters["ref_cur"].Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["ref_cur"].Value).GetDataReader();

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