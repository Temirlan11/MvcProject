using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyMeet.Models
{
    public class User_Team
    {
        public int Id { get; set; }
        public int? userId { get; set; }
        public User user { get; set; }

        public int? teamId { get; set; }
        public Team team { get; set; }
    }
}