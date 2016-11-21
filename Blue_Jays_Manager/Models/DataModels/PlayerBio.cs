using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataModels
{
    public class PlayerBio
    {
        public int PlayerBioID { get; set; }
        public int PlayerNum { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Born { get; set; }
        public string Draft { get; set; }
        public string HighSchool { get; set; }
        public string College { get; set; }
        public string Debut { get; set; }
    }
}