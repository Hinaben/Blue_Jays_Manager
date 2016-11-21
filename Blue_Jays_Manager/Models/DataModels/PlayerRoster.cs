using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blue_Jays_Manager.Models.DataModels
{
    public class PlayerRoster
    {
        [Display(AutoGenerateField =false)]
        public int PlayerRosterID { get; set; }
        public int PlayerNum { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string SkillOrientation { get; set; }
        public string DateOfBirth { get; set; }
    }
}