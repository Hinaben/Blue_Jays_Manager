using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client; //prefect!!

namespace Blue_Jays_Manager.Models.DataAccessLayer
{
    public class LoadExcelData
    {
        private static string excelPath = HttpContext.Current.Server.MapPath(".") + "\\App_Data\\BlueJaysDataSheet.xlsx";
        private static string connectionString = ConfigurationManager.ConnectionStrings["BlueJaysConnection"].ConnectionString;
        public static void LoadToDatabase()
        {
            DataSet excelDataSet = null;
            IExcelDataReader reader = null;

            using (FileStream file = File.Open(excelPath, FileMode.Open, FileAccess.Read))
            {
                reader = ExcelReaderFactory.CreateOpenXmlReader(file);

                reader.IsFirstRowAsColumnNames = true;

                excelDataSet = reader.AsDataSet();
            }

            using (OracleConnection con = new OracleConnection(connectionString))
            {
                con.Open();
                foreach (DataTable table in excelDataSet.Tables)
                {
                    switch (table.TableName)
                    {
                        case "PlayerRoster":

                            foreach (DataRow row in table.Rows)
                            {
                                InsertPlayerRoster(con, row);
                            }
                            break;

                        //case "CoachRoster":
                        //    foreach (DataRow row in table.Rows)
                        //    {
                        //        InsertCoachRoster(con, row);
                        //    }
                        //    break;

                        //case "PlayerBio":
                        //    foreach (DataRow row in table.Rows)
                        //    {
                        //        InsertPlayerBio(con, row);
                        //    }
                        //    break;
                        //case "PitchingStats":
                        //    foreach (DataRow row in table.Rows)
                        //    {
                        //        InsertPitchingStats(con, row);
                        //    }
                        //    break;
                        //case "FieldingStats":
                        //    foreach (DataRow row in table.Rows)
                        //    {
                        //        InsertFieldingStats(con, row);
                        //    }
                        //    break;
                        //case "PlayerStatsSummary":
                        //    foreach (DataRow row in table.Rows)
                        //    {
                        //        InsertPlayerStatsSummary(con, row);
                        //    }
                        //    break;
                        //case "BattingStats":
                        //    foreach (DataRow row in table.Rows)
                        //    {
                        //        InsertBattingStats(con, row);
                        //    }
                        //    break;

                        default:
                            break;
                    }
                }
            }
        }

        private static void InsertBattingStats(OracleConnection conn, DataRow row)
        {
            //becuase we using oracle everything that begins with Sql.....has to be changed to Oracle

            OracleCommand cmd = new OracleCommand("spInsertIntoBattingStats", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("battingStatsID", row["BattingStatsID"]));
            cmd.Parameters.Add(new OracleParameter("playerNum", row["PlayerNum"]));
            cmd.Parameters.Add(new OracleParameter("batStatYear", row["1B"]));
            cmd.Parameters.Add(new OracleParameter("team", row["2B"]));
            cmd.Parameters.Add(new OracleParameter("league", row["3B"]));
            cmd.Parameters.Add(new OracleParameter("games", row["4B"]));
            cmd.Parameters.Add(new OracleParameter("atBats", row["5B"]));
            cmd.Parameters.Add(new OracleParameter("runs", row["6B"]));
            cmd.Parameters.Add(new OracleParameter("hits", row["7B"]));
            cmd.Parameters.Add(new OracleParameter("totalBases", row["8B"]));
            cmd.Parameters.Add(new OracleParameter("doubles", row["9B"]));
            cmd.Parameters.Add(new OracleParameter("triples", row["10B"]));
            cmd.Parameters.Add(new OracleParameter("homeRuns", row["11B"]));
            cmd.Parameters.Add(new OracleParameter("runsBattedIn", row["12B"]));
            cmd.Parameters.Add(new OracleParameter("basesOnBalls", row["13B"]));
            cmd.Parameters.Add(new OracleParameter("intentionalBasesOnBalls", row["14B"]));
            cmd.Parameters.Add(new OracleParameter("strikeouts", row["15B"]));
            cmd.Parameters.Add(new OracleParameter("stolenBases", row["16B"]));
            cmd.Parameters.Add(new OracleParameter("caughtStealing", row["17B"]));
            cmd.Parameters.Add(new OracleParameter("battingAverage", row["18B"]));
            cmd.Parameters.Add(new OracleParameter("onBasePercentage", row["19B"]));
            cmd.Parameters.Add(new OracleParameter("sluggingPercentage", row["20B"]));
            cmd.Parameters.Add(new OracleParameter("onBasePlusSlugging", row["21B"]));
            cmd.Parameters.Add(new OracleParameter("groundOrAirOuts", row["22B"]));
            cmd.ExecuteNonQuery();
        }

        private static void InsertPlayerStatsSummary(OracleConnection conn, DataRow row)
        {
            OracleCommand cmd = new OracleCommand("spInsertIntoPlayerStatsSummary", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("playerStatsSummaryID", row["PlayerStatsSummaryID"]));
            cmd.Parameters.Add(new OracleParameter("playerNum", row["PlayerNum"]));
            cmd.Parameters.Add(new OracleParameter("summaryYear", row["1SS"]));
            cmd.Parameters.Add(new OracleParameter("wins", row["2SS"]));
            cmd.Parameters.Add(new OracleParameter("losses", row["3SS"]));
            cmd.Parameters.Add(new OracleParameter("earnedRunsAverage", row["4SS"]));
            cmd.Parameters.Add(new OracleParameter("games", row["5SS"]));
            cmd.Parameters.Add(new OracleParameter("gamesStarted", row["6SS"]));
            cmd.Parameters.Add(new OracleParameter("saves", row["7SS"]));
            cmd.Parameters.Add(new OracleParameter("inningsPitched", row["8SS"]));
            cmd.Parameters.Add(new OracleParameter("strikeOuts", row["9SS"]));
            cmd.Parameters.Add(new OracleParameter("walkAndHitsPerInningsPitched", row["10SS"]));


            cmd.ExecuteNonQuery();
        }

        private static void InsertFieldingStats(OracleConnection conn, DataRow row)
        {
            OracleCommand cmd = new OracleCommand("spInsertIntoFieldingStats", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("fieldingStatsID", row["FieldingStatsID"]));
            cmd.Parameters.Add(new OracleParameter("playerNum", row["PlayerNum"]));
            cmd.Parameters.Add(new OracleParameter("fieldStatYear", row["1F"]));
            cmd.Parameters.Add(new OracleParameter("team", row["2F"]));
            cmd.Parameters.Add(new OracleParameter("league", row["3F"]));
            cmd.Parameters.Add(new OracleParameter("position", row["4F"]));
            cmd.Parameters.Add(new OracleParameter("games", row["5F"]));
            cmd.Parameters.Add(new OracleParameter("gamesStarted", row["6F"]));
            cmd.Parameters.Add(new OracleParameter("inningsAtThisPosition", row["7F"]));
            cmd.Parameters.Add(new OracleParameter("totalChances", row["8F"]));
            cmd.Parameters.Add(new OracleParameter("putOuts", row["9F"]));
            cmd.Parameters.Add(new OracleParameter("assists", row["10F"]));
            cmd.Parameters.Add(new OracleParameter("errors", row["11F"]));
            cmd.Parameters.Add(new OracleParameter("doublePlays", row["12F"]));
            cmd.Parameters.Add(new OracleParameter("passedBall", row["13F"]));
            cmd.Parameters.Add(new OracleParameter("stolenBases", row["14F"]));
            cmd.Parameters.Add(new OracleParameter("caughtStealing", row["15F"]));
            cmd.Parameters.Add(new OracleParameter("rangeFactor", row["16F"]));
            cmd.Parameters.Add(new OracleParameter("fieldingPercentage", row["17F"]));

            cmd.ExecuteNonQuery();
        }

        private static void InsertPitchingStats(OracleConnection conn, DataRow row)
        {
            OracleCommand cmd = new OracleCommand("spInsertIntoPitchingStats", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new OracleParameter("pitchingStatsID", row["PitchingStatsID"]));
            cmd.Parameters.Add(new OracleParameter("playerNum", row["PlayerNum"]));
            cmd.Parameters.Add(new OracleParameter("pitchStatYear", row["1P"]));
            cmd.Parameters.Add(new OracleParameter("team", row["2P"]));
            cmd.Parameters.Add(new OracleParameter("league", row["3P"]));
            cmd.Parameters.Add(new OracleParameter("wins", row["4P"]));
            cmd.Parameters.Add(new OracleParameter("losses", row["5P"]));
            cmd.Parameters.Add(new OracleParameter("earnedRunsAverage", row["6P"]));
            cmd.Parameters.Add(new OracleParameter("games", row["7P"]));
            cmd.Parameters.Add(new OracleParameter("gamesStarted", row["8P"]));
            cmd.Parameters.Add(new OracleParameter("completeGames", row["9P"]));
            cmd.Parameters.Add(new OracleParameter("shutOuts", row["10P"]));
            cmd.Parameters.Add(new OracleParameter("saves", row["11P"]));
            cmd.Parameters.Add(new OracleParameter("saveOpportunities", row["12P"]));
            cmd.Parameters.Add(new OracleParameter("inningsPitched", row["13P"]));
            cmd.Parameters.Add(new OracleParameter("hits", row["14P"]));
            cmd.Parameters.Add(new OracleParameter("runs", row["15P"]));
            cmd.Parameters.Add(new OracleParameter("earnedRuns", row["16P"]));
            cmd.Parameters.Add(new OracleParameter("homeRuns", row["17P"]));
            cmd.Parameters.Add(new OracleParameter("hitBatsmen", row["18P"]));
            cmd.Parameters.Add(new OracleParameter("basesOnBalls", row["19P"]));
            cmd.Parameters.Add(new OracleParameter("intentionalBasesOnBalls", row["20P"]));
            cmd.Parameters.Add(new OracleParameter("strikeOuts", row["21P"]));
            cmd.Parameters.Add(new OracleParameter("battingAverage", row["22P"]));
            cmd.Parameters.Add(new OracleParameter("walksAndHitsPerInningsPitched", row["23P"]));
            cmd.Parameters.Add(new OracleParameter("groundOrAirOuts", row["24P"]));

            // ExecuteNonQuery used for UDI of data into tables
            cmd.ExecuteNonQuery();
        }

        private static void InsertPlayerRoster(OracleConnection conn, DataRow row)
        {
            OracleCommand cmd = new OracleCommand("spInsertIntoPlayerRoster", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("playerID", row["PlayerID"]));
            cmd.Parameters.Add(new OracleParameter("playerNum", row["PlayerNum"]));
            cmd.Parameters.Add(new OracleParameter("name", row["Name"]));
            cmd.Parameters.Add(new OracleParameter("position", row["Position"]));
            cmd.Parameters.Add(new OracleParameter("height", row["Height"]));
            cmd.Parameters.Add(new OracleParameter("weight", row["Weight"]));
            cmd.Parameters.Add(new OracleParameter("skillOrientation", row["SkillOrientation"]));
            cmd.Parameters.Add(new OracleParameter("dateOfBirth", row["DateOfBirth"]));

            cmd.ExecuteNonQuery();
        }

        private static void InsertCoachRoster(OracleConnection conn, DataRow row)
        {
            OracleCommand cmd = new OracleCommand("spInsertIntoCoachRoster", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("coachID", row["CoachID"]));
            cmd.Parameters.Add(new OracleParameter("coachNumber", row["CoachNumber"]));
            cmd.Parameters.Add(new OracleParameter("name", row["Name"]));
            cmd.Parameters.Add(new OracleParameter("position", row["Position"]));

            cmd.ExecuteNonQuery();
        }

        private static int InsertPlayerBio(OracleConnection conn, DataRow row)
        {
            OracleCommand cmd = new OracleCommand("spInsertIntoPlayerBio", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("playerBioID", row["PlayerBioID"]));
            cmd.Parameters.Add(new OracleParameter("playerNum", row["PlayerNum"]));
            cmd.Parameters.Add(new OracleParameter("name", row["Name"]));
            cmd.Parameters.Add(new OracleParameter("age", row["Age"]));
            cmd.Parameters.Add(new OracleParameter("born", row["Born"]));
            cmd.Parameters.Add(new OracleParameter("draft", row["Draft"]));
            cmd.Parameters.Add(new OracleParameter("highSchool", row["HighSchool"]));
            cmd.Parameters.Add(new OracleParameter("college", row["College"]));
            cmd.Parameters.Add(new OracleParameter("debut", row["Debut"]));


            return cmd.ExecuteNonQuery();
        }




    }
}