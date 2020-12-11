using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyMeet.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string img_url { get; set; } 
        public int max_users { get; set; }
        public System.DateTime created_date { get; set; }
        public int? user_id { get; set; }
        public User user { get; set; }
        public ICollection<Post> posts { get; set; }
        public ICollection<User_Team> Users_Teams { get; set; }
        public Team()
        {
            posts = new List<Post>();
            Users_Teams = new List<User_Team>();
        }
    }
}