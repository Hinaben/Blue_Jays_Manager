using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blue_Jays_Manager.Models.DataModels
{
    public class LockedUser
    {
        //This new data model was added
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsLocked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}