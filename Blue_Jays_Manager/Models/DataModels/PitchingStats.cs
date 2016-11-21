using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataModels
{
    public class PitchingStats
    {
        public int PitchingStatsID { get; set; }
        public int PlayerNum { get; set; }
        public string PitchStatYear { get; set; }
        public string Team { get; set; }
        public string League { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double EarnedRunsAverage { get; set; }
        public int Games { get; set; }
        public int GamesStarted { get; set; }
        public int CompleteGames { get; set; }
        public int ShutOuts { get; set; }
        public int Saves { get; set; }
        public int SaveOpportunities { get; set; }
        public double InningsPitched { get; set; }
        public int Hits { get; set; }
        public int Runs { get; set; }
        public int EarnedRuns { get; set; }
        public int HomeRuns { get; set; }
        public int HitBatsmen { get; set; }
        public int BasesOnBalls { get; set; }
        public int IntentionalBasesOnBalls { get; set; }
        public int StrikeOuts { get; set; }
        public double BattingAverage { get; set; }
        public double WalksAndHitsPerInningsPitched { get; set; }
        public double GroundOrAirOuts { get; set; }
    }
}