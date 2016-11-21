using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataModels
{
    public class PlayerStatsSummary
    {
        public int PlayerNum { get; set; }
        public string SummaryYear { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double EarnedRunsAverage { get; set; }
        public int Games { get; set; }
        public int GamesStarted { get; set; }
        public int Saves { get; set; }
        public double InningsPitched { get; set; }
        public int StrikeOuts { get; set; }
        public double WalkAndHitsPerInningsPitched { get; set; }
    }
}