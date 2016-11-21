using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataModels
{
    public class BattingStats
    {
        public int BattingStatsID { get; set; }
        public int PlayerNum { get; set; }
        public string BatStatYear { get; set; }
        public string Team { get; set; }
        public string League { get; set; }
        public int Games { get; set; }
        public int AtBats { get; set; }
        public int Runs { get; set; }
        public int Hits { get; set; }
        public int TotalBases { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HomeRuns { get; set; }
        public int RunsBattedIn { get; set; }
        public int BasesOnBalls { get; set; }
        public int IntentionalBasesOnBalls { get; set; }
        public int Strikeouts { get; set; }
        public int StolenBases { get; set; }
        public int CaughtStealing { get; set; }
        public double BattingAverage { get; set; }
        public double OnBasePercentage { get; set; }
        public double SluggingPercentage { get; set; }
        public double OnBasePlusSlugging { get; set; }
        public double GroundOrAirOuts { get; set; }
    }
}