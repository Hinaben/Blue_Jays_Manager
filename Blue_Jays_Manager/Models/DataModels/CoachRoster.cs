using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataModels
{
    public class CoachRoster
    {
        public int CoachRosterID { get; set; }
        public int CoachNumber { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string IsLocked { get; set; }
    }
}