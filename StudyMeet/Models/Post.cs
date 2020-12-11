using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyMeet.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string question { get; set; }
        public DateTime created_date { get; set; }

        public int? asking_user_id { get; set; }
        public User user { get; set; }
        public int? teamId { get; set; }
        public Team teams { get; set; }
        public ICollection<PostFeedback> postFeedbacks { get; set; }
        public Post()
        {
            postFeedbacks = new List<PostFeedback>();
        }
    }
}