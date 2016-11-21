using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataModels
{
    public class FieldingStats
    {
        public int FieldingStatsID { get; set; }
        public int PlayerNum { get; set; }
        public string FieldStatYear { get; set; }
        public string Team { get; set; }
        public string League { get; set; }
        public string Position { get; set; }
        public int Games { get; set; }
        public int GamesStarted { get; set; }
        public double InningsAtThisPosition { get; set; }
        public int TotalChances { get; set; }
        public int Putouts { get; set; }
        public int Assists { get; set; }
        public int Errors { get; set; }
        public int DoublePlays { get; set; }
        public int PassedBall { get; set; }
        public int StolenBases { get; set; }
        public int CaughtStealing { get; set; }
        public double RangeFactor { get; set; }
        public double FieldingPercentage { get; set; }
    }
}